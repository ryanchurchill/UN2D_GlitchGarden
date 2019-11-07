using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// part of Defender
public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    AttackerSpawner myLaneSpawner;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("Fire!");
        }
        else
        {

        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            if (GetComponent<Defender>().GetLaneNumber() == spawner.GetLaneNumber())
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return (myLaneSpawner.transform.childCount > 0);
    }
}
