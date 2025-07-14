using System;

public static class EventBus
{
    public static event Action OnAttackStart;
    public static event Action OnPunchEventEnabled;
    public static event Action OnPunchEventDisabled;

    public static void RaiseOnAttackStart() => OnAttackStart?.Invoke();
    public static void RaiseOnPunchEventEnabled () => OnPunchEventEnabled?.Invoke();
    public static void RaiseOnPunchEventDisabled () => OnPunchEventDisabled?.Invoke();
}
