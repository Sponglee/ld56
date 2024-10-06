using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public PlayerState PlayerState;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Outside"))
        {
            ChangeState(PlayerState.Assembled);

            transform.rotation = Quaternion.identity;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Inside"))
        {
            ChangeState(PlayerState.Running);
            transform.rotation = Quaternion.Euler(90, 0, 0);
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