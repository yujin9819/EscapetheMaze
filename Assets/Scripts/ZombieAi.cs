using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ZombieAi : MonoBehaviour
{
    NavMeshAgent nav;
    Animator anim;
    public Transform target;
    public Transform player;
    public float dirChangeInterval; // 방향전환 빈도
    public bool isFollowingPlayer;
    
    Vector3 point;
    public float range = 10;

    private void Start()
    {
        Evnets();
        StartCoroutine(ZombieRndMove());
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private IEnumerator ZombieRndMove()
    {
        while (!isFollowingPlayer)
        {
            yield return new WaitForSeconds(5);
            if (RandomPoint(target.transform.position, range, out point))
            {
                target.transform.position = point;
            }
            nav.SetDestination(target.transform.position);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    private void Evnets()
    {
        EventManager.instance.AddEvent("PlayerInZombieArea", p =>
        {
            isFollowingPlayer = true;
            anim.SetBool("isFollowingPlayer", true);
            nav.speed = 3f;
            nav.SetDestination(player.position);
            StopCoroutine(ZombieRndMove());
        });
        EventManager.instance.AddEvent("PlayerOutZombieArea", p =>
        {
            isFollowingPlayer = false;
            anim.SetBool("isFollowingPlayer", false);
            nav.speed = .5f;
            nav.SetDestination(player.position);
            StartCoroutine(ZombieRndMove());
        });
    }
}
