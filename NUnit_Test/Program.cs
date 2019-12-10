using System;
using NUnit.Framework;
using NUnit.Compatibility;
using Lab_008_TDD_Collections;
using Lab_009_Rabbit_Test;
using System.Security.Cryptography;
using Lab_020_Northwind_Product;
using Lab_014_LINQ;
using Lab_026_Fibibacci;

namespace NUnit_Test
{
    class NUnit_Test
    {
        // annotations
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void RunThisTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestCase(4, 2, 7, 6, 9, 541)]
        [TestCase(65, 32, 2, 56, 30, 11214)]
        [TestCase(4, 34, 2, 5, 26, 2662)]
        [TestCase(6, 4, 3, 1, 2, 301)]
        public void ArrayListDictionaryGetTotal(int a,int b, int c, int d, int e, int expected)
        {
            int anwser = ArrayListDictionarySnapLab.GetSnapLabTotal(a, b, c, d, e);

            Assert.AreEqual(expected,anwser);
        }

        [TestCase(3, 7, 8)]
        [TestCase(4, 15, 16)]
        [TestCase(5, 31, 32)]
        public void TestRabbitGrowth(int years, int  expectAgeTotal, int rabbitCount)
        {
            (int ageTotal, int actualRabbitCount) = RabbitCollection.MultiplyRabbits(years);

            Assert.AreEqual(ageTotal, expectAgeTotal);
            Assert.AreEqual(actualRabbitCount, rabbitCount);
        }

        [TestCase(3, 3, 1)]
        [TestCase(4, 4, 2)]
        [TestCase(5, 6, 3)]
        [TestCase(6, 9, 4)]
        public void TestRabbitGrowthWithAgesOverThree(int years, int expectAgeTotal, int rabbitCount)
        {
            (int ageTotal, int actualRabbitCount) = RabbitCollection.MultiplyRabbitsAboveAgeThree(years);

            Assert.AreEqual(expectAgeTotal, ageTotal);
            Assert.AreEqual(rabbitCount, actualRabbitCount);
        }

        #region Test Number Pf Northwind Customers

        [TestCase(null, 103)]
        [TestCase("London", 18)]
        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
            var n = new Lab_014_LINQ.NorthwindDb();

            Assert.AreEqual(expected, n.CountNorthwind(city));
        }

        #endregion

        #region Test Number Of Products

        [TestCase(3)]
        public void TestNumberOfProductsBeginingWithP(int expected)
        {
            Products p = new Products();
            int actual = p.GetProduct();
            Assert.AreEqual(expected, actual);
        }
        [TestCase("P", 3)]
        public void TestNumberOfProductsBeginingWithALetter(string s, int expected)
        {
            Products p = new Products();
            int actual = p.GetProductWithLetter(s);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("P", 17)]
        [TestCase("A", 58)]
        [TestCase("H", 27)]
        public void TestNumberOfProductsContainsALetter(string s, int expected)
        {
            Products p = new Products();
            int actual = p.GetProductContainsLetter(s);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Fibonacci Tests

        [TestCase(3,3)]
        [TestCase(4,5)]
        [TestCase(5,7)]
        public void TestNthFibSequance(int i, int expected)
        {

            Assert.AreEqual(expected, Fibobacci.ReturnFibonacciNthItemInSequenece(i));
        }

        #endregion

    }
}
