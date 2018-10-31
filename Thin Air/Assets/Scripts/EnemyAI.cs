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

        //variables for patrolling
        public GameObject[] waypoints;
        [SerializeField]
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;
        //variables for chasing
        public float chaseSpeed = 1f;
        public GameObject target;

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
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 25f,mask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 25f, mask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                target = player;
                state = EnemyAI.State.CHASE;
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward+Vector3.right), out hit, 25f, mask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward -Vector3.right) * hit.distance, Color.yellow);
                target = player;
                state = EnemyAI.State.CHASE;
            }

        }
        private void LateUpdate()
        {
            StartCoroutine("FSM");

        }
        
        void Patrol()
        {
            agent.speed = patrolSpeed;
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