using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numAttackersOnScreen = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelOver())
        {
            Debug.Log("End Level Now!");
        }
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

    private bool isLevelOver()
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
