using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGetWorldPoint : MonoBehaviour
{
    [SerializeField] LayerMask terrainMask;
    public CameraEvent e_CameraPointClick = new CameraEvent();
    public bool isPlaying = true;

    Camera cam;


    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 10000, Color.yellow);

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0) && isPlaying)
        {
            if (Physics.Raycast(ray, out hit, 10000, terrainMask))
            {
                e_CameraPointClick?.Invoke(hit.point);
            }
        }
    }
}
