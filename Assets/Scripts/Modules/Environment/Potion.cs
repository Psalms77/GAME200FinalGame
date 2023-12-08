using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Observer
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) { 
            
            
            EventManager.SendNotification(EventName.PotionCollected); 

            Debug.Log("Potion Collected");
            Destroy(this.gameObject);
        }
    }

}
