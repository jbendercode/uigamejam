using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

	private int tabletScore;
	private int shooterScore;
	private int minInfluence;
	private int maxInfluence;
	private int tabletInfluenceGain;
	private int shooterInfluenceGain;
	public int influence;
	private float markerStartX;

	private int timer = 10;

	public Transform markerToMove;
	public Transform shooterScoreText;
	public Transform tabletScoreText;

	// Use this for initialization
	void Start () {
		tabletScore = 0;
		shooterScore = 0;
		minInfluence = 0;
		maxInfluence = 200;
		influence = 100;
		tabletInfluenceGain = 70;
		shooterInfluenceGain = 130;
		markerStartX = markerToMove.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (influence < tabletInfluenceGain) {
			tabletScore += 1;
		} else if (influence > shooterInfluenceGain) {
			shooterScore += 1;
		}
		shooterScoreText.GetComponent<Text> ().text = shooterScore.ToString();
		tabletScoreText.GetComponent<Text> ().text = tabletScore.ToString();
	}

	public void updateInfluence(int addToInf){
		influence += addToInf;
		influence = influence < minInfluence ? minInfluence : influence;
		influence = influence > maxInfluence ? maxInfluence : influence;
		markerToMove.transform.position = new Vector3(markerStartX - (100 - influence), markerToMove.position.y, markerToMove.position.z);
		Debug.Log (influence);
	}
}
