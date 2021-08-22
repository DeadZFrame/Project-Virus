using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityBot : MonoBehaviour
{
    public GameObject[] securityBots;
    public GameObject player;
    public Material[] materials;

    public float botSpeed = 4f, distance;
    private int detectionIndex, chaseIndex;

    private void Awake()
    {
        for(int i = 0; i<securityBots.Length; i++)
        {
            securityBots[i].AddComponent<Rigidbody>();
            securityBots[i].GetComponent<Rigidbody>().useGravity = false;
            securityBots[i].AddComponent<NavMeshAgent>();
            securityBots[i].AddComponent<Light>();
            securityBots[i].GetComponent<MeshRenderer>().sharedMaterial = materials[0];
        }
    }

    private void FixedUpdate()
    {
        Detection();
        Chase();
    }

    public void Detection()
    {
        while (detectionIndex < securityBots.Length)
        {
            distance = Vector3.Distance(securityBots[detectionIndex].transform.position, player.transform.position);
            detectionIndex++;
        }
        detectionIndex = 0;
        if(detectionIndex < 20f)
        {
            Debug.Log("In combat");
        }
    }

    public void Chase()
    {
        while(chaseIndex < securityBots.Length)
        {
            securityBots[chaseIndex].GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            securityBots[chaseIndex].GetComponent<NavMeshAgent>().speed = botSpeed;
            chaseIndex++;
        }
        chaseIndex = 0;
    }
}
