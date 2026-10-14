using UnityEngine;

public class IdleState : State
{
    Agent owner;
    private Animation animationComponent;
    private int count = 0;
    public IdleState(Agent owner)
    {
        this.owner = owner;
        animationComponent = owner.GetComponent<Animation>();
    }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
        count = 0;
        animationComponent.Play("Take 001");
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


//start 120 ends 400