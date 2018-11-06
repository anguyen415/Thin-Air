using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Image RedKey;
    [SerializeField]
    private Image GreenKey;
    [SerializeField]
    private Image YellowKey;
    [SerializeField]
    private Image BlueKey;
    [SerializeField]
    private Color visibleKey;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlayerKeys>().Havekey(0)) {
            YellowKey.color = visibleKey; 
        }
        if (player.GetComponent<PlayerKeys>().Havekey(1)) {
            RedKey.color = visibleKey;
        }
        if (player.GetComponent<PlayerKeys>().Havekey(2))
        {
            GreenKey.color = visibleKey;
        }
        if (player.GetComponent<PlayerKeys>().Havekey(4))
        {
            BlueKey.color = visibleKey;
        }
    }
}
