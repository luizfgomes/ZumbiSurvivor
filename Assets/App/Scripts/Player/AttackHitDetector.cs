using UnityEngine;
using Enemy.Navigation;
using Util.Ragdoll;
using Enemy;

public class AttackHitDetector : MonoBehaviour
{
    private RagdollController _ragdollController;
    private EnemyEvents _enemyEvents;
    private EnemyNavigationSystem _enemyNavigationSystem;
    private EnemyStatus _enemyStatus;
    private bool _value;

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.tag == "CollisionDetector" )
        {
            _ragdollController = other.GetComponentInParent<RagdollController>();
            _enemyEvents = other.GetComponentInParent<EnemyEvents>();
            _enemyNavigationSystem = other.GetComponentInParent<EnemyNavigationSystem>();
            _enemyStatus = other.GetComponentInParent<EnemyStatus>();

            if ( _enemyNavigationSystem.EnemyData.CharData.isAlive )
                EventBus.RaiseOnAttackStart();
            _enemyEvents.onDie();

            _ragdollController.SetRagdollActive(true);

            _value = _enemyStatus.IsCollectable;
        }
    }
}