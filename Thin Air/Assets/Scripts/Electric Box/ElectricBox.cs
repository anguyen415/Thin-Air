using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBox : MonoBehaviour {

	GameObject[] blockOrder = new GameObject[16];
	int correct = 0;
	public bool powerOn = false;

	// Will save positions of Correct Path
	Vector3 p1 = new Vector3();
	Vector3 p2 = new Vector3();
	Vector3 p3 = new Vector3();
	Vector3 p5 = new Vector3();
	Vector3 p6 = new Vector3();
	Vector3 p7 = new Vector3();
	Vector3 p8 = new Vector3();
	Vector3 p9 = new Vector3();
	Vector3 p10 = new Vector3();
	Vector3 p11 = new Vector3();
	Vector3 p12 = new Vector3();
	Vector3 p15 = new Vector3();
	//

	// Use this for initialization
	void Start ()
	{
		saveSpots();
		randomShuffle();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!powerOn)
			checkPuzzle();
	}

	void randomShuffle()
	{
		int i;
		for (int k = 0; k < 16; k++)
		{
			i = Random.Range(0, 16);
			// Swap
			Vector3 temp = blockOrder[k].transform.position;
			blockOrder[k].transform.position = blockOrder[i].transform.position;
			blockOrder[i].transform.position = temp;
			//
		}
	}

	void checkPuzzle()
	{
		if(blockOrder[1].transform.position == p1 || blockOrder[1].transform.position == p6 || blockOrder[1].transform.position == p11)
			glowBlock(blockOrder[1], true);
		else
			glowBlock(blockOrder[1], false);
		//
		if (blockOrder[2].transform.position == p2 || blockOrder[2].transform.position == p7)
			glowBlock(blockOrder[2], true);
		else
			glowBlock(blockOrder[2], false);
		//
		if (blockOrder[3].transform.position == p3 || blockOrder[3].transform.position == p10 || blockOrder[3].transform.position == p12)
			glowBlock(blockOrder[3], true);
		else
			glowBlock(blockOrder[3], false);
		//
		if (blockOrder[4].transform.position == p9)
			glowBlock(blockOrder[4], true);
		else
			glowBlock(blockOrder[4], false);
		//
		if (blockOrder[5].transform.position == p5 || blockOrder[5].transform.position == p15)
			glowBlock(blockOrder[5], true);
		else
			glowBlock(blockOrder[5], false);
		//
		if (blockOrder[6].transform.position == p1 || blockOrder[6].transform.position == p6 || blockOrder[6].transform.position == p11)
			glowBlock(blockOrder[6], true);
		else
			glowBlock(blockOrder[6], false);
		//
		if (blockOrder[7].transform.position == p2 || blockOrder[7].transform.position == p7)
			glowBlock(blockOrder[7], true);
		else
			glowBlock(blockOrder[7], false);
		//
		if (blockOrder[8].transform.position == p8)
			glowBlock(blockOrder[8], true);
		else
			glowBlock(blockOrder[8], false);
		//
		if (blockOrder[9].transform.position == p9)
			glowBlock(blockOrder[9], true);
		else
			glowBlock(blockOrder[9], false);
		//
		if (blockOrder[10].transform.position == p3 || blockOrder[10].transform.position == p10 || blockOrder[10].transform.position == p12)
			glowBlock(blockOrder[10], true);
		else
			glowBlock(blockOrder[10], false);
		//
		if (blockOrder[11].transform.position == p1 || blockOrder[11].transform.position == p6 || blockOrder[11].transform.position == p11)
			glowBlock(blockOrder[11], true);
		else
			glowBlock(blockOrder[11], false);
		//
		if (blockOrder[12].transform.position == p3 || blockOrder[12].transform.position == p10 || blockOrder[12].transform.position == p12)
			glowBlock(blockOrder[12], true);
		else
			glowBlock(blockOrder[12], false);
		//
		if (blockOrder[13].transform.position == p8)
			glowBlock(blockOrder[13], true);
		else
			glowBlock(blockOrder[13], false);
		//
		if (blockOrder[14].transform.position == p9)
			glowBlock(blockOrder[14], true);
		else
			glowBlock(blockOrder[14], false);
		//
		if (blockOrder[15].transform.position == p5 || blockOrder[15].transform.position == p15)
			glowBlock(blockOrder[15], true);
		else
			glowBlock(blockOrder[15], false);
		//

		if (correct == 9) // (+12) + (-3)
			powerOn = true;
		correct = 0;
	}

	void glowBlock(GameObject block, bool ON) // Makes block glow if on correct spot
	{
		Material thisMat;
		if (ON)
		{
			thisMat = block.GetComponent<Renderer>().material;
			thisMat.EnableKeyword("_EMISSION");
			correct++;
		}
		else // not ON
		{
			thisMat = block.GetComponent<Renderer>().material;
			thisMat.DisableKeyword("_EMISSION");
			correct--;
		}
	}

	void saveSpots()
	{
		blockOrder[0] = GameObject.Find("EMPTY");
		blockOrder[1] = GameObject.Find("1");
		blockOrder[2] = GameObject.Find("2");
		blockOrder[3] = GameObject.Find("3");
		blockOrder[4] = GameObject.Find("4");
		blockOrder[5] = GameObject.Find("5");
		blockOrder[6] = GameObject.Find("6");
		blockOrder[7] = GameObject.Find("7");
		blockOrder[8] = GameObject.Find("8");
		blockOrder[9] = GameObject.Find("9");
		blockOrder[10] = GameObject.Find("10");
		blockOrder[11] = GameObject.Find("11");
		blockOrder[12] = GameObject.Find("12");
		blockOrder[13] = GameObject.Find("13");
		blockOrder[14] = GameObject.Find("14");
		blockOrder[15] = GameObject.Find("15");
		p1 = blockOrder[1].transform.position;
		p2 = blockOrder[2].transform.position;
		p3 = blockOrder[3].transform.position;
		p5 = blockOrder[5].transform.position;
		p6 = blockOrder[6].transform.position;
		p7 = blockOrder[7].transform.position;
		p8 = blockOrder[8].transform.position;
		p9 = blockOrder[9].transform.position;
		p10 = blockOrder[10].transform.position;
		p11 = blockOrder[11].transform.position;
		p12 = blockOrder[12].transform.position;
		p15 = blockOrder[15].transform.position;
	}

}
