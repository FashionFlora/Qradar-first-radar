using LogicLyric.AAParser;
using System.Collections.Generic;
namespace LogicLyric
{
    public class ReceiverBuilder
    {
        private  AlbionParser parser;

        public AlbionParser Parser { get => parser; set => parser = value; }

        public ReceiverBuilder()
        {
            parser = new AlbionParser();
        }

        public static ReceiverBuilder Create()
        {
            return new ReceiverBuilder();
        }

        public ReceiverBuilder AddHandler<TPacket>(PacketHandler<TPacket> handler)
        {
            parser.AddHandler(handler);

            return this;
        }

        public ReceiverBuilder AddEventHandler<TEvent>(EventPacketHandler<TEvent> handler) where TEvent : BaseEvent
        {
            AddHandler(handler);

            return this;
        }

        public ReceiverBuilder AddRequestHandler<TOperation>(RequestPacketHandler<TOperation> handler) where TOperation : BaseOperation
        {
            AddHandler(handler);

            return this;
        }

        public ReceiverBuilder AddResponseHandler<TOperation>(ResponsePacketHandler<TOperation> handler) where TOperation : BaseOperation
        {
            AddHandler(handler);

            return this;
        }

        public ProtocolParser Build()
        {
            return parser;
        }
    }
}
