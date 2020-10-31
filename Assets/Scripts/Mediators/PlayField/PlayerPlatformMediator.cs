using Input;
using UnityEngine;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class PlayerPlatformMediator : Mediator<PlayerPlatformView>
    {
        [Inject] public IInput Input { get; set; }
        
        private float _input;

        private void Update()
        {
            _input = Input.GetHorizontalInput() * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            View.Translate(_input);
        }
    }
}