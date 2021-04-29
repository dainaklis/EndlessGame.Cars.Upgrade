using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public static SpawnManager Instance;
    [SerializeField] private bool canSpawn;

    [SerializeField] private GameObject [] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float xMargin = 2;
    [SerializeField] private float spawnTimer = 2;
    

    [Header("LEVEL REIKSMES/ Scaling Values")]
    [SerializeField] private float scalingMultiplier = 1.0001f;
    [SerializeField] private float spawnTimerMax ;  
    [SerializeField] private float scaledSpawnTimerMax ;
    [SerializeField] private float entitiesSpeed ;
    [SerializeField] private float scaledEntitiesSpeed;
    private bool maxVelocityReached;


    private void Awake() 
    {
       Instance = this;

       scaledEntitiesSpeed = spawnTimerMax / scaledSpawnTimerMax * entitiesSpeed;
       
    }

    
    private void Update()
    {
        if (!canSpawn)
        {
            return;
        }

        //InscreaseSpeed();
        TrySpawn();
    }

    //--------------------METODAI----------------------------+---------------------------------

    private void TrySpawn()
    {

        
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            SpawnEntity();

        }
    }
    public void StartScript()
    {
        canSpawn = true;
        spawnTimer = spawnTimerMax;


        //Kai Perkam Upgrade padideja greitis SPAWN
        int placeHolders = PlayerPrefs.GetInt(ShopItems.ShopItem.placeHolder.ToString());
        if (placeHolders > 0)
        {
            entitiesSpeed += placeHolders * 2;
        }
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = GetMobManager.Instance.GetMob();
        spawnPosition.x = Random.Range(-xMargin, xMargin);

        GameObject spawnEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
        spawnEntity.GetComponent<Rigidbody2D>().velocity = new  Vector2(0, -entitiesSpeed);
    }

    private void InscreaseSpeed()
    {
        if (maxVelocityReached || Time.frameCount % 5 != 0 ||Time.timeScale == 0)
        {
            return;
        }


        if (spawnTimerMax > scaledSpawnTimerMax)
        {
            spawnTimerMax /= scalingMultiplier;
        }
        else
        {
            spawnTimerMax = scaledSpawnTimerMax;
        }

        if (entitiesSpeed < scaledEntitiesSpeed)
        {
            entitiesSpeed *= scalingMultiplier;
        }
        else
        {
            entitiesSpeed = scaledEntitiesSpeed;
        }
        if (spawnTimerMax == scaledSpawnTimerMax && entitiesSpeed == scaledEntitiesSpeed)
        {
            maxVelocityReached = true;
        }

        GameObject[] entitiesInGame = GameObject.FindGameObjectsWithTag("Entity");
        foreach (GameObject e in entitiesInGame)
        {   
            if (e.GetComponent<Rigidbody2D>() != null)
            {
                e.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
            }
            
        }
    }


}
