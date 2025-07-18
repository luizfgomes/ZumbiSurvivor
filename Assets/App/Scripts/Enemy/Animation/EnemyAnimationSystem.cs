using UnityEngine;
using Enemy.Collision.System;

namespace Enemy.Animation
{
    public class EnemyAnimationSystem : AnimationController
    {
        [SerializeField] private YAxisLerpRotator _yAxisLerpRotator;
        [SerializeField] private EnemyCollisionSystem _enemyCollisionSystem;
        [SerializeField] private EnemyEvents _enemyEvents;

        private void Awake ()
        {
            if ( !_enemyEvents )
                _enemyEvents = GetComponent<EnemyEvents>();

            if( !_yAxisLerpRotator )
                _yAxisLerpRotator = GetComponent<YAxisLerpRotator>();

            if ( !_enemyCollisionSystem )
            {
                _enemyCollisionSystem = GetComponent<EnemyCollisionSystem>();
            }
        }

        private void OnEnable ()
        {
            _enemyEvents.onEnemyTransition += Transition;
            _enemyEvents.onEnemyTurn += Turn;
            _enemyEvents.onEnemyRunning += Running;
        }

        private void OnDisable ()
        {
            _enemyEvents.onEnemyTransition -= Transition;
            _enemyEvents.onEnemyTurn -= Turn;
            _enemyEvents.onEnemyRunning -= Running;
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
            _enemyEvents.OnEnemyRunning();
        }
    }
}