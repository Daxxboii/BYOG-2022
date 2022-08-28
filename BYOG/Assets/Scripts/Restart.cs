using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    public delegate void _Restart();
    public static _Restart restart; 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            restart.Invoke();
           //
            Destroy(this);
        }
    }
}
