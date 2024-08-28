using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class PlayerChangeEventHandler : EventPacketHandler<PlayerChangeItemEvent>
    {

        PlayerHandler playerHandler;
        public PlayerChangeEventHandler() : base(EventCodes.ChangeItem) { }

        public PlayerChangeEventHandler(PlayerHandler playerHandler) : base(EventCodes.ChangeItem)
        {

            this.playerHandler = playerHandler;
        }

        protected override Task OnActionAsync(PlayerChangeItemEvent value)
        {

         
                playerHandler.UpdatePlayerInitialHealth(int.Parse(value.Id), value.CurrentHealth, value.InitialHealth);
            
          //  playerHandler.UpdatePlayerInitialHealth(int.Parse(value.Id), value.CurrentHealth, value.InitialHealth);

            return Task.CompletedTask;
        }
    }
}
