using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] LayerMask pointMask;

    void OnTriggerEnter(Collider col)
    {
        if (MyMask.Contains(pointMask, col.gameObject.layer))
        {
            PointBehaviour pb = col.GetComponent<PointBehaviour>();
            stats.points += pb.pointCount;
            pb.e_die?.Invoke();
            Destroy(pb.gameObject);
        }
    }
}
