using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]private GameObject enemy1;
	[SerializeField]private GameObject enemy2;
	[SerializeField]private GameObject enemy3;
	int time = 0;
	int wave = 0;
	// Use this for initialization
	void Start () {
		Debug.Log("a");
		//Instantiate (enemy1,new Vector3(0,0,0),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {


		if(wave == 0){
			if (time % 400 == 0)StartCoroutine(Pattern1(enemy1,0));
			if (time % 400 == 200)StartCoroutine(Pattern1(enemy1,1));
			if (time % 400 == 399){
				wave ++;
				time = 0;
			}
		}
		if (wave == 1) {
			if (time % 400 == 0)StartCoroutine(Pattern1(enemy2,0));
			if (time % 400 == 200)StartCoroutine(Pattern1(enemy2,1));
			if (time % 400 == 399){
				wave = 0;
				time = 0;
			}
		}
		time ++;
		
			//int r = Random.Range(1,4);
			//if(r==3)Instantiate (enemy1, new Vector3 (Random.Range(-1,2) * 50, 130, 0), Quaternion.AngleAxis(0,new Vector3(0,0,0)));
			//if(r==2)Instantiate (enemy2, new Vector3 (Random.Range(-1,2) * 50, 130, 0), Quaternion.AngleAxis(0,new Vector3(0,0,0)));
			//if(r==1)Instantiate (enemy3, new Vector3 (Random.Range(-1,2) * 50, 130, 0), Quaternion.AngleAxis(0,new Vector3(0,0,0)));
	}
	IEnumerator Pattern1(GameObject e,int pos){
		for (int i = 0; i < 3; i++) {
			if (pos == 0)
				Instantiate (e, new Vector3 (-50 + 30 * i, 130, 0), Quaternion.AngleAxis (0, new Vector3 (0, 0, 1)));
			if (pos == 1)
				Instantiate (e, new Vector3 (50 - 30 * i, 130, 0), Quaternion.AngleAxis (0, new Vector3 (0, 0, 1)));
			yield return new WaitForSeconds (.5f);
		}
	}
}
