using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    [SerializeField] private Text moneyInShopText;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        UpdateMoneyInShop();
    }
    public void UpdateMoneyInShop()
    {
        moneyInShopText.text = CarMoney.Instance.ReturnCurrentMoney() + " Gold";
    }

    public void DebugAddMoney()
    {
        CarMoney.Instance.AddMoneyAndSave(1000);
        UpdateMoneyInShop();
    }

    public void DeleteAllPrefbs()
    {
        PlayerPrefs.DeleteAll();
    }
}
