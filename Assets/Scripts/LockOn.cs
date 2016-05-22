using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockOn : MonoBehaviour {
	[SerializeField]
	Canvas targetCanvas;

	[SerializeField]
	GameObject targetPrefab;

	[SerializeField]
	List<GameObject> targetingObjects = new List<GameObject>();

	Leap.Controller controller;

	void Start(){
		controller = new Leap.Controller();
	}
	// Update is called once per frame
	void Update () {
		if(controller.Frame().Hands.Count==2){
			var enemy = TargetEnemies.insntace.get();
			if(!enemy){
				return;
			}
			enemy.GetComponent<TargetEnemy>().FireLockon();
			Audio.instance.PlaySE("LockSE");
			targetingObjects.Add(enemy);
		} else {
			if(targetingObjects.Count > 0){
				for( int i = 0; i < targetingObjects.Count;i++){
					Destroy(targetingObjects[i],i*Time.deltaTime * 0.1f);
					GameManager.instance.cnt++;
				}
				targetingObjects.Clear();
			}
		}
			
	
	}
}
