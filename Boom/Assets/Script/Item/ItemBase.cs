using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ItemBase : MonoBehaviour {
	public UnityEvent GetItem;
	Rigidbody2D rg;
	protected Vector2 preVel;
	public int num;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		Setup ();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		Move ();
		MoveUpdate ();
	}
	void MoveUpdate() {
		rg.velocity = new Vector2(preVel.x, preVel.y);
	}
	void Update () {
		Updates();
		if (transform.position.y < -150 || transform.position.y > 200 || transform.position.x < -200 || transform.position.x > 200)
			Destroy (this.gameObject);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag =="Player") {
			GetItem.Invoke();
			Destroy(this.gameObject);
		}
	}
	protected virtual void Move(){
	}
	protected virtual void Setup(){
	}
	protected virtual void Updates(){
	}
	public int Num{
		get{
			return num;
		}
	}
}
