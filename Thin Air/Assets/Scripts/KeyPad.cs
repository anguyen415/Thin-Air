using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour {
    private string code = null;
    private int index = 0;
    private string alpha;
    [SerializeField]
    private Text input;
   /* [SerializeField]
    GameObject keyPad;*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void keypadInput(string number)
    {
        index++;
        if(index < 5)
        {
            code = code + number;
            input.text = code;
        }
    }
    public void clearInput()
    {
        code = null;
        input.text = code;
        index = 0;
    }
    public void checkInput()
    {
        if(code == "4321")
        {
            Debug.Log("Test");
        }
        else
        {
            code = "Error: Incorrect Input. Try Again.";
            input.text = code;
            code = null;
            index = 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<SetActive>().Press();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<SetActive>().Left();
        }
    }

}
