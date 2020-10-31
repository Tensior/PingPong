namespace Input
{
    class KeyboardInput : IInput
    {
        public float GetHorizontalInput()
        {
            return UnityEngine.Input.GetAxis("Horizontal");
        }
    }
}