﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class StartThisClient : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
        this.GetComponent<NetworkManager>().StartClient();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
