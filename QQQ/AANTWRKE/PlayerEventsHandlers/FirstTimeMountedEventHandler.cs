using LogicLyric.PlayerEvents;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric
{
    public class FirstTimeMountedEventHandler : EventPacketHandler<FirstTimeMountedEvent>
    {

        PlayerHandler playerHandler;
        public FirstTimeMountedEventHandler() : base(EventCodes.FirstTimeMounted) { }

        public FirstTimeMountedEventHandler(PlayerHandler playerHandler) : base(EventCodes.FirstTimeMounted)
        {

            this.playerHandler = playerHandler;
        }

        protected override Task OnActionAsync(FirstTimeMountedEvent value)
        {


            bool mounted = false;


  

            if(value.Mounted11)
            {
                playerHandler.UpdatePlayerMounted(int.Parse(value.Id), true);
                mounted = true;
         
                return Task.CompletedTask;
            }
            if (value.Ten.Equals("-1"))
            {
                playerHandler.UpdatePlayerMounted(int.Parse(value.Id), true);

                mounted = true;
            
            }
            else
            {
                playerHandler.UpdatePlayerMounted(int.Parse(value.Id), false);
                mounted = false;

            }



   

       

            return Task.CompletedTask;
        }
    }
}
