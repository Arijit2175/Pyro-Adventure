using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    SwordHitbox swordHitbox;
    public AudioSource attackAudio;

    public void SetSword(GameObject sword)
    {
        if (sword == null)
        {
            swordHitbox = null;
            return;
        }

        swordHitbox = sword.GetComponentInChildren<SwordHitbox>();
    }

    public void PlaySwing()
    {
        attackAudio.Play();
    }

    public void EnableHitbox()
    {
        if (swordHitbox != null)
            swordHitbox.EnableHitbox();
    }

    public void DisableHitbox()
    {
        if (swordHitbox != null)
            swordHitbox.DisableHitbox();
    }
}