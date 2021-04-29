using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class KmManager : MonoBehaviour
{   
    public static KmManager Instance;
    public const string prefKm = "prefKm";

    [SerializeField] public Text kmText2; 
    [SerializeField] public Text AllKmText; 


    public float kmTraveled {get; private set;}
    [SerializeField] private float kmIndexSpeed;
    private bool isTraveling;



    private void Awake() 
    {
        Instance = this; 

        int AllKmTraveler = PlayerPrefs.GetInt(prefKm);

        AllKmText.text = "Daugiausiai Nukeliavau: " +  AllKmTraveler + " km \n" ;

    }

    
    void Update()
    {
        if (!isTraveling)
        {
            return;   
        }

        kmTraveled += Time.deltaTime * kmIndexSpeed;
        kmText2.text = (int)kmTraveled + " km";


        //KAI PERKI UPDATE PADIDEJA SPEDD KM
        // int strongersOarsLevel = PlayerPrefs.GetInt(ShopItems.ShopItem.strongersOars.ToString());

        // if (strongersOarsLevel > 0)
        // {
        //     kmTraveled += strongersOarsLevel * 0.2f;
        // }
 
    }


    public void StartScript()
    {
        isTraveling = true;


        int roadSpeed = PlayerPrefs.GetInt(ShopItems.ShopItem.roadSpeeds.ToString());
        if (roadSpeed > 0)
        {
            kmIndexSpeed += roadSpeed * 2;
            //kmTraveled = (kmTraveled + Time.deltaTime * 2) + roadSpeed * 5;
        }
    }

    public bool CheckNewHigScore()
    {
        if ((int)kmTraveled > PlayerPrefs.GetInt(prefKm))
        {
            //new High score
            PlayerPrefs.SetInt(prefKm, (int)kmTraveled);

            Debug.Log("New Hight Score: " + (int)kmTraveled + "km") ;
            return true;
        }
        else
        {
            Debug.Log("No New Hight km :( ");
            return false;
        }
    }

    public float ReturnKmTraveler()
    {
        return (int)kmTraveled;
    }

}
