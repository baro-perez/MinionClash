Army-clash-like test assigment for Álvaro Pérez Alarcón

This document explains some design choices taken for the development of the project. The project is a game inspired by Army Clash where two groups of units fight each other until a group is eliminated.


# Interpretations of the design document

Since the design document only states that "the user is able to randomize armies before the start of the simulation", my interpretation is that the game is idle, working as a simulator, but you can edit the randomization of units before the start. The user is able to modify the chances of each unit type for each team, and the units will appear at random times with a maximum time that is also defined in the menu (this menu also serves as a demonstration of the Model-View-ViewModel pattern implementation).

Since the document specifies colored units, to differenciate each team I've used white and black, changing the color of units and health bars.

The game ends when the last unit is spawned and one of the teams has no units left.


# The Unit class groups behaviours in components

To allow new units to be implemented, we separate each component of a behaviour in extendible classes, which execute each piece of behaviour for the character, like movement, health, or attacking

I've also included the possibility of executing more behaviours before and after the "standard" ones, to allow possible future extensions.


# Model/view/controller architecture for the game
Classes related to the logic of the game are independent on the view, and they communicate between each other through events, to maintain separation of concerns and interchangeability of layers.

The controller in this case is the ClassicGameModeController monobehaviour, which feeds "ticks" to the model layer and checks for the win condition.

A DataModel layer allows the values to be configured in ScriptableObjects that are used to create the model layer objects.


# Model-View-ViewModel pattern for the UI

ViewModel classes hold the current visual state of the object they're modeling, and support binders that allow the Unity Canvas classes (view layer) to present it on the interface.

Using this pattern, we can decouple th Model and View layers, making it very fast and safe to iterate on the UI. The ViewModel just needs to be aware on when it needs to raise property changes, and the UiBinders, which are specific for view elements, will automatically update to reflect these changes.


# Extra feature(s)

Because the game is mostly idle, I've decided to add some user interactability by including bombs.

Since I had already added avoidance to the units' movement, I was observing interesting movements when units came close to one another, forming melees and crowds. I thought it would be a good idea to include bombs that would push units as well as do damage, affecting the way the units move and empowering the user to separate crowds. The bomb has an expanding area of effect that is reflected on the visuals, and does progressive damage and push (i.e. units on the edge of the AoE won't be pushed as much).

Since it wasn't too much of a stretch, I've also added a small push into the melee attack of units, which also serves as a demonstration of how the game can be extended, in this case to add a decorator behaviour.
