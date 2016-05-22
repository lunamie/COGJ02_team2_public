using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour 
{
	RectTransform rectTransform = null;
	[SerializeField]
	Transform target = null;
	[SerializeField]
	Animator lockonAnimation;
	public void setTarget(Transform t){
		this.target = t;
	}
	void Awake()
	{
		rectTransform = GetComponent<RectTransform> ();
	}
	void Start(){
		if(target){
			rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);
		}
	}
	public void Lockon(){
		if(lockonAnimation){
			lockonAnimation.SetTrigger("Lockon");
		}
	}
	void Update()
	{
		if(!target){
			Destroy(gameObject);
		}else{
			rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);
		}
	}
}