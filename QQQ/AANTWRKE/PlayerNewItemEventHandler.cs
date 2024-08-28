using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class PlayerNewItemEventHandler : EventPacketHandler<PlayerNewItemEvent>
    {

        PlayerHandler playerHandler;
        public PlayerNewItemEventHandler() : base(EventCodes.WearItem) { }

        public PlayerNewItemEventHandler(PlayerHandler playerHandler) : base(EventCodes.WearItem)
        {

            this.playerHandler = playerHandler;
        }

        protected override Task OnActionAsync(PlayerNewItemEvent value)
        {

            if(value.Items == null)
            {
                return Task.CompletedTask;
            }

      
                playerHandler.UpdatePlayerItem(int.Parse(value.Id), value.Items);
            
     
            return Task.CompletedTask;

        }
    }
}
