using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Vector3 initialPlayerPosition;
    private bool hasPlayerMoved;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (player != null)
        {
            hasPlayerMoved = false;
            initialPlayerPosition = player.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (!hasPlayerMoved && initialPlayerPosition != player.position)
            {
                hasPlayerMoved = true;
            }

            if (hasPlayerMoved)
            {
                navMeshAgent.SetDestination(player.position);
            }
            
        }

    }
}
