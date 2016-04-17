using UnityEngine;
using System.Collections;

public class TouchUsingCamera : MonoBehaviour {
	private Camera cam;
	static private Vector3 pos;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		EventManager.TouchBegin.AddListener (() => {pos = cam.ScreenToWorldPoint (AppUtil.GetTouchPosition ());});
		EventManager.TouchMove.AddListener (() => {pos = cam.ScreenToWorldPoint (AppUtil.GetTouchPosition ());});
	}
	static public Vector3 TouchPosition(){
		return pos;
	}

}
