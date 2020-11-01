using Signals;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class BallMediator : Mediator<BallView>
    {
        [Inject] public BallColorChangedSignal BallColorChangedSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            BallColorChangedSignal.AddListener(View.SetBallColor);
        }
    }
}