using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if (collision.CompareTag("Entity"))
       {
           Destroy(collision.gameObject);
       }
   }
}
