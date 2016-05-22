using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Audio.instance.PlayBGM("edm_02_loop");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			SceneManager.LoadScene("FighterScene");
		}
	}
}
