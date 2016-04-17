using UnityEngine;
using System.Collections;

public class Particle_Sponer : MonoBehaviour {
	private GameObject p; 
	[SerializeField] private GameObject particle;
	[SerializeField] private int num = 1;

	// Update is called once per frame
	void Awake(){
		p= particle;
	}
	public void Particle() {
		for(int i=0;i<num;i++)Instantiate(p,transform.position,transform.rotation);

	}
}
