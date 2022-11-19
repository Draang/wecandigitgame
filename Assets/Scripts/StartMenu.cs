using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }
    public void doExitGame()
    {
        Destroy(gameObject);
        Application.Quit();
    }
}
