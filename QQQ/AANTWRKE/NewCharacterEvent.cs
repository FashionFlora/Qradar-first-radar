using System;
using System.Collections.Generic;
using System.Linq;
using LogicLyric.AAParser;
using System.Collections.Generic;
namespace LogicLyric
{
    public class NewCharacterEvent : BaseEvent
    {
        public NewCharacterEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            Id = parameters[0].ToString();
            Name = parameters[1].ToString();

     
            GuildName = parameters.TryGetValue(8, out object guildName) ? guildName.ToString() : null;

  
            Position = ObjectConverter.ConvertArray<float>((object[])parameters[14]);

     
            Alliance = parameters.TryGetValue(44, out object alliance) ? alliance.ToString() : null;
        

            try
            {

                Items = ObjectConverter.ConvertArray<short>((object[])parameters[38]);
            }

            catch
            {

            
            }
    

            InitialHealth = ObjectConverter.ConvertTo<float>(parameters[20]);
            try
            {
                CurrentHealth = ObjectConverter.ConvertTo<float>(parameters[20]);
            }
            catch
            {
                CurrentHealth = InitialHealth;
            }

    







        }

        public string Id { get; }
        public string Name { get; }
        public string GuildName { get; }

        public string Alliance { get; }
        public Single[] Position { get; }

        public Single CurrentHealth { get; }
        public Single InitialHealth { get; }

        public Int16[] Items { get; }
    }
}
