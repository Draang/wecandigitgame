using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlExit : MonoBehaviour
{
    float levelLoadDelay = 0.5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLvl = currentSceneIndex + 1;
        if (nextLvl == SceneManager.sceneCountInBuildSettings)
        {
            nextLvl = 0;
        }
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(nextLvl);
    }
}
