using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 10;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>(); //hiển thị số lượng mạng lên màn hình
        UpdateDisplay();
        Debug.Log("Difficulty is : " + PlayerPrefsController.GetDifficulty()); 
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();//chuyển đổi text sang string để hiển thị (livesText: hiện thị ra tên, lives: hiển thị ra số
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().LoseCondition();
        }
    }
}
