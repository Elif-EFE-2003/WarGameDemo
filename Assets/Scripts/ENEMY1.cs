using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY1 : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent Agent;
    public GameObject targetPos;
    public int targetIndex;
    public List<GameObject> patrolPoints;
    public int hp;
    void Start()
    {
        Agent=GetComponent<NavMeshAgent>();
        targetIndex=0;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position)<20){
           Agent.SetDestination(player.transform.position);
        }else{
            Agent.SetDestination(patrolPoints[targetIndex].transform.position);
            float distanceToTargetPosition=Vector3.Distance(transform.position,patrolPoints[targetIndex].transform.position);
            if(distanceToTargetPosition<3){
            targetIndex++;
            if(targetIndex==patrolPoints.Count){
                targetIndex=0;
            }
        }
        }
        

    }
}
