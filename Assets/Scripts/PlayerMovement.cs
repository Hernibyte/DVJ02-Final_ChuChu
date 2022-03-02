using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask terrainMask;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxDistanceToPoint;

    Vector3 endPosition = new Vector3();
    Vector3 m_start = new Vector3();
    bool isMoving = false;

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
            if (Vector3.Distance(transform.position, endPosition) < maxDistanceToPoint)
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
        transform.Translate(Vector3.forward * movementSpeed);
        
        Vector3 tDir = endPosition - transform.position;
        float singleStep = rotationSpeed * Time.fixedDeltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, tDir, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void PlaceTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 100, 0), Vector3.down, out hit, 500, terrainMask))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + (transform.localScale.y / 2), hit.point.z);
        }
    }
}
