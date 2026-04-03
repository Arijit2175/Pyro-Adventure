using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject gameUICanvas;
    public MonoBehaviour cameraController;
    public Slider volumeSlider;

    private bool isPaused = false;

    void Start()
    {
        pauseCanvas.SetActive(false);
        volumeSlider.value = AudioListener.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsGameOver())
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        pauseCanvas.SetActive(isPaused);
        gameUICanvas.SetActive(!isPaused);

        Time.timeScale = isPaused ? 0f : 1f;

        cameraController.enabled = !isPaused;

        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    bool IsGameOver()
    {
        GameOverManager gom = FindObjectOfType<GameOverManager>();
        return gom != null && gom.gameOverCanvas.activeSelf;
    }

    public void ResumeGame()
    {
        isPaused = false;

        pauseCanvas.SetActive(false);
        gameUICanvas.SetActive(true);

        Time.timeScale = 1f;

        cameraController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}