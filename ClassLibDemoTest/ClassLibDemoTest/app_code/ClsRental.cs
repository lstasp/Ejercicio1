using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibDemoTest.app_code
{
    public class ClsRental
    {
        public enum PeriodTypeEnum
        {
            Hour = 0,
            Day = 1,
            Week = 2
        }

        private static ClsRental thisObjectInstance = null;
        private Guid _idRental;
        private DateTime _startDateRental;
        private DateTime _endDateRental;
        private double _totalRental;

        public Guid IdRental { get => _idRental; set => _idRental = value; }
        public DateTime StartDateRental { get => _startDateRental; set => _startDateRental = value; }
        public DateTime EndDateRental { get => _endDateRental; set => _endDateRental = value; }
        public double TotalRental { get => _totalRental; set => _totalRental = value; }

        public const double hourTimeRentalPrice = 5;
        public const double dayTimeRentalPrice = 20;
        public const double weekTimeRentalPrice = 60;

        public static ClsRental GetInstance()
        {
            if (thisObjectInstance == null)
                thisObjectInstance = new ClsRental();

            return thisObjectInstance;
        }

        public ClsRental RentTotal(DateTime start, DateTime end)
        {
            ClsRental Rent = new ClsRental
            {
                IdRental = new Guid()
            };

            try
            {
                TimeSpan diff = end.Subtract(start);
                Rent.StartDateRental = start;
                Rent.EndDateRental = end;

                if (diff.Ticks > 0)
                {
                    Rent.TotalRental = Convert.ToDouble
                        (Rent.RentalByPeriod(diff.Days, PeriodTypeEnum.Day).TotalRental +
                        Rent.RentalByPeriod(diff.Hours, PeriodTypeEnum.Hour).TotalRental +
                        (diff.Days >= 7 ? Rent.RentalByPeriod(diff.Days / 7, PeriodTypeEnum.Week).TotalRental : 0));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception, message: " + ex.Message.ToString());

                return null;
            }

            return Rent;
        }

        public ClsRental RentalByPeriod(int PeriodNumber, PeriodTypeEnum PeriodType)
        {
            ClsRental Rent = new ClsRental();

            try
            {
                switch (PeriodType)
                {
                    case PeriodTypeEnum.Hour:
                        Rent.TotalRental = PeriodNumber * hourTimeRentalPrice;
                        break;
                    case PeriodTypeEnum.Day:
                        Rent.TotalRental = PeriodNumber * dayTimeRentalPrice;
                        break;
                    case PeriodTypeEnum.Week:
                        Rent.TotalRental = PeriodNumber * weekTimeRentalPrice;
                        break;
                }

            }
            catch (ObjectDisposedException ex)
            {
                Console.Write("ObjectDisposedException, message: " + ex.Message.ToString());
                throw;
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

            return Rent;
        }

    }
}
