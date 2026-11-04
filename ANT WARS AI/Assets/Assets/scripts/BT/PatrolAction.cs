using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Patrol", story: "[Self] patrols [Nest]", category: "Action", id: "97b01d917df9a38288a4d6852f68d47d")]
public partial class PatrolAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Nest;

    private QueenCollision collisionSensor;
    private Animation animationComponent;
    private int count = 0;

    protected override Status OnStart()
    {
        count = 0;
        animationComponent = Self.Value.GetComponent<Animation>();
        collisionSensor = Self.Value.GetComponent<QueenCollision>();
        animationComponent.Play("Take 001");
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        count++;

        if (count > 150)
        {
            Debug.Log(count);
            animationComponent.Stop("Take 001");
            count = 0;
            animationComponent.Play("Take 001");
        }
        else if (collisionSensor.isAttacking)
        {
            return Status.Failure;
        }

            Self.Value.transform.Translate(-Vector3.right * Time.deltaTime);
        return Status.Running;


    }

    protected override void OnEnd()
    {
    }
}


