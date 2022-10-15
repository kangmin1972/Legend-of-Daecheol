using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BookAI_follow : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform Player;

    public LayerMask playerlayer;

    public Vector3 spawnpoint;

    public Vector3 walkpoint;
    public bool walkpointset;
    public float walkpointrange;

    public float sightrange;
    public LayerMask groundlayer;
    public bool playerinsightrange;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        spawnpoint = gameObject.transform.position;
    }

    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, playerlayer);

        if (!playerinsightrange)
        {
            MoveAround();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void MoveAround()
    {
        agent.SetDestination(spawnpoint);
    }

    private void searchwalkpoint()
    {
        float z = Random.Range(-walkpointrange, walkpointrange);
        float x = Random.Range(-walkpointrange, walkpointrange);

        walkpoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        
        walkpointset = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(Player.position);
    }
}
