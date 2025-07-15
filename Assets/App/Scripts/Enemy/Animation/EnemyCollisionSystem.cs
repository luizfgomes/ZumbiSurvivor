using UnityEngine;

namespace Enemy.Collision.System
{
    public class EnemyCollisionSystem : MonoBehaviour
    {
        private GameObject _target;
        private bool _isFacingRight;

        public bool IsFacingRight => _isFacingRight;

        #region collider region
        private void OnTriggerEnter ( Collider other )
        {
            if(other.gameObject.tag == "Player" )
            {
                if ( !_target )
                {
                    _target = other.gameObject;
                }

                if ( IsPlayerInFront(_target.transform) )
                {
                    EventBus.RaiseOnEnemyTransition();
                } else
                {
                    EventBus.RaiseOnEnemyTurn();
                }
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