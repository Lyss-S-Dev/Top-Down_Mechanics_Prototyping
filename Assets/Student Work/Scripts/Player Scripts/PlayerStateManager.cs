using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public enum PlayerState
    {
        NORMAL,
        INVINCIBLE,
        DEAD,
    }

   private  PlayerState currentPlayerState = PlayerState.NORMAL;

   public void ChangePlayerState(PlayerState stateToChange)
   {
       currentPlayerState = stateToChange;
   }

   public PlayerState GetCurrentPlayerState()
   {
       return currentPlayerState;
   }
}
