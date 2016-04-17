using UnityEngine;
using System.Collections;

public class CameraFixer : MonoBehaviour {
	[SerializeField]private float width=9;
	[SerializeField]private float height=16;
	private Camera cam;
	private float pixelPerUnit = 10f;
	
	void Awake () {

		float ratio = (Screen.width*1.0f / Screen.height) / (width / height);
		// カメラコンポーネントを取得します
		cam = GetComponent<Camera> ();
		//Rect newAspect = new Rect (0,0,0.5f,1.0f);
		//cam.rect = newAspect;
		//cam.orthographicSize = Screen.height / 2f;
		cam.ResetAspect();
		cam.aspect = width / height;
	}
}
