using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    private void Update()
    {
        if(Input.anyKey)
        {
            LoadScene("Game");
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
