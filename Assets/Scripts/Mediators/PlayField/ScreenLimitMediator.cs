using Signals;
using UnityEngine;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class ScreenLimitMediator : Mediator<ScreenLimitView>
    {
        [Inject] public LoseGameSignal LoseGameSignal { get; set; }
        public override void OnRegister()
        {
            base.OnRegister();
            View.OnCollision += () =>
            {
                Debug.Log("LoseGameSignal Dispatch");
                LoseGameSignal.Dispatch();
            };
        }
    }
}