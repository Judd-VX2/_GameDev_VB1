using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject tank;

    private Vector3 offset = new Vector3(0,25,-170);

   
    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + offset;
    }
}
