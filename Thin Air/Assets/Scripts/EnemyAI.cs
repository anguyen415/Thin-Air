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
        public float timer = 5f;

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
            timer = 5f;
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
           /* Debug.DrawRay(eyelevel, transform.TransformDirection(Vector3.forward) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward + Vector3.right) * 25f, Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward - Vector3.right) * 25f, Color.yellow);*/

            eyelevel = transform.position;
            eyelevel.y = transform.position.y + 3.3f;
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward), out hit, 25f,mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward - Vector3.right), out hit, 25f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(eyelevel, transform.TransformDirection(Vector3.forward+Vector3.right), out hit, 25f, mask))
            {
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if(state == EnemyAI.State.CHASE)
            {
                timer -= Time.deltaTime;
                
            }
            if (timer <= 0f)
            {
                state = EnemyAI.State.PATROL;
            }
        }
        private void LateUpdate()
        {
            StartCoroutine("FSM");

        }
        
        void Patrol()
        {
            agent.speed = patrolSpeed;
            timer = 5f;

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

    }
}