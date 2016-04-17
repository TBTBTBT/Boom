using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {
	private Rigidbody2D rg;
	private Vector2 topLeft;
	private Vector2 bottomRight;
	private Camera cam;
	private Vector2 speedNormalize;
	private float rotation = 0;
	private float minRadius = 25;
	private float spd = 100;
	private float radius = 5 ;
	private Player p;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		topLeft = cam.ScreenToWorldPoint (new Vector3(0,0,0));
		bottomRight = cam.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
		speedNormalize = new Vector2 (0,-1);
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		speedNormalize = p.OptionDirection;
		spd = p.Spd;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	float GetRad(Vector2 len){
		//Debug.Log (Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg);
		return Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg;
	}
	float GetRadTrue(Vector2 len){
		float angle = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
		if (angle > 0) {
			return angle;
		} 
		else {
			return 360.0f+angle;
		}
	}
	void Move(){
		rg.velocity = speedNormalize  * spd;
		transform.position = new Vector3(transform.position.x,transform.position.y,0);
		if(speedNormalize.y>-1)speedNormalize = new Vector2(speedNormalize.x,speedNormalize.y-0.012f);
		rotation += 20;
		transform.rotation = Quaternion.AngleAxis (rotation,new Vector3(0,0,1));
	}
	void FixedUpdate () {
		Reflect ();
		Move ();
	}
	void Reflect(){
		if (transform.position.x - radius < topLeft.x) {
			
			if(rg.velocity.x < 0){
				
				speedNormalize  = new Vector2(-speedNormalize .x,speedNormalize .y);
				
			}
			
		}
		if (transform.position.x  + radius + 1> bottomRight.x) {
			if(rg.velocity.x > 0){
				speedNormalize  = new Vector2(-speedNormalize .x,speedNormalize .y);
			}
			
		}
		if (transform.position.y  < topLeft.y - 20) {
			
			if(rg.velocity.y < 0){
				Destroy (this.gameObject);

				
			}
			
		}
		if (transform.position.y  + radius > bottomRight.y) {
			if(rg.velocity.y > 0){
				speedNormalize  = new Vector2(speedNormalize .x,-speedNormalize .y);
			}
			
		}
	}
	public void ReflectEnemy(Vector3 pos){
		Vector2 relativePos = transform.position - pos;
		float angle = GetRadTrue (relativePos.normalized);
		//Debug.Log (angle);
		/*
		if (angle < 45 || angle > 315) {
			if(rg.velocity.y < 0){
				speedNormalize  = new Vector2(speedNormalize .x,-speedNormalize .y);
				return;
			}

		}
		if (angle >= 45 && angle<135) {
			if(rg.velocity.x < 0){
				speedNormalize  = new Vector2(-speedNormalize .x,speedNormalize .y);
				return;
			}
		}
		if (angle >= 135 && angle<225) {
			if(rg.velocity.y > 0){
				speedNormalize  = new Vector2(speedNormalize .x,-speedNormalize .y);
				return;
			}

		}
		if (angle >= 225 && angle<315) {
			if(rg.velocity.x > 0){
				speedNormalize  = new Vector2(-speedNormalize .x,speedNormalize .y);
				return;
			}
		}

		Debug.Log(angle);
*/
		speedNormalize = relativePos.normalized;
		if (angle > 90 - minRadius && angle <= 90) {
			speedNormalize = new Vector2 (Mathf.Cos (minRadius * Mathf.PI / 180), Mathf.Sin (minRadius * Mathf.PI / 180));
		}
		if (angle > 270 && angle < 270 + minRadius) {
			speedNormalize = new Vector2 (-Mathf.Cos (minRadius * Mathf.PI / 180), Mathf.Sin (minRadius * Mathf.PI / 180));
			
		}
		if (angle > 90 && angle < 90 + minRadius) {
			speedNormalize = new Vector2 (Mathf.Cos (minRadius * Mathf.PI / 180), -Mathf.Sin (minRadius * Mathf.PI / 180));
			
		}
		if (angle <= 270 && angle > 270 - minRadius) {
			speedNormalize = new Vector2 (-Mathf.Cos (minRadius * Mathf.PI / 180), -Mathf.Sin (minRadius * Mathf.PI / 180));
			
		}
	}
	void OnTriggerEnter2D(Collider2D c){
		if (c.transform.tag == "Enemy") {
				ReflectEnemy (c.transform.position);				
		}
	}
}
