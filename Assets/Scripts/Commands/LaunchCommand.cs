using Services;
using Signals;
using strange.extensions.command.impl;

namespace Commands
{
    /// <summary>
    /// Главная комманда, запускающая игру
    /// </summary>
    public class LaunchCommand : Command
    {
        [Inject] public IPlayerDataService PlayerDataService { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        
        public override void Execute()
        {
            PlayerDataService.Load();
            StartGameSignal.Dispatch();
        }
    }
}