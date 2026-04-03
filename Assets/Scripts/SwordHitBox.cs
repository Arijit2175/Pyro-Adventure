using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float damage = 20f;
    HashSet<GameObject> hitEnemies = new HashSet<GameObject>();
    Collider col;

    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;

        GameObject enemyRoot = other.transform.root.gameObject;

        if (hitEnemies.Contains(enemyRoot)) return;

        hitEnemies.Add(enemyRoot);

        Enemy enemy = enemyRoot.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Dragon dragon = other.GetComponentInParent<Dragon>();
        if (dragon != null)
        {
            dragon.TakeDamage((int)damage);
        }
    }

    public void EnableHitbox()
    {
        hitEnemies.Clear();
        col.enabled = true;
    }

    public void DisableHitbox()
    {
        col.enabled = false;
    }
}