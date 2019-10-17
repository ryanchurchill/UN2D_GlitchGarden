using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float CurrentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * CurrentSpeed * Time.deltaTime);
    }

    public void SetCurrentSpeed(float Speed)
    {
        this.CurrentSpeed = Speed;
    }
}
