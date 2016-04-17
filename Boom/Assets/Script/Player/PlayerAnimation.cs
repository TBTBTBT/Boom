using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimation : MonoBehaviour {

	// Use this for initialization
	private Player player;
	private List<Renderer> model;

	void Start () {
		model = new List<Renderer>();
		for(int i = 0; i < transform.childCount;i++) {
			Debug.Log(i);
			Renderer child;
			child = transform.GetChild(i).GetComponent<Renderer>();
			model.Add(child);

		}
		player = GetComponent<Player> ();
		player.MotionChanged.AddListener (ChangeModel);
	}
	
	// Update is called once per frame
	void Change(int index){
		int count = 0;
		foreach(Renderer r in model){
			r.enabled = false;
			if(count == index)r.enabled = true;
			count++;
		}
	}
	void ChangeModel() {
		if(player.Motion == 0){
			Change (0);
		}
		if(player.Motion == 1){
			Change (1);
		}
	}
}
