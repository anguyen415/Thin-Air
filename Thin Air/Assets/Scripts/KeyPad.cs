using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour {
    private string code = null;
    private string message = null;
    private int index = 0;
    private string alpha;
    private bool unlocked = false;
    [SerializeField]
    private Text input;
    [SerializeField]
    private Text displaytext;
    [SerializeField]
    GameObject electric;
    [SerializeField]
    GameObject player;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip successsound;
    [SerializeField]
    private AudioClip failsound;
    private bool played;
    private float wait;
    // Use this for initialization
    void Start () {
        message = "No power.";
        displaytext.text = message;
        played = false;
        wait = successsound.length;
    }
	
	// Update is called once per frame
	void Update () {
        if (electric.GetComponent<ElectricBox>().powerOn)
        {
            message = "Enter the code: ";
            displaytext.text = message;
        }
        Debug.Log(wait);

        if (played)
        {
            wait -= Time.deltaTime; //reverse count
        }
        if (wait < 0f)
        {
            unlocked = true;
            gameObject.SetActive(false);
            player.GetComponent<PlayerMovement_anh>().enabled = true;
        }

    }

    public void keypadInput(string number)
    {
        if (electric.GetComponent<ElectricBox>().powerOn)
        {
            index++;
            if (index < 5)
            {
                code = code + number;
                input.text = code;
            }
        }
    }
    public void clearInput()
    {
        if (electric.GetComponent<ElectricBox>().powerOn)
        {
            code = null;
            input.text = code;
            index = 0;
        }
    }
    public void checkInput()
    {
        if (electric.GetComponent<ElectricBox>().powerOn)
        {
            if (code == "4321")
            {
                source.PlayOneShot(successsound, .5f);
                played = true;
                
            }
            else
            {
                code = "Error: Incorrect Input. Try Again.";
                input.text = code;
                code = null;
                index = 0;
                source.PlayOneShot(failsound, .5f);
            }
            
        }
        
    }
    public bool checkLock()
    {
        return unlocked;
    }

}
