using System;
using System.Collections;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public enum PlayerState
    {
        NORMAL,
        INVINCIBLE,
        DEAD,
    }

    [SerializeField] private float invincibleTime = 0.5f;

    private PlayerState currentPlayerState;

   private void Start()
   {
       ChangePlayerState(PlayerState.NORMAL);
   }

   public void ChangePlayerState(PlayerState stateToChange)
   {
       currentPlayerState = stateToChange;

       switch (stateToChange)
       {
           case PlayerState.NORMAL:
               break;
           case PlayerState.INVINCIBLE:
               StartCoroutine(InvincibleTime());
               break;
           case PlayerState.DEAD:
               GetComponent<PlayerHealth>().PlayerDeathSequence();
               break;
       }
   }

   public PlayerState GetCurrentPlayerState()
   {
       return currentPlayerState;
   }

   private IEnumerator InvincibleTime()
   {
       yield return new WaitForSeconds(invincibleTime);
       ChangePlayerState(PlayerState.NORMAL);
   }
}
