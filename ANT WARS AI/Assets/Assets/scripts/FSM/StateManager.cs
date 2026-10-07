using UnityEngine;

public class StateManager 
{
    State CurrState;
    
    public void ChangeState(State newState)
    {
        if (CurrState != null)
        {
            CurrState.Exit();
        }
        CurrState = newState;
        newState.Enter();
    }
    public void Update()
    {
        if (CurrState != null) CurrState.Execute();
    }
}
