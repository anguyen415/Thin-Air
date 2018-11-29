using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string newGameScene;

	public GameObject Camera;
	public float spinDegreeX = 0f;
	public float spinDegreeY = 20f;
	public float spinDegreeZ = 0f;
	public GameObject Static;
	private float startPos;
	private bool Done = true;
	public GameObject Logo;
	public GameObject Credits;

	// Use this for initialization
	void Start()
    {
		Camera = GameObject.Find("Main Camera");
		Static = GameObject.Find("Static");
		startPos = Static.GetComponent<RectTransform>().anchoredPosition.y;
	}

    // Update is called once per frame
    void Update()
    {
		Camera.transform.Rotate(spinDegreeX * Time.deltaTime, spinDegreeY * Time.deltaTime, spinDegreeZ * Time.deltaTime);
		//Static.active = false;

		if(Done)
			StartCoroutine(move());

	}
	public void NewGame()
    {
		Logo.active = true;
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	
	public void StartCredits()
	{
		Credits.active = true;
		this.gameObject.active = false;
	}

	public IEnumerator move()
	{
		Done = false;
		for(float k=0; k < 10; k++)
		{
			yield return new WaitForSeconds(0.05f);
			Static.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPos - 4*k);
			yield return new WaitForSeconds(0.05f);
			Static.GetComponent<RectTransform>().localScale = -1 * (Static.GetComponent<RectTransform>().localScale);
		}
		Done = true;
	}


}