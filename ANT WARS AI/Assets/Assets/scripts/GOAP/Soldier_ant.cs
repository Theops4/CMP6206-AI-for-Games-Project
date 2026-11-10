using UnityEngine;
using System.Collections.Generic;

public class Soldier_ant : GOAP_Agent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("Attack", 1, true);
        goals.Add(s1, 1);
    }

}
