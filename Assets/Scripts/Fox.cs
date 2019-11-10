using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // animator consts
    const string ANIMATOR_VAR_JUMP = "jumpTrigger";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        Gravestone gravestone = otherObject.GetComponent<Gravestone>();
        if (gravestone)
        {
            GetComponent<Animator>().SetTrigger(ANIMATOR_VAR_JUMP);
            return;
        }

        Defender defender = otherObject.GetComponent<Defender>();
        if (defender)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
