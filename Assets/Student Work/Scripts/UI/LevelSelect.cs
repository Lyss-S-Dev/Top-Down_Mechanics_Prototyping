using UnityEngine;


public class LevelSelect : MonoBehaviour
{
    public void SelectLevelToLoad(string sceneName)
    {
        SceneLoader.instance.HandleLoadScene(sceneName);
    }
}
