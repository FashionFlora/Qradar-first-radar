using LogicLyric;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLyric.HarvestableCodes
{
    public class MobChangeStateEvent : BaseEvent
    {

        public MobChangeStateEvent(Dictionary<byte, object> parameters) : base(parameters)
        {

            int mobId = 0;
            byte enchantmentLevel = 0;
            if (!int.TryParse(parameters[0].ToString(), out mobId))
            {
                return;
            }
     
            if (!byte.TryParse(parameters[1].ToString(), out enchantmentLevel))
            {
                return;
            }

         
            this.mobId = mobId;
            this.enchantmentLevel = enchantmentLevel;

        }

        public int mobId { get; }
        public byte enchantmentLevel { get; }





    }
}
