using UnityEngine;
using System.Collections.Generic;

public sealed class World 
{
    private static readonly World instance = new World();
    private static WorldStates world;

    static World()
    {
        world = new WorldStates();
    }

    private World()
    {
    }

    public static World Instance
    {
        get
        {
            return instance;
        }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
