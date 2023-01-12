using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    [Header("Spawning Lists")]
    GameObject currentSpawnPos;
    GameObject StartSpawn;
    public List<GameObject> spawnPrefabs;

    [Header("Spawning Properties")]
    public int minPlatformAmount;
    public int maxPlatformAmount;

    public float minPlatformOffsetY;
    public float maxPlatformOffsetY;

    int levelPlatformLimit;
    int platformsInScene = 0;

    int platforms = 0;

    bool startPlatformPlaced = false;

    private void Start()
    {
        StartSpawn = GameObject.FindGameObjectWithTag("StartPos");
        CreateStartPlatform();
        levelPlatformLimit = PlatformAmount();
    }

    private void Update()
    {
        AddPlatforms();      
    }

    void CreateStartPlatform()
    {
            GameObject temp = Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Count)], StartSpawn.transform.position, Quaternion.identity);
            Destroy(StartSpawn.gameObject);
            platformsInScene++;   
        ChangeSpawnPos();
        startPlatformPlaced = true;
    }

    int PlatformAmount()
    {
        int amount = Random.Range(minPlatformAmount, maxPlatformAmount);
        return amount;
    }

    void ChangeSpawnPos()
    {
        currentSpawnPos = GameObject.FindGameObjectWithTag("BackSpawnPos");
    }

    void AddPlatforms()
    {
        if (startPlatformPlaced)
        {
            if (platformsInScene < levelPlatformLimit)
            {
                if (currentSpawnPos != null)
                {
                    Vector3 offset = new Vector3(0, Random.Range(minPlatformOffsetY, maxPlatformOffsetY), 0);
                    GameObject temp = Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Count)], currentSpawnPos.transform.position + offset, Quaternion.identity);


                    Destroy(currentSpawnPos.gameObject);
                    platformsInScene++;
                    platforms++;
                }
                else
                {
                    ChangeSpawnPos();
                }
            }

        }
    }

}
