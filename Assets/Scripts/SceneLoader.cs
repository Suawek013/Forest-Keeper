using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentStateIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentStateIndex + 1);
    }
    public void LoadStartScene()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
