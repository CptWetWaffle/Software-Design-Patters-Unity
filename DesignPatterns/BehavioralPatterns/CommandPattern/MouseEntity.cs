using System.Collections;
using UnityEngine;

namespace DesignPatterns
{
    [RequireComponent(typeof(ICommandProcessor))]
    [RequireComponent(typeof(InputProcessor))]
    public class MouseEntity : MonoBehaviour, IEntity
    {
        private Coroutine _coroutine;
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
            var mouseClick = _inputProcessor.GetClickPosition();
            if (mouseClick != null)
                _commandProcessor.ExecuteCommand(new MouseMoveCommand(this, mouseClick.Value));
            
            if(_inputProcessor.ReadUndo()) _commandProcessor.Undo();
            
            if(_inputProcessor.ReadRedo()) _commandProcessor.Redo();
        }

        public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(MoveFromToAsync(startPosition, endPosition));
        }

        private IEnumerator MoveFromToAsync(Vector3 startPosition, Vector3 endPosition)
        {
            var elapsed = 0f;
            while (elapsed < 1f)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsed);
                yield return null;
            }

            transform.position = endPosition;
        }
    }
}