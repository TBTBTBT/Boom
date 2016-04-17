using UnityEngine;
using System.Collections;

public class PropellarSpiner : MonoBehaviour {
	private float rotation=0;
	[SerializeField]private float spd = 10;
	// Use this for initialization
	void Start () {
		rotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		rotation += spd;
		transform.localRotation = Quaternion.AngleAxis (rotation,new Vector3(0,1,0));
	}
}
