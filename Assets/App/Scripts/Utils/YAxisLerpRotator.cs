using UnityEngine;

public class YAxisLerpRotator : MonoBehaviour
{
    [SerializeField] private float rotationTime = 0.5f;

    private bool _isRotating;
    private float _elapsed;
    private Quaternion _startRot;
    private Quaternion _endRot;

    public void Rotate180 ()
    {
        if ( _isRotating )
            return;

        _isRotating = true;
        _elapsed = 0f;

        _startRot = transform.rotation;
        _endRot = _startRot * Quaternion.Euler(0f, 180f, 0f);
    }

    private void Update ()
    {
        if ( !_isRotating )
            return;

        _elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(_elapsed / rotationTime);

        transform.rotation = Quaternion.Lerp(_startRot, _endRot, t);

        if ( t >= 1f )
            _isRotating = false;
    }
}