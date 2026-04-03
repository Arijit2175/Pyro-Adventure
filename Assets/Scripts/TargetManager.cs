using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform npc1;
    public Transform npc2;
    public Transform scroll;
    public Transform dragon;

    public DirectionArrow arrow;

    void Update()
    {
        switch (QuestManager.Instance.questStage)
        {
            case 0:
                arrow.target = npc1;
                break;

            case 1:
                arrow.target = npc2;
                break;

            case 2:
                arrow.target = scroll;
                break;

            case 3:
                arrow.target = npc2;
                break;

            case 4:
                arrow.target = dragon;
                break;

            default:
                arrow.target = null;
                break;
        }
    }
}