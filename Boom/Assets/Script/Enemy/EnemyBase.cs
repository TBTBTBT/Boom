using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour
{
//	[SerializeField] string hitTag;
	[SerializeField] int hpMax = 10;
	[SerializeField] bool isKnockBack = false;
	[SerializeField] int score = 0;
	protected Vector2 preVel;
	protected int hp;
	protected int explosionTime = 0;
	Rigidbody2D rg;
	int hittime=0;
	public UnityEvent OnBreaked;
	void Awake(){
		if (OnBreaked == null) {
			OnBreaked = new UnityEvent();
		}
	}
	void Start() {
		rg = GetComponent<Rigidbody2D> ();
		hp = hpMax;
		preVel = new Vector2 (0, 0);
		Setup ();

	}

	void Update () {
		if(hp<=0){
			Explosion();
		}
			Damaged();
			Updates();
		if (transform.position.y < -150 || transform.position.y > 200 || transform.position.x < -200 || transform.position.x > 200)
			Destroy (this.gameObject);
	}

	void FixedUpdate() {
			if (hittime == 0) {
				Move ();

			}
			MoveUpdate ();
	}

	void MoveUpdate() {

			rg.velocity = new Vector2(preVel.x, preVel.y);
	}

	void Damaged() {
		if (hittime >= 1) {
			hittime++;
		}
		if (hittime > 10) {
			hittime = 0;
		}
		if (hp > hpMax) {
			hp = hpMax;
		}
	}
	void Explosion(){
		//explosionTime++;
		//if (explosionTime > 10) {
		if (OnBreaked != null)OnBreaked.Invoke ();
			Destroy (this.gameObject);
		//}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Option" && hittime == 0) {
			//if (collision.gameObject.GetComponent<Player> ().Motion == 1) {
			//	collision.gameObject.GetComponent<Player> ().ReflectEnemy(transform.position);
				hp--;
				hittime = 1;
				if (isKnockBack == true) {
					if (collision.transform.position.x <= transform.position.x) {
						preVel = new Vector2 (2, 0);
					}
					if (collision.transform.position.x > transform.position.x) {
						preVel = new Vector2 (-2, 0);
					}
				}


			//}
		}
	}

	protected virtual void Move(){
	}
	protected virtual void Setup(){
	}
	protected virtual void Updates(){
	}
}
