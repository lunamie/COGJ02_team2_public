using UnityEngine;
using System.Collections;

public class BOSSScript : MonoBehaviour {

	// プレハブを取得
	public GameObject prefab;
	private int enemycount;
	public int enemyNumber;
	// Use this for initialization
	void Start () {
		enemycount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		enemycount = this.transform.childCount;
		if (enemycount < enemyNumber) {
			// プレハブからインスタンスを生成
			float rangex = Random.Range(500f, 1000f);
			float rangey = Random.Range(-100f, 100f);
			float rangez = Random.Range(500f, 1000f);
			if (Random.Range (-1f, 1f) < 0)
				rangez = -rangez;
			if (Random.Range (-1f, 1f) < 0)
				rangex = -rangex;

			float rot = Random.Range(90f, 270f);
//			float rot = 0;
//			if (rangez > 0)
//				rot = 270;
//			else
//				rot = 90;
////				transform.Rotate (new Vector3 (0,90,0));
//			Debug.Log ("rangez = "+rangez);

//			Instantiate (prefab, new Vector3(0, -100, rangez), Quaternion.identity);
			GameObject obj = (GameObject)Instantiate (prefab, transform.position, new Quaternion(0,1,0, rot));
			obj.transform.parent = transform;
		}
	
	}
}
