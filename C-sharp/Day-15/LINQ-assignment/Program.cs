using System;
using System.Collections.Generic;
using System.Linq;

namespace AutonomousRobot.AI
{
    class SensorReading
    {
        public int SensorId;
        public string Type;
        public double Value;
        public DateTime Timestamp;
        public double Confidence;
    }

    enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    class DecisionEngine
    {
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory.Where(s => s.Timestamp >= fromTime).ToList();
        }

        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(r => r.Type == "Battery" && r.Value < 20);
        }

        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            return readings
                .Where(r => r.Type == "Distance")
                .Select(r => r.Value)
                .DefaultIfEmpty(double.MaxValue)
                .Min();
        }

        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings
                .Where(r => r.Type == "Temperature")
                .All(r => r.Value < 90);
        }

        public double GetAverageVibration(List<SensorReading> readings)
        {
            return readings
                .Where(r => r.Type == "Vibration")
                .Select(r => r.Value)
                .DefaultIfEmpty(0)
                .Average();
        }

        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                .GroupBy(r => r.Type)
                .ToDictionary(g => g.Key, g => g.Average(r => r.Confidence));
        }

        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                .GroupBy(r => r.Type)
                .Where(g => g.Count(r => r.Confidence < 0.4) > 2)
                .Select(g => g.Key)
                .ToList();
        }

        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var batteryValues = sensorHistory
                .Where(r => r.Type == "Battery")
                .OrderBy(r => r.Timestamp)
                .Select(r => r.Value)
                .ToList();

            if (batteryValues.Count < 2)
                return false;

            return batteryValues
                .Zip(batteryValues.Skip(1), (prev, next) => next < prev)
                .All(x => x);
        }

        public double GetWeightedDistance(List<SensorReading> readings)
        {
            var distanceSensors = readings.Where(r => r.Type == "Distance");

            double weightedSum = distanceSensors.Sum(r => r.Value * r.Confidence);
            double totalConfidence = distanceSensors.Sum(r => r.Confidence);

            if (totalConfidence == 0)
                return double.MaxValue;

            return weightedSum / totalConfidence;
        }

        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (recentReadings.Any(r => r.Type == "Battery" && r.Value < 20))
                return RobotAction.Stop;

            if (IsBatteryDrainingFast(sensorHistory))
                return RobotAction.Stop;

            double nearestDistance = recentReadings
                .Where(r => r.Type == "Distance")
                .Select(r => r.Value)
                .DefaultIfEmpty(double.MaxValue)
                .Min();

            if (nearestDistance < 1.0)
                return RobotAction.Reroute;

            if (recentReadings.Any(r => r.Type == "Temperature" && r.Value >= 90))
                return RobotAction.SlowDown;

            return RobotAction.Continue;
        }
    }

    class Program
    {
        static void Main()
        {
            List<SensorReading> sensorHistory = new List<SensorReading>
            {
                new SensorReading { SensorId=1, Type="Distance", Value=0.8, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-9)},
                new SensorReading { SensorId=2, Type="Battery", Value=18, Confidence=0.8, Timestamp=DateTime.Now.AddSeconds(-8)},
                new SensorReading { SensorId=3, Type="Temperature", Value=92, Confidence=0.7, Timestamp=DateTime.Now.AddSeconds(-7)},
                new SensorReading { SensorId=4, Type="Vibration", Value=8.2, Confidence=0.6, Timestamp=DateTime.Now.AddSeconds(-6)},
                new SensorReading { SensorId=5, Type="Battery", Value=75, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-5)},
                new SensorReading { SensorId=6, Type="Distance", Value=2.5, Confidence=0.5, Timestamp=DateTime.Now.AddSeconds(-4)},
                new SensorReading { SensorId=7, Type="Battery", Value=60, Confidence=0.85, Timestamp=DateTime.Now.AddSeconds(-3)},
                new SensorReading { SensorId=8, Type="Battery", Value=40, Confidence=0.8, Timestamp=DateTime.Now.AddSeconds(-2)},
                new SensorReading { SensorId=9, Type="Temperature", Value=70, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-1)},
                new SensorReading { SensorId=10, Type="Vibration", Value=7.8, Confidence=0.7, Timestamp=DateTime.Now.AddSeconds(-1)}
            };

            DateTime fromTime = DateTime.Now.AddSeconds(-10);
            DecisionEngine engine = new DecisionEngine();

            var recentReadings = engine.GetRecentReadings(sensorHistory, fromTime);
            Console.WriteLine("Recent Readings Count: " + recentReadings.Count);
            Console.WriteLine("Battery Critical: " + engine.IsBatteryCritical(recentReadings));
            Console.WriteLine("Nearest Obstacle Distance: " + engine.GetNearestObstacleDistance(recentReadings));
            Console.WriteLine("Temperature Safe: " + engine.IsTemperatureSafe(recentReadings));
            Console.WriteLine("Average Vibration: " + engine.GetAverageVibration(recentReadings));

            Console.WriteLine("Sensor Health:");
            foreach (var h in engine.CalculateSensorHealth(sensorHistory))
                Console.WriteLine($"{h.Key} -> {h.Value:F2}");

            var faulty = engine.DetectFaultySensors(sensorHistory);
            Console.WriteLine("Faulty Sensors: " + (faulty.Count == 0 ? "None" : string.Join(", ", faulty)));

            Console.WriteLine("Battery Draining Fast: " + engine.IsBatteryDrainingFast(sensorHistory));
            Console.WriteLine("Weighted Distance: " + engine.GetWeightedDistance(recentReadings));

            RobotAction action = engine.DecideRobotAction(recentReadings, sensorHistory);
            Console.WriteLine("Robot Action: " + action);
        }
    }
}
