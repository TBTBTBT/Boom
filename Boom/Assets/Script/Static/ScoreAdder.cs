using UnityEngine;
using System.Collections;

public class ScoreAdder : MonoBehaviour {
	[SerializeField]private int addScore = 100;
		
	// Update is called once per frame
	public void Add(){
		Score.ScoreAdd (addScore);
		Debug.Log (Score.score);
	}
}
