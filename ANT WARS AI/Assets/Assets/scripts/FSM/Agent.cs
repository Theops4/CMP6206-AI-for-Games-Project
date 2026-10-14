using UnityEngine;

public class Agent : MonoBehaviour
{
    StateManager sm = new StateManager();
    void Start()
    {
        sm.ChangeState(new WalkState(this));
    }

    void Update()
    {
        sm.Update();
        if (!(sm.CurrentState is IdleState))
        {
            sm.ChangeState(new WalkState(this));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("FOOD"))
        {
            sm.ChangeState(new IdleState(this));
        }

    }
}
