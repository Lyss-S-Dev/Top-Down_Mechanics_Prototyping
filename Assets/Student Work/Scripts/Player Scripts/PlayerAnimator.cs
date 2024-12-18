using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMover playerMover;

    private bool attackAnimationPlaying = false;

    private const string ANIMATOR_IS_RUNNING_STRING = "IS_RUNNING";
    private const string ANIMATOR_IS_ATTACK_STRING = "IS_ATTACK";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMover = GetComponent<PlayerMover>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(ANIMATOR_IS_RUNNING_STRING, playerMover.GetIsRunning());
        
    }

    public void PerformAttackAnimation()
    {
        animator.SetTrigger(ANIMATOR_IS_ATTACK_STRING);
        attackAnimationPlaying = true;
    }

    public void EndAttackAnimation()
    {
        attackAnimationPlaying = false;
    }

    public bool IsAttackAnimationPlaying()
    {
        return attackAnimationPlaying;
    }
    
}
