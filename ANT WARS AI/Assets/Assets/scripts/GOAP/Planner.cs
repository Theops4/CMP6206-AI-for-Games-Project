using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GOAP_Action action;
    public Node(Node parent, float cost, Dictionary<string, int> allStates, GOAP_Action action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);
        this.action = action;
    }
}

public class Planner 
{ 
    public Queue<GOAP_Action> plan(List<GOAP_Action> actions, Dictionary<string, int> goal, WorldStates states)
    {
        List<GOAP_Action> usuableActions = new List<GOAP_Action>();
        foreach (GOAP_Action a in actions)
        {
            if (a.IsAchievable())
            {
                usuableActions.Add(a);
            }
        }
        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, World.Instance.GetWorld().GetStates(), null);

        bool success = BuildGraph(start, leaves, usuableActions, goal);
        if(!success)
        {
            Debug.Log("NO PLAN");
            return null;
        }

        Node cheapest = null;
        foreach(Node leaf in leaves)
        {
            if(cheapest == null)
            {
                cheapest = leaf;
            }
            else
            {
                if(leaf.cost < cheapest.cost)
                {
                    cheapest = leaf;
                }
            }
            List<GOAP_Action> result = new List<GOAP_Action>();
            Node n = cheapest;
            while(n != null)
            {
                if(n.action != null)
                {
                    result.Insert(0, n.action);
                }
                n = n.parent;
            }
            Queue<GOAP_Action> queue = new Queue<GOAP_Action>();
            foreach(GOAP_Action a in result)
            {
                queue.Enqueue(a);
            }
            return queue;
        }
        return null;
    }
    private bool BuildGraph(Node parent, List<Node> leaves, List<GOAP_Action> usableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;
        foreach(GOAP_Action action in usableActions)
        {
            if(action.IsAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach(KeyValuePair<string, int> effect in action.effects)
                {
                    if(!currentState.ContainsKey(effect.Key))
                    {
                        currentState.Add(effect.Key, effect.Value);
                    }
                }
                Node node = new Node(parent, parent.cost + action.cost, currentState, action);
                if(GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GOAP_Action> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if(found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private List<GOAP_Action> ActionSubset(List<GOAP_Action> actions, GOAP_Action removeMe)
    {
        List<GOAP_Action> subset = new List<GOAP_Action>();
        foreach(GOAP_Action a in actions)
        {
            if(!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }
        return subset;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach(KeyValuePair<string, int> g in goal)
        {
            if(!state.ContainsKey(g.Key))
            {
                return false;
            }
        }
        return true;
    }
}
