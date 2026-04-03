using UnityEngine;

public class DragonHitboxController : MonoBehaviour
{
    public Collider mouthCollider;

    DragonAttack dragonAttack;

    void Start()
    {
        dragonAttack = mouthCollider.GetComponent<DragonAttack>();
    }

    public void EnableHitbox()
    {
        mouthCollider.enabled = true;
        dragonAttack.ResetHit();
    }

    public void DisableHitbox()
    {
        mouthCollider.enabled = false;
    }
}