# My Puzzle Game

This is a simple point and click puzzle game developed in Unity.
The player’s goal is to select three objects of the same color to clear them from the scene and progress through levels.

# Starting the Game

Before starting any project, it's essential to have a clear idea of the game.
I began by brainstorming a fun and engaging concept. The idea was to create a point and click puzzle game where the player must find three pieces of each color to progress to the next level.
I almost forgot the most important part is to actually start making the game.

## Scene and Game Management

Using separate scenes helps reduce complexity and improves project organization.
It also makes the game easier to expand in the future.
By dividing the game into distinct scenes, we avoid unnecessary clutter and improve both maintainability and performance.

Also, thanks to using managers with the Singleton pattern and persistent GameObjects, scene transitions are smoother without the need to reload shared data.[For the scenes that we work with it is not really impactful.]

## Game Idea

As a player, your goal is to eliminate every colorful object in the scene by selecting three objects of the same color, regardless of type.
The Observer pattern would come in handy with this game mechanic.
Also, I thought creating clickable objects using ScriptableObjects is a plus for scalability of the game, new kinds of objects can be added easily this way. Therefore, we will proceed with this idea.

## First Steps

I started by creating some sample scenes and a main menu scene. The sample scenes are just an office room for now.
The main menu was created using enums, dictionaries, and a UI Manager, rather than activating/deactivating UI elements manually.
This system is more scalable and cleaner, even for a small project.
To achieve this, I created a UI Manager and a Game Manager using the Singleton design pattern, since these components must be universal and unique.
Event based UI also helps minimize unnecessary processing menu updates are only triggered when needed.

## Level 1

I began by organizing the scene and removing unused objects. I also made some changes to the layout of the environment.
Then, I created a Match Manager using the Singleton pattern. This pattern was chosen because the Match Manager must be globally accessible and unique.
To support the game mechanic, I added a Clickable Object script. With this script, I can turn any object into a clickable item.
Instead of constantly searching for objects in the scene, I store selected items in a list. This makes the game more responsive and reduces resource usage. (This is fundamental again, since our scenes are really negligible.)
After all the coding and adjustments, I managed to create the first game mechanic that destroys 3 objects of the same color when chosen at once.
Also, those objects can be seen in the selection menu, so the player will not be confused.

## Audio Manager

Once again, I used the Singleton pattern for the Audio Manager.
With this manager, I’m able to play background music and sound effects effectively.
I’ve now integrated these into the game. Having a global audio system helps manage clips easily without duplicating components across scenes.

## Adding Particle System

Particle systems are not just decorative they must be integrated into the game mechanics so players feel satisfied with their actions.
Following this idea, I implemented a system where, when three objects are selected, they disappear with a visual effect.
This wasn’t straightforward because the prefabs had child components. To work around this, I used a small trick:
Right before the object vanishes, the particle effect is played, and the particle system is detached from the parent object.
Then the object is destroyed, and afterward, the particle system is also destroyed.
This way, the visual effect continues to play even if the object itself is removed immediately helping visual clarity without breaking immersion.

## Using the Observer Pattern in the UI System

I used the Observer pattern to manage opening and closing menus.
Buttons trigger events, and the UI Manager listens and reacts.
The pattern works in some parts of the project, but not everywhere. Still, it's helpful for this project.

## Future Ideas
After most things got rounded up, I was able to build a new scene with ease because I had reusable systems in place.
The whole structure from menu handling to game logic is modular, so expanding the game feels smooth.
A countdown would be a nice mechanic to keep the player engaged.
Increasing the number of colorful objects in each scene while reducing the number required for a match could also be a great way to increase the challenge





