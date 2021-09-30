using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D 
    {
        if(other.CompareTag("player") && gameManager.hasKey)
        {
            print("you have unlocked the door!");
            gameManager.isDoorLockcked = false;
        }
        else
        {
            print("The door is locked! you cannot exit this place!hahahahahah");
        }
  
}
