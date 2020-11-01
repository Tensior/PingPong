using Models;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class SetBallColor : Command
    {
        [Inject] public Color BallColor { get; set; }
        [Inject] public IBallModel BallModel { get; set; }
        
        public override void Execute()
        {
            BallModel.Color = BallColor;
        }
    }
}