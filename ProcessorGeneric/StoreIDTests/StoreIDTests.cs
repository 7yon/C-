using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessorGeneric;

namespace ProcessorGenericTests
{
    [TestClass]
    public class StoreIDTests
    {

        [TestMethod]
        public void StoreID_TryCreateObject_MustReturnNewObject()
        {
            var a = StoreID.Create<MyLogger>();

            Assert.AreEqual(new MyLogger().GetType(), a.GetType());
        }

        [TestMethod]
        public void StoreID_TryGetAllObjectSpecificType_MustReturnNULL()
        {
            StoreID.Create<MyLogger>();
            StoreID.Create<MyEngine>();
            StoreID.Create<MyEngine>();
            StoreID.Create<MyEntity>();

            var a = StoreID.OutAllPair<MyEngine>();

            Assert.AreEqual(2, a.Count);
        }

        [TestMethod]
        public void StoreID_TryGetObjectFromIncorrectId_MustReturnNULL()
        {
            StoreID.Create<MyLogger>();
            StoreID.Create<MyEngine>();
            StoreID.Create<MyEngine>();
            StoreID.Create<MyEntity>();

            var a = StoreID.Find<MyEntity>(Guid.NewGuid());

            Assert.AreEqual(null, a);
        }

    }
}
