using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static float spawnChance = 50.0f;

    [SerializeField] private Transform[] obstacleTransforms;
    [SerializeField] private GameObject[] obstaclePrefabs;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        switch(GameManager.Instance.difficulty)
        {
            case 0:
                EasySpawn();
                break;
            case 1:
                MediumSpawn();
                break;
            case 2:
                HardSpawn();
                break;
            case 3:
                ExpertSpawn();
                break;
        }
    }

    private void EasySpawn()
    {
        int chanceTwoSpawn2PerRow = 0;
        int chanceToSpawnRow = 50;

        bool spawnRow1 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow2 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow3 = Random.Range(0, 100) <= chanceToSpawnRow;

        if(spawnRow1)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(0, 3, spawnTwoPerRow);
        }
        if(spawnRow2)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(3, 6, spawnTwoPerRow);
        }
        if(spawnRow3)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(6, 9, spawnTwoPerRow);
        }
    }

    private void MediumSpawn()
    {
        int chanceTwoSpawn2PerRow = 50;
        int chanceToSpawnRow = 70;

        bool spawnRow1 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow2 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow3 = Random.Range(0, 100) <= chanceToSpawnRow;

        if(spawnRow1)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(0, 3, spawnTwoPerRow);
        }
        if(spawnRow2)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(3, 6, spawnTwoPerRow);
        }
        if(spawnRow3)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(6, 9, spawnTwoPerRow);
        }
    }

    private void HardSpawn()
    {
        int chanceTwoSpawn2PerRow = 70;
        int chanceToSpawnRow = 90;

        bool spawnRow1 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow2 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow3 = Random.Range(0, 100) <= chanceToSpawnRow;

        if(spawnRow1)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(0, 3, spawnTwoPerRow);
        }
        if(spawnRow2)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(3, 6, spawnTwoPerRow);
        }
        if(spawnRow3)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(6, 9, spawnTwoPerRow);
        }
    }

    private void ExpertSpawn()
    {
        int chanceTwoSpawn2PerRow = 100;
        int chanceToSpawnRow = 100;

        bool spawnRow1 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow2 = Random.Range(0, 100) <= chanceToSpawnRow;
        bool spawnRow3 = Random.Range(0, 100) <= chanceToSpawnRow;

        if(spawnRow1)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(0, 3, spawnTwoPerRow);
        }
        if(spawnRow2)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(3, 6, spawnTwoPerRow);
        }
        if(spawnRow3)
        {
            bool spawnTwoPerRow = Random.Range(0, 100) <= chanceTwoSpawn2PerRow;
            SpawnRow(6, 9, spawnTwoPerRow);
        }
    }


    private void SpawnRow(int minIndex, int maxIndex, bool twoPerRow)
    {
        if(twoPerRow)
        {
            int index1 = Random.Range(minIndex, maxIndex);
            int index2 = Random.Range(minIndex, maxIndex);
            int prefabIndex1 = Random.Range(0, obstaclePrefabs.Length);
            int prefabIndex2 = Random.Range(0, obstaclePrefabs.Length);
            while(index2 == index1)
            {
                index2 = Random.Range(minIndex, maxIndex);
            }
            Instantiate(obstaclePrefabs[prefabIndex1], obstacleTransforms[index1].position, obstacleTransforms[index1].rotation).transform.SetParent(transform);
            Instantiate(obstaclePrefabs[prefabIndex2], obstacleTransforms[index2].position, obstacleTransforms[index2].rotation).transform.SetParent(transform);
        }
        else
        {
            int index = Random.Range(minIndex, maxIndex);
            int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[prefabIndex], obstacleTransforms[index].position, obstacleTransforms[index].rotation).transform.SetParent(transform);
        }
    }
}

