using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetEnemies : MonoBehaviour {
	static TargetEnemies instance_ = null;
	static public TargetEnemies insntace {
		get{
			return instance_ ?? new GameObject("TargetEnemies").AddComponent<TargetEnemies>();
		}
	}
	public List<GameObject> targets = new List<GameObject>();
	// Use this for initialization
	void Awake () {
		instance_ = this;
	}

	public void Add(GameObject obj){
		targets.Add(obj);
	}
	public GameObject get(){
		var ret = targets.FindLast(n=>!this.isOutOfScreen(n.transform));
		if(ret){
			targets.Remove(ret);
		}
		return ret;
	}
	bool isOutOfScreen(Transform t) {
		Vector3 positionInScreen = Camera.main.WorldToViewportPoint(transform.position);
		positionInScreen.z = transform.position.z;

		if (positionInScreen.x <= 0 ||
			positionInScreen.x >= 1 ||
			positionInScreen.y <= 0 ||
			positionInScreen.y >= 1)
		{
			return true;
		} else {
			return false;
		}
	}
}