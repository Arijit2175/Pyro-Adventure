using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameUICanvas;
    public GameObject player;
    public HealthSystem playerHealth;
    public Transform[] checkpoints;

    public void ShowGameOver()
    {
        gameUICanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryFromCheckpoint()
    {
        Debug.Log("Retry Clicked");
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        int checkpointIndex = QuestManager.Instance.lastCheckpoint;

        player.transform.position = checkpoints[checkpointIndex].position;

        QuestManager.Instance.questStage = checkpointIndex;

        playerHealth.ResetHealth();
        player.SetActive(true);

        gameOverCanvas.SetActive(false);
        gameUICanvas.SetActive(true);
    }
}