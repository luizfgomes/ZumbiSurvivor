using UnityEngine;
using UnityEngine.AI;
using Enemy.Animation;

namespace Enemy.Navigation
{
    public class EnemyNavigationSystem : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CharData _enemyData;
        [SerializeField] private NavMeshAgent _agent;
        private EnemyAnimationSystem _enemyAnimationSystem;

        private void OnEnable ()
        {
            _enemyAnimationSystem.OnEnemyRunning += SetMovementActive;
        }

        private void OnDisable ()
        {
            _enemyAnimationSystem.OnEnemyRunning -= SetMovementActive;
        }

        public Transform Target
        {
            set { _target = value; }
        }

        private void Awake ()
        {
            _agent = GetComponent<NavMeshAgent>();
            _enemyAnimationSystem = GetComponent<EnemyAnimationSystem>();
        }

        private void Start ()
        {
            SetMovementDisactive();
        }

        private void Update ()
        {
            if ( !_enemyData.isAlive && !_agent.isStopped )
            {
                SetMovementDisactive();
                return;
            }
            if ( _target != null && !_agent.isStopped )
            {
                _agent.SetDestination(_target.position);
            }
        }

        public void SetTarget ( Transform newTarget )
        {
            _target = newTarget;
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