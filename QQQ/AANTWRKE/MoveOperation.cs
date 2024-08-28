using System;
using System.Collections.Generic;
using LogicLyric.AAParser;
using System.Collections.Generic;
namespace LogicLyric
{
    public class MoveOperation : BaseOperation
    {
        public MoveOperation(Dictionary<byte, object> parameters) : base(parameters)
        {


            //  Time = parameters[0].ToString();

       
       
            Position = ObjectConverter.ConvertArray<float>((object[])parameters[1]);

       
            //NewPosition = (float[])parameters[3];


            // Speed = (float)parameters[4];


        }



        public string Time { get; }
        public Single[] Position { get; }
        public float Direction { get; }
        public float[] NewPosition { get; }
        public float Speed { get; }
    }
}
