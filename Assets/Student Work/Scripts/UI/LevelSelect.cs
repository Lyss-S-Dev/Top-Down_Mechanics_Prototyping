using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    /// <summary>
    /// Call the load scene method from the scene loader
    /// </summary>
    /// <param name="sceneName">Name of the scene to load</param>
    public void SelectLevelToLoad(string sceneName)
    {
        AudioPlayer.Instance.PlayClipAtPosition("UI Button");
        SceneLoader.Instance.HandleLoadScene(sceneName);
    }
}
