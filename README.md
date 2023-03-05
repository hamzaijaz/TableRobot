# TableRobot
This console application is a simulation of a toy robot moving on a square tabletop of dimensions 5 units x 5 units, starting from (0,0) to (5,5)

Coded in c# .NET 6

### How to run TableRobot on your machine?
Prerequisite software
* Visual Studio
* .NET 6 installed

Once you have these prerequisites:
1. Open the solution ```TableRobot.sln``` in Visual Studio
2. Build the solution and make sure there are no errors
3. Run and debug the project by clicking on play button with TableRobot: ![image](https://user-images.githubusercontent.com/33806340/222958143-e342b238-fe4d-4e10-81a2-c8f9c9f61208.png)
4. This will start the application on Console, along with instructions: ![image](https://user-images.githubusercontent.com/33806340/222958180-6815054e-cb23-455a-ba20-cdd677df9e2e.png)

Initially it will be a 5x5 units table. You will need to follow instructions in order to play.

1. ```PLACE``` command: It places the robot on table. Correct pattern to use this command is ```PLACE x,y,direction```
For example:
    * PLACE 0,0,NORTH
    * PLACE 1,5,SOUTH
    * PLACE 5,5,WEST
Any x or y coordinate more than the size of table will result in error.

2. ```MOVE``` command: It moves the robot one unit forward in the direction which it is currently facing. If the robot is already facing edge of the table, it will not move further forward.
For example:
    * MOVE

3. ```LEFT``` command: It rotates the robot 90 degrees counter clockwise. If the robot is facing NORTH, a ```MOVE``` command will result in robot facing WEST.

4. ```RIGHT``` command: It rotates the robot 90 degrees clockwise. If the robot is facing NORTH, a ```MOVE``` command will result in robot facing EAST.

5. ```Report``` command: It reports the current position and direction of the robot in format (x, y) direction.
For example:
    * if the robot is 2 units x, and 5 units y, facing NORTH, the report command will produce following response ```Current position of robot is: (2, 5) Facing NORTH```

6. ```Draw``` command: It draws a table of 5x5 units, starting from 0,0, and shows position of robot as R
For example:
    * a robot on 2,5,NORTH will be shown as
    .&emsp;&emsp;.&emsp;&emsp;r&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.
    .&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.
    .&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.
    .&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.
    .&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.
    .&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.&emsp;&emsp;.

7. ```HELP``` command: It shows the instructions again to the user.

8. ```EXIT``` command: It exits the user from the program
