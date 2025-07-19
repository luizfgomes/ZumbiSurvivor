using System;

public static class EventBus
{
    #region player variables
    public static event Action OnAttackStart;
    public static event Action OnPunchEventEnabled;
    public static event Action OnPunchEventDisabled;
    public static event Action OnTradeEnemy;
    public static event Action OnStackEnemy;
    public static event Action OnUpdateUI;
    #endregion

    #region player methods 
    public static void RaiseOnAttackStart() => OnAttackStart?.Invoke();
    public static void RaiseOnPunchEventEnabled () => OnPunchEventEnabled?.Invoke();
    public static void RaiseOnPunchEventDisabled () => OnPunchEventDisabled?.Invoke();
    public static void RaiseOnTradeEnemy () => OnTradeEnemy?.Invoke();
    public static void RaiseOnStackEnemy () => OnStackEnemy?.Invoke();
    public static void RaiseOnUpdateUI () => OnUpdateUI?.Invoke();
    #endregion

}
