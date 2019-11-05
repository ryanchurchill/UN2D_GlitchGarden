using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;
    [SerializeField] Attacker attackerPrefab;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAttacker()
    {
        Attacker attacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        attacker.transform.parent = transform;
    }
}
