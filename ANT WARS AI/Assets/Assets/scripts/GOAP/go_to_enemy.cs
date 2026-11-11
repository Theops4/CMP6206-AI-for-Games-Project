using UnityEngine;

public class go_to_enemy : GOAP_Action
{
    private Animation animationComponent;
    private int count = 0;

    private void Update()
    {
        if (!running || animationComponent == null)
        {
            return;
        }

        count++;

        if (count > 150)
        {
            animationComponent.Stop("Take 001");
            count = 0;
            animationComponent.Play("Take 001");
        }
    }

    public override bool PrePerform()
    {
        animationComponent = GetComponent<Animation>();

        count = 0;
        animationComponent.Play("Take 001");

        return true;
    }

    public override bool PostPerform()
    {
        if (animationComponent != null)
        {
            animationComponent.Stop("Take 001");
        }

        count = 0;
        return true;
    }
}
