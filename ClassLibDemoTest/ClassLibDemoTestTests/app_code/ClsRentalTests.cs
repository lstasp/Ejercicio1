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
    public class ClsRentalTests
    {
        [Test()]
        public void RentTotalTest()
        {
            ClsRental Rental = new ClsRental();
            ClsRental RentalResult = 
                Rental.RentTotal(DateTime.Now, DateTime.Now.AddDays(-3));

            Assert.IsNull(RentalResult);
        }

        [Test()]
        public void RentTotalTest1()
        {
            ClsRental Rental = new ClsRental();
            ClsRental RentalResult = 
                Rental.RentTotal(DateTime.Now, DateTime.Now.AddDays(3));

            Assert.AreEqual(expected: 60d, actual: RentalResult.TotalRental);
        }

        [Test()]
        public void RentalByPeriodTest()
        {
            ClsRental Rental = new ClsRental();
            ClsRental RentalResult = 
                Rental.RentalByPeriod(3, ClsRental.PeriodTypeEnum.Day);

            Assert.AreEqual(expected: 60d, actual: RentalResult.TotalRental);
        }
    }
}