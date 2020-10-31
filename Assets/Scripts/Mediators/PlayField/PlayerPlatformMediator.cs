using Input;
using Signals;
using UnityEngine;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class PlayerPlatformMediator : Mediator<PlayerPlatformView>
    {
        [Inject] public IInput Input { get; set; }
        [Inject] public BallHitPlayerSignal BallHitPlayerSignal {get; set; }

        
        private float _input;

        public override void OnRegister()
        {
            base.OnRegister();
            View.OnBallHit += BallHitPlayerSignal.Dispatch;
        }

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