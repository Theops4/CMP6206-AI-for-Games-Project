using UnityEngine;


public class WalkState : State
{
    private Animation animationComponent;
    private int count = 0;
    Agent owner;

    public WalkState(Agent owner)
    {
        this.owner = owner;
        animationComponent = owner.GetComponent<Animation>();
    }

    public override void Enter()
    {
        Debug.Log("Entering Walk State");
        count = 0;
        animationComponent.Play("Take 001");

    }
    public override void Execute()
    {
        Debug.Log(count);
        count++;
        if (count > 120)
        {
            animationComponent.Stop("Take 001");
            count = 0;
            animationComponent.Play("Take 001");
        }
        owner.transform.Translate(-Vector3.right * Time.deltaTime);
    }
    public override void Exit()
    {
        Debug.Log("Exiting Walk State");
    }
}
