using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day20_DesignUndergroundSystem
    {
        //Note: With this version of code, I am not keeping track of all the completed trips of the customer,
        //I am only tracking trip record for the trips happened directly between StartStation and EndStation
        private CustomerRecord customerRecordKeeper;
        private Dictionary<string, TripRecord> tripRecordKeeper;
        public Day20_DesignUndergroundSystem()
        {
            customerRecordKeeper = new CustomerRecord();
            tripRecordKeeper = new Dictionary<string, TripRecord>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            customerRecordKeeper.CustomerCheckIn(id, stationName, t);
        }

        public void CheckOut(int id, string stationName, int t)
        {
            customerRecordKeeper.CustomerCheckOut(id, stationName, t, ref tripRecordKeeper);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            string key = $"{startStation}{endStation}";
            double res;
            if (tripRecordKeeper.ContainsKey(key))
            {
                res = (double)tripRecordKeeper[key].TotalTimeTaken / tripRecordKeeper[key].TotalTripTaken;
            }
            else
            {
                throw new Exception("No Trip Record Exist");
            }
            return res;
        }
    }

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

        public void CustomerCheckOut(int cusomerId, string checkOutStation, int checkOutTime, ref Dictionary<string, TripRecord> tripRecords)
        {
            if (customerTripsDict.ContainsKey(cusomerId))
            {
                //Currently, assumption is Cusomer will only have one Active trip at a time and so this logic
                //If in future enhancement, more Active trips is a usecase,this logic will change with additional filter criteria
                var activeTrip = customerTripsDict[cusomerId].Where(p => !p.IsTripCompleted).FirstOrDefault();

                //Checkout Current Active trip 
                activeTrip.CheckOutLocation = checkOutStation;
                activeTrip.CheckOutTime = checkOutTime;
                activeTrip.IsTripCompleted = true;

                //Add trip record in TripRecordKeeper list reference
                string key = $"{activeTrip.CheckInLocation}{checkOutStation}";
                if (!tripRecords.ContainsKey(key))
                {
                    tripRecords.Add(key, new TripRecord());
                }
                tripRecords[key].StartLocation = activeTrip.CheckInLocation;
                tripRecords[key].EndLocation = checkOutStation;
                tripRecords[key].TotalTimeTaken += checkOutTime - activeTrip.CheckInTime;
                tripRecords[key].TotalTripTaken += 1;
            }
        }
    }

    public class TripRecord
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int TotalTimeTaken { get; set; } = 0;
        public int TotalTripTaken { get; set; } = 0;
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

        public CustomerTrips(string checkInLocation, int checkInTime)
        {
            this.CheckInLocation = checkInLocation;
            this.CheckInTime = checkInTime;
            this.IsTripCompleted = false; 
        }
    }

    /**
     * Your UndergroundSystem object will be instantiated and called as such:
     * UndergroundSystem obj = new UndergroundSystem();
     * obj.CheckIn(id,stationName,t);
     * obj.CheckOut(id,stationName,t);
     * double param_3 = obj.GetAverageTime(startStation,endStation);
     */
}
