using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.AAParser
{
    public abstract class ProtocolParser 
    {
        public virtual  void OnEvent(byte code, Dictionary<byte, object> parameters)
        {
     
        }

        public virtual void OnRequest(byte operationCode, Dictionary<byte, object> parameters)
        {
       
        }


        public virtual void OnResponse(byte operationCode, Dictionary<byte, object> parameters)
        {
       
        }

        public void ReceivePacket(byte[] payload)
        {

            PhotonPacket photonPacket = new PhotonPacket(this , payload);
        }
    }
}
