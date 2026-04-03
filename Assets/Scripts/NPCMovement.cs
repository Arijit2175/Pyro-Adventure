using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float waitTime = 2f;

    private bool movingForward = true;
    private float waitTimer = 0;
    private int currentWaypoint = 0;
    private NavMeshAgent agent;
    private Animator animator;
    private bool HasWaypoints => waypoints != null && waypoints.Length > 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (HasWaypoints)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
        else
        {
            agent.ResetPath();
            agent.isStopped = true;
        }
    }

    void Update()
    {
        if (!HasWaypoints)
        {
            if (animator != null)
            {
                animator.SetFloat("Speed", 0f);
            }
            return;
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > waitTime)
            {
                waitTimer = 0;
                GoToNextWaypoint();
            }
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    void GoToNextWaypoint()
    {
        if (!HasWaypoints)
        {
            return;
        }

        if (movingForward)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = waypoints.Length - 1;
                movingForward = false;
            }
        }
        else
        {
            currentWaypoint--;
            if (currentWaypoint < 0)
            {
                currentWaypoint = 1;
                movingForward = true;
            }
        }

        agent.SetDestination(waypoints[currentWaypoint].position);
    }
}