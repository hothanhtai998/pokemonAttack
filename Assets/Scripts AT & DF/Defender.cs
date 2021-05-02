using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount); //thêm ngôi sao(tiền) vào chỗ hiển thị
    }

    public int GetStarsCost()
    {
        return starCost;
    }
}
