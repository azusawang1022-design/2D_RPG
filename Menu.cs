using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Popup;
    public TMP_Text messageText;

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Clicked");
    }

    public void ExitGame()
    {
        Application.Quit();

    }
    public void MissionComplete()
    {
        Popup.SetActive(true);
        messageText.text = "QUEST Cleared!";
        transform.position = new Vector3(
        transform.position.x + 20f,
        transform.position.y,
        transform.position.z
        );

        Time.timeScale = 0f;
    }
    public void MissionFailed()
    {
        Popup.SetActive(true);
        messageText.text = "YOU DIED";
        transform.position = new Vector3(
        transform.position.x + 90f,
        transform.position.y,
        transform.position.z
        );

        Time.timeScale = 0f;
    }

    public void Replay()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
