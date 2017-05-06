using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour {
    
    SpriteRenderer sr;
    public bool amOffense = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
