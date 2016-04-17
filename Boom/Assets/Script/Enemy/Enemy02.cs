using UnityEngine;
using System.Collections;
using Boom.Math;
public class Enemy02 : EnemyBase {
	float spd;
	Vector2 aimPos;

	protected override void Setup(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector2 playerPos = new Vector2(0,0);
		if (player != null) {
			playerPos = player.transform.position;
		}
		spd = 0;
		Vector2 pos = transform.position;
		Vector2 relativePos = pos - playerPos;
		aimPos = relativePos.normalized;
		float angle = Radius.GetAngleFromLength (aimPos);
		transform.rotation = Quaternion.AngleAxis(-angle,new Vector3(0,0,1)); 
	}
	protected override void Move(){

		//float angle = Radius.GetAngleFromLength (pos - aimPos);

		if (spd > -80)
			spd--;
		preVel = aimPos * spd;
	}
}