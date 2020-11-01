using Signals;
using UnityEngine;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class ScreenLimitMediator : Mediator<ScreenLimitView>
    {
        [Inject] public StopGameSignal stopGameSignal { get; set; }
        public override void OnRegister()
        {
            base.OnRegister();
            View.OnCollision += () =>
            {
                Debug.Log("StopGameSignal Dispatch");
                stopGameSignal.Dispatch();
            };
        }
    }
}