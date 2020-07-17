using System;
using System.Collections.Generic;

namespace oopquiz
{
    class Program
    {
        // Main method: DO NOT ALTER CODE IN HERE!
        static void Main(string[] args)
        {
            // Create two new bikes
            var myBike = new Bicycle(10, "Road", 2015);
            var yourBike = new Bicycle(3, "Mountain", 2012);

            try {
                // Should fail since it's an invalid bike type
                var failBike = new Bicycle(10, "Magical bike", 2019);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            // Count total number of bikes. Should be 2
            int totalBikes = Bicycle.NumberOfBikes;
            Console.WriteLine($"There are {totalBikes} bikes.");

            // Can we both fit on the same bike? Nope!
            string[] people = {"me", "you"};
            bool canWeFit = myBike.CanWeAllFit(people);
            Console.WriteLine($"Can we fit? {canWeFit}");

            myBike.StartMoving();

            myBike.SpeedUp();

            myBike.SpeedUp();

            myBike.StopMoving();

            Console.WriteLine($"My speed: {myBike.CurrentSpeed}");
            if (myBike.CurrentSpeed != 0) {
                throw new Exception("Incorrect speed on my bike!");
            }

            try {
                // Should fail and catch since we are speeding up without starting
                myBike.SpeedUp();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }


            yourBike.StartMoving();

            try {
                // Should fail and catch since we are slowing down to an invalid speed
                yourBike.SlowDown();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            yourBike.SpeedUp();
            yourBike.SpeedUp();

            Console.WriteLine($"Your speed: {yourBike.CurrentSpeed}");
            if (yourBike.CurrentSpeed != 3) {
                throw new Exception("Incorrect speed on your bike!");
            }

            try {
                // Should fail and catch since we are speeding up to an invalid speed
                yourBike.SpeedUp();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Success!");
        }
    }

    abstract class Vehicle {
        public int NumWheels { get; }
        public bool IsElectric { get; }
        protected int _maxPassengers;
        protected bool _isMoving;

        // Constructor
        public Vehicle(int numWheels, bool isElectric, int maxPassengers) {
            NumWheels = numWheels;
            IsElectric = isElectric;
            _maxPassengers = maxPassengers;
        }

        // Regular method
        public bool CanWeAllFit(string[] people) {
            return people.Length <= _maxPassengers;
        }

        // Virtual defaults
        public virtual void StartMoving() {
            _isMoving = true;
        }

        public virtual void StopMoving() {
            _isMoving = false;
        }

        // Abstract methods
        public abstract void SpeedUp();
        public abstract void SlowDown();
    }

    class Bicycle : Vehicle {
        public int NumSpeeds { get; }
        public string BikeType { get; }
        public int Year { get; }
        public int CurrentSpeed { get; private set; }

        // Keeps track of the total number of bikes initialized
        public static int NumberOfBikes = 0;

        static List<string> _validBikeTypes = new List<string>() { "Road", "Hybrid", "Mountain" };

        public Bicycle(
            int numSpeeds, 
            string bikeType, 
            int year
        ) : base(2, false, 1) {
            if (!_validBikeTypes.Contains(bikeType)) {
                throw new Exception($"Invalid bike type: {bikeType}");
            }
            CurrentSpeed = 0;
            _isMoving = false;
            Year = year;
            NumSpeeds = numSpeeds;
            BikeType = bikeType;

            // Increment the total number of bikes
            NumberOfBikes++;
        }

        public override void SpeedUp() {
            if (_isMoving && CurrentSpeed < NumSpeeds) {
                CurrentSpeed++;
            }
        }

        public override void SlowDown() {
            if (_isMoving && CurrentSpeed > 1) {
                CurrentSpeed--;
            }
        }

        public override void StopMoving() {
            if (_isMoving) {
                CurrentSpeed = 0;
                _isMoving = false;
            }
        }

        public override void StartMoving() {
            if (!_isMoving) {
                CurrentSpeed = 1;
                _isMoving = true;
            }
        }
    }
}
