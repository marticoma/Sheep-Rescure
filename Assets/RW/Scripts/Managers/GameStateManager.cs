using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int sheepSaved; // 2

    [HideInInspector]
    public int sheepDropped; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5
    public int sheepShootBeforeWin;

    void Awake()
    {
        Instance = this;
    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
        if (sheepSaved == sheepShootBeforeWin) // 2
        {
            Win();
            sheepDropped = 0;
            sheepSaved = 0;
            sheepShootBeforeWin = sheepShootBeforeWin+2;
            UIManager.Instance.UpdateSheepDropped();
            UIManager.Instance.UpdateSheepSaved();
            if(SheepSpawner.Instance.timeBetweenSpawns>0.5f)
            SheepSpawner.Instance.timeBetweenSpawns =  SheepSpawner.Instance.timeBetweenSpawns - 0.1f;
        }

    }
    private void GameOver()
    {
        sheepSpawner.canSpawn = false; // 1
        sheepSpawner.DestroyAllSheep(); // 2
        UIManager.Instance.ShowGameOverWindow();

    }

    private void Win()
    {
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowWinWindow();

    }
    public void DroppedSheep()
    {
        sheepDropped++; // 1
        UIManager.Instance.UpdateSheepDropped();


        if (sheepDropped == sheepDroppedBeforeGameOver) // 2
        {
            GameOver();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
