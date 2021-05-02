using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TrigerDeathVFX();
            //Destroy(gameObject);
            if (gameObject.GetComponent<Pikachu>())
            {
                FindObjectOfType<ScoreManager>().AddScore(10);
            }
            if (gameObject.GetComponent<Totodile>())
            {
                FindObjectOfType<ScoreManager>().AddScore(20);
            }
            Destroy(gameObject);
        }
    }

    private void TrigerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation); //vị trí tạo clone vụ nổ vfx
        Destroy(deathVFXObject, 1f);//xoá vfx sau 1f thời gian
    }
}
