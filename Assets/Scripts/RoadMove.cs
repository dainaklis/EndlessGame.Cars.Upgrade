using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public static RoadMove Ikeliam;


    //VEIKIA Hooson 2d Endles Runner For beginers.....
    [SerializeField] private float speedRoad;
    [SerializeField] Renderer BGRendered;
    [SerializeField] private bool canRoad = false;


    //-----------------------------------------------------------------

    private void Awake() 
    {
       Ikeliam = this;

    }
    
    private void Update() 
    {
        TryRoadMove();
    }

    //------------------------------------------------------------------
    public void StartRoadScript()
    {
        canRoad = true;


        //KAI PERKI UPDATE PADIDEJA SPEDD KELIO
        int roadSpeed = PlayerPrefs.GetInt(ShopItems.ShopItem.roadSpeeds.ToString());

        if (roadSpeed > 0)
        {
            speedRoad += roadSpeed * 1;
        }
    }

    private void TryRoadMove()
    {
        if (canRoad)
        {
           BGRendered.material.mainTextureOffset += new Vector2(speedRoad * Time.deltaTime, 0f); 
        }
        
    }



}
