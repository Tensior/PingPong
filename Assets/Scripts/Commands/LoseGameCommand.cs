﻿using Signals;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    public class LoseGameCommand : Command
    {
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        public override void Execute()
        {
            Debug.Log("LoseGameCommand");
            //blabla...
            StartGameSignal.Dispatch();
        }
    }
}