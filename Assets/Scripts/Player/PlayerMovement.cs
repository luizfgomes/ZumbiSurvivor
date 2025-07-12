using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharData _charData;
        [SerializeField] private FixedJoystick _fixedJoystick;
        [SerializeField] private Rigidbody _rigidbody;

        private readonly float _deadzoneValue = 0.001f;

        private void Awake ()
        {
            if ( !_rigidbody )
            {
                return;
            }

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate ()
        {
            var vertical = _fixedJoystick.Vertical;
            var horizontal = _fixedJoystick.Horizontal;

            Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);

            //For correcting the deadzone if the game is expanded in the future.
            if ( inputDirection.sqrMagnitude < _deadzoneValue )
                return;

            Vector3 move = inputDirection.normalized * _charData.moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + move);

            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            Quaternion smoothedRotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, _charData.rotationSpeed * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(smoothedRotation);
        }
    }
}

