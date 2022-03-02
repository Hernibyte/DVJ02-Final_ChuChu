using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] LayerMask pointMask;

    PlayerStats stats;
    
    
    void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (MyMask.Contains(pointMask, col.gameObject.layer))
        {
            CollectableBehaviour pb = col.GetComponent<CollectableBehaviour>();
            stats.points += pb.pointCount;
            pb.e_die?.Invoke();
            Destroy(pb.gameObject);
        }
    }
}
