using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class UnpauseGameCommand : Command
    {
        public override void Execute()
        {
            Time.timeScale = 1f;
        }
    }
}