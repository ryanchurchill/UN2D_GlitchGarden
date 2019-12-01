using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    const int SPLASH_SCREEN_INDEX = 0;
    const int START_MENU_INDEX = 1;
    const int FIRST_LEVEL_INDEX = 2;

    int currentSceneIndex = 0;

    public void LoadStartMenu()
    {
        StartCoroutine(LoadStartMenuWithDelay());
    }

    private IEnumerator LoadStartMenuWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(START_MENU_INDEX);
        currentSceneIndex = START_MENU_INDEX;
    }

    public void LoadLoseScreen()
    {
        // TODO: better lose screen
        SceneManager.LoadScene(START_MENU_INDEX);
        currentSceneIndex = START_MENU_INDEX;
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(FIRST_LEVEL_INDEX);
        currentSceneIndex = FIRST_LEVEL_INDEX;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
