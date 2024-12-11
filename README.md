# ShipLander

| Control | Action       |
|---------|--------------|
| A       | Rotate Left  |
| D       | Rotate Right |
| W       | Boost        |

- I added a 2d sprite and using a polygon collider i built the map. With some help online i found the command [collider.CreateMesh](https://github.com/Daniel-WORK-GH/ShipLander/blob/main/Assets/Scripts/Ground.cs) and could render the map using a custom material.
- I added the script from my previous program that will keep the screen the same size. ([ScreenKeeper](https://github.com/Daniel-WORK-GH/ShipLander/blob/main/Assets/Scripts/ScreenSizeKeeper.cs))
- I added the end platform script - it will start couting the second a player collides with it and reset the counter if the player leaves the platform, after 3 seconds the game will go to the next level.
- I added the ship script that will rotate when A/D are pressed and move upwards when W is pressed, using the [velocity magnitude](https://github.com/Daniel-WORK-GH/ShipLander/blob/ffb24dacef9218259ba0b1a2e86775a0af0f0d32/Assets/Scripts/ShipScript.cs#L50C33-L50C69) i calculate how hard the plalyer hit a surface to reset the level.
