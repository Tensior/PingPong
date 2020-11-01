using Signals;
using UnityEngine;

namespace Models
{
    class BallModel : IBallModel
    {
        [Inject] public BallColorChangedSignal BallColorChangedSignal { get; set; }
        [Inject] public SaveGameSignal SaveGameSignal { get; set; }

        public Color Color 
        {
            get => _color;
            set
            {
                _color = value;
               BallColorChangedSignal.Dispatch(_color);
               SaveGameSignal.Dispatch();
            }
        }

        private Color _color = Color.yellow;
    }
}