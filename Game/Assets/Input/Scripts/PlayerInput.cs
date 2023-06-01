using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAT.Input
{
    public class PlayerInput : MonoBehaviour
    {
        private GameInput _gameInput;

        void Awake()
        {
            _gameInput = new GameInput();
            _gameInput.Movement.Enable();
            _gameInput.Movement.Move.performed += Move_performed;
            _gameInput.Movement.Jump.performed += Jump_performed;
            _gameInput.Movement.Look.performed += Look_performed;
        }

        private void Look_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx);
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx);
        }

        private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
