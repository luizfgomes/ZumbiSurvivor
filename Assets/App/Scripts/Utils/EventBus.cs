using System;

public static class EventBus
{
    #region player variables
    public static event Action OnAttackStart;
    public static event Action OnPunchEventEnabled;
    public static event Action OnPunchEventDisabled;
    #endregion
    #region enemy variables
    public static event Action OnEnemyTurn;
    public static event Action OnEnemyTransition;
    public static event Action OnEnemyRunning;
    #endregion

    #region player methods 
    public static void RaiseOnAttackStart() => OnAttackStart?.Invoke();
    public static void RaiseOnPunchEventEnabled () => OnPunchEventEnabled?.Invoke();
    public static void RaiseOnPunchEventDisabled () => OnPunchEventDisabled?.Invoke();
    #endregion

    #region enemy methods
    public static void RaiseOnEnemyTurn () => OnEnemyTurn?.Invoke();
    public static void RaiseOnEnemyTransition () => OnEnemyTransition?.Invoke();
    public static void RaiseOnOnEnemyRunning () => OnEnemyRunning?.Invoke();
    #endregion
}
