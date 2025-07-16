using UnityEngine;
using Player.Animation;

namespace Player.Atack
{
    public class AttackStarter : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationController _playerAnimationController;

        private void Awake ()
        {
            if ( _playerAnimationController )
                return;

            _playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        private void Update ()
        {
            if ( Input.GetKeyDown(KeyCode.Space) )
            {
                _playerAnimationController.Attack();
                EventBus.RaiseOnAttackStart();
            }
        }
    }
}

