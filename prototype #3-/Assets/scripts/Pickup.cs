using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pickuptype         
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public Pickuptype type;
    public int value;

    // Start is called before the first frame update
    void start()
    {

    }

    // Update is called once per frame
    void update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            Player PlayerController = other.GetComponent<PlayerController>();

            switch(type)
            {
                case Pickuptype.Health:
                    Player.GiveHealth(value);
                    break;
                case Pickuptype.Ammo:
                    Player.GiveAmmo(value);
                    break;
            }

            Destroy(gameObject);
        }
    }
}