using NUnit.Framework;
using ClassLibDemoTest.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDemoTest.app_code.Tests
{
    [TestFixture()]
    public class ClsFamilyRentalTests
    {
        [Test()]
        public void GetDiscountTest()
        {
            ClsFamilyRental FamilyRental = new ClsFamilyRental();
            List<ClsRental> RentalList = new List<ClsRental>();

            for (int i = 0; i < ClsFamilyRental.MaxLimit - 1; i++)
            {
                ClsRental AuxRent = new ClsRental();
                AuxRent.TotalRental = 10;
                RentalList.Add(AuxRent);
            }

            double result = FamilyRental.GetDiscount(RentalList);
            Assert.AreEqual(12, result);
        }
    }
}