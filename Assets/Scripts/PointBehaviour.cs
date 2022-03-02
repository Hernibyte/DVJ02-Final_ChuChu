using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask pointMask;
    [SerializeField] LayerMask terrainMask;

    [HideInInspector] public UnityEvent e_die = new UnityEvent();

    public int pointCount = 0;

    Vector3 raycastPointPostition;


    void Start()
    {
        raycastPointPostition = transform.position + new Vector3(0, 100, 0);
        PlaceTerrain();
    }

    void PlaceTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPointPostition, Vector3.down, out hit, 500, terrainMask))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y + (transform.localScale.y), hit.point.z);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (MyMask.Contains(pointMask, col.gameObject.layer))
        {
            e_die?.Invoke();
            Destroy(gameObject);
        }
    }
}
