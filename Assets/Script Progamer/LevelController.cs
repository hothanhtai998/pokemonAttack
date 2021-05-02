using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel; //màn hình thắng
    [SerializeField] GameObject loseLabel; //màn hình thua
    [SerializeField] GameObject pauseLabel; //màn hình dừng game

    int numberOfAttacker = 0;
    bool levelTimeFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        pauseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerKilled()
    {
        numberOfAttacker--;
        if (numberOfAttacker <= 0 && levelTimeFinished)
        {
            WinCondition();//điều kiện thắng
        }
    }

    public void WinCondition()//điều kiện thắng
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();       
        Time.timeScale = 0;
    }

    public void LoseCondition()//điều kiện thua
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseCondition()//điều kiện dừng game
    {
        pauseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeCondition()//điều kiện tiếp tục game
    {
        pauseLabel.SetActive(false);
        Time.timeScale = 1;
    }

    public void LevelTimerFinished()//thời gian kết thúc màn chơi
    {
        levelTimeFinished = true;
        StopSpawner();
    }

    private void StopSpawner()//dừng việc thêm quái vật cho màn chơi
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
