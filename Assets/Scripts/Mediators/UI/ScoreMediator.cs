using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class ScoreMediator : Mediator<ScoreView>
    {
        [Inject] public CurrentScoreChangedSignal CurrentScoreChangedSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            CurrentScoreChangedSignal.AddListener(View.SetCurrentScore);
        }
    }
}