using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCredits : MonoBehaviour {

	private float startPos;
	public float MoveRate = 1f;
	public GameObject Canvas;

	//	public TextAsset asset;
	/*
		void OnGUI()
		{
			//	GUILayout.Label(asset.text);
			GUILayout.Label(asset.ToString());
		}
	*/
	void Start()
	{
		startPos = this.GetComponent<RectTransform>().anchoredPosition.y;
		StartCoroutine(move());
	//	Canvas = GameObject.Find("Canvas");
	}


	public IEnumerator move()
	{
		for (float k = 0; k < 325; k++)
		{
			yield return new WaitForSeconds(0.2f / MoveRate);
			this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPos + k*10f);
		}
		this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPos);

		Canvas.gameObject.active = true;
		this.enabled = false;
	}

}
