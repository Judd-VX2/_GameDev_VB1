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

    [Header ("Bobbing Anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private bool bobbingUp;

    void start()
    {
      // set the start position
      startPos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch(type)
            {
                case Pickuptype.Health:
                    player.GiveHealth(value);
                    break;

                case Pickuptype.Ammo:
                player.GiveAmmo(value);
                break;
            }

            Destroy(gameObject);
        }
    }


    void Update()
    {
       //Rotating
       transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

       //Bob Up and Down
       Vector3 offset = (bobbingUp == true ? new Vector3(0,bobHeight / 2, 0) : new Vector3(0, -bobHeight /2, 0));
       transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

       if(transform.position == startPos + offset)
           bobbingUp = !bobbingUp;
    }
    
}