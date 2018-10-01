using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement_1: MonoBehaviour {
        [SerializeField]
        private bool _useFixedUpdateForInput = false;

        [SerializeField]
        private float _speed = 3.0f;

        private static float HorizontalInput {
            get { return Input.GetAxis("Horizontal"); }
        }

        private static float VerticalInput {
            get { return Input.GetAxis("Vertical"); }
        }

        private static Vector3 UserInput {
            get { return new Vector3(HorizontalInput,0.0f, VerticalInput); }
        }

        private Vector3   _inputDirection;
        private Rigidbody _rigidBody;

        private void Awake() {
            _rigidBody = GetComponentInChildren<Rigidbody>();
        }

        private void Update() {
            if (!_useFixedUpdateForInput) {
                _inputDirection = UserInput;
            }
        }

        private void FixedUpdate() {
            if (_useFixedUpdateForInput) {
                _inputDirection = UserInput;
            }

            _rigidBody.velocity = new Vector3(_inputDirection.x, 0.0f, _inputDirection.y) * _speed;
        }
    }
