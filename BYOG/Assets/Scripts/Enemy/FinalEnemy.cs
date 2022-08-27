using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class FinalEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigidbody;
    [SerializeField] private float Speed;

    [Foldout("Scene Related", true)]
    [SerializeField] private List<GameObject> Boulders;


}
