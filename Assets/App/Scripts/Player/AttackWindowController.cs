using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AttackWindowController : MonoBehaviour, IAttackWindow
{
    [SerializeField] private BoxCollider _hitBox;

    private void Awake ()
    {
        if ( _hitBox )
        {
            _hitBox.enabled = false;
            return;
        } else
        {
            _hitBox = GetComponent<BoxCollider>();
            _hitBox.enabled = false;
        }
    }

    public void EnabledPunchEvent ()
    {
        _hitBox.enabled = true;
        EventBus.RaiseOnPunchEventEnabled();
    }

    public void DisabledPunchEvent ()
    {
        _hitBox.enabled = false;
        EventBus.RaiseOnPunchEventDisabled();
    }
}