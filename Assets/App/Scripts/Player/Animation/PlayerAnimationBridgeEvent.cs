using UnityEngine;

public class PlayerAnimationBridgeEvent : MonoBehaviour
{
    [SerializeField] private AttackWindowController _attackWindowController;

    public void EnabledPunchEvent ()
    {
        _attackWindowController.EnabledPunchEvent();
    }

    public void DisabledPunchEvent ()
    {
        _attackWindowController.DisabledPunchEvent();
    }
}
