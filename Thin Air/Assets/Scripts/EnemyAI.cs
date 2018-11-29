using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class EnemyAI : MonoBehaviour
    {
        public NavMeshAgent agent;        // the navmesh agent required for the path finding
        public ThirdPersonCharacter character;
        public enum State
            
        {
            PATROL,
            CHASE
        }
        public float giveUpTimer;
        public State state;
        private RaycastHit hit;
        private GameObject player;
        private LayerMask mask;
        private int mask2 = 1 << 9;
        //variables for patrolling
        public GameObject[] waypoints;
        [SerializeField]
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;
        //variables for chasing
        public float chaseSpeed = 1f;
        private Vector3 eyelevel;
        public GameObject target;
        public float timer = 20f;
        public float awakenTimer = 10f;
        public GameObject gas;
        public bool awaken;
        public int timeAlive;
        public Animator anim;
        public GameObject lightHelmet;
        public AudioSource audio;
        public AudioClip chaseSound;
        public AudioClip deathSound;
        public AudioClip patrolSound;
        AnimatorClipInfo[] m_AnimatorClipInfo;
        bool hasRespawn;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            agent.updatePosition = true;
            agent.updateRotation = false;
            state = EnemyAI.State.PATROL;
            mask = LayerMask.GetMask("Player");
            player = GameObject.FindWithTag("Player");
            awaken = false;
            anim.SetBool("isDead", true);
            gas.SetActive(false);
            lightHelmet.SetActive(false);
            timeAlive = 1;
            hasRespawn = false;
            timer = giveUpTimer;
            awakenTimer = 5f;

        }
         IEnumerator FSM()
        {
            switch (state)
            {
                case State.PATROL:
                    {
                        Patrol();
                        break;
                    }
                case State.CHASE:
                    {
                        Chase();
                        break;
                    }
            }
            yield return null;

        }

        private void Update()
        {
            Debug.DrawRay(eyelevel, transform.TransformDirection(Vector3.forward) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(.5f, 0, 0)) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(.5f, 0, 0)) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(.25f, 0, 0)) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - new Vector3(.25f, 0, 0)) * 25f, Color.yellow);
            awakenTimer -= Time.deltaTime;
            
            if ((awakenTimer <= 0f) && (timeAlive ==1))
            {
                spawn();
                timeAlive = 0;
            }
            if (timer <= 0f)
            {
                state = EnemyAI.State.PATROL;
            }
           
            eyelevel = transform.position;
            eyelevel.y = transform.position.y + 3.3f;
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward), out hit, 18f,mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward - Vector3.right), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward + Vector3.right), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }

            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward - new Vector3(.5f, 0, 0)), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward + new Vector3(.5f, 0, 0)), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward - new Vector3(.25f, 0, 0)), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward + new Vector3(.25f, 0, 0)), out hit, 18f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }

            if (state == EnemyAI.State.CHASE)
            {
                timer -= Time.deltaTime;
                
            }



        }
        private void LateUpdate()
        {
            if (awaken)
            {
                m_AnimatorClipInfo = anim.GetCurrentAnimatorClipInfo(0);
                if (m_AnimatorClipInfo[0].clip.ToString() == "Armature|Possessed (UnityEngine.AnimationClip)")
                {
                    StartCoroutine("FSM");
                }
            }
           

        }
        
        void Patrol()
        {
            agent.speed = patrolSpeed;
            timer = giveUpTimer;

            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {

                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);

            }
            else if(Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) < 2)
            {
                waypointInd += 1;
                waypointInd = waypointInd % waypoints.Length;
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }
        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        void spawn()
        {

            gas.SetActive(true);
            lightHelmet.SetActive(true);
            anim.SetBool("isDead", false);
            anim.SetBool("isSpawn", true);
            awaken = true;
            gas.GetComponent<GasEnemyAnimation>().setSpawn();
            audio.clip = patrolSound;
            audio.Play(1);
            audio.loop = true;

        }
        void despawn()
        {
            anim.SetBool("isDead", true);
            anim.SetBool("isSpawn", false);
            awaken = false;
            agent.isStopped = true;
            StopCoroutine("FSM");
            lightHelmet.SetActive(false);
            gas.GetComponent<GasEnemyAnimation>().setDie();
            audio.Stop();
            audio.loop = false;
            hasRespawn = true;
            awakenTimer = 30f;


        }
    }
}