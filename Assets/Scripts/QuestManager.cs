using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public int questStage = 0;
    public int lastCheckpoint = 0;   

    public bool questAccepted = false;
    public bool scrollCollected = false;

    void Awake()
    {
        Instance = this;
    }

    public void AdvanceQuest()
    {
        questStage++;
        lastCheckpoint = questStage - 1;
    }
}