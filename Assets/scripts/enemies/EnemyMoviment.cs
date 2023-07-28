using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoviment : MonoBehaviour
{
    private NavMeshAgent enemyNavMesh;
    [SerializeField] private float minDistanceToPlayer; 
    public Transform player;
    private float rotationSpeed = 5f;
    
    void Awake()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
        enemyNavMesh.updateRotation = false;

        minDistanceToPlayer = 5f;
        enemyNavMesh.stoppingDistance = minDistanceToPlayer;
    }

    void Update()
    {
        enemyNavMesh.SetDestination(player.position);
        SetEnemyRotation();
    }

    private void SetEnemyRotation()
    {
        Vector3 playerDirection = transform.position - player.position;
        playerDirection.y = 0f;

        if(playerDirection != Vector3.zero)
        {
            Quaternion enemyTargetRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, enemyTargetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
