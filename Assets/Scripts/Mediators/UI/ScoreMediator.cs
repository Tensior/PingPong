using Models;
using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class ScoreMediator : Mediator<ScoreView>
    {
        [Inject] public CurrentScoreChangedSignal CurrentScoreChangedSignal { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public LoseGameSignal LoseGameSignal { get; set; }
        [Inject] public IScoreModel ScoreModel { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            CurrentScoreChangedSignal.AddListener(View.SetCurrentScore);
            StartGameSignal.AddListener(() =>
            {
                View.gameObject.SetActive(true);
                View.SetBestScore(ScoreModel.BestScore);
            });
            LoseGameSignal.AddListener(() => View.gameObject.SetActive(false));
        }
    }
}