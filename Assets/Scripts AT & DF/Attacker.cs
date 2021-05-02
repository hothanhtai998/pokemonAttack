using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,10f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); //cập nhật frame đi về phía bên trái của attacker
        UpdateAnimationState();
    }

    private void UpdateAnimationState()//hàm cập nhật hành động của quái vật
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);//nếu như không gặp defender thì quái vật sẽ ngừng tấn công và tiếp tục di chuyển
        }
    }

    public void SetMovementSpeed(float speed) //tuỳ chỉnh tốc độ
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true); //nếu quái vật gặp defender thì sẽ đánh
        currentTarget = target;
    }

    public void DamageToCurrentDefenfer(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);//hàm làm cho quái vật tấn công defender
        }
    }
}
