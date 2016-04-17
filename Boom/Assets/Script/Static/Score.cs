using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	static public int score = 0;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	static public void ScoreAdd(int s){
		score += s;
	}
	// Update is called once per frame

}
