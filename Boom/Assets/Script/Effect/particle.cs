using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {

	[SerializeField] float ext = 1;
	[SerializeField] bool loc=false;
	[SerializeField] float spd =1;
	[SerializeField] float acc =0;
	float ang=0;
	float ct=0;
	Color alpha = new Color(0, 0, 0, 0.01f);
	void Start () {
		if (loc == false) {
			ang = Random.Range (0, 360);
			transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
			transform.Rotate (new Vector3 (0, 0, ang));
		}
	}
	
	// Update is called once per frame
	void Update () {
		ct++;
		spd += acc;
		ext -= 0.04f;
		/*if(GetComponent<Renderer>().material.color.a >= 0){
			GetComponent<Renderer>().material.color -= alpha;
		}*/
		if(loc==false)transform.position += new Vector3 (spd*Mathf.Cos (ang*Mathf.PI/180),spd*Mathf.Sin (ang*Mathf.PI/180),0);

		if(ext!=0){
			transform.localScale = new Vector3(ext,ext,ext);
		}
		//transform.position += mov;
		if(ext<=0){
			Destroy(gameObject);
		}
		
	}

}
