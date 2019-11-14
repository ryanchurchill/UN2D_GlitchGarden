using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    // Cached components
    HealthDisplay healthDisplay;

    private void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide!");
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            healthDisplay.DealDamage(attacker.GetAttackDamage());
            Destroy(attacker.gameObject);
        }
    }
}
