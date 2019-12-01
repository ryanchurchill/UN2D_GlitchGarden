using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    
    int numAttackersOnScreen = 0;
    bool levelTimerFinished = false;
    bool levelOver = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelOver)
        {
            if (isWinCondition())
            {
                levelOver = true;
                StartCoroutine(HandleWinCondition());
            }
        }
        
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void AttackerSpawned()
    {
        numAttackersOnScreen++;
    }

    public void AttackerKilled()
    {
        numAttackersOnScreen--;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private bool isWinCondition()
    {
        //return levelTimerFinished;
        return (numAttackersOnScreen <= 0 && levelTimerFinished);
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
