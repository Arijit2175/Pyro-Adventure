using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objective;

    void Update()
    {
        switch (QuestManager.Instance.questStage)
        {
            case 0:
                objective.text = "Go talk to the first villager";
                break;

            case 1:
                objective.text = "Go to the village chief";
                break;

            case 2:
                objective.text = "Find the ancient scroll";
                break;

            case 3:
                objective.text = "Return to the village chief";
                break;

            case 4:
                objective.text = "Defeat the dragon";
                break;

            case 5:
                objective.text = "Quest Complete!";
                break;
        }
    }
}