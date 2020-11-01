using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class PauseGameCommand : Command
    {
        public override void Execute()
        {
            Time.timeScale = 0f;
        }
    }
}