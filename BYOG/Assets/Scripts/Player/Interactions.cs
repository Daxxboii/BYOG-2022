using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTutorial.PlayerControl;
using MyBox;

public class Interactions : MonoBehaviour
{
    [SerializeField,ReadOnly]private PlayerController _PlayerController;
    [SerializeField, Range(1f, 10f)] private float Range;
    [SerializeField] private LayerMask Layermask;

    [Foldout("Buttons")]
    [SerializeField] private GameObject InteractHandle;

    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(_PlayerController.Cam.position, _PlayerController.Cam.transform.TransformDirection(Vector3.forward));
        if(Physics.Raycast(ray,out hit,Range, Layermask))
        {
            InteractHandle.SetActive(true);
        }
        else
        {
            InteractHandle.SetActive(false);
        }
    }
}
