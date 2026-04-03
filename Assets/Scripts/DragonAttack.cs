using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    public int damage = 20;
    bool hasHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if(hasHit) return;
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by dragon");

            HealthSystem player = other.GetComponent<HealthSystem>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            hasHit = true;
        }
    }

    public void ResetHit()
    {
        hasHit = false;
    }
}