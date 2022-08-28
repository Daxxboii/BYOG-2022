using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MyBox;
using UnityTutorial.PlayerControl;
using EZCameraShake;

public class EvilSuda : MonoBehaviour
{
    public Animator Animator;
    public float Cooldown_Period;
    public NavMeshAgent agent;
    public GameObject Player;
    public float AttackDistance;
    public float MaxDistanceForWarping;
    public float FickerDistance;

    public SkinnedMeshRenderer[] Renderers;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerController.Defended += OnDefend;
       // InvokeRepeating("Flicker", 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Vector3.Distance(Player.transform.position, transform.position) );
        agent.SetDestination(Player.transform.position);

        if (Vector3.Distance(Player.transform.position, transform.position) < AttackDistance)
        {
            Interactions.instance.Die();
        }
        if (Vector3.Distance(Player.transform.position, transform.position) < FickerDistance) CameraShaker.Instance.ShakeOnce(100, 100,0.1f,0.1f);

    }

    void OnDefend()
    {
       
            if (Vector3.Distance(Player.transform.position, transform.position) < FickerDistance) agent.Warp(GetRandomPoint(transform.position, MaxDistanceForWarping));
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;

        NavMeshHit hit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);

        return hit.position;
    }

    void Flicker()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < FickerDistance)
        {
            bool Random = randomBoolean();
           foreach(SkinnedMeshRenderer r in Renderers)
            {
                r.enabled = Random;
            }
        }
    }

    bool randomBoolean()
    {
    if (Random.Range(0.1f,1f) >= 0.5)
    {
        return true;
    }
    return false;
    }
}
