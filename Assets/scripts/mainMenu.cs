using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Main : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync (2);
    }

     public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

        public void OptionsMenu()
    {
        SceneManager.LoadSceneAsync (1);
    }}
