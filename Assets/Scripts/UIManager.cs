using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject go_InGamePanel;
    [SerializeField] Text t_Time;
    [SerializeField] Text t_Points;

    [SerializeField] GameObject go_EndGamePanel;
    [SerializeField] Text t_endGamePointsCount;
    [SerializeField] Text t_TimeOut;
    [SerializeField] Text t_maxPoints;

    [SerializeField] GameObject go_PausePanel;


    public void ChangeHiddenInGamePanel(bool hide)
    {
        go_InGamePanel.SetActive(hide);
    }

    public void ChangeTimeText(float time)
    {
        t_Time.text = "TIME: " + Mathf.Round(time);
    }

    public void ChangePointsText(int points)
    {
        t_Points.text = "POINTS: " + points;
    }

    public void ChangeHiddenEndGamePanel(bool hide)
    {
        go_EndGamePanel.SetActive(hide);
    }

    public void ChangeEndGamePointsCount(int points)
    {
        t_endGamePointsCount.text = points.ToString();
    }

    public void ChangeHiddenTimeOut(bool hide)
    {
        t_TimeOut.gameObject.SetActive(hide);
    }

    public void ChangeHiddenMaxPoints(bool hide)
    {
        t_maxPoints.gameObject.SetActive(hide);
    }

    public void ChangeHiddenPause(bool hide)
    {
        go_PausePanel.SetActive(hide);
    }
}
