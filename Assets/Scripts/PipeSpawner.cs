using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipe;

    private void Start()
    {
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0f,Random.Range(-heightRange, heightRange));
        Instantiate(pipe, spawnPos, quaternion.identity);
        Destroy(pipe, 10f);
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
