using UnityEngine;
using System.Collections;

public class ParticleSpin : MonoBehaviour {
	private float angle =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle += 20;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
	}
}
