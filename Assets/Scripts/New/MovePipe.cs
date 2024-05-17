using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.65f;
   
    private void Update()
    {
        if(GameManager.Instance.Player._gameStates == GameStates.Playing)
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        
    }
}
