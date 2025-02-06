using System;
using UnityEngine;

public class LevelGoal : MonoBehaviour, IPickup
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if player run the pickup code
        if (other.gameObject.GetComponent<PlayerMover>()) 
        {
            HandlePickup();
        }
    }

    public void HandlePickup()
    {
        
        GameStateManager.instance.ChangeGameState(GameStateManager.GameState.CUTSCENE);
        AudioPlayer.instance.PlayClipAtPosition("Victory");
        animator.SetTrigger("Level Win");
        
    }

    protected void WinAnimationDone()
    {
        GameStateManager.instance.ChangeGameState(GameStateManager.GameState.END_OF_LEVEL);
    }
}
