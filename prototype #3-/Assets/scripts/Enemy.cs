using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.LIng;

public class Enemy : MonoBehaviour
{

    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    [Header ("Movement")]
    public float moveSpeed;
    public float attackRange;

    public float yPathOffset;


    private List<Vector3> path;

    private Weapons weapon;
    private GameObject target;

   // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;

        // Gather the Compnents 
        weapon = GetComponent<Weapon>();
        target = FindObjectType<playerController>().gameObject;

        InvokeRepeating("UpdatePath",0.0f, 0.5f);
    }

    void UpdatePath()
    {
        // Calculate a path to the target
        NavMeshPath navmeshPath = new NavMeshPath();
        NavMeshPath.Calculatepath (transform.position, transform.Posiyion. NaveMesth.AllAreas, naveMeshPath );

        // Save path to the list 
        path = navMeshPath.TOList();
        
        void ChaseTarget()
        [
            if(path.Count == 0)
                return;

                // Move towards the closest path
                transform.position = Vector3.move
        ]
    }































    // Update is called oce per frame
    void Update()
    {
        // Look at target 
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad20eg;

        transform.eulerAngles = Vector3.up * angle;

      // Get distance from enemy to player/target
      float dist = Vector3.Distance 
    }
}

