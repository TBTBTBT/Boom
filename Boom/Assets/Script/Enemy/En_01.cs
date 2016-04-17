using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class En_01 : EnemyBase {
	GameObject player;
	Transform model;
	float maxSpd = 5f;
	float spd = 0;
	bool direction= true;
	int wait = 0;
	float posy = 0;

	float rotation = 180;
	protected override void Setup (){
		posy = transform.position.y;
		player = GameObject.FindGameObjectWithTag ("Player");
		model = transform.GetChild (0);
	}
	protected override void Move(){
		if (player != null)MoveHorizontal ();
	}
	protected override void Updates(){
		transform.position = new Vector3 (transform.position.x, posy, 0);
	}
	void MoveHorizontal(){
		if(spd>0)spd -= 0.025f;
		if (spd <= 0) {
			wait++;
			if (player.transform.position.x > transform.position.x && rotation>140)rotation--;
			if (player.transform.position.x <= transform.position.x && rotation<220)rotation++;
			model.transform.rotation = Quaternion.AngleAxis(rotation,new Vector3(0,1,0));
			if(wait>=100){
				spd = maxSpd;
				if (rotation>=180)direction= false;
				if (rotation<180)direction = true;
				wait=0;

			}
		}

		if(direction == true)preVel = new Vector2 (spd,0);
		if (direction == false)preVel = new Vector2 (-spd, 0);

	}
}
