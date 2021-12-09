using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public GameObject hitPartical;

    void OnEnable()
    {
       shootTime = Time.time;
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Create the hit particle effect 
        GameObject obj = Instantiate(hitPartical, transform.position, Quaternion.identity);
        //Destroy Hit Particle
        Destroy(obj, 0.5f);

        //Did we hit the target aka player 
        if(other.CompareTag("player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
         else 
           if(other.CompareTag("Enemy"))
               other.GetComponent<Enemy>().TakeDamage(damage);


        //Disable Bullet
        gameObject.SetActive(false);


    }

   // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
        gameobject.SetActive(false);
    }
}
