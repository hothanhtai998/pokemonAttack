using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaStone : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] float currentSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime); //cập nhật frame đi về phía bên trái của attacker
    }


}
