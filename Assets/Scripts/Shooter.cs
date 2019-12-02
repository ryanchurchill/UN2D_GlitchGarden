using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// part of Defender
public class Shooter : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    
    [SerializeField] GameObject projectile, gun;

    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    // animator consts
    const string ANIMATOR_VAR_IS_ATTACKING = "isAttacking";

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool(ANIMATOR_VAR_IS_ATTACKING, true);
        }
        else
        {
            animator.SetBool(ANIMATOR_VAR_IS_ATTACKING, false);
        }
    }

    public void Fire()
    {
        GameObject spawnedProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        spawnedProjectile.transform.parent = projectileParent.transform;
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
