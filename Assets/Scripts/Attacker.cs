﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int attackDamage = 0;

    float CurrentSpeed = 0;

    GameObject currentTarget;

    // animator consts
    const string ANIMATOR_VAR_IS_ATTACKING = "isAttacking";

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerKilled();
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * CurrentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            Walk();
        }
    }

    public void SetCurrentSpeed(float Speed)
    {
        this.CurrentSpeed = Speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool(ANIMATOR_VAR_IS_ATTACKING, true);
        currentTarget = target;
    }

    public void Walk()
    {
        GetComponent<Animator>().SetBool(ANIMATOR_VAR_IS_ATTACKING, false);
        currentTarget = null;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(attackDamage);
        }
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }
}
