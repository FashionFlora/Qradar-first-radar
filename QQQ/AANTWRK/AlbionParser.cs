
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using LogicLyric.AAParser;


namespace LogicLyric
{

    
    public  class AlbionParser : ProtocolParser
    {
        private readonly HandlersCollection handlers;


        

        public AlbionParser()
        {

            handlers = new HandlersCollection();

        }

        public void AddHandler<TPacket>(PacketHandler<TPacket> handler)
        {
            handlers.Add(handler);
        }
  

        public  override void OnEvent(byte Code, Dictionary<byte, object> Parameters)
        {

            if (Code == 3)
            {
                const short Move = 3;
                Parameters.Add(252, Move);

            }



            short eventCode = 0;
            try
            {
                eventCode = short.Parse(Parameters[252].ToString());
            }
            catch(Exception e)
            {
                return;

            }


            if(eventCode == 27)
            {
                /*
                Console.Write("event code:" + eventCode + " ");
                foreach (var pair in Parameters)
                {
                    Console.Write($"  {pair.Key}  {pair.Value}");
                }
                Console.WriteLine(" ");
                */
            }

                    





            var eventPacket = new EventPacket(eventCode, Parameters);


           _ = handlers.HandleAsync(eventPacket);


        }

        public override void OnRequest(byte OperationCode, Dictionary<byte, object> Parameters)
        {
            short operationCode = 0;

            try
            {
                operationCode = short.Parse(Parameters[253].ToString());
            }
            catch (Exception e)
            {
                return;

            }
      

            




            var requestPacket = new RequestPacket(operationCode, Parameters);
            _ = handlers.HandleAsync(requestPacket);



        }

        public override void OnResponse(byte OperationCode, Dictionary<byte, object> Parameters)
        {


        }

        private short ParseOperationCode(Dictionary<byte, object> parameters)
        {

  
            if (!parameters.TryGetValue(253, out object value))
            {
                throw new InvalidOperationException();
            }



            return (short)value;
        }

        private short ParseEventCode(Dictionary<byte, object> parameters)
        {



 
            
            
            

            if (!parameters.TryGetValue(252, out object value))
            {
                throw new InvalidOperationException();
            }





            return (short)value;
        }


    }
}
