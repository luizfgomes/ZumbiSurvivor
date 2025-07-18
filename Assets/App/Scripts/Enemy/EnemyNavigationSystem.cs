using UnityEngine;
using UnityEngine.AI;
using Enemy.Animation;
using Enemy;

namespace Enemy.Navigation
{
    public class EnemyNavigationSystem : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private EnemyStatus _enemyData;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private EnemyEvents _enemyEvents;
        private EnemyAnimationSystem _enemyAnimationSystem;

        public EnemyStatus EnemyData => _enemyData;

        private void OnEnable ()
        {
            _enemyEvents.onEnemyRunning += SetMovementActive;
            _enemyEvents.onDie += Die;
            _enemyEvents.onDie += SetMovementDisactive;
        }

        private void OnDisable ()
        {
            _enemyEvents.onEnemyRunning -= SetMovementActive;
            _enemyEvents.onDie -= Die;
            _enemyEvents.onDie -= SetMovementDisactive;
        }

        public Transform Target
        {
            set { _target = value; }
        }

        private void Awake ()
        {
            _agent = GetComponent<NavMeshAgent>();
            _enemyAnimationSystem = GetComponent<EnemyAnimationSystem>();
            _enemyData = GetComponent<EnemyStatus>();

            if ( !_enemyEvents )
                _enemyEvents = GetComponent<EnemyEvents>();
        }

        private void Start ()
        {
            SetMovementDisactive();
            _enemyData.CharData.isAlive = true;
        }

        private void Update ()
        {
            if ( !_enemyData.CharData.isAlive )
            {
                return;
            }
            if ( _target != null )
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

        public void Die ()
        {
            _enemyData.CharData.isAlive = false;
        }
    }
}