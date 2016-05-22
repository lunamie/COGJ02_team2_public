using UnityEngine;
using System.Collections;

//angleのスピードで、とあるオブジェクトの周りを回転するスクリプト
public class TargetRotation : MonoBehaviour {

	//変数
	//一秒当たりの回転角度
	public  float angle = 30f;

	//回転の中心をとるために使う変数
	private Vector3 targetPos;
	private Vector3 slidePos;//元の位置からtargetPosをずらす
	private Vector3 deltaPos;//targetPosからの距離
	private Vector3 rotatePos;//deltaPosから初期角度計算
	private float r;
	public float xUpperLimit;
	public float xLowerLimit;
	public float yUpperLimit;
	public float yLowerLimit;
	public float zUpperLimit;
	public float zLowerLimit;


	// Use this for initialization
	void Start () {
		//targetに、"Point"の名前のオブジェクトのコンポーネントを見つけてアクセスする
//		int setPoint = Random.Range(1, 4);
		Transform target = transform.parent;
//		if(setPoint==1)target = GameObject.Find("Point").transform;
//		else if(setPoint==2)target = GameObject.Find("Point2").transform;
//		else if(setPoint==3)target = GameObject.Find("Point3").transform;
//		else target = GameObject.Find("Point4").transform;
		//変数targetPosにPointの位置情報を取得
		targetPos = target.position;

		slidePos = new Vector3 (Random.Range(xLowerLimit,xUpperLimit),
			Random.Range(yLowerLimit,yUpperLimit),
			Random.Range(zLowerLimit,zUpperLimit));
		targetPos = targetPos + slidePos;
		deltaPos = transform.position - targetPos;
		r = Mathf.Sqrt(deltaPos.z*deltaPos.z + deltaPos.x*deltaPos.x);
		float rotatetheta = Mathf.Atan2(deltaPos.x,deltaPos.z);//ラジアン(pi)
//		Debug.Log("theta = "+(rotatetheta));
//		Debug.Log("eul = "+(360/2*Mathf.PI)*(rotatetheta));
//		float tt = Mathf.Rad2Deg(rotatetheta);
		float rotateEuler = (360/2*Mathf.PI)*(rotatetheta);
		float tt = 90f;
		if (deltaPos.z < 0 ^ deltaPos.x < 0)
			tt = -tt;
		transform.Rotate ( new Vector3(0, tt+rotateEuler,0));
		slidePos = new Vector3 (Random.Range(xLowerLimit,xUpperLimit),
			Random.Range(yLowerLimit,yUpperLimit),
			Random.Range(zLowerLimit,zUpperLimit));


//		transform.position = targetPos + new Vector3(0, 0, 100);
//		transform.position = targetPos + deltaPos;
		//自分の向きをターゲットの正面に向ける
//				transform.LookAt(target);

		//自分をZ軸を中心に0～360でランダムに回転させる
//		transform.Rotate(new Vector3(0, 0, Random.Range(0,360)),Space.World);	
		//まだ回転しない
		transform.Rotate(new Vector3(0, 0, 0),Space.World);	
	}

	void Update () {

		//	Pointを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
		Vector3 axis = transform.TransformDirection(Vector3.up);
		transform.RotateAround(targetPos, axis ,angle/(r) * Time.deltaTime);

	}

	void OnCollisionEnter(Collision other) {

		Destroy(gameObject);
		Debug.Log ("hit!");

	}
}