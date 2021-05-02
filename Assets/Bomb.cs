using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    float currentSpeed = 0;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {
            Destroy(otherCollider.gameObject);
            currentSpeed = 20f;
            TrigerDeathVFX();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime); //cập nhật frame đi về phía bên trái của attacker
    }



    private void TrigerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation); //vị trí tạo clone vụ nổ vfx
        Destroy(deathVFXObject, 1f);//xoá vfx sau 1f thời gian
    }

}
