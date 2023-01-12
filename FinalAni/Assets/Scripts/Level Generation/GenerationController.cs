using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationController : MonoBehaviour
{


    [Header("Starting Platform Properties")]
    public List<GameObject> startingPlatforms;

    [Header("Spawning Lists")]
    GameObject currentSpawnPos;
    public List<GameObject> spawnPrefabsNormal;
    public List<GameObject> elevatorPrefabs;

    [Header("Final Platform")]
    public GameObject FinalPlatformPrefab;

    [Header("Spawning Properties")]
    public int minPlatformAmount;
    public int maxPlatformAmount;

    [Space(20)]
    public int minPlatformsBetweenElevator;
    public int maxPlatformsBetweenElevator;

    [Space(20)]
    public float minPlatformOffset;
    public float maxPlatformOffset;

    int levelPlatformLimit;
    int platformsInScene = 0;

    int platforms = 0;

    bool startPlatformPlaced = false;

    private void Start()
    {
        currentSpawnPos = GameObject.FindGameObjectWithTag("StartPos");
        CreateStartPlatform();
        levelPlatformLimit = PlatformAmount();
    }

    private void Update()
    {
        if (platforms < Random.Range(minPlatformsBetweenElevator, maxPlatformsBetweenElevator))
        {
            AddPlatforms();   
        }
        else
        {
            AddElevator();
        }

    }

    void CreateStartPlatform()
    {

      GameObject temp = Instantiate(startingPlatforms[Random.Range(0, startingPlatforms.Count)], currentSpawnPos.transform.position, Quaternion.identity);
      
        Destroy(currentSpawnPos.gameObject);
        ChangeSpawnPos();
        platformsInScene++;
        startPlatformPlaced = true;
    }

    int PlatformAmount()
    {
        int amount = Random.Range(minPlatformAmount, maxPlatformAmount);
        return amount;
    }

    void ChangeSpawnPos()
    {
        currentSpawnPos = GameObject.FindGameObjectWithTag("SpawnPos");
    }

    void AddPlatforms()
    {
        if (startPlatformPlaced)
        {
            if (platformsInScene < levelPlatformLimit - 1)
            {
                if (currentSpawnPos != null)
                {
                    Vector3 offset = new Vector3(0, Random.Range(minPlatformOffset, maxPlatformOffset), 0);
                    GameObject temp = Instantiate(spawnPrefabsNormal[Random.Range(0, spawnPrefabsNormal.Count)], currentSpawnPos.transform.position + offset, Quaternion.identity);
                    Destroy(currentSpawnPos.gameObject);
                    platformsInScene++;
                    platforms++;
                } else
                {
                    ChangeSpawnPos();
                }              
            } else
            {
                Destroy(currentSpawnPos.gameObject);
                ChangeSpawnPos();
                AddLastPlatform();
            }
        }
    }

    void AddElevator()
    {
        if (startPlatformPlaced)
        {
            if (platformsInScene < levelPlatformLimit - 1)
            {
                if (currentSpawnPos != null)
                {
                    Vector3 offset = new Vector3(0, Random.Range(minPlatformOffset, maxPlatformOffset), 0);
                    GameObject temp = Instantiate(elevatorPrefabs[Random.Range(0, elevatorPrefabs.Count)], currentSpawnPos.transform.position, Quaternion.identity);
                    Destroy(currentSpawnPos.gameObject);
                    platformsInScene++;
                    platforms = 0;
                }
                else
                {
                    ChangeSpawnPos();
                }
            } else
            {
                Destroy(currentSpawnPos.gameObject);
                ChangeSpawnPos();
                AddLastPlatform();
            }
        }
    }

    void AddLastPlatform()
    {
        if (platformsInScene == levelPlatformLimit - 1)
        {
            if (currentSpawnPos != null)
            {
                Vector3 offset = new Vector3(0, Random.Range(minPlatformOffset, maxPlatformOffset), 0);
                GameObject temp = Instantiate(FinalPlatformPrefab, currentSpawnPos.transform.position, Quaternion.identity);
                Destroy(currentSpawnPos.gameObject);
                platformsInScene++;
                Destroy(gameObject);
            } else
            {
                ChangeSpawnPos();
            }
        }
    }

}
