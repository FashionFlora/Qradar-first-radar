using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class PlayerRegenEventHandler : EventPacketHandler<PlayerRegenEvent>
    {

        PlayerHandler playerHandler;
        public PlayerRegenEventHandler() : base(EventCodes.HealthRegen) { }

        public PlayerRegenEventHandler(PlayerHandler playerHandler) : base(EventCodes.HealthRegen)
        {

            this.playerHandler = playerHandler;
        }

        protected override Task OnActionAsync(PlayerRegenEvent value)
        {

            if(value.HealthRegen ==-10)
            {

                return Task.CompletedTask;
            }


            playerHandler.UpdatePlayerHealth(int.Parse(value.Id), value.InitialHealth);
            return Task.CompletedTask;
        }
    }
}
