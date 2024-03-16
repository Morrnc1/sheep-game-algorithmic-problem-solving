using UnityEngine;
using System.Collections.Generic;

public class SheepManager : MonoBehaviour
{
    public Sheep sheepPrefab;
    public List<Sheep> sheepList = new List<Sheep>();

    private void Start()
    {
        SpawnSheep();
    }

    private void SpawnSheep()
    {
        Sheep newSheep = Instantiate(sheepPrefab, transform.position, transform.rotation);
        sheepList.Add(newSheep);

        newSheep.OnHitByHay.AddListener(() => HandleHitByHay(newSheep));
        newSheep.OnDropped.AddListener(() => HandleDropped(newSheep));
    }

    private void HandleHitByHay(Sheep sheep)
    {
        Debug.Log("Sheep hit by hay");

        sheepList.Remove(sheep);
        UpdateSheepCount();
    }

    private void HandleDropped(Sheep sheep)
    {
        Debug.Log("Sheep dropped");

        sheepList.Remove(sheep);
        UpdateSheepCount();
    }

    private void UpdateSheepCount()
    {
        Debug.Log("Number of sheep: " + sheepList.Count);
    }
}
