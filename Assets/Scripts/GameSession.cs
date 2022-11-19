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
    [SerializeField] TextMeshProUGUI continueTxt;
    [SerializeField] GameObject btnReturn;
    [SerializeField] GameObject btnStart;
    [SerializeField] bool gameRunning = true;
    [SerializeField] Canvas gameOverCanvas;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            gameRunning = true;
            DontDestroyOnLoad(gameObject);
        }
    }
    void ManageUiButtons(bool ban)
    {
        btnReturn.SetActive(ban);
        btnStart.SetActive(ban);
        pauseTxt.enabled = ban;
        continueTxt.enabled = ban;
    }
    private void Start()
    {
        livesTxt.text = playerLives.ToString();
        gameOverCanvas.enabled = false;
        ManageUiButtons(false);
        ChangeGameRunningState(true);
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            playerLives--;
            livesTxt.text = playerLives.ToString();
            GameOver();
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

    private void GameOver()
    {
        gameOverCanvas.enabled = true;
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        /* SceneManager.LoadScene(0);
        Destroy(gameObject); */
    }
    public void ChangeGameRunningState(bool gameRunning)
    {
        this.gameRunning = gameRunning;
        AudioSource[] allAudios = FindObjectsOfType<AudioSource>();
        if (this.gameRunning)
        {
            //Game running
            Time.timeScale = 1f;
            ManageUiButtons(false);
            foreach (AudioSource audio in allAudios)
            {
                audio.Play();
            }
        }
        else
        {
            //Game paused
            ManageUiButtons(true);
            Time.timeScale = 0f;
            foreach (AudioSource audio in allAudios)
            {
                audio.Pause();
            }
        }
    }
    public void onClickPauseBtn()
    {
        ChangeGameRunningState(!gameRunning);
    }
    public bool GetGameRunning()
    {
        return gameRunning;
    }
    public void doExitGame()
    {
        Destroy(gameObject);
        Application.Quit();

    }
    public void doReturnToMenu()
    {
        Destroy(gameObject);
        // GameOver();
        SceneManager.LoadScene(0);

    }
    public void doRestartGame()
    {
     
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }
}
