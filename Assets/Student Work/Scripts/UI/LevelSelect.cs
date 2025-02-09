using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void SelectLevelToLoad(string sceneName)
    {
        AudioPlayer.Instance.PlayClipAtPosition("UI Button");
        SceneLoader.Instance.HandleLoadScene(sceneName);
    }
}
