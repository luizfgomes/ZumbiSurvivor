using UnityEngine;
using Enemy;
using Player;
using UnityEngine.AI;

public class EnemyCollector : MonoBehaviour
{
    [SerializeField] private StackManager _stackManager;
    [SerializeField] private PlayerStatus _playerStatus;

    private void Awake ()
    {
        if (!_stackManager)
            _stackManager = GetComponent<StackManager>();

        if ( !_playerStatus )
            _playerStatus = GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter ( Collider other )
    {
        if (other.gameObject.CompareTag("CollisionDetector"))
        {
            BoxCollider [] _colliders;
            CapsuleCollider [] _capsuleCollider;
            Rigidbody [] _rb;
            NavMeshAgent _navMesh;

            _colliders = other.transform.parent.GetComponentsInChildren<BoxCollider>();
            _capsuleCollider = other.transform.parent.GetComponentsInChildren<CapsuleCollider>();
            _rb = other.transform.parent.GetComponentsInChildren<Rigidbody>();
            _navMesh = other.transform.parent.GetComponent<NavMeshAgent>();


            var collectable = other.GetComponentInParent<EnemyStatus>();

            if ( collectable != null && collectable.IsCollectable && _playerStatus.CurrentStack < _playerStatus.MaxStack )
            {
                _stackManager.AddToStack(other.transform.parent);

                foreach ( BoxCollider col in _colliders )
                {
                    col.enabled = false;
                }

                foreach ( CapsuleCollider col in _capsuleCollider )
                {
                    col.enabled = false;
                }

                foreach ( Rigidbody rb in _rb )
                {
                    rb.isKinematic = true;
                }

                _navMesh.enabled = false;
            }
        }
    }
}
