using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemPriceText;


    public enum ShopItem {strongersOars, placeHolder, roadSpeeds}
    public ShopItem ItemType;

    [SerializeField] private string itemName = "PlaceHolder";
    [SerializeField] private int itemPrice = 10;
    [SerializeField] private int itemLevel;
    [SerializeField] private int itemLevelMax ;


    private void Awake() 
    {
       UpdateItemUI();         
    }

    public void BuyItem()
    {
        if (itemLevel < itemLevelMax && CarMoney.Instance.ReturnCurrentMoney() >= itemPrice)
        {
            itemLevel++;

            PlayerPrefs.SetInt(ItemType.ToString(), itemLevel);

            CarMoney.Instance.AddMoneyAndSave(-itemPrice);

            UpdateItemUI();
            
            ShopManager.Instance.UpdateMoneyInShop();
        }
    }


    private void UpdateItemUI()
    {
        itemLevel = PlayerPrefs.GetInt(ItemType.ToString());

        itemNameText.text = "LV. " +  itemLevel + " - " + itemName;
        itemPriceText.text = itemPrice + " G";

        if (itemLevel == itemLevelMax)
        {
           itemNameText.text = "Max Lv " + itemName; 
           itemPriceText.text = "0 G";
        }
    }







}
