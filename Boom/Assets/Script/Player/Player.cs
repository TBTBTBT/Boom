using UnityEngine;
using UnityEngine.Events;
using System.Collections;
[RequireComponent (typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
	private Rigidbody2D rg;
	private Vector2 topLeft;
	private Vector2 bottomRight;
	private Camera cam;
	private int motion=0;
	private Vector2 speedNormalize;
	private float rotation = 0;
	private float minRadius = 25;
	private float radius = 5 ;
	private float pow = 0;
	private float spd = 100;
	private Vector3 optionSpawnPos;
	private Vector2 optionDirection;
	private int optionNum = 0;
	private int optionCnt = 0;
	private int optionTime = 0;
	[SerializeField]private GameObject option;
	//event
	public UnityEvent MotionChanged;
	// Use this for initialization
	void Awake(){
		if (MotionChanged == null) {
			MotionChanged = new UnityEvent();
		}
	}
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		topLeft = cam.ScreenToWorldPoint (new Vector3(0,0,0));
		bottomRight = cam.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
		//Debug.Log (bottomRight);
		motion = 1;
		speedNormalize = new Vector2 (0,-1);
		optionDirection = new Vector2 (0,-1);
		EventManager.TouchMove.AddListener (Charge);
		EventManager.TouchEnd.AddListener (TouchEndEvent);
	}
	//Event
	void TouchEndEvent(){
		if(motion == 0)AddAcc(TouchUsingCamera.TouchPosition());
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		Reflect ();
		Move ();
		ChangeMotion ();

		if (motion == 1) {
			optionTime++;
			if(optionTime %5 == 0 && optionCnt < optionNum){
				Instantiate(option,optionSpawnPos,Quaternion.AngleAxis(0,new Vector3(0,1,0)));
				optionCnt++;
			}
		}
	}
	void Update(){

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
	void Charge(){
		if(pow<100)pow += 2;
	}
	void AddAcc(Vector3 touchPos) {
		spd = 150 + 200 * pow / 100.0f;
		//Debug.Log (spd);
			pow = 0;
		Vector2 relativePos = -(transform.position - touchPos);
		speedNormalize = relativePos.normalized;
		if (speedNormalize .y < 0) {
			speedNormalize  = new Vector2 (speedNormalize .x,-speedNormalize .y);
		}
		if (GetRad (speedNormalize ) < minRadius) {
			speedNormalize  = new Vector2(Mathf.Cos(minRadius*Mathf.PI/180),Mathf.Sin(minRadius*Mathf.PI/180));
		}
		if (GetRad (speedNormalize ) > 180 - minRadius) {
			speedNormalize  = new Vector2(Mathf.Cos((180 - minRadius)*Mathf.PI/180),Mathf.Sin((180 - minRadius)*Mathf.PI/180));
		}
		/*if (speed.y / speed.x < Mathf.Tan (Mathf.PI/6)) {
			if(speed.x<=0) {
				speed = 
			}
			else{
			}
		}*/
		MotionChange (1);

	//	rg.velocity = relativePos *80;
//		transform.position = cam.ScreenToWorldPoint(AppUtil.GetTouchPosition());

	}
	void MotionChange(int m){
		motion = m;
		if (motion == 0) {
		//	GetComponent<CircleCollider2D>().isTrigger = true;

		}
		if (motion == 1) {
			optionSpawnPos = transform.position;
			optionDirection = speedNormalize;
			optionCnt = 0;
			optionTime = 0;
		//	GetComponent<CircleCollider2D>().isTrigger = false;
		}
		MotionChanged.Invoke ();
	}
	void ChangeMotion(){
		if (motion == 1) {
			rotation += 20;
			}
		if (motion == 0) {
			rotation=0;
		}
		transform.rotation = Quaternion.AngleAxis (rotation,new Vector3(0,0,1));

	}
	void Move(){
		if (motion == 1) {
			rg.velocity = speedNormalize  * spd;
			if(speedNormalize.y>-1)speedNormalize = new Vector2(speedNormalize.x,speedNormalize.y-0.012f);
		} else {
			rg.velocity = Vector2.zero;
		}
		transform.position = new Vector3(transform.position.x,transform.position.y,0);
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
		if (transform.position.y  - (radius + 4) < topLeft.y) {
		
			if(rg.velocity.y < 0){
				speedNormalize  = new Vector2(speedNormalize .x,-speedNormalize .y);
				pow = 0;
				MotionChange (0);

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
			if(motion == 1){
				ReflectEnemy(c.transform.position);
			}
			if(motion == 0){
				Destroy(this.gameObject);
			}

		}
		if (c.transform.tag == "Item") {
			int num = c.gameObject.GetComponent<ItemBase>().Num;
			
			if(num == 1){
				OptionNumAdd();
			}
		}
	}
	public void OptionNumAdd(){
		if(optionNum<10)optionNum ++;
	}
	public float MinRadius{
		get {
			return minRadius;
		}
	}
	public int Motion{
		get {
			return motion;
		}
	}
	public float Pow{
		get {
			return pow;
		}
	}
	public float Spd{
		get {
			return spd;
		}
	}
	public Vector2 OptionDirection{
		get {
			return optionDirection;
		}
	}
}
