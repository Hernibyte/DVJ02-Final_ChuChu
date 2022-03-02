using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField] GameObject go_credits;

    void Start()
    {
        go_credits.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits(bool state)
    {
        go_credits.SetActive(state);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
