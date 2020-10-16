using System;
using System.Collections;
using UnityEngine;

namespace DesignPatterns
{
    [RequireComponent(typeof(ICommandProcessor))]
    [RequireComponent(typeof(InputProcessor))]
    public sealed class KeyboardEntity : MonoBehaviour, IEntity
    {
        private InputProcessor _inputProcessor;
        private ICommandProcessor _commandProcessor;
        public Transform Transform => transform;

        private void Awake()
        {
            _commandProcessor = GetComponent<ICommandProcessor>();
            _inputProcessor = GetComponent<InputProcessor>();
        }

        private void Update()
        {
            var direction = _inputProcessor.ReadInput();
            if (direction != Vector3.zero)
                _commandProcessor.ExecuteCommand(new MoveCommand(this, direction));
            
            if(_inputProcessor.ReadUndo()) _commandProcessor.Undo();
            
            if(_inputProcessor.ReadRedo()) _commandProcessor.Redo();

            var scaleDirection = _inputProcessor.ReadScale();
            if(scaleDirection != 0f)
                _commandProcessor.ExecuteCommand(new ScaleCommand(this, scaleDirection));
        }
        
        public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
        {
            if (transform.position == startPosition)
                transform.position = endPosition;
        }
    }
}