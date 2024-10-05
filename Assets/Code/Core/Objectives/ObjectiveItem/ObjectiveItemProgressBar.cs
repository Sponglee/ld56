using System;
using Code.Core.MVP;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.Core.Objectives.ObjectiveItem
{
    public class ObjectiveItemProgressBar : ViewMonoBehaviour<ObjectivesPresenter>
    {
        [SerializeField] protected TMP_Text _progressText;
        [SerializeField] protected RectTransform _progressFill;
        [SerializeField] protected RectTransform _progressContainer;

        private Tween _updateZoneTypeIconTween;
        private Tween _progressBarSizeTween;
        private Tweener _progressBarTweener;
        private Tweener _progressBarTextTweener;
        private bool _isDestroyed;
        private float _startWidth;

        private int _cachedMaxValue = 0;
        private int _cachedCurrentValue = 0;

        public void Initialize(float aValue)
        {
        }

        public void Initialize(int currentValue, int maxvalue)
        {
            _startWidth = _progressContainer.rect.width;
            UpdateProgressBarWidth((float)currentValue / maxvalue * _startWidth);
            UpdateBarText(currentValue, maxvalue);
        }

        protected void OnDispose()
        {
            _updateZoneTypeIconTween?.Kill();
            _progressBarTweener?.Kill();
            _progressBarSizeTween?.Kill();
            _progressBarTextTweener?.Kill();
        }

        public void UpdateBarText(int currentValue, int maxValue)
        {
            _cachedMaxValue = maxValue;

            PlayProgressBarTextAnimation(_cachedCurrentValue, currentValue, 0.5f);
        }

        public void UpdateBarValue(float startValue, float endValue, float duration)
        {
            PlayProgressBarAnimation(startValue, endValue, duration);
        }

        public void UpdateBarValue(float endValue, float duration)
        {
            PlayProgressBarAnimation(_progressFill.rect.width / _startWidth, endValue, duration);
        }

        public void OnFillComplete(Action callback)
        {
        }

        private void PlayProgressBarAnimation(float startValue, float endValue, float duration)
        {
            _progressBarTweener?.Kill();

            UpdateProgressBarWidth(startValue);
            _progressBarTweener = DOVirtual.Float(
                startValue * _startWidth,
                Mathf.Clamp(endValue * _startWidth, 0f, _startWidth),
                duration, UpdateProgressBarWidth).SetEase(Ease.InCirc);
            _progressBarTweener.OnComplete(() => { });
        }

        private void PlayProgressBarTextAnimation(int startValue, int endValue, float duration)
        {
            _progressBarTextTweener?.Kill();

            _progressBarTextTweener = DOVirtual.Int(
                startValue, endValue, duration,
                UpdateProgressBarText).SetEase(Ease.InCirc).OnComplete(() => { _cachedCurrentValue = endValue; });
        }

        private void UpdateProgressBarWidth(float width)
        {
            _progressFill.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        private void UpdateProgressBarText(int currentValue)
        {
            _progressText.text = $"{currentValue.ToString()}/{_cachedMaxValue.ToString()}";
        }
    }
}