using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

namespace Project_Invasion
{
    public class PlayerController : MonoBehaviour
    {
        [Header ("Movement and Camera Settings")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float xRange = 5f;
        [SerializeField] private float yRange = 5f;
        
        [Header ("Tweaks")]
        [SerializeField] private float pitchPositionFactor = 1f;
        [SerializeField] private float pitchMovementFactor = 2f;
        [SerializeField] private float rollPositionFactor = -2f;
        [SerializeField] private float rollMovementFactor = -4f;
        [SerializeField] private float yawPositionFactor = -0.5f;
        [SerializeField] private float yawMovementFactor = -1f;
        
        private Vector2 _movementInput;  // movement input
        private bool _isTransforming;   // check if the ship is on manual movement or not
        private float _pitch, _yaw, _roll;
        public bool isLaserActive;

        private void Start()
        {
            isLaserActive = false;
        }
        
        private void Update()
        {
            Move();
            ProcessRotation();
        }

        private void OnMove(InputValue input)
        {
            _movementInput = input.Get<Vector2>();
            
            if (_movementInput != new Vector2(0,0))
            {
                _isTransforming = true;
            }
            else
            {
                _isTransforming = false;
            }
        }

        private void OnFire(InputValue input)
        {
            if (input.isPressed)
            {
                isLaserActive = !isLaserActive;
            }
        }
        
        private void Move()
        {
            float xChange = _movementInput.x * moveSpeed * Time.deltaTime;
            float yChange = _movementInput.y * moveSpeed * Time.deltaTime;

            Vector3 delta = new Vector3(xChange, yChange, 0);

            Vector3 currentPos = transform.localPosition;

            float newPosX = delta.x + currentPos.x;
            float newPosY = delta.y + currentPos.y;

            float clampedPosX = Mathf.Clamp(newPosX, -xRange, xRange);
            float clampedPosY = Mathf.Clamp(newPosY, -yRange, yRange);

            transform.localPosition = new Vector3(clampedPosX, clampedPosY, transform.localPosition.z);
        }
        
        private void ProcessRotation()
        {
            if (_isTransforming)
            {
                Rotate();
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        private void Rotate()
        {
            float positionalPitch = transform.localPosition.y * pitchPositionFactor;    // amount of pitch related to local position
            float movementPitch = _movementInput.y * pitchMovementFactor;    // amount of pitch related to movement
            float positionalRoll = transform.localPosition.x * rollPositionFactor;  // amount of roll related to local position
            float movementRoll = _movementInput.x * rollMovementFactor;  // amount of roll related to movement
            float positionalYaw = transform.localPosition.x * yawPositionFactor;    // amount of yaw related to local position
            float movementYaw = _movementInput.x * yawMovementFactor;    // amount of yaw related to movement
            
            _pitch = positionalPitch + movementPitch;
            _roll = positionalRoll + movementRoll;
            _yaw = positionalYaw + movementYaw;
                
            transform.localRotation = Quaternion.Euler(_pitch, _yaw, _roll);
        }
    }
}
