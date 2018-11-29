using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCredits : MonoBehaviour {

	private float startPos;
	public float MoveRate = 1f;

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
	}


	public IEnumerator move()
	{
		for (float k = 0; k < 400; k++)
		{
			yield return new WaitForSeconds(0.2f / MoveRate);
			this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPos + k*10f);
		}
		this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPos);
		this.enabled = false;
	}

}
