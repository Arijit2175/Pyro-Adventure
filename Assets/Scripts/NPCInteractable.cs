using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public string npcName = "Villager";
    public bool isFirstNPC = false;

    [Header("Normal Dialogue")]
    [TextArea] public string[] dialogueLines;

    [Header("Quest Dialogue")]
    public bool isQuestNPC = false;
    [TextArea] public string[] questDialogue;
    [TextArea] public string[] completedDialogue;

    public GameObject interactPopup;

    bool playerNearby;

    public void Interact()
    {
        if (!playerNearby) return;

        interactPopup.SetActive(false);

        if (isQuestNPC)
        {
            if (QuestManager.Instance.questStage == 1)
            {
                DialogueManager.Instance.StartDialogue(npcName, questDialogue);
                QuestManager.Instance.AdvanceQuest();
                Debug.Log("Find the scroll");
            }
            else if (QuestManager.Instance.questStage == 2)
            {
                DialogueManager.Instance.StartDialogue(npcName, questDialogue);
            }
            else if (QuestManager.Instance.questStage == 3)
            {
                DialogueManager.Instance.StartDialogue(npcName, completedDialogue);
                QuestManager.Instance.AdvanceQuest();
                Debug.Log("Go to dragon");
            }
        }
        else
        {
            DialogueManager.Instance.StartDialogue(npcName, dialogueLines);
        }

        if (isFirstNPC && QuestManager.Instance.questStage == 0)
        {
            QuestManager.Instance.AdvanceQuest();
            Debug.Log("Go to NPC 2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            interactPopup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactPopup.SetActive(false);
        }
    }
}