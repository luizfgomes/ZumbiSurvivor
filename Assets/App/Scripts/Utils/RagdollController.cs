using UnityEngine;
using UnityEngine.Events;

namespace Util.Ragdoll
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField]private Animator _animator;
        private Rigidbody [] _ragdollBodies;

        public UnityEvent activeRagdoll;


        private void Awake ()
        {
            if ( !_animator )
            {
                _animator = GetComponentInChildren<Animator>();
            }

            _ragdollBodies = GetComponentsInChildren<Rigidbody>();

            SetRagdollActive(false);
        }

        public void SetRagdollActive ( bool active )
        {
            foreach ( var rb in _ragdollBodies )
            {
                if ( rb.gameObject != this.gameObject )
                {
                    rb.isKinematic = !active;
                    Collider col = rb.GetComponent<Collider>();
                    if ( col != null )
                        col.enabled = active;
                }
            }

            _animator.enabled = !active;
            activeRagdoll?.Invoke();
        }
    }
}