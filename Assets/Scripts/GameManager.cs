using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraGetWorldPoint cam;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] UIManager uIManager;
    [SerializeField] CollectableSpawnManager collectableSpawnManager;
    [SerializeField] float gameDurationTime;

    Timer timer = new Timer();
    bool playing = true;


    void Start()
    {
        cam.e_CameraPointClick.AddListener(playerMovement.MoveTo);
        collectableSpawnManager.noMorePoints.AddListener(EndGameWithPointCount);

        uIManager.ChangeHiddenPause(false);
        uIManager.ChangeHiddenEndGamePanel(false);
    }

    void Update()
    {
        if (playing)
        {
            uIManager.ChangeTimeText(timer.time);
            uIManager.ChangePointsText(playerStats.points);
            if (timer.CalcTime(gameDurationTime))
            {
                EndGameWithoutPointCount();
            }
        }
    }

    void EndGameWithPointCount()
    {
        uIManager.ChangeHiddenEndGamePanel(true);
        uIManager.ChangeHiddenInGamePanel(false);
        uIManager.ChangeHiddenTimeOut(false);
        uIManager.ChangeHiddenMaxPoints(true);
        uIManager.ChangeEndGamePointsCount(playerStats.points);

        cam.isPlaying = false;
        playing = false;
    }

    void EndGameWithoutPointCount()
    {
        uIManager.ChangeHiddenEndGamePanel(true);
        uIManager.ChangeHiddenInGamePanel(false);
        uIManager.ChangeHiddenMaxPoints(false);
        uIManager.ChangeEndGamePointsCount(playerStats.points);

        cam.isPlaying = false;
        playing = false;
    }

    public void Pause()
    {
        uIManager.ChangeHiddenPause(true);
        Time.timeScale = 0;
        cam.isPlaying = false;
    }

    public void Continue()
    {
        uIManager.ChangeHiddenPause(false);
        Time.timeScale = 1;
        cam.isPlaying = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
