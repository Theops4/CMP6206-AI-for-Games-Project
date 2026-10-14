using UnityEngine;

public class EatState : State
{
    Agent owner;
    private Animation animationComponent;
    private int count = 0;
    public EatState(Agent owner)
    {
        this.owner = owner;
        animationComponent = owner.GetComponent<Animation>();
    }

    public override void Enter()
    {
        Debug.Log("Entering Eat State");
        count = 0;
        animationComponent.Play("Take 001");
        AnimationState state = animationComponent["Take 001"];
        state.time = 120f / 60f; // Set the time to start from frame 120
    }
    public override void Execute()
    {
        
        count ++;
        if (count > 2100)
        {
            Debug.Log(count);
            Debug.Log("Restarting Eat Animation");
            animationComponent.Stop("Take 001");
            count = 0;
            animationComponent.Play("Take 001");
            AnimationState state = animationComponent["Take 001"];
            state.time = 120f / 60f; // Set the time to start from frame 120
        }
    }
    public override void Exit()
    {
        Debug.Log("Exiting Eat State");
    }
}


//start 120 ends 400