using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultScene : MonoBehaviour {
	[SerializeField]
	Text scoreText;

	void Start(){
		scoreText.text= GameManager.instance.cnt.ToString();
		GameManager.instance.cnt = 0;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			SceneManager.LoadScene("TitleScene");
		}
	}
}
