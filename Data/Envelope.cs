using System;
using System.Collections.Generic;

namespace Profile.CSharp.Microservice
{
    public class Envelope<T>
    {
        public T Data { get; set; }

        public Envelope(T data)
        {
            Data = data;
        }
    }
}
