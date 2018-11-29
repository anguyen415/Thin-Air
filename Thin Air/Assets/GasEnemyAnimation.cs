using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEnemyAnimation : MonoBehaviour {

	private Quaternion Target;
	public float spinDegree = 5f;
	public float moveDegree = 3f;
    public Animator anim;
    AnimatorClipInfo[] m_AnimatorClipInfo;
    bool dead = false;

    // Use this for initialization
    void Start ()
	{
        //		Target = transform.rotation;
        //	Target.y = spinDegree;
    }

    // Update is called once per frame
    void Update ()
	{

        if (dead)
        {
            m_AnimatorClipInfo = anim.GetCurrentAnimatorClipInfo(0);
            if (m_AnimatorClipInfo.Length == 0)
            {
                gameObject.SetActive(false);
            }
        }
		transform.Rotate(0, spinDegree * Time.deltaTime, moveDegree * Time.deltaTime); //rotates 'spinDegree' degrees per second around y axis
	}
    public void setSpawn()
    {
        anim.SetBool("isSpawning", true);
    }
    public void setDie()
    {
        anim.SetBool("isDying", true);
        anim.SetBool("isSpawning", false);
        dead = true;
    }
}
