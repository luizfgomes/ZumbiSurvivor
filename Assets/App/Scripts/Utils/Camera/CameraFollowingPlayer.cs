using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 5f;

    private void LateUpdate ()
    {
        if ( _target != null )
        {
            Vector3 desiredPosition = _target.position + _offset;

            // Aqui � onde a m�gica da suaviza��o real acontece
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;

            transform.LookAt(_target);
        }
    }
}
