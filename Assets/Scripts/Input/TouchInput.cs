using UnityEngine;

namespace Input
{
    class TouchInput : IInput
    {
        private float _previousPositionX;
        public float GetHorizontalInput()
        {
            if (UnityEngine.Input.touchCount == 0)
            {
                return 0f;
            }
            
            var touch = UnityEngine.Input.GetTouch(0);
            var input = 0f;
            if (touch.phase == TouchPhase.Began)
            {
                _previousPositionX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                input = (touch.position.x - _previousPositionX) * 30 / Screen.width;
                _previousPositionX = touch.position.x;
            }

            Debug.Log(input);

            return input;
        }
    }
}