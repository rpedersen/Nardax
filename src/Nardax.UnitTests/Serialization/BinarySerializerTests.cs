using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nardax.Serialization;

namespace Nardax.UnitTests.Serialization
{
    [TestClass]
    public class BinarySerializerTests
    {
        [TestMethod]
        public void Serialize_ValidObject_RoundTripSuccessful()
        {
            var person = new Person { FirstName = "Ryan", Lastname = "Pedersen" };
            var serializer = new BinarySerializer<Person>();
            var serializedPerson = serializer.Serialize(person);

            var deserializedPerson = serializer.Deserialize(serializedPerson);

            Assert.AreEqual(person.FirstName, deserializedPerson.FirstName);
            Assert.AreEqual(person.Lastname, deserializedPerson.Lastname);
        }

        [Serializable]
        public class Person
        {
            public string FirstName { get; set; }

            public string Lastname { get; set; }
        }
    }
}
