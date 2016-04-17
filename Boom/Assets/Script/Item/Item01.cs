using UnityEngine;
using System.Collections;

public class Item01 : ItemBase{
	override protected void Setup(){
		num = 1;
	}
	override protected void Move(){
		preVel = new Vector2 (0, -10);
	}
}
