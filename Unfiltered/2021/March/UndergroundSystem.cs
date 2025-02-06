using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.March
{
    class UndergroundSystem
    {
        private readonly IDictionary<string, List<int>> _avgTravelTimes;
        private readonly IDictionary<int, Travel> _customerTravelStart;

        public UndergroundSystem()
        {
            _avgTravelTimes = new Dictionary<string, List<int>>();
            _customerTravelStart = new Dictionary<int, Travel>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            if (_customerTravelStart.ContainsKey(id))
            {
                throw new Exception("Customer already traveling");
            }
            else
            {
                _customerTravelStart.Add(id, new Travel()
                {
                    StationName = stationName,
                    Time = t
                });
            }
        }

        public void CheckOut(int id, string stationName, int t)
        {
            if (!_customerTravelStart.ContainsKey(id))
            {
                throw new Exception("Customer not traveling");
            }
            else
            {
                var startTravel = _customerTravelStart[id];
                string key = $"{startTravel.StationName}{stationName}";
                if (_avgTravelTimes.ContainsKey(key))
                {
                    _avgTravelTimes[key].Add(t - startTravel.Time);
                }
                else
                {
                    _avgTravelTimes.Add(key, new List<int>()
                    {
                        t-startTravel.Time
                    });
                }

                _customerTravelStart.Remove(id);
            }
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            string key = $"{startStation}{endStation}";
            if (_avgTravelTimes.ContainsKey(key))
            {
                var times = _avgTravelTimes[key].Average();
                return times;
            }
            else
            {
                throw new Exception("No records exists");
            }
        }

        public class Travel
        {
            public int Time { get; set; }
            public string StationName { get; set; }
        }

        [Test(Description = "https://leetcode.com/problems/design-underground-system/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Design Underground System")]
        public void Test1()
        {
            UndergroundSystem undergroundSystem = new UndergroundSystem();
            undergroundSystem.CheckIn(45, "Leyton", 3);
            undergroundSystem.CheckIn(32, "Paradise", 8);
            undergroundSystem.CheckIn(27, "Leyton", 10);
            undergroundSystem.CheckOut(45, "Waterloo", 15);
            undergroundSystem.CheckOut(27, "Waterloo", 20);
            undergroundSystem.CheckOut(32, "Cambridge", 22);
            var response = undergroundSystem.GetAverageTime("Paradise", "Cambridge");
            ClassicAssert.AreEqual(14, response);
            
            undergroundSystem.CheckIn(10, "Leyton", 24);
            response = undergroundSystem.GetAverageTime("Leyton", "Waterloo");          // return 11.00000
            ClassicAssert.AreEqual(11, response);

            undergroundSystem.CheckOut(10, "Waterloo", 38);
            response = undergroundSystem.GetAverageTime("Leyton", "Waterloo");
            ClassicAssert.AreEqual(12, response);

        }
    }
}
