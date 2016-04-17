using UnityEngine;
using System.Collections;
using Boom.Math;
public class Enemy03 : EnemyBase {
	float spd;
	Vector2 direction;
	float aim;
	int motion = 0;
	GameObject player;

	protected override void Setup(){
	 player = GameObject.FindGameObjectWithTag("Player");

		direction = new Vector2 (0,1);
		spd = 0;
		//transform.rotation = Quaternion.AngleAxis(-angle,new Vector3(0,0,1)); 
	}
	protected override void Move(){
		if (player != null) {
			aim =  player.transform.position.y;
		}
		//float angle = Radius.GetAngleFromLength (pos - aimPos);

		if (spd > -60)
			spd--;
		preVel = direction * spd;
		if (transform.position.y < aim && motion == 0) {
			if (transform.position.x < player.transform.position.x)
				direction = new Vector2 (-1, 0);
			else
				direction = new Vector2 (1, 0);
			motion = 1;
		}
	}
}