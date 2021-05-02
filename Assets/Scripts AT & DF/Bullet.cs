using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1f,10f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float damage = 50;
    public AudioSource sounds;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);//di chuyển viên đạn(Bullet) về phía bên phải
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damage);//làm giảm máu
            sounds.Play();
            Destroy(gameObject,0.05f);
        }
    }

}
