using UnityEngine;

namespace DesignPatterns
{
    public sealed class InputProcessor
    {
        public Vector3? GetClickPosition()
        {
            if (!Input.GetMouseButtonDown(0) || Camera.main == null) return null;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                return hitInfo.point;

            return null;
        }

        public Vector3 ReadInput()
        {
            var x = 0f;
            if (Input.GetKey(KeyCode.RightArrow))
                x = 1f;
            if (Input.GetKey(KeyCode.LeftArrow))
                x = -1f;

            var y = 0f;
            if (Input.GetKey(KeyCode.UpArrow))
                y = 1f;
            if (Input.GetKey(KeyCode.DownArrow))
                y = -1f;

            if (x != 0 || y != 0)
                return new Vector3(x, y, 0);

            return Vector3.zero;
        }

        internal bool ReadUndo()
        {
            return Input.GetKey(KeyCode.Backspace);
        }

        internal bool ReadRedo()
        {
            return Input.GetKey(KeyCode.Space);
        }

        internal float ReadScale()
        {
            if (Input.GetKey(KeyCode.Q))
                return 1f;
            if (Input.GetKey(KeyCode.A))
                return -1f;

            return 0f;
        }
    }
}