using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{

    // void Update()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         StartGame();
    //     }
    // }

    public void StartGame()
    {
        RoadMove.Ikeliam.StartRoadScript();

        SpawnManager.Instance.StartScript();        

        KmManager.Instance.StartScript();
        
        CarsMovement.Instance.StartMoveScript();

        enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
