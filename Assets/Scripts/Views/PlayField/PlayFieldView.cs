using System.Threading.Tasks;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    public class PlayFieldView : View
    {
        [SerializeField] private BallView _ball;
        [SerializeField] private PlayerPlatformView _playerPlatform;
        [SerializeField] private Transform _fieldSides;

        protected override void OnEnable()
        {
            base.OnEnable();
            SetContentActive(true);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            SetContentActive(false);
        }

        private async void SetContentActive(bool isActive)
        {
            _playerPlatform.gameObject.SetActive(isActive);
            foreach (Transform side in _fieldSides)
            {
                {
                    side.gameObject.SetActive(isActive);
                }
            }
            
            if (isActive)
            {
                //Задержка перед появлением мячика, чтобы для игрока было не так внезапно
                await Task.Delay(1000);
            }
            _ball.gameObject.SetActive(isActive);
        }
    }
}