using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMover playerMover;

    private bool attackAnimationPlaying;

    [SerializeField] private GameObject deathParticles;

    private const string ANIMATOR_IS_RUNNING_STRING = "IS_RUNNING";
    private const string ANIMATOR_IS_ATTACK_STRING = "IS_ATTACK";
    private const string ANIMATOR_DEATH_STRING = "DEATH";

    private void Start()
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

    protected void EndAttackAnimation()
    {
        attackAnimationPlaying = false;
    }

    public bool IsAttackAnimationPlaying()
    {
        return attackAnimationPlaying;
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger(ANIMATOR_DEATH_STRING);
    }

    protected void SpawnDeathParticles()
    {
        Instantiate(deathParticles,transform.position,quaternion.identity);
    }
    protected void DeathAnimationEnded()
    {
        GetComponent<PlayerHealth>().KillPlayer();
    }
    
}
