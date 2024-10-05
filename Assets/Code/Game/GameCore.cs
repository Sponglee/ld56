using System.Threading;
using Code.Core.CameraControl.CameraMovement;
using Code.Core.CameraControl.Provider;
using Code.Core.Config;
using Code.Core.Config.MainLocalConfig;
using Code.Core.MVP.Disposable;
using Code.Core.ResourceLoader.AddressableResourceLoader;
using Code.Core.TickHandler;
using Code.Core.TickHandler.UnityTickHandler;
using Code.Game.Config.Parser;
using Code.Game.Config.RemoteConfigs;
using Cysharp.Threading.Tasks;
using ResourceInfo.Code.Core.ResourceInfo;
using UnityEngine;

public class GameCore : Singleton<MonoBehaviour>
{
    private readonly ICompositeDisposable _compositeDisposable = new CompositeDisposable();
    private readonly CancellationTokenSource _closeSceneTokenSource = new();

    private AddressableResourceLoader _resourceLoader;
    private ITickHandler _tickHandler;

    private CameraProvider _cameraProvider;
    private ILocalConfig _localConfig;

    private Camera _mainCamera;
    [SerializeField] Transform _mainCanvas;

    private async void Awake()
    {
        var token = _closeSceneTokenSource.Token;

        _tickHandler = InitializeTickHandler();
        _compositeDisposable.AddDisposable(_tickHandler);

        _resourceLoader = new AddressableResourceLoader();

        _compositeDisposable.AddDisposable(_resourceLoader);

        _localConfig = await InitializeConfig(token);

        _cameraProvider = await InitializeCamera(token);
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        if (!_closeSceneTokenSource.IsCancellationRequested)
        {
            _closeSceneTokenSource.Cancel();
        }

        _closeSceneTokenSource.Dispose();
        _compositeDisposable.Dispose();
    }

    private ITickHandler InitializeTickHandler()
    {
        var dispatcherObject = new GameObject();
        dispatcherObject.transform.SetParent(transform);
        var dispatcher = dispatcherObject.AddComponent<UnityDispatcherBehaviour>();
        ITickHandler tickHandler = new UnityTickHandler(dispatcher);
        _compositeDisposable.AddDisposable(dispatcher, tickHandler);

        return tickHandler;
    }

    private async UniTask<CameraProvider> InitializeCamera(CancellationToken token)
    {
        var remoteConfigPagesContainerResourceId =
            ResourceIdContainer.ModulesResourceContainer.CommonGameplay.CameraRigView;

        var cameraModel = new CameraMovementModel();
        var cameraView =
            await _resourceLoader
                .LoadResourceAsync<CameraMovementView>(remoteConfigPagesContainerResourceId, token);
        var cameraPresenter = new CameraMovementPresenter(cameraView, cameraModel, _tickHandler, _localConfig);
        var cameraProvider = new CameraProvider(cameraPresenter);

        _mainCamera = Camera.main;
        return cameraProvider;
    }

    private async UniTask<ILocalConfig> InitializeConfig(CancellationToken token)
    {
        var remoteConfigPagesContainerResourceId =
            ResourceIdContainer.ModulesResourceContainer.RemoteConfigPagesContainer;

        var remoteConfigPagesContainer =
            await _resourceLoader.LoadResourceAsync<RemoteConfigPagesContainer>(remoteConfigPagesContainerResourceId,
                token);

        remoteConfigPagesContainer.Initialize();
        _compositeDisposable.AddDisposable(remoteConfigPagesContainer);

        ILocalConfig config = new LocalConfig();
        IConfigParser configParser = new ConfigParser(remoteConfigPagesContainer, config);
        _compositeDisposable.AddDisposable(configParser, config);

        await configParser.ParseConfigAsync(token);

        return config;
    }
}