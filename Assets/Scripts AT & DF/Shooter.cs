using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject bulletParent;
    const string BULLET_PARENT_NAME = "Bullets";//tạo ra thư mục Projectiles để chứa tất cả projectiles(cái này là vật như rìu,dưa chuột(gun) bắn về quái vật)

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        bulletParent = GameObject.Find(BULLET_PARENT_NAME);//tạo ra projectile...(giống như defender)
        if (!bulletParent)
        {
            bulletParent = new GameObject(BULLET_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane()) //kiểm tra xem quái vật có cùng hàng với defender không,nếu có thì bắn, không thì thôi
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y/*vị trí của attacker*/ - transform.position.y/*vị trí của defender*/) 
                <= Mathf.Epsilon); //position y là theo hàng ngang
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(shooter, gun.transform.position, transform.rotation) as GameObject; //vị trí xuất hiện của viên đạn
        newBullet.transform.parent = bulletParent.transform;
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) //kiểm tra xem có quái vật trong hàng hay không
        { return false; }
        else
        { return true; }
    }
}
