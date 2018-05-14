using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibDemoTest.app_code
{
    public class ClsFamilyRental
    {
        private static ClsFamilyRental thisObjectInstance = null;

        private const int minLimit = 3;
        private const int maxLimit = 5;
        private int idFamilyRental;
        private double _discountRental;
        private double _totalRental;
        private List<ClsRental> _rentals;

        public int GetIdFamilyRental()
        {
            return idFamilyRental;
        }

        public void SetIdFamilyRental(int value)
        {
            idFamilyRental = value;
        }

        public double DiscountRental { get => _discountRental; set => _discountRental = value; }
        public double TotalRental { get => _totalRental; set => _totalRental = value; }
        public List<ClsRental> Rentals { get => _rentals; set => _rentals = value; }

        public static int MaxLimit => maxLimit;

        public static int MinLimit => minLimit;

        public static ClsFamilyRental GetInstance()
        {
            if (thisObjectInstance == null)
            {
                thisObjectInstance = new ClsFamilyRental
                {
                    Rentals = new List<ClsRental>()
                };
            }

            return thisObjectInstance;
        }

        public double GetDiscount(ICollection<ClsRental> Rentals)
        {
            double discount = 0;
            const int discountPerFamilyRental = 30;

            try
            {
                if ((Rentals.Count() > MinLimit) && (Rentals.Count < MaxLimit))
                    discount = Rentals.Sum(z => Convert.ToDouble(z.TotalRental)) * discountPerFamilyRental / 100;
            }
            catch (InvalidCastException ex)
            {
                Console.Write("InvalidCastException, message: " + ex.Message.ToString());
                throw;
            }
            catch (Exception ex)
            {
                Console.Write("Exception, message: " + ex.Message.ToString());
                throw;
            }

            return discount;
        }

    }
}
