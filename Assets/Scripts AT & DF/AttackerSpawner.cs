using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)//khi spawn = true
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); //tạo ra attacker trong khoảng từ min đến max
            SpawnAttacker();
        }
    }

    public void StopSpawning()//dừng việc thêm quái vật vào trò chơi
    {
        spawn = false;
    }


    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); //gọi quái vật ra theo số lượng random
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker =
           Instantiate(myAttacker, transform.position, transform.rotation)
           as Attacker;//tạo ra các clone attacker (Instantiate: tạo ra clone)
        newAttacker.transform.parent = transform; //lấy vị trí chính xác của quái vật khi xuất hiện ở dòng nào(ví dụ ở dòng 1 hoặc 2,3,4,5)
    }
}
