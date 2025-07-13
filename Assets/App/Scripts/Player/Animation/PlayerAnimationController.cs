using UnityEngine;
using Player.Movement;

namespace Player.Animation
{
    public class PlayerAnimationController : AnimationController
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private void Update ()
        {
            IdleOrRun(_playerMovement.IsRunning);
        }
    }
}