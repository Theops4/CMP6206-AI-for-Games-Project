using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Guard", story: "[Self] attacks [Enemy]", category: "Action", id: "a3f5cb2d2bbc7a3f87a4dbecf4b389d0")]
public partial class GuardAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;
    private QueenCollision collisionSensor;
    private Animation animationComponent;
    private int count = 0;

    protected override Status OnStart()
    {
  
        count = 0;
        animationComponent = Self.Value.GetComponent<Animation>();
        collisionSensor = Self.Value.GetComponent<QueenCollision>();
        AnimationState state = animationComponent["Take 001"];
        state.time = 120f / 60f; // Set the time to start from frame 120
        animationComponent.Play("Take 001");
        if (collisionSensor.isAttacking)
        {
            animationComponent.Play("Take 001");
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (collisionSensor.isAttacking)
        {
            count++;
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
            return Status.Running;
        }
        else
        {
            return Status.Failure;
        }
    }

    protected override void OnEnd()
    {
    }

}

