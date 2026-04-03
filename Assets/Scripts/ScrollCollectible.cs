using UnityEngine;

public class ScrollCollectible : MonoBehaviour
{
    public GameObject interactPopup;

    bool playerNearby;

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            CollectScroll();
        }
    }

    void CollectScroll()
    {
        Debug.Log("Scroll Collected!");

        QuestManager.Instance.scrollCollected = true;
        QuestManager.Instance.AdvanceQuest();

        if (interactPopup != null)
            interactPopup.SetActive(false);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (interactPopup != null)
                interactPopup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            if (interactPopup != null)
                interactPopup.SetActive(false);
        }
    }
}