using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    //public event EventHandler NewSceneIsLoading;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
        
        
    }

    public void HandleLoadScene(string sceneNameToLoad)
    {
        Debug.Log("WE ARE GOING TO LOAD A SCENE");
        
        StartCoroutine(LoadAsyncScene(sceneNameToLoad));
    }



    private IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);
        
        //you can put a loading screen here

        while (!loadingScene.isDone)
        {
            yield return null;
        }
    }

    public void RestartCurrentScene()
    {
        HandleLoadScene(SceneManager.GetActiveScene().name);
    }
}
