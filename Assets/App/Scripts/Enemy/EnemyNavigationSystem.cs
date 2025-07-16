using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Navigation
{
    public class EnemyNavigationSystem : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _agent;

        private void OnEnable ()
        {
            EventBus.OnEnemyRunning += Test;
        }

        private void OnDisable ()
        {
            EventBus.OnEnemyRunning -= Test;
        }

        public Transform Target
        {
            set { _target = value; }
        }

        private void Awake ()
        {
            _agent = GetComponent<NavMeshAgent>();
            SetMovementDisactive();
        }

        private void Update ()
        {
            if ( _target != null && !_agent.isStopped )
            {
                _agent.SetDestination(_target.position);
            }
        }

        public void SetTarget ( Transform newTarget )
        {
            _target = newTarget;
        }

        public void Test ()
        {
            SetMovementActive();
        }

        public void SetMovementActive ()
        {
            _agent.isStopped = false;
        }

        public void SetMovementDisactive ()
        {
            _agent.isStopped = true;
        }
    }
}