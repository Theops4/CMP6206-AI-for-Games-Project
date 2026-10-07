using UnityEngine;

public class Agent : MonoBehaviour
{
    StateManager sm = new StateManager();
    void Start()
    {
        sm.ChangeState(new IdleState(this));
    }

    void Update()
    {
        sm.Update();
        if (this.transform.position.x > 5)
        {
            sm.ChangeState(new WalkState(this));
        }
        else if (this.transform.position.x < -5)
        {
            sm.ChangeState(new IdleState(this));
        }
    }
}
