using Tarject.Runtime.Core.Interfaces;
using UnityEngine;

namespace Runtime.PlayerMovementModule.Controller
{
    public class PlayerMovementController : IInitializable, IUpdatable
    {
        private readonly InputHandler _inputHandler;

        public PlayerMovementController(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Initialize()
        {
            if (_inputHandler == null)
            {
                Debug.LogError($"PlayerMovementController --> InputHandler could not be injected from hierarchy");
            }
        }

        public void Update()
        {
            Debug.Log($"[PROOF] - PlayerMovementController --> InputHandler from hierarchy - InputHandling: {_inputHandler.inputHandling}");
        }
    }
}