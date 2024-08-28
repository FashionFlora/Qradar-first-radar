using LogicLyric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicLyric.AAParser;

namespace LogicLyric.HarvestableCodes
{
    public class NewSimpleHaverstableObjectListEvent : BaseEvent
    {

        public NewSimpleHaverstableObjectListEvent(Dictionary<byte, object> parameters) : base(parameters)
        {


        

            a0 = ObjectConverter.ConvertArray<int>((object[])parameters[0]).ToList();
        


            a1 = (Byte[])parameters[1];


            a2 = (Byte[])parameters[2];

     
            a3 = ObjectConverter.ConvertArray<Single>((object[])parameters[3]);

            a4 = (Byte[])parameters[4];




        }

        public List<int> a0 { get; }
        public Byte[] a1 { get; }
        public Byte[] a2 { get; }
        public Single[] a3 { get; }
        public Byte[] a4 { get; }



    }


}