using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public camerafollow tank;

    private Vector3 Offset = new Vector3(0,25,-50);

   
    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + offset;
    }
}
