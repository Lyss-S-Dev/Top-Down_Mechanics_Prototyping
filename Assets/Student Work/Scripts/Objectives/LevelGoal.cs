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
        AudioPlayer.Instance.PlayClipAtPosition("Victory");
        animator.SetTrigger("Level Win");
    }

    protected void WinAnimationDone()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.END_OF_LEVEL);
    }
}
