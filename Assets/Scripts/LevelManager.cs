using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void GameStart()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameOver()
    {
        StartCoroutine(wait("GameOver",sceneLoadDelay));
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator wait(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
