using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaStoneSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] MegaStone megastonePrefab;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); //thời gian để tạo ra attacker trong khoảng từ min đến max
            SpawnMegastone();
        }
    }

    private void SpawnMegastone()
    {
        MegaStone 
            newMegastone = Instantiate(megastonePrefab, transform.position, transform.rotation) 
            as MegaStone;//tạo ra các clone attacker (Instantiate: tạo ra clone)
        newMegastone.transform.parent = transform;
    }
}
