using System;
using System.Threading.Tasks;
using LogicLyric.Core;
using System.Collections.Generic;
namespace LogicLyric
{
    public class MoveRequestHandler : RequestPacketHandler<MoveOperation>
    {
        PlayerHandler playerHandler;
        public MoveRequestHandler() : base(OperationCodes.Move) { }
        public MoveRequestHandler(PlayerHandler playerHandler) : base(OperationCodes.Move)
        {

            this.playerHandler = playerHandler;
        
        
        }
        protected override Task OnActionAsync(MoveOperation value)
        {






            lock (StaticLocks.localLock)
            {


                playerHandler.UpdateLocalPlayerPosition(value.Position[0], value.Position[1]);
            }




            return Task.CompletedTask;
        }


    }
}
