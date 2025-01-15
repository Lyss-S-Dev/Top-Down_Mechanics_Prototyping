using UnityEngine;

public class IdleState : EnemyStateBase
{
    public override void OnEnterState()
    {
        Debug.Log("I AM ENTERING THE IDLE STATE");
    }

    public override void OnStateUpdate()
    {
        Debug.Log("I AM IN THE IDLE STATE");
    }
}
