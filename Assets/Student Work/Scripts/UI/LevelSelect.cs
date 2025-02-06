using UnityEngine;


public class LevelSelect : MonoBehaviour
{
    public void SelectLevelToLoad(string sceneName)
    {
        AudioPlayer.instance.PlayClipAtPosition("UI Button");
        SceneLoader.instance.HandleLoadScene(sceneName);
    }
}
