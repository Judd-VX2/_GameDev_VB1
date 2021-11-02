using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string pickupName;

    public int amount;

    public GameManager gameManager;

    void OnTriggerEnter2D(collider2D other)
    {
     if(other.CompareTag("player"))
     {
         print("You've picked up a"+ pickupname);
         gameManager.haskey = true;
         Destroy(gameObject)
     }
    }
}

