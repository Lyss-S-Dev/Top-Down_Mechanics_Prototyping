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
        if (other.gameObject.GetComponent<PlayerMover>()) 
        {
            HandlePickup();
        }
    }

    public void HandlePickup()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.CUTSCENE);
        ScoringManager.Instance.EndActionCombo();
        AudioPlayer.Instance.PlayClipAtPosition("Victory");
        animator.SetTrigger("Level Win");
    }

    //Called at the end of an animation via an event
    protected void WinAnimationDone()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.END_OF_LEVEL);
    }
}
