using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraGetWorldPoint m_cam;
    [SerializeField] PlayerMovement m_playerMovement;
    [SerializeField] PlayerStats m_playerStats;
    [SerializeField] UIManager uIManager;
    [SerializeField] PointSpawnManager m_pointSpawnManager;
    [SerializeField] float gameDurationTime;

    Timer timer = new Timer();
    bool playing = true;


    void Start()
    {
        m_cam.e_CameraPointClick.AddListener(m_playerMovement.MoveTo);
        uIManager.ChangeHiddenEndGamePanel(false);
        m_pointSpawnManager.noMorePoints.AddListener(EndGameWithPointCount);
    }

    void Update()
    {
        if (playing)
        {
            uIManager.ChangeTimeText(timer.time);
            uIManager.ChangePointsT(m_playerStats.points);
            if (timer.CalcTime(gameDurationTime))
            {
                EndGame();
            }
        }
    }

    void EndGameWithPointCount()
    {
        uIManager.ChangeHiddenEndGamePanel(true);
        uIManager.ChangeHiddenInGamePanel(false);
        uIManager.ChangeHiddenTimeOut(false);
        uIManager.ChangeHiddenMaxPoints(true);
        uIManager.ChangeEndGamePointsCount(m_playerStats.points);

        m_cam.isPlaying = false;
        playing = false;
    }

    void EndGame()
    {
        uIManager.ChangeHiddenEndGamePanel(true);
        uIManager.ChangeHiddenInGamePanel(false);
        uIManager.ChangeHiddenMaxPoints(false);
        uIManager.ChangeEndGamePointsCount(m_playerStats.points);

        m_cam.isPlaying = false;
        playing = false;
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
