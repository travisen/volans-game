﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_thruster : MonoBehaviour {
    public SpriteRenderer thrust;
    // Use this for initialization
    void Start () {
        thrust = GetComponent<SpriteRenderer>();
        thrust.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}