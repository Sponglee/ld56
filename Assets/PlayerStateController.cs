using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateController : MonoBehaviour
{
    public PlayerState PlayerState;
    public ToggleCoatController toggleCoatController;
    public GroundChecker groundChecker;
    public TiltController tiltController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Outside"))
        {
            ChangeState(PlayerState.Assembled);
            groundChecker.IsChecking = true;
            toggleCoatController.ToggleCoat(true);
            tiltController.TiltUp();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Inside"))
        {
            ChangeState(PlayerState.Running);
            groundChecker.IsChecking = false;
            toggleCoatController.ToggleCoat(false);
            tiltController.TiltSideways();
        }
    }


    public void ChangeState(PlayerState targetState)
    {
        PlayerState = targetState;
    }
}

public enum PlayerState
{
    Assembled,
    Running
}