using System;
using System.Collections.Generic;

namespace Profile.CSharp.Microservice
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person Supervisor { get; set; }
        public Person CareerCounselor { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<string> Emails { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
