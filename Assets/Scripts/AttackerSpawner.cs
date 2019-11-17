using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;
    [SerializeField] Attacker[] attackers;
    [SerializeField] int laneNumber;

    bool spawning = true;

    IEnumerator Start()
    {
        while (spawning)
        {
            float secondsUntilNextSpawn = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(secondsUntilNextSpawn);
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackers.Length - 1);
        Attacker attacker = Instantiate(attackers[attackerIndex], transform.position, transform.rotation);
        attacker.transform.parent = transform;
    }

    public int GetLaneNumber()
    {
        return laneNumber;
    }
}
