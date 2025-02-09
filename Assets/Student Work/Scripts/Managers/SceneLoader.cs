using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private LoadingScreen loadingScreen;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        loadingScreen.ShowLoadingScreen();
        StartCoroutine(LoadAsyncScene(sceneNameToLoad));
    }
    
    private IEnumerator LoadAsyncScene(string sceneName)
    {
        //Arbitrary time so the loading screen is visible for more than a few frames
        yield return new WaitForSecondsRealtime(2f);

        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);
        
        while (!loadingScene.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        
        loadingScreen.HideLoadingScreen();
    }

    public void RestartCurrentScene()
    {
        HandleLoadScene(SceneManager.GetActiveScene().name);
    }
}
