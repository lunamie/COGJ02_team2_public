using UnityEngine;
using System.Collections;

public class CloudGen : MonoBehaviour {
	[SerializeField] GameObject[] cloudPrefabs;
	[SerializeField] int max;
	[SerializeField] float range;
	[SerializeField] float scale;
	// Use this for initialization
	void Start () {
		if(cloudPrefabs.Length==0){
			return;
		}
		for(var i=0 ; i< max;i++){
			var obj = Object.Instantiate(
				cloudPrefabs[Random.Range(0,cloudPrefabs.Length)],
				new Vector3(
					Random.Range(-range,range) ,
					Random.Range(-range,range) ,
					Random.Range(-range,range)),
				Quaternion.identity
			) as GameObject;
			obj.transform.localScale = new Vector3(scale,scale,scale);
			obj.transform.parent=this.transform;


		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
