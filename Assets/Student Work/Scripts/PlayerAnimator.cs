using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMover playerMover;

    private const string ANIMATOR_IS_RUNNING_STRING = "IS_RUNNING";
    
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
}
