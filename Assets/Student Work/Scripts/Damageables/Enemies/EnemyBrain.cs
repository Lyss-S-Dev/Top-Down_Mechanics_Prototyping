using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    protected EnemyStateBase currentState;
    

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateUpdate();
        }
        
    }

    protected void ChangeCurrentState(EnemyStateBase stateToChange)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }
        
        currentState = stateToChange;
        currentState.OnEnterState();
    }
    
}
