Snake A
=======

Application
-----------
The application is a game based off a version of Snake found in late 90's Nokia phones. The
player controls a snake, which moves at discrete periods of time, and can move either
horizontally or vertically. The aim is to eat as much food as possible, avoiding the screen
boundaries and the snake itself in the process. The snake grows each time food is eaten,
increasing the difficulty of avoiding obstacles.

How to use
----------
The game is optimised for a 3:2 aspect ratio. At thinner ratios, parts of the game will not
be visible. The game is playable at wider ratios, the extra width is covered in black.
The instructions scene should be surrounded by a white outline, which can be used to ensure
the window is of adequate shape. For Microsoft Surface 3 and 4, switching to Tablet mode
ensures a reasonable aspect ratio for the game.

The game should begin in the main menu scene. The main menu has three buttons:
- Normal Mode: Starts the game with the snake moving at normal speed
- Fast Mode: Starts the game with the snake moving twice as fast as Normal Mode.
             Also causes the blurring effect to be progress faster.
- Instructions: Goes to the Instructions scene which details the game controls

In the game, there is a panel at the top of the screen, which contains, from left to right:
- Score: A number that represents the number of food items eaten
- Mode: Indicates which mode the game is in (either normal or fast)
- Menu: A button to return to the main menu, only visible when the snake has collided
- Restart: A button to restart the game, only visible when the snake has collided

The game controls are detailed in the instructions scene. Touch is used to control the snake's
movement direction. Touching the right half of the screen causes the snake to turn 90 degrees
clockwise, which is a right turn from the snake's perspective. Touching the left half of the
screen causes the snake to turn anticlockwise.

It is possible to control to some degree where the food will appear next. This is an extra
feature which does not need to be utilised to play the game successfully, but can allow
skilled players to achieve higher scores than otherwise possible. This is controlled by using
the accelerometer. A quick tilt of the top of the screen downwards will cause the food to next
appear in the top half of the screen. A quick tilt of the top of the screen upwards will cause
the food to next appear in the bottom half of the screen. The reasoning is that the half that
is lowered is where the food moves to, as if influenced by gravity.

Alternate controls are available with keyboard input. These are detailed in the instructions
scene. The keyboard can be used as the sole means of input, or in conjunction with the use of
an accelerometer or touch, whichever controls are desirable. Buttons respond to mouse clicks
in addition to touch.

Object modelling
----------------
All objects are generated programmatically. There a three main objects in the game, the floor,
the food and the snake. The floor is a plane, the food is a cube, and the snake is a parent of
multiple cubes. The snake begins with 30 cubes and grows by 10 cubes each time food is eaten.
This means that after eating 20 food items, the snake is made up of 230 cubes.

Graphics and camera motion
--------------------------
The three main objects in the game use three different shaders. The floor uses a shader that
blurs a texture by an amount that can be set externally. The blurring effect is achieved by
summing horizonally adjacent colours on a texture according to a Normal distribution. This
shader also contains Unity macros to handle the receiving of shadows. For receiving shadows,
a built-in Unity directional light is required.

Each cube of the snake uses a Phong shader with each cube alternating between two colours.
This shader also uses Unity's VertexLit shader as a fallback to allow it to cast shadows onto
the floor. The food uses a semi-transparent shader, which when combined with a particle system
that produces a sparkle effect, makes the food clearly stand out as a special item. The camera
shakes horizontally briefly when a collision occurs, providing greater visual impact of a
collision.

App certification
-----------------
The app prelaunch test failed, which is a known bug, as documented here:
https://developer.microsoft.com/en-us/windows/develop/app-certification-kit
As the Windows 10 version of the Microsoft Surface provided is 1511, the test cannot be
passed.
The supported APIs test failed, which seems to be due to the use of libraries that allow
for debugging facilities in Unity.

Sources used
------------
Normal distribution and summing in BlurShader.shader
http://answers.unity3d.com/questions/407214/gaussian-blur-shader.html

For receiving shadows in BlurShader.shader
https://alastaira.wordpress.com/2014/12/30/adding-shadows-to-a-unity-vertexfragment-shader-
in-7-easy-steps/

GenerateTriangles method in FloorScript.cs
http://catlikecoding.com/unity/tutorials/procedural-grid/
