using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 4f;
    
    int numAttackersOnScreen = 0;
    bool levelTimerFinished = false;
    bool levelOver = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelOver)
        {
            if (isWinCondition())
            {
                levelOver = true;
                //GetComponent<AudioSource>().Play();
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
