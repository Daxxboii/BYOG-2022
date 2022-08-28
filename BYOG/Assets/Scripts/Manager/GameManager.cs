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
        if (instance == null) instance = this;
    }

    public void LoadScene(string SceneName){
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadSceneAsync(SceneIndex);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneIndex = scene.buildIndex;
    }

}
