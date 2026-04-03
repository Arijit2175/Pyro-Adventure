using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealtDamage;

    [SerializeField] float weaponDamage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (!canDealDamage || hasDealtDamage) return;

        HealthSystem health = other.GetComponentInParent<HealthSystem>();

        if (health != null)
        {
            Vector3 hitPoint = other.ClosestPoint(transform.position);

            health.TakeDamage(weaponDamage);
            health.HitVFX(hitPoint);

            hasDealtDamage = true;
            Debug.Log("Enemy dealt damage");
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }
}