using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Entity"))
        {
            if (collision.GetComponent<EntityType>().entityType == EntityType.EntityTypes.booty)
            {
                CarMoney.Instance.AddMoney(1);                
                Destroy(collision.gameObject);  //Sunaikinam KRUMUS("Booty")
            }
            else
            {
                FinishGameManager.Instance.FinishGame();
            }

            // switch (collision.GetComponent<EntityType>().entityType)
            // {
            //     case EntityType.EntityTypes.booty:
            //     //add score
            //     break;

            //     case EntityType.EntityTypes.rock:
            //     //lose                
            //     break;
            // }
            
        }
    }
}
