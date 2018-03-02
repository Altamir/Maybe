using System;
using System.Collections.Generic;
using System.Linq;
using Alt.Utils.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaybeTests
{
    public class Car
    {
        public string name { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Imay_not_null()
        {
            IMaybe<Car> mayCar = Maybe<Car>.None;
            Assert.IsNotNull(mayCar);
        }

        [TestMethod]
        public void Test_Imay_not()
        {
            IMaybe<Car> mayCar = default(Maybe<Car>);

            Assert.IsNotNull(mayCar);
            Assert.IsFalse(mayCar.HasValue);
        }

        [TestMethod]
        public void Test_tentar_pegar_valor_caom_error()
        {
            IMaybe<Car> mayCar = default(Maybe<Car>);

            Assert.IsNotNull(mayCar);
            Assert.IsFalse(mayCar.HasValue);
            Assert.IsNull(mayCar.Value);
            Assert.AreEqual(mayCar.Error, "Sem valor");
        }

        [TestMethod]
        public void Test_Imay_Sem_Valo()
        {
            IMaybe<Car> mayCar = Maybe<Car>.None;
            Assert.IsTrue(!mayCar.HasValue);
        }

        [TestMethod]
        public void Test_Imay_Sem_valor_com_msg_error()
        {
            IMaybe<Car> mayCar = Maybe<Car>.WithErrors(new List<string> { "Error test" });
            Assert.IsTrue(!mayCar.HasValue);
            Assert.AreEqual(mayCar.Errors.Single(), "Error test");
        }

        [TestMethod]
        public void Test_Imay_Com_valor_()
        {
            IMaybe<Car> mayCar = Maybe<Car>.Some(new Car() { name = "car test" });
            Assert.IsTrue(mayCar.HasValue);
            Assert.AreEqual(mayCar.Value.name, "car test");
        }


    }
}
