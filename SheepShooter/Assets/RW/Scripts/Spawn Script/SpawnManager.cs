using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns = 5f;

    public List<Sheep> sheepList = new List<Sheep>(); //dont private things reeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
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
        GameObject newSheepObject = Instantiate(sheepPrefab, spawnPoint.position, Quaternion.identity);
        Sheep newSheep = newSheepObject.GetComponent<Sheep>();
        if (newSheep != null)
        {
            // Add event listeners to count and destroy sheep
            newSheep.OnDropped.AddListener(() => HandleSheepDropped(newSheep));
            newSheep.OnHitByHay.AddListener(() => HandleSheepHitByHay(newSheep));
            sheepList.Add(newSheep);
        }
        else
        {
            Debug.LogWarning("Failed to get Sheep component from spawned sheep.");
        }
    }

    private void HandleSheepDropped(Sheep sheep)
    {
        if (sheepList.Contains(sheep))
        {
            sheepList.Remove(sheep);
            Destroy(sheep.gameObject);
            Debug.Log("Sheep dropped and destroyed.");
        }
    }

    private void HandleSheepHitByHay(Sheep sheep)
    {
        if (sheepList.Contains(sheep))
        {
            sheepList.Remove(sheep);
            Destroy(sheep.gameObject);
            Debug.Log("Sheep hit by hay and destroyed.");
        }
    }
}
