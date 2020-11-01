using Signals;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class ScreenLimitMediator : Mediator<ScreenLimitView>
    {
        [Inject] public BallOutOfScreenSignal BallOutOfScreenSignal { get; set; }
        
        public override void OnRegister()
        {
            base.OnRegister();
            View.OnBallCollision += () => BallOutOfScreenSignal.Dispatch();
        }
    }
}