using UnityEngine;

public abstract class AnimationController : MonoBehaviour, IAnimationController
{
    [SerializeField]protected Animator animator;

    protected virtual void Awake ()
    {
        if ( animator )
            return;
        animator = GetComponentInChildren<Animator>();
    }

    public virtual void IdleOrRun (bool value)
    {
        animator.SetBool("Run", value);
        Debug.Log("O valor no AnimationController é: " + value);
    }

    public virtual void Attack ()
    {
        animator.SetTrigger("Punch");
    }
}
