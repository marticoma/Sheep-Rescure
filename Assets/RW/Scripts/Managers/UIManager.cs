using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 1

    public Text sheepSavedText; // 2
    public Text sheepDroppedText; // 3
    public GameObject gameOverWindow; // 4
    public GameObject winWindow;
    public int delaytime;
    public int level;
    public Text levelText;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        level = 0;
        ShowWinWindow();
    }

    public void UpdateSheepSaved() // 1
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // 2
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    public void ShowWinWindow(){
        level++;
        levelText.text = "Level " + level.ToString();
        StartCoroutine(Win());
    }

    private IEnumerator Win(){
        winWindow.SetActive(true);
        yield return new WaitForSeconds(delaytime);
        winWindow.SetActive(false);
    } 

}

