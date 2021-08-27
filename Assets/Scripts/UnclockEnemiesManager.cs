using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnclockEnemiesManager : MonoBehaviour
{
    [SerializeField] private int yardsToBeAtToIncreaceDifficulty;
    private int previousKmMet;

    private void Update() 
    {
        int currentKm = (int)KmManager.Instance.kmTraveled;

        if (currentKm % yardsToBeAtToIncreaceDifficulty == 0 && currentKm != previousKmMet)
        {
            previousKmMet = currentKm; 
            GetMobManager.Instance.AddEnemy();
        }
    }
}
