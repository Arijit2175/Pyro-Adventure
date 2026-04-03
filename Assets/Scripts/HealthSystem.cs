using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;

    public GameOverManager gameOverManager;

    Animator animator;
    public AudioSource hitAudio;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(hitAudio != null) hitAudio.Play();
        if (animator != null) animator.SetTrigger("damage");
        if (health <= 0)
        {
            StartCoroutine(DieRoutine());
        }
    }

    IEnumerator DieRoutine()
    {
        if (ragdoll != null)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
        }

        yield return new WaitForSeconds(0.1f);

        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
        else
        {
            Debug.LogError("GameOverManager not assigned!");
        }

        gameObject.SetActive(false);
    }

    public void ResetHealth()
    {
        health = 100;
    }

    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }
}
