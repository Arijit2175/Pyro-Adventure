using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public int showAtStage;
    public GameObject visual;

    void Update()
    {
        if (QuestManager.Instance == null) return;

        visual.SetActive(QuestManager.Instance.questStage == showAtStage);
    }
}