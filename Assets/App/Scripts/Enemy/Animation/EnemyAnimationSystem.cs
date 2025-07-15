using UnityEngine;
using Enemy.Collision.System;

namespace Enemy.Animation
{
    public class EnemyAnimationSystem : AnimationController
    {
        private EnemyCollisionSystem _enemyCollisionSystem;

        private void OnEnable ()
        {
            EventBus.OnEnemyTransition += Transition;
            EventBus.OnEnemyTurn += Turn;
            EventBus.OnEnemyRunning += Running;
        }

        private void OnDisable ()
        {
            EventBus.OnEnemyTransition -= Transition;
            EventBus.OnEnemyTurn -= Turn;
            EventBus.OnEnemyRunning -= Running;
        }

        #region  new animation status
        private void Transition ()
        {
            animator.SetTrigger("Transition");
        }

        private void Turn ()
        {
            animator.SetTrigger("Turn");
        }

        private void Running ()
        {
            animator.SetBool("Running", true);
        }
        #endregion

        //AnimationEvent
        public void ZombieRun ()
        {
            EventBus.RaiseOnOnEnemyRunning();
        }
    }
}

