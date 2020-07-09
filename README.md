Challenge: 
- Make the code compile and run properly. Do not change the Program.Main method.
- Only change the code of the Vehicle and Bicycle classes

Description:
- Vehicle is a base class. Specific types of vehicles, such as 'Bicycle', can derive from it
- A bicycle must have the type Road, Mountain, or Hybrid. Otherwise it should throw an exception
- A Bicycle should have 4 publicly available methods: StartMoving, StopMoving, SpeedUp, SlowDown
- When the Bicycle starts moving, it should have a speed of 1. When it stops, it should be 0
- A bicycle's cannot speed up beyond its 'NumSpeeds' and should never slow down to less than 0 speed
- A bicycle should be Moving before it's speed can be increased or slowed down
- A bicycle cannot slow down from speed of 1 to 0. It must use StopMoving()

Reminder: Do NOT alter the Main method. The challenge is to have the project build and run successfully. The output should be as follows:

Invalid Bike Type: Magical bike
There are 2 bikes.
Can we fit? False
My speed: 0
Your speed speed: 3
Success!
