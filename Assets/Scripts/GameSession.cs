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
        livesTxt.text = playerLives.ToString();
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
    public void ProcessPlayerDeath(bool loadScene, bool killedByBoss)
    {
        setLessLives();
        Debug.Log(playerLives + " " + killedByBoss);
        if (playerLives < 1 || killedByBoss)
        {
            playerLives = 1;
            setLessLives();
            GameOver();
        }
        else
        {
            if (!loadScene)
            {
                return;
            }
            TakeLife();
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
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);



    }

    public void setMoreLifes()
    {
        playerLives++;
        livesTxt.text = playerLives.ToString();
    }
    public void setLessLives()
    {

        playerLives--;
        livesTxt.text = playerLives.ToString();
    }

    private void GameOver()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f;
        gameRunning = false;
        /* ManageUiButtons(true); */

        FindObjectOfType<ScenePersist>().DestroyScenePersist();
    }

    public void ChangeGameRunningState(bool gameRunning)
    {
        this.gameRunning = gameRunning;
        AudioSource[] allAudios = FindObjectsOfType<AudioSource>();
        bool ban = this.gameRunning;
        ManageUiButtons(!ban);
        Time.timeScale = ban ? 1f : 0f;
        foreach (AudioSource audio in allAudios)
        {
            if (ban)
            {

                audio.Play();
            }
            else
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
        SceneManager.LoadScene(0);
        FindObjectOfType<ScenePersist>().DestroyScenePersist();
        Destroy(gameObject);

    }
    public void doRestartGame()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Destroy(gameObject);
    }
}
