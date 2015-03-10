using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nardax.Serialization;

namespace Nardax.Tests.Serialization
{
    [TestClass]
    public class XmlSerializerTests
    {
        [TestMethod]
        public void Serialize_ValidObject_RoundTripSuccessful()
        {
            var person = new Person { FirstName = "Ryan", Lastname = "Pedersen" };
            var serializer = new XmlSerializer<Person>();
            var serializedPerson = serializer.Serialize(person);

            var deserializedPerson = serializer.Deserialize(serializedPerson);

            Assert.AreEqual(person.FirstName, deserializedPerson.FirstName);
            Assert.AreEqual(person.Lastname, deserializedPerson.Lastname);
        }

        public class Person
        {
            public string FirstName { get; set; }

            public string Lastname { get; set; }
        }
    }
}