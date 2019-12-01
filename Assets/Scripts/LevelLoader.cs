using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    const int SPLASH_SCREEN_INDEX = 0;
    const int START_MENU_INDEX = 1;
    const int OPTIONS_INDEX = 2;
    const int FIRST_LEVEL_INDEX = 3;

    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadStartMenuWithDelay()
    {
        StartCoroutine(LoadStartMenuWithDelayCr());
    }

    private IEnumerator LoadStartMenuWithDelayCr()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(START_MENU_INDEX);
    }

    public void LoadLoseScreen()
    {
        // TODO: better lose screen
        SceneManager.LoadScene(START_MENU_INDEX);
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene(OPTIONS_INDEX);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(FIRST_LEVEL_INDEX);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadStartMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(START_MENU_INDEX);
    }
}
