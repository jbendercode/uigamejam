using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	private int tileType;
	public Material[] tileMaterials;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Set tile type
	public void setTileType(int type){
		tileType = type;

		switch (type) {
			case 0:
				gameObject.GetComponent<Renderer>().material = tileMaterials [0];
				break;
			case 1:
				gameObject.GetComponent<Renderer>().material = tileMaterials [1];
				break;
		}
	}
}
