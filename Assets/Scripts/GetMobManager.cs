using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMobManager : MonoBehaviour
{
    public static GetMobManager Instance;
    

    [SerializeField] private int howManyEnemiesUnlocked;
    [SerializeField] private int howManyEnemiesUnclokedMax;

    [SerializeField] private GameObject [] entitiesPrefabs;


   private void Awake() 
   {
       Instance = this;
       howManyEnemiesUnclokedMax = entitiesPrefabs.Length - 2;
   }


   public GameObject GetMob()
   {
       return  entitiesPrefabs[Random.Range(0, 2 + howManyEnemiesUnlocked)];
   }

   public void AddEnemy()
   {
       if (howManyEnemiesUnlocked < howManyEnemiesUnclokedMax)
       {
           howManyEnemiesUnlocked++;
       }
   }
}
