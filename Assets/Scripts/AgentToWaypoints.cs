using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class AgentToWaypoints : MonoBehaviour
{
    #region Variables

    [SerializeField] private float agentSpeed = 5;
    [SerializeField] private Transform waypointsParent;
    private List<Transform> waypoints = new List<Transform>();
    private int numberOfWaypoints;
    private float reachDistance = 0.5f;
    private int currentIndex;

    private NavMeshAgent agent;

    #endregion

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        numberOfWaypoints = waypointsParent.childCount;
        currentIndex = 0;

        for (int i = 0; i < numberOfWaypoints; i++)
        {
            waypoints.Add(waypointsParent.GetChild(i));
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentIndex].transform.position) <= reachDistance && currentIndex < numberOfWaypoints - 1)
        {
            currentIndex++;
        }
        
        MoveToWaypoint(waypoints[currentIndex]);
    }

    private void MoveToWaypoint(Transform transform)
    {
        agent.speed = agentSpeed;
        agent.SetDestination(transform.position);
        //agent.destination = transform.position;
    }
}
