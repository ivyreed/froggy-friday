using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Main : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync (1);
    }

}
