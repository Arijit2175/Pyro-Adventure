using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gameUI;

    void Start()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
    }

    public void PlayGame()
    {
        menuPanel.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}