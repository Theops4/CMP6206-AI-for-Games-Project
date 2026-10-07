using UnityEngine;

public class IdleState : State
{
    Agent owner;
    public IdleState(Agent owner)
    {
        this.owner = owner;
    }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
    }
    public override void Execute()
    {
        Debug.Log("Executing Idle State");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
