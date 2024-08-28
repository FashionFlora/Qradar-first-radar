using Crypt.AAParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.AAParser;

public class PhotonCommand
{
    public ProtocolParser Parent { get; private set; }
    public BinaryReader Payload { get; private set; }
    public byte CommandType { get; private set; }
    public byte ChannelId { get; private set; }
    public byte CommandFlags { get; private set; }
    public uint CommandLength { get; private set; }
    public uint SequenceNumber { get; private set; }
    public byte MessageType { get; private set; }
    public object Data { get; private set; }

    public PhotonCommand(ProtocolParser parent, BinaryReader payloadStream)
    {
        Parent = parent;
        Payload = payloadStream;
        ParseCommand();
    }

    private void ParseCommandHeader()
    {
        CommandType = Payload.ReadByte();
 
        ChannelId = Payload.ReadByte();

        CommandFlags = Payload.ReadByte();

       Payload.BaseStream.Position += 1; // Skip one byte
        CommandLength = BinaryReaderExtensions.ReadBigEndian<uint>(Payload);
 
        SequenceNumber = BinaryReaderExtensions.ReadBigEndian<uint>(Payload);

        var remainingBytes = (int)(CommandLength - 12);

        var remainingData = Payload.ReadBytes(remainingBytes);
        Payload = new BinaryReader(new MemoryStream(remainingData));
    }

    private void ParseCommand()
    {
        ParseCommandHeader();

        switch (CommandType)
        {
            case 7:
                Payload.BaseStream.Position += 4;
                goto case 6; // Continue with case 6
            case 6:
                ParseReliableCommand();
                break;
            case 4:
                // Disconnect
                break;
        }
    }

    private void ParseReliableCommand()
    {
        Payload.BaseStream.Position += 1;
        MessageType = Payload.ReadByte();

     
        switch (MessageType)
        {
            case 2:
                byte operationCode = this.Payload.ReadByte();
                Parent.OnRequest(operationCode, Protocol16Deserializer.DeserializeOperationRequest(this.Payload));
                break;
            case 3:
                byte responseCode = this.Payload.ReadByte();
                Parent.OnRequest(responseCode, Protocol16Deserializer.DeserializeOperationRequest(this.Payload));
                break;
            case 4:
                byte eventCode = this.Payload.ReadByte();
                Parent.OnEvent(eventCode, Protocol16Deserializer.DeserializeEventData(this.Payload));
                break;
        }
    }
}