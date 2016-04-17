using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private Renderer child;
	private GameObject player;
	private Player playerScript;
	// Use this for initialization
	void Start () {
		child = transform.GetChild(0).GetComponent<Renderer>();
		player = GameObject.FindGameObjectWithTag("Player");
		DisableModel ();
		EventManager.TouchMove.AddListener (ActiveModel);
		EventManager.TouchMove.AddListener (MoveModel);
		EventManager.TouchEnd.AddListener (DisableModel);
		playerScript = player.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void DisableModel(){
		child.enabled = false;
	}
	void ActiveModel(){
		if (player != null) {
			transform.position = player.transform.position;
			if (playerScript.Motion == 0)
				child.enabled = true;
		}
	}
	float GetRad(Vector2 len){
		//Debug.Log (Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg);
		return Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg;
	}
	void MoveModel(){
		float direction = GetRad(-(transform.position - TouchUsingCamera.TouchPosition())) - 90;
		if (direction < playerScript.MinRadius-90) {
			direction = playerScript.MinRadius-90;
		}
		if (direction > (90 - playerScript.MinRadius)) {
			direction = (90 - playerScript.MinRadius);
		}
		transform.rotation = Quaternion.AngleAxis (direction,new Vector3(0,0,1));
		transform.localScale = new Vector3 (1,1 + playerScript.Pow / 100,1);
	}

}
