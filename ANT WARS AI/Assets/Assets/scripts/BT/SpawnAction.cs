using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Spawn", story: "[Self] spawns [Worker]", category: "Action", id: "3bc37e5ba14014b80348babd5fb3ff86")]
public partial class SpawnAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Worker;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

