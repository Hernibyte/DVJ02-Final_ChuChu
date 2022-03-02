using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableSpawnManager : MonoBehaviour
{
    [SerializeField] int spawnAmount;
    [SerializeField] Vector2 minSpawnPosition;
    [SerializeField] Vector2 maxSpawnPosition;
    [SerializeField] GameObject pointSpawnPrefab;

    [HideInInspector] public UnityEvent noMorePoints = new UnityEvent();

    public int spawnPointCount;

    void Start()
    {
        SpawnPoints();
    }

    void SpawnPoints()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            CollectableBehaviour pb = Instantiate(pointSpawnPrefab, 
                new Vector3(
                    Random.Range(minSpawnPosition.x, maxSpawnPosition.x), 
                    0,
                    Random.Range(minSpawnPosition.y, maxSpawnPosition.y)), 
                Quaternion.identity, 
                transform).GetComponent<CollectableBehaviour>();
            pb.e_die.AddListener(RestCount);
            spawnPointCount++;
        }
    }

    void RestCount()
    {
        spawnPointCount--;
        if (spawnPointCount <= 0)
        {
            noMorePoints?.Invoke();
        }
    }
}
