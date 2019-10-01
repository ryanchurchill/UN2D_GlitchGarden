using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStartMenu()
    {
        StartCoroutine(LoadStartMenuWithDelay());
    }

    private IEnumerator LoadStartMenuWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Start Menu");
    }
}
