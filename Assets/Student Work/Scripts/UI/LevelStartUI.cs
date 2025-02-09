using UnityEngine;

public class LevelStartUI : MonoBehaviour
{
    protected void LevelStartAnimEnded()
    {
        GameStateManager.Instance.ChangeGameState(GameStateManager.GameState.IN_GAME);
    }
}
