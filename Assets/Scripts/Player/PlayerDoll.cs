using UnityEngine;

public class PlayerDoll : MonoBehaviour
{
    Animator animator;

    public void SetLeftAnimation()
    {
        animator = GetComponentInChildren<Animator>();

        animator.SetTrigger("DeathLeft");
    }

    public void SetRightAnimation()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("DeathRight");
    }
}
