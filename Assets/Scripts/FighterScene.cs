using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FighterScene : MonoBehaviour {

	float limitTime=60.0f;
	float nowTime = 0f;
	[SerializeField]
	Text timerText;
	public void Start(){
		StartGame();
	}
	public void StartGame(){
		StartCoroutine(CountTime());
	}
	IEnumerator CountTime(){
		while(nowTime < limitTime){
			yield return 0;
			nowTime += Time.deltaTime;
			timerText.text = "Time: "+(limitTime-nowTime).ToString("##.##");
		}
		timerText.text = "時間切れ!";
		GameManager.instance.ToResult();
	}

}
