using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    [SerializeField] private string pipe = "Pipe";
    private void  OnCollisionEnter2D (Collision2D other)
    {
        Debug.Log($"Tile hit");
        Destroy(other.transform.parent.gameObject);
    }
}
