using Crypt.AAParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.AAParser
{

    public class PhotonPacket
    {
        public ProtocolParser Parent { get; private set; }
  
        public BinaryReader Payload { get; private set; }
        public ushort PeerId { get; private set; }
        public byte Flags { get; private set; }
        public byte CommandCount { get; private set; }
        public uint Timestamp { get; private set; }
        public uint Challenge { get; private set; }
        public List<PhotonCommand> Commands { get; private set; }

        public PhotonPacket(ProtocolParser parent, Byte[] payload)
        {
            Parent = parent;

            MemoryStream memoryStream = new MemoryStream(payload);
            Payload = new BinaryReader(memoryStream);
            Commands = new List<PhotonCommand>();
            ParsePacket();
        }

        private void ParsePhotonHeader()
        {
            PeerId = Payload.ReadUInt16();
   
            Flags = Payload.ReadByte();

            CommandCount = Payload.ReadByte();





      
            Timestamp = BinaryReaderExtensions.ReadBigEndian<uint>(Payload);
       
            Challenge  = BinaryReaderExtensions.ReadBigEndian<uint>(Payload);
   
        }

        private void ParsePacket()
        {
            ParsePhotonHeader();

            for (int i = 0; i < CommandCount; i++)
            {

                Commands.Add(new PhotonCommand(Parent, Payload));

            }
        }
    }

}
