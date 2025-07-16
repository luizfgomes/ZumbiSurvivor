using UnityEngine;
using System;
using Enemy.Collision.System;

namespace Enemy.Animation
{
    public class EnemyAnimationSystem : AnimationController
    {
        [SerializeField]private YAxisLerpRotator _yAxisLerpRotator;
        [SerializeField] private EnemyCollisionSystem _enemyCollisionSystem;
        public Action OnEnemyRunning { get; set; }

        private void Awake ()
        {
            if( !_yAxisLerpRotator )
                _yAxisLerpRotator = GetComponent<YAxisLerpRotator>();

            if ( !_enemyCollisionSystem )
            {
                _enemyCollisionSystem = GetComponent<EnemyCollisionSystem>();
            }
        }
        private void OnEnable ()
        {
            _enemyCollisionSystem.OnEnemyTransition += Transition;
            _enemyCollisionSystem.OnEnemyTurn += Turn;
            OnEnemyRunning += Running;
        }

        private void OnDisable ()
        {
            _enemyCollisionSystem.OnEnemyTransition -= Transition;
            _enemyCollisionSystem.OnEnemyTurn -= Turn;
            OnEnemyRunning -= Running;
        }

        #region  new animation status
        private void Transition ()
        {
            animator.SetTrigger("Transition");
        }

        private void Turn ()
        {
            animator.SetTrigger("Turn");
            _yAxisLerpRotator.Rotate180();
        }

        private void Running ()
        {
            animator.SetBool("Running", true);
        }
        #endregion

        //AnimationEvent
        public void ZombieRun ()
        {
            OnEnemyRunning?.Invoke();
        }
    }
}

