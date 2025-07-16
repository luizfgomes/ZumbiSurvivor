using UnityEngine;
using Enemy.Navigation;
using System;

namespace Enemy.Collision.System
{
    public class EnemyCollisionSystem : MonoBehaviour
    {
        [SerializeField] private EnemyNavigationSystem _agent;
        private Transform _target;
        private bool _isFacingRight;

        public bool IsFacingRight => _isFacingRight;
        public Action OnEnemyTransition{ get; set; }
        public Action OnEnemyTurn { get; set; }

        private void Awake ()
        {
            if ( !_agent )
            {
                _agent = GetComponent<EnemyNavigationSystem>();
            }
        }

        #region collider region
        private void OnTriggerEnter ( Collider other )
        {
            if(other.gameObject.tag == "Player" )
            {
                if ( !_target )
                {
                    _target = other.transform;
                }

                if ( IsPlayerInFront(_target) )
                {
                    OnEnemyTransition?.Invoke();
                } else
                {
                    OnEnemyTurn?.Invoke();
                }

                _agent.Target = _target;
            }
        }
        #endregion

        private bool IsPlayerInFront(Transform player )
        {
            Vector3 toPlayer = player.position - transform.position;

            toPlayer.y = 0;

            Vector3 forward = transform.forward;

            float dot = Vector3.Dot(toPlayer.normalized, forward);

            return dot > 0f;
        }
    }
}