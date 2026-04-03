using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingManager : MonoBehaviour
{
    public GameObject endingCanvas;
    public GameObject gameUICanvas;

    public Image fadePanel;
    public TMP_Text storyText;
    public GameObject exitButton;

    public float fadeSpeed = 1f;
    public float typingSpeed = 0.03f;

    string fullStory =
        "The usurper has fallen...\n\n" +
        "With unwavering courage, the knight struck down the dragon\n" +
        "and restored peace to the kingdom.\n\n" +
        "The people rejoice, and hope returns once more.\n\n" +
        "THE END\n\n" +
        "Thanks for playing!";

    public void ShowEnding()
    {
        StartCoroutine(EndingSequence());
    }

    IEnumerator EndingSequence()
    {
        gameUICanvas.SetActive(false);
        endingCanvas.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.unscaledDeltaTime * fadeSpeed;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        storyText.gameObject.SetActive(true);
        storyText.text = "";

        foreach (char letter in fullStory)
        {
            storyText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        yield return new WaitForSecondsRealtime(1f);
        exitButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}