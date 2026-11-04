using UnityEngine;

public class QueenCollision : MonoBehaviour
{
    public bool isAttacking = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Collision detected with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");
            isAttacking = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Collision ended with: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");
            isAttacking = false;
        }
    }
}