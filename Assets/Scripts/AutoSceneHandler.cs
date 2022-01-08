using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneHandler : MonoBehaviour
{

    public float timeInterval = 10.0f;
    public string nextScene;

    private void Start()
    {
        Invoke("DoTransition", timeInterval);
    }

    private void DoTransition()
    {
        SceneManager.LoadScene(nextScene);
    }

}
