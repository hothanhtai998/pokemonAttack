using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    public int timeToWait;
    public AudioSource[] sounds;
    public bool canPlant = true;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()//hiển thị tiền ở chỗ defender
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text, add some");
        }
        else
        {
            costText.text = defenderPrefab.GetStarsCost().ToString();
        }
    }

    void OnMouseDown()
    {
        if (FindObjectOfType<StarDisplay>().CurrentStars() >= defenderPrefab.GetComponent<Defender>().GetStarsCost() /*&& canPlant == true*/)//nếu số tiền trên bảng điểm nhiều hơn hoặc bằng số tiền của defender thì sẽ kích hoạt
        {
            sounds[0].Play();
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
            //canPlant = false;
            //StartCoroutine(WaitTime());
        }
        else if (FindObjectOfType<StarDisplay>().CurrentStars() < defenderPrefab.GetComponent<Defender>().GetStarsCost() /*|| canPlant == false*/)
        {
            sounds[1].Play();
            
        }
    }


    private void Update()
    {
        if (/*!canPlant ||*/ FindObjectOfType<StarDisplay>().CurrentStars() < defenderPrefab.GetComponent<Defender>().GetStarsCost())
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    //public void StartRecharge()
    //{
    //    canPlant = false;
    //    StartCoroutine(WaitTime());
    //}

    //IEnumerator WaitTime()
    //{
    //    yield return new WaitForSeconds(timeToWait);//thêm thời gian chờ cho defender
    //    canPlant = true;
    //}
}
