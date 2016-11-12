using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class StartThisHost : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<NetworkManager>().StartHost();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
