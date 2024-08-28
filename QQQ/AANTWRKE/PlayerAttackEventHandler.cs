using LogicLyrico.Mobs;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class PlayerAttackEventHandler : EventPacketHandler<PlayerAttackEvent>
    {

        PlayerHandler playerHandler;
        public PlayerAttackEventHandler() : base(EventCodes.PlayerAttack) { }
        public PlayerAttackEventHandler(PlayerHandler playerHandler) : base(EventCodes.PlayerAttack)
        {

            this.playerHandler = playerHandler;
  

        }
        protected override Task OnActionAsync(PlayerAttackEvent value) {


            if(value.CurrentHealth == -1000000000)
            {
                return Task.CompletedTask;
            }

       
                playerHandler.UpdatePlayerHealth(int.Parse(value.Id), value.CurrentHealth);
            
          //  playerHandler.UpdatePlayerHealth(int.Parse(value.Id), value.CurrentHealth);

            return Task.CompletedTask;
        }
    }
}
