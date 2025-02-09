using UnityEngine;

public class LevelStartUI : MonoBehaviour
{
    protected void LevelStartAnimEnded()
    {
        AudioPlayer.Instance.PlayClipAtPosition("Round Start Go");
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.IN_GAME);
    }
}
