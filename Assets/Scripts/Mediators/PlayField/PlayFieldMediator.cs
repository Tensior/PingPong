using Signals;
using UnityEngine;
using Views.PlayField;

namespace Mediators.PlayField
{
    public class PlayFieldMediator : Mediator<PlayFieldView>
    {
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public StopGameSignal stopGameSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            StartGameSignal.AddListener(() =>
            {
                Debug.Log("StartGameSignal Listener");
                View.gameObject.SetActive(true);
            });
            stopGameSignal.AddListener(() =>
            {
                Debug.Log("StopGameSignal Listener");
                View.gameObject.SetActive(false);
            });
        }
    }
}