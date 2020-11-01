using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class ColorChoiceMediator : Mediator<ColorChoiceView>
    {
        [Inject] public BallColorChosenSignal BallColorChosenSignal { get; set; }
        
        public override void OnRegister()
        {
            base.OnRegister();
            View.gameObject.SetActive(false);
            View.OnColorChosen += BallColorChosenSignal.Dispatch;
        }
    }
}