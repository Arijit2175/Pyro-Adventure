using UnityEngine;

public class SwordHitboxController : MonoBehaviour
{
    private Collider col;

    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    public void EnableHitbox()
    {
        col.enabled = true;
        Debug.Log("Hitbox Enabled");
    }

    public void DisableHitbox()
    {
        col.enabled = false;
        Debug.Log("Hitbox Disabled");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!col.enabled) return;

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");
        }
    }
}