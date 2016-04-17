using UnityEngine;
using System.Collections;

public class Enemy01 : EnemyBase {
	float spd;
	[SerializeField]float maxSpd = 30;
	Vector2 direction;
	protected override void Setup(){
		float angle = transform.localEulerAngles.z;
		direction = new Vector2(-Mathf.Sin(angle*Mathf.PI/180),Mathf.Cos(angle*Mathf.PI/180));

		spd = 0;
	}
	protected override void Move(){
		if(spd> -maxSpd)spd -= 0.5f;
		preVel = direction * spd;
	}
}
