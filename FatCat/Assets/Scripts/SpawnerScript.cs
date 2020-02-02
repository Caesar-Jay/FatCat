using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> foodSpawns;
    public List<GameObject> itemSpawns;
    public GameObject foodPile;
    public List<GameObject> destroyables;
    public GameObject enemy;
    public GameObject player;

    private List<int> lastSpawnFood = new List<int>();
    private Random random = new Random();

    private void Start()
    {
        foreach(var item in itemSpawns)
        {
            var spawned = SpawnItem(item.transform.position);
            var gs = FindObjectOfType<GameScore>();
            spawned.GetComponent<DestroyableScript>().gameManager = gs;
        }

        //itemSpawns.ForEach((x) => SpawnItem(x.transform.position));
    }

    public GameObject SpawnFood()
    {
        var noOfSpawns = foodSpawns.Count;
        int spawnPos;

        do
        {
            spawnPos = random.Next(0, noOfSpawns);
            Debug.Log(spawnPos);
        }
        while (lastSpawnFood.Contains(spawnPos));

        if(lastSpawnFood.Count > 1)
            lastSpawnFood.RemoveAt(0);
        lastSpawnFood.Add(spawnPos);

        var pile = Instantiate(foodPile, foodSpawns[spawnPos].transform.position, Quaternion.identity);
        return pile;
    }

    public GameObject SpawnItem(Vector3 pos)
    {
        var spawnNumber = random.Next(0, destroyables.Count); 
        var item = Instantiate(destroyables[spawnNumber], pos, Quaternion.identity);
        return item;
    }
}
