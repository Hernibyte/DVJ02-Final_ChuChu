using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 position;

    void Awake()
    {
        ChangePosition();
    }

    void Update()
    {
        LookAt();
    }

    void LookAt()
    {
        transform.LookAt(target);
    }

    void ChangePosition()
    {
        transform.position = position;
    }
}
