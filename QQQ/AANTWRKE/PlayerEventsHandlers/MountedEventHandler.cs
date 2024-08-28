using LogicLyric.PlayerEvents;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class MountedEventHandler : EventPacketHandler<MountedEvent>
    {

        PlayerHandler playerHandler;
        public MountedEventHandler() : base(EventCodes.Mounted) { }

        public MountedEventHandler(PlayerHandler playerHandler) : base(EventCodes.Mounted)
        {

            this.playerHandler = playerHandler;
        }

        protected override Task OnActionAsync(MountedEvent value)
        {


        //    playerHandler.UpdatePlayerMounted(int.Parse(value.Id), value.Mounted);

            return Task.CompletedTask;
        }
    }
}
