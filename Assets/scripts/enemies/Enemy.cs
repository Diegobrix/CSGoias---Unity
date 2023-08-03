using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IShot
{
    public AIStateMachine stateMachine;
    public EnemyPath enemyPatrolPath;
    private NavMeshAgent meshAgent;
    public NavMeshAgent MeshAgent { get => meshAgent; }

    private string currentState;
    public float maxEnemyLife;
    private float currentEnemyLife;

    private void Awake() {
        maxEnemyLife = 30f;
        currentEnemyLife = maxEnemyLife;
        meshAgent = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<AIStateMachine>();

        stateMachine.Init();
    }

    public void Hit(Vector3 direction, float damage)
    {
        GetShotted(direction, damage);
    }

    private void GetShotted(Vector3 shotOrigin, float gunDamage)
    {
        Debug.Log("Ai Papai");
        if(gunDamage >= currentEnemyLife)
        {
            Destroy(gameObject);
            return;
        }

        currentEnemyLife -= gunDamage;
    }
}
