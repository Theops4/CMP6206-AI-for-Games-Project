using UnityEngine;

public class WalkState : State
{
    Agent owner;
    public WalkState(Agent owner)
    {
        this.owner = owner;
    }

    public override void Enter()
    {
        Debug.Log("Entering Walk State");
    }
    public override void Execute()
    {
        Debug.Log("Executing Walk State");
    }
    public override void Exit()
    {
        Debug.Log("Exiting Walk State");
    }
}
