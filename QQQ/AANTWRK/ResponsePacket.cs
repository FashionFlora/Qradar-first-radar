﻿using System.Collections.Generic;

namespace LogicLyric
{
    public class ResponsePacket
    {
        public ResponsePacket(short operationCode, Dictionary<byte, object> Parameters)
        {



            OperationCode = operationCode;
            this.Parameters = Parameters;

        }

        public short OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
