using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask terrainMask;

    Vector3 endPosition = new Vector3();
    Vector3 m_start = new Vector3();
    bool isMoving = false;
    Timer timer = new Timer();

    void Start()
    {
        m_start = transform.position;
        endPosition = transform.position;
    }

    void Update()
    {
        PlaceTerrain();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
            if (timer.CalcFixedTime(1))
                isMoving = false;
        }
    }

    public void MoveTo(Vector3 position)
    {
        if (!isMoving)
        {
            endPosition = position;
            m_start = transform.position;
            isMoving = true;
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(m_start, endPosition, timer.time);
    }

    void PlaceTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 50, terrainMask))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + (transform.localScale.y / 2), hit.point.z);
        }
    }
}
