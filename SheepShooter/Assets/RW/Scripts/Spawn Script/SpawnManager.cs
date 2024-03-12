using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns = 5f;

    private List<GameObject> sheepList = new List<GameObject>();
    private Coroutine spawnCoroutine;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        
    }
    

    IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

  void SpawnSheep()
{
    if (sheepPrefab == null || sheepSpawnPositions.Count == 0)
    {
        Debug.LogWarning("Sheep prefab or spawn positions not set!");
        return;
    }

    Transform spawnPoint = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)];
    GameObject newSheep = Instantiate(sheepPrefab, spawnPoint.position, Quaternion.identity);
    sheepList.Add(newSheep);
}

    public void HandleSheepEvent(GameObject sheep)
    {
        if (sheepList.Contains(sheep))
        {
            sheepList.Remove(sheep);
            Destroy(sheep);
        }
    }
}
