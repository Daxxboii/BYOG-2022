using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [ReadOnly]public int SceneIndex;

    public void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int Index){
        SceneManager.LoadSceneAsync(Index);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneIndex = scene.buildIndex;
    }

}
