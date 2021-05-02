using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    public bool canPlant = true;
    private int timeToWait;
    const string DEFENDER_PARENT_NAME = "Defenders";//tạo ra thư mục Defenders để chứa tất cả defender

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME); //gom các defender về chung 1 thư mục Defenders
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClick()); 
    }

    public void SetSelectedDefender(Defender defenderToSelect) 
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarsCost();
        if (starDisplay.HaveEnoughtStars(defenderCost) && canPlant)//kiểm tra xem số sao có đủ để mua defender không
        {
            SpawnDefender(gridPos);
            //StartRecharge();
            starDisplay.SpendStars(defenderCost);//trừ số ngôi sao(tiền) sau khi chọn defender để đặt lên bàn chơi
        }
    }


    private Vector2 GetSquareClick()//lấy vị trí khi click chuột
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //vị trí click so với thế giới(world) được chuyển thành grid
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos); //đưa vị trí click về các số nguyên để hiển thị(ví dụ(1, 1), (2, 3), ....)
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)//đổi số thực thành số nguyên (ví dụ (1.123123, 2.1434543) ==> (1, 2)....)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender /*đối tượng được tạo clone*/, 
            roundedPos/*vị trí xuất hiện*/, Quaternion.identity) as Defender;

        newDefender.transform.parent = defenderParent.transform;//vị trí thư mục Defenders chứa tất cả defender(sau này làm cho quái vật giống vậy luôn)
    }

    //public void StartRecharge()//thêm thời gian chờ cho defender
    //{
    //    canPlant = false;
    //    StartCoroutine(WaitTime());
    //}

    //IEnumerator WaitTime()
    //{
    //    yield return new WaitForSecondsRealtime(FindObjectOfType<Charizard>().Time(10));//thêm thời gian chờ cho defender
    //    canPlant = true;
    //}
}
