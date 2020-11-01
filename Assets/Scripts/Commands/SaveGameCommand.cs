using Services;
using strange.extensions.command.impl;

namespace Commands
{
    public class SaveGameCommand : Command
    {
        [Inject] public IPlayerDataService PlayerDataService { get; set; }
        
        public override void Execute()
        {
            PlayerDataService.Save();
        }
    }
}