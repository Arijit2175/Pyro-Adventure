using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int health = 100;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            StartCoroutine(HandleDeath());
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    IEnumerator HandleDeath()
    {
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);

        yield return new WaitForSeconds(2f);

        if (QuestManager.Instance.questStage == 4)
        {
            QuestManager.Instance.AdvanceQuest();
            FindObjectOfType<EndingManager>().ShowEnding();
            Debug.Log("Game Complete!");
        }
    }
}
