using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraGetWorldPoint m_cam;
    [SerializeField] PlayerMovement m_playerMovement;

    void Start()
    {
        m_cam.e_CameraPointClick.AddListener(m_playerMovement.MoveTo);
    }
}
