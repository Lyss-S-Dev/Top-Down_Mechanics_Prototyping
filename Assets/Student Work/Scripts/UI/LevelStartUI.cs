using UnityEngine;

public class LevelStartUI : MonoBehaviour
{

    protected void LevelStartAnimEnded()
    {
        GameStateManager.instance.ChangeGameState(GameStateManager.GameState.IN_GAME);
    }
}
