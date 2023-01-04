# Sodium2D
Sodium2D is a completely customizable 2D game engine made in C# using the .NET Framework.

## Requirements
- Windows device
- .NET Framework installed
- Visual Studio or any other IDE

## Setup
1. Install the files above.
2. Open the ```Game.cs``` file
3. You are done! :D

## How To Use

### Script
Once opened, the file's content should look like this:
```c#
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace Sodium
{
    class Game : GameEngine
    {
        public Game() : base(new Vector(1000, 1000), "Game") { }

        public override void OnLoad()
        {

        }

        public override void OnUpdate()
        {

        }
    }
}
```

### Initialization
You may notice on line 10 this line of code:
```c#
public Game() : base(new Vector(1000, 1000), "Game") { }
```
This line of code Initializes the game and has 2 arguments:
- The games window size (Vector)
- The name of the window (String)

### OnLoad
```OnLoad``` is a function that runs once on the start of the game.

### OnUpdate
```OnUpdate``` is a function that runs every frame while the game is active.

### Shapes
#### Square
Draw a square to the screen based off arguments:
```c#
Shape shape = new Shape(new Vector(500, 500), new Vector(50, 50), Color.Black, "Wall", Type.Square, null);
```
This function has 6 arguments:
- Position (Vector)
- Size (Vector)
- Color (Color)
- Tag (string)
- Type (Type)
- Image (Bitmap)

#### Image
Draw a image the screen based off arguments:
```c#
Shape shape = new Shape(new Vector(500, 500), new Vector(50, 50), Color.Black, "Wall", Type.Sprite, new Bitmap(@"Your Path Here"));
```

#### Position
Return the `Shape` `Vector` Position:
```c#
Console.WriteLine(shape.Position);
shape.Position = new Vector(250,250);
```

#### Scale
Return the `Shape` `Vector` Scale:
```c#
Console.WriteLine(shape.Scale);
shape.Scale = new Vector(250,250);
```

#### Collision
Returns ```true``` or ```false``` based on if a `Shape` is colliding with a `Shape` with `Tag`:
```c#
if (Shape.IsCollided(p, "Object")) System.Windows.Forms.Application.Exit();
```

### User Input
#### Get Key Down
Returns ```true``` or ```false``` based on if a specific key is pressed:
```c#
Input.GetKey(Key.Space);
```
This function has 1 argument:
- Key (Key)

#### Get Key Up
Returns ```true``` or ```false``` based on if a specific key is up:
```c#
Input.GetKeyUp(Key.Space);
```
This function has 1 argument:
- Key (Key)

### Vectors
#### Normalize
Makes the magnatude of the ```Vector``` 1.
```c#
Console.WriteLine(new Vector(6, 7).normalize);
```

#### Get Vector's X Value
Get the `Vector`'s X value
```c#
Console.WriteLine(shape.Position.X);
```

#### Get Vector's Y Value
Get the `Vector`'s Y value
```c#
Console.WriteLine(shape.Position.Y);
```

#### Get Middle Location Of Shape
Returns the `Vector` Position of the middle of a shape based on its ```Vector``` Position and Scale:
```c#
Vector.GetMiddlePosition(shape.Position, shape.Scale)
```
This function has 2 argument:
- Position (Vector)
- Scale (Vector)

#### Get Direction
Returns the `Vector` Direction from one `Vector` Position to another:
```c#
Vector.GetDirection(shape1.Position, shape2.Position)
```
This function has 2 argument:
- Too (Vector)
- From (Vector)

#### Get Distance
Returns the `Double` Distance from one `Vector` Position to another:
```c#
Vector.GetDirection(shape1.Position, shape2.Position)
```

This function has 2 argument:
- Point1 (Vector)
- Point2 (Vector)

#### Get Closest Shape
Returns the closest `Shape` with `Tag` excluding `Exeption`:
```c#
Vector.GetDirection(new Vector(500, 500), "Wall", shape)
```

This function has 3 argument:
- Position (Vector)
- Tag (string)
- Exeption (Shape)

### Rooms
#### Add Room
Add `string[,]` Room to Rooms
```c#
string[,] map = new string[20, 20]
{
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", "p", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
};

Room.AddRoom(map);
```
This function has 1 argument:
- Map (string[,])

#### Get Current Room
Returns `int` current room
```c#
Console.WriteLine(Room.GetCurrentRoom());
```

#### Get Positions Of A Certain Tiles
Returns `List<Vector>` of Positions of a certain tile
```c#
foreach (Vector i in Room.GetTiles("p"))
{
    p = new Shape(i, new Vector(50, 50), Color.Black, "Player", Type.Square, null));
}
```
This function has 1 argument:
- Tile (string)