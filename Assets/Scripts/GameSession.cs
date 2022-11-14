using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
/* Solo una game session */
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 1;
    [SerializeField] TextMeshProUGUI livesTxt;
    [SerializeField] TextMeshProUGUI pauseTxt;
    [SerializeField] bool gameRunning = true;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        livesTxt.text = playerLives.ToString();
        pauseTxt.enabled=false;
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState(!gameRunning);
        }
    }
    void TakeLife()
    {
        playerLives--;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
        livesTxt.text = playerLives.ToString();

    }
    public void setMoreLifes()
    {
        playerLives++;
        livesTxt.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ChangeGameRunningState(bool gameRunning)
    {
        this.gameRunning = gameRunning;
        AudioSource[] allAudios = FindObjectsOfType<AudioSource>();
        if (this.gameRunning)
        {
            //Game running
            Time.timeScale = 1f;
            pauseTxt.enabled=false;
            foreach (AudioSource audio in allAudios)
            {
                audio.Play();
            }
        }
        else
        {
            //Game paused
            pauseTxt.enabled=true;
            Time.timeScale = 0f;
            foreach (AudioSource audio in allAudios)
            {
                audio.Pause();
            }
        }
    }
    public void onClickPauseBtn(){
        ChangeGameRunningState(!gameRunning);
    }
    public bool GetGameRunning()
    {
        return gameRunning;
    }
}
