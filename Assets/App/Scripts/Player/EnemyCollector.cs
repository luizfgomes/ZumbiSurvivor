using UnityEngine;
using Enemy;
using UnityEngine.AI;

public class EnemyCollector : MonoBehaviour
{
    [SerializeField] private StackManager _stackManager;

    private void Awake ()
    {
        if (!_stackManager)
            _stackManager = GetComponent<StackManager>();
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

            if ( collectable != null && collectable.IsCollectable )
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
