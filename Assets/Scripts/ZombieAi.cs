using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Kino;

public class ZombieAi : MonoBehaviour
{
    public AnalogGlitch analogGlitch;
    NavMeshAgent nav;
    Animator anim;
    public Transform target;
    public Transform player;
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
            yield return new WaitForSeconds(3);
            if (RandomPoint(transform.position, range, out point))
            {
                target.transform.position = point;
            }
            nav.SetDestination(target.position);
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
            nav.speed = 2.5f;
            target.position = player.position;
            analogGlitch.scanLineJitter = .3f;
            analogGlitch.colorDrift = .1f;
        });

        EventManager.instance.AddEvent("PlayerOutZombieArea", p =>
        {
            isFollowingPlayer = false;
            anim.SetBool("isFollowingPlayer", false);
            nav.speed = 2f;
            EventManager.instance.SendEvent("EnabledCrossSfx");
            analogGlitch.scanLineJitter = 0f;
            analogGlitch.colorDrift = 0f;
        });
    }

    private void Update()
    {
        nav.SetDestination(target.position);
    }
}
