using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject inGamePanel;
    [SerializeField] Text t_Time;
    [SerializeField] Text t_Points;

    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text t_endGamePointsCount;
    [SerializeField] Text t_TimeOut;
    [SerializeField] Text t_maxPoints;


    public void ChangeHiddenInGamePanel(bool hide)
    {
        inGamePanel.SetActive(hide);
    }

    public void ChangeTimeText(float time)
    {
        t_Time.text = "TIME: " + Mathf.Round(time);
    }

    public void ChangePointsT(int points)
    {
        t_Points.text = "POINTS: " + points;
    }

    public void ChangeHiddenEndGamePanel(bool hide)
    {
        endGamePanel.SetActive(hide);
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
}
