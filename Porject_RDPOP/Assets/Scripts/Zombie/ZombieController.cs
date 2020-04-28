using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController: MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent nav;
    Transform player;

    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() => nav.SetDestination(player.position);
}
