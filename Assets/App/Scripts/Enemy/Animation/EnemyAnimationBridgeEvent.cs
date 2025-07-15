using UnityEngine;
using Enemy.Animation;

public class EnemyAnimationBridgeEvent : MonoBehaviour
{
    [SerializeField]private EnemyAnimationSystem animationSystem;

    public void ZombieRun ()
    {
        animationSystem?.ZombieRun();
    }
}
