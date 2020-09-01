using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Use this for initialization

    void LoadS()
    {
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }
}
