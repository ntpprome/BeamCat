using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random  = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject spawnerPrefab;
    private List<GameObject> Pipes;
    [SerializeField] private float spawnRate = 1f; 
    [SerializeField] private float waitTime = 12f; 
    [SerializeField] private float minHeight = -1f; 
    [SerializeField] private float maxHeight = 1f;
    

    private void Start()
    {
        Pipes = new List<GameObject>();
        GameManager.Instance.Player.OnGameOver += EndSpwan;
        GameManager.Instance.Player.OnGameRestart += StartSpwan;
    }

    private void StartSpwan()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        DestroyAllPipes();
    }
       
    private void EndSpwan()
    {
        CancelInvoke(nameof(Spawn));
        DestroyAllPipes();
    }
    private void Spawn()
    {
        GameObject pipe = Instantiate(spawnerPrefab, transform.position, quaternion.identity);
        var position = pipe.transform.position;
        position += Vector3.up * Random.Range(minHeight, maxHeight);
        position = new Vector3(position.x, position.y, 0f);
        pipe.transform.position = position;
        Pipes.Add(pipe);
    }

   void  DestroyAllPipes()
    {
        foreach (var pipe in Pipes)
        {
            Destroy(pipe);
        }
    }
    
}
