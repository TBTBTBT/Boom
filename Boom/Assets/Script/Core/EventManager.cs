using UnityEngine;
using UnityEngine.Events;
using System.Collections;


//please singleton
public class EventManager : MonoBehaviour {
	static public UnityEvent TouchBegin;
	static public UnityEvent TouchMove;
	static public UnityEvent TouchEnd;
	// Use this for initialization
	void Awake() {
	if (TouchBegin == null) {
			TouchBegin = new UnityEvent();
		}
	if (TouchMove == null) {
			TouchMove = new UnityEvent();
		}
	if (TouchEnd == null) {
			TouchEnd = new UnityEvent();
		}
	}

	void TouchEvent(){
		TouchInfo touch = AppUtil.GetTouch();
		if (touch == TouchInfo.Began) {
			TouchBegin.Invoke();
			// タッチ開始
		} else if (touch == TouchInfo.Moved) {
			TouchMove.Invoke();
			// タッチ移動
		} else if (touch == TouchInfo.Ended) {
			TouchEnd.Invoke();
			// タッチ終了
		}
		
	}
	// Update is called once per frame
	void Update () {
		TouchEvent ();
	}
}
