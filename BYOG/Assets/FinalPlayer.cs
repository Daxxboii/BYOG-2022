using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinalPlayer : MonoBehaviour
{
    public VideoPlayer VP;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            VP.Play();
        }
    }
}
