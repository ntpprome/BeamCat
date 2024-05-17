using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
public class Paralax : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] private float paralaxSpeed = 1f;
    private Player player;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
         player = GameManager.Instance.Player;

    }

    private void Update()
    {
        if(player.GameIsRunning())
            _meshRenderer.material.mainTextureOffset += new Vector2(paralaxSpeed* Time.deltaTime, 0f);
    }
}
