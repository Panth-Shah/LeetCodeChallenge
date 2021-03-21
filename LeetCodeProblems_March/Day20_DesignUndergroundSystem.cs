using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day20_DesignUndergroundSystem
    {
        private CustomerRecord customerRecordKeeper;
        public Day20_DesignUndergroundSystem()
        {
            customerRecordKeeper = new CustomerRecord();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            customerRecordKeeper.CustomerCheckIn(id, stationName, t);
        }

        public void CheckOut(int id, string stationName, int t)
        {
            customerRecordKeeper.CustomerCheckOut(id, stationName, t);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            double res = 0;
            return res;
        }
    }

    /**
     * Your UndergroundSystem object will be instantiated and called as such:
     * UndergroundSystem obj = new UndergroundSystem();
     * obj.CheckIn(id,stationName,t);
     * obj.CheckOut(id,stationName,t);
     * double param_3 = obj.GetAverageTime(startStation,endStation);
     */

    public class CustomerRecord
    {
        private readonly Dictionary<int, List<CustomerTrips>> customerTripsDict = new Dictionary<int, List<CustomerTrips>>();
        public CustomerRecord()
        {

        }

        public void CustomerCheckIn(int customerId, string checkInStation, int checkInTime)
        {
            if (!customerTripsDict.ContainsKey(customerId))
            {
                customerTripsDict.Add(customerId, new List<CustomerTrips>());
            }

            customerTripsDict[customerId].Add(new CustomerTrips(checkInStation, checkInTime));
        }

        public void CustomerCheckOut(int cusomerId, string checkOutStation, int checkOutTime)
        {
            if (customerTripsDict.ContainsKey(cusomerId))
            {
                var activeTrip = customerTripsDict[cusomerId].Where(p => !p.IsTripCompleted).FirstOrDefault();
                activeTrip.CheckOutLocation = checkOutStation;
                activeTrip.CheckOutTime = checkOutTime;
                activeTrip.IsTripCompleted = true;
                //Only set Trip record upon checkout
            }
        }
    }

    public class TripRecord
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int TotalTimeTaken { get; set; }
        public int TotalTripTaken { get; set; }
        public TripRecord()
        {

        }
    }

    public class CustomerTrips
    {

        public string CheckInLocation { get; set; }
        public int CheckInTime { get; set; }
        public string CheckOutLocation { get; set; }
        public int CheckOutTime { get; set; }
        public bool IsTripCompleted { get; set; }
        public int AveragetravelTime { get; set; }

        public CustomerTrips(string checkInLocation, int checkInTime)
        {
            this.CheckInLocation = checkInLocation;
            this.CheckInTime = checkInTime;
            this.IsTripCompleted = false; 
        }
    }
}
