using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent agent;
    public Transform goal;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(goal.position);
    }
}