using UnityEngine;
using System.Collections;

public class TileHandler : MonoBehaviour {

	public GameObject tile;
	public ArrayList tiles = new ArrayList();
	public int tilesWide;
	public int tilesLong;
	public Vector3 tileGenStartPoint;

	// Use this for initialization
	void Start () {
		generateTiles ();	
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Generate tiles
	private void generateTiles(){
		for (int i = 0; i < tilesWide; i++) {
			for (int j = 0; j < tilesLong; j++) {
				// new tile location
				Vector3 tileLocation = new Vector3 (tileGenStartPoint.x + i, 
													tileGenStartPoint.y, 
													tileGenStartPoint.z + j);

				GameObject newTile = Instantiate (tile, tileLocation, Quaternion.identity) as GameObject;
				newTile.GetComponent<Tile>().setTileType (i % 2);
				tiles.Add (newTile);
			}
		}
	}
}
