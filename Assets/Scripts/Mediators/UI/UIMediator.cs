using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class UIMediator : Mediator<UIView>
    {
        [Inject] public ChoseBallColorButtonSignal ChoseBallColorButtonSignal { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public StopGameSignal StopGameSignal { get; set; }
        
        public override void OnRegister()
        {
            base.OnRegister();

            StartGameSignal.AddListener(() => View.gameObject.SetActive(true));
            StopGameSignal.AddListener(() => View.gameObject.SetActive(false));

            View.OnChooseBallColor += ChoseBallColorButtonSignal.Dispatch;
        }
    }
}