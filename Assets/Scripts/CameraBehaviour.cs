using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 pos = new Vector3();
    Vector3 newScale = new Vector3(1, 1, 1);

    void Update()
    {
        ChangePosition();
        Move();
        ScaleSpace();
    }

    void ChangePosition()
    {
        transform.position = target.position;
    }

    void Move()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        pos.x += x;
        pos.y += y;

        transform.rotation = Quaternion.Euler(pos.x, pos.y, 0.0f);
    }

    void ScaleSpace()
    {
        float s = 1;
        if (Input.GetKey(KeyCode.E)) s = 1.1f;
        else if (Input.GetKey(KeyCode.Q)) s = 0.9f;

        newScale *= s;

        transform.localScale = newScale;
    }
}
