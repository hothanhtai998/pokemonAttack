using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totodile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Snolax>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
