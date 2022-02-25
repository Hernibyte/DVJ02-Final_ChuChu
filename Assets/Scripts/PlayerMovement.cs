using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask terrainMask;

    Vector3 endPosition;
    Transform m_start;

    void Start()
    {
        m_start = transform;
        endPosition = transform.position;
    }

    void Update()
    {
        PlaceTerrain();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void MoveTo(Vector3 position)
    {
        m_start = transform;
        endPosition = position;
    }

    void Move()
    {
        transform.position = Vector3.Lerp(m_start.position, endPosition, 0.1f);
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
