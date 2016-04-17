using UnityEngine;
using System.Collections;
namespace Boom.Math{

public class Radius : MonoBehaviour {
		//cos 0 - 180
		static public float GetAngleFromLengthHarf(Vector2 len){
			//Debug.Log (Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg);
			return Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg;
		}
		//tan 0 - 360
		static public float GetAngleFromLength(Vector2 len){
			//Debug.Log (Mathf.Acos(len.x / Mathf.Sqrt (Mathf.Pow (len.y, 2) + Mathf.Pow (len.x, 2))) * Mathf.Rad2Deg);
			float angle = Mathf.Atan2(len.x, len.y) * Mathf.Rad2Deg;
			if (angle > 0) {
				return angle;
			} 
			else {
				return 360.0f+angle;
			}
		}

}
}