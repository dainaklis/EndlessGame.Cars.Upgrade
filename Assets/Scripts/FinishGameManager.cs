using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text youLostText;
     


    private void Awake() 
    {
       Instance = this; 
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        bool isNewHighScore = KmManager.Instance.CheckNewHigScore();
        if(isNewHighScore)
        {
            youLostText.text = "New High Score! \n" + KmManager.Instance.ReturnKmTraveler();
            
        }

        int moneyMadeThisGame = CarMoney.Instance.GetMoneyMadeAndSaveMoney();
        moneyText.text = "Money: " + moneyMadeThisGame;

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
