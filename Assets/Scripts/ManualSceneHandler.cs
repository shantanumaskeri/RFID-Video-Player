using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualSceneHandler : MonoBehaviour
{

    public void DoTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
