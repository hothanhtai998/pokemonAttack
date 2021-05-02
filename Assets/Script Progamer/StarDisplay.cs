using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 1000;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();//hiển thị số sao(tiền) lên màn hình
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();//chuyển đổi text sang string để hiển thị
    }

    public bool HaveEnoughtStars(int amount) //kiểm tra số sao có đủ để chọn defender không
    {
        return stars >= amount;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public int CurrentStars()
    {
        return stars;
    }

}
