using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private float spawnChance;
    [SerializeField] private Transform[] itemTransforms;
    [SerializeField] private GameObject[] itemPrefabs;

    private void Start()
    {
        SpawnItems();
    }



    private void SpawnItems()
    {
        foreach(Transform itemTransform in itemTransforms)
        {
            float chance = Random.Range(0.0f, 100.0f);
            if(chance <= spawnChance)
            {
                GameObject spawnedItem = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], itemTransform.position, itemTransform.rotation);
                spawnedItem.transform.rotation = Quaternion.Euler(new Vector3(spawnedItem.transform.rotation.x, Random.Range(0.0f, 360.0f), spawnedItem.transform.rotation.z));
                spawnedItem.transform.SetParent(transform);
            }
        }
    }
}
