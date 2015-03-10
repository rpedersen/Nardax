using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nardax.Tests
{
    [TestClass]
    public class AsseblyExtensionsTests
    {
        [TestMethod]
        public void GetAppSettingsValue_ValidKey_ReturnsValue()
        {
            var validKey = "ValidKey";
            var expectedAppSettingVlaue = "SomeValue";

            var assembly = Assembly.GetExecutingAssembly();
            var actualAppSettingValue = assembly.GetAppSettingsValue(validKey);

            Assert.AreEqual(expectedAppSettingVlaue, actualAppSettingValue);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetAppSettingsValue_InvalidKey_ThrowsException()
        {
            var invalidKey = "InvalidSetting";

            var assembly = Assembly.GetExecutingAssembly();
            assembly.GetAppSettingsValue(invalidKey);

            Assert.Fail();
        }
    }
}