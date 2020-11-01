using Signals;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class PlayFieldMediator : Mediator<PlayFieldView>
    {
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public StopGameSignal StopGameSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            StartGameSignal.AddListener(() =>
            {
                View.gameObject.SetActive(true);
            });
            StopGameSignal.AddListener(() =>
            {
                View.gameObject.SetActive(false);
            });
        }
    }
}