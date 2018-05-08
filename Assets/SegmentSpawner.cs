using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject segmentPrefab;
    [SerializeField] private Transform player;

    private float nextPositionToSpawn, nextDistanceToSpawnAt;
    private Queue<GameObject> segments;

    private void Start()
    {
        nextPositionToSpawn = 60.0f;
        nextDistanceToSpawnAt = player.transform.position.z + 10.0f;
        segments = new Queue<GameObject>();
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, -20.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, -10.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, 10.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, 20.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, 30.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, 40.0f), Quaternion.identity));
        segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, 50.0f), Quaternion.identity));
    }

    private void Update()
    {
        if(player.transform.position.z >= nextDistanceToSpawnAt)
        {
            nextDistanceToSpawnAt += 10.0f;
            segments.Enqueue(Instantiate(segmentPrefab, new Vector3(0.0f, 0.0f, nextPositionToSpawn), Quaternion.identity));
            nextPositionToSpawn += 10.0f;
            Destroy(segments.Dequeue());
        }
    }

    public void DestroyAllSegments()
    {
        for(int i = 0; i < segments.Count; i++)
        {
            Destroy(segments.Dequeue());
        }
    }
}
