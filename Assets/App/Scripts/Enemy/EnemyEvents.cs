using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    public Action onEnemyRunning { get; set; }
    public Action onEnemyTransition { get; set; }
    public Action onEnemyTurn { get; set; }

    public Action onDie { get; set; }

    public void OnEnemyRunning ()
    {
        onEnemyRunning?.Invoke();
    }

    public void OnEnemyTransition ()
    {
        onEnemyTransition?.Invoke();
    }

    public void OnEnemyTurn()
    {
        onEnemyTurn?.Invoke();
    }

    public void OnDie ()
    {
        onDie?.Invoke();
    }
}
