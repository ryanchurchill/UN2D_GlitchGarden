using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTock();
    }

    void moveTock()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health collidingObjectHealth = collision.GetComponent<Health>();
        if (collidingObjectHealth)
        {
            collidingObjectHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
