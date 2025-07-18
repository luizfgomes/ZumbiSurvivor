using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerStatus _playerStatus;
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private CharacterController _characterController;

        private readonly float _deadzoneValue = 0.001f;
        private readonly float _gravity = -9.8f;
        private bool _isGrounded;
        private bool _isRunning;
        private Vector3 _velocity;

        public bool IsRunning
        {
            get => _isRunning;
        }

        private void Awake ()
        {
            if ( !_characterController )
                _characterController = GetComponent<CharacterController>();

            if ( !_playerStatus )
                _playerStatus = GetComponent<PlayerStatus>();
        }

        private void FixedUpdate ()
        {
            float moveHorizontal = _fixedJoystick.Horizontal;
            float moveVertical = _fixedJoystick.Vertical;

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            _isGrounded = _characterController.isGrounded;

            if ( movement.magnitude > 1 )
            {
                movement.Normalize();
            }

            _characterController.Move(movement * _playerStatus.PlayerData.moveSpeed * Time.deltaTime);

            if ( movement.magnitude > 0 )
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _playerStatus.PlayerData.rotationSpeed * Time.deltaTime);
            }

            if ( !_isGrounded )
            {
                _velocity.y += _gravity * Time.deltaTime;
            } else
            {
                _velocity.y = 0;
            }

            _characterController.Move(_velocity * Time.deltaTime);

            _isRunning = (moveHorizontal != 0 || moveVertical != 0) ? true : false;
        }
    }
}

