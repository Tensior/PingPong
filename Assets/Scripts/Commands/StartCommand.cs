using Signals;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
    /// <summary>
    /// Главная комманда, запускающая игру
    /// </summary>
    public class StartCommand : Command
    {
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        
        public override void Execute()
        {
            Debug.Log("StartCommand");
            //подготовка
            
            StartGameSignal.Dispatch();
        }
    }
}