using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerPathFinding : MonoBehaviour
{
   public Vector3 FinalDestination;
    public CinemachineDollyCart Cart;
    //float PathLength;

    private void Start()
    {
      //  StartPos = transform.position;
        //PathLength = Cart.m_Path.PathLength;
    }

    private void Update()
    {
        Cart.m_Position = Vector3.Distance(transform.position, FinalDestination);
    }
}
