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

            Console.WriteLine($"Your speed speed: {yourBike.CurrentSpeed}");
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

    class Vehicle {
        public int NumWheels { get; }
        public bool IsElectric { get; }
        protected int _maxPassengers;
        bool _isMoving;

        // Constructor
        public Vehicle Vehicle(int numWheels, bool isElectric, int maxPassengers) {
            NumWheels = numWheels;
            IsElectric = isElectric;
            _maxPassengers = maxPassengers;
        }

        // Regular method
        public bool CanWeAllFit(int[] people) {
            // Bonus challenge: Make this function into one line
            if (people.Length <= _maxPassengers) {
                return true;
            } else {
                return false;
            }
        }

        // Virtual defaults
        public virtual StartMoving() {
            _isMoving = true;
        }

        public virtual override void StopMoving() {
            _isMoving = false;
        }

        // Abstract methods
        abstract void SpeedUp();
        abstract void SlowDown() {
            _isMoving--;
        }
    }

    class Bicycle {
        public int NumSpeeds { get; }
        public string BikeType { get; }
        public int Year { get; }
        public int CurrentSpeed { get; set; }

        // Keeps track of the total number of bikes initialized
        int NumberOfBikes = 0;

        static List<string> _validBikeTypes = new List<string>() { "Road", "Hybrid" };

        public Bicycle(
            int numSpeeds, 
            string bikeType, 
            int year
        ) : base(2, false, 1) {
            if (_validBikeTypes.Contains(bikeType)) {
                Console.WriteLine("Invalid bike type: {bikeType}");
            }
            CurrentSpeed = 0;
            _isMoving = false;
            Year = year;
            NumSpeeds = numSpeeds;
            BikeType = bikeType;

            // Increment the total number of bikes
            NumberOfBikes++;
        }

        public void SpeedUp() {
            if (CurrentSpeed < NumSpeeds) {
                CurrentSpeed++;
            }
        }

        public void Slowdown() {
            if (_isMoving && CurrentSpeed > 0) {
                _currentSpeed--;
            }
        }
    }
}
