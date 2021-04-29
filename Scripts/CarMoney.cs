using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoney : MonoBehaviour
{
    public static CarMoney Instance;

    [SerializeField] private int currentMoney;

    public const string prefMoney = "prefMoney";


    

    private void Awake() 
    {
        Instance = this;

        currentMoney = PlayerPrefs.GetInt(prefMoney);
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
    }
    public void AddMoneyAndSave(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        PlayerPrefs.SetInt(prefMoney, currentMoney);
    }

    public int GetMoneyMadeAndSaveMoney()
    {
        int moneyMadeThisGame = currentMoney - PlayerPrefs.GetInt(prefMoney);
        PlayerPrefs.SetInt(prefMoney, currentMoney);

        return moneyMadeThisGame;
    }

    public int ReturnCurrentMoney()
    {
        return currentMoney;
    }
}
