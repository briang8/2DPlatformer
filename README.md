# 2D Platformer

A 2D game built in Unity. Run through levels, collect coins, defeat enemies, shoot the boss and beat the clock.

---

## Controls

| Action | Key |
|--------|-----|
| Move left / right | A / D or Arrow Keys |
| Jump | Spacebar |
| Shoot | J |

---

## How to Play

Start the game from the Main Menu by clicking Play. Move through the level collecting coins and avoiding or defeating enemies along the way. You have 3 lives. A countdown timer runs in the top right corner of the screen. To win you need to defeat the boss and collect all the coins before the timer runs out. If you run out of lives or the timer hits zero, the game ends and you can choose to replay or return to the main menu.

If you fall into the water or get hit by an enemy, you lose a life and respawn at the last ground position you were standing on. When you have no lives left, the end screen appears.

---

## Features

**Main Menu**
A start screen with three buttons. Play launches the game. Settings opens a panel where you can toggle the music on or off and adjust the volume. Quit closes the application.

**Settings**
The music toggle and volume slider in the settings panel save your preferences. When you load into the gameplay scene your settings carry over automatically.

**Countdown Timer**
A timer in the top right corner counts down from a set time. When it reaches zero the game ends.

**Shooting**
Press J to fire a bullet in the direction the player is facing. Bullets travel forward and stop when they hit an enemy or a solid surface.

**Enemies**
Several enemy types are spread across the level, each with different behaviour. Some walk toward you, some jump, some fly and drop projectiles, and one hangs from above. The boss at the end of the level throws boulders and requires multiple hits to defeat.

**Coin Collection**
Coins are scattered throughout the level. Collecting all of them is one of the two conditions required to win.

**Win and Lose Screens**
A single end panel handles both outcomes. It shows "YOU WIN" when you defeat the boss and collect all coins, and "GAME OVER" when you run out of lives or time. From this screen you can replay the level or return to the main menu.

**Respawn System**
Taking damage flashes the player sprite and grants brief invincibility before respawning at the last position you were standing on solid ground.

---

## Running Locally

Requirements:
- Unity 6 or later 
- Git

Steps:

1. Clone the repository
```
git clone [https://github.com/briang8/2DPlatformer.git]
```

2. Open Unity Hub, click Add, and select the cloned project folder

3. Once the project loads, open the scene at Assets/Scenes/MainMenuScene to start from the main menu, or Assets/Scenes/GameScene-ALU to jump straight into the game

4. Press the Play button in the Unity Editor to run the game

No additional packages are required. TextMeshPro assets will be imported automatically if prompted by Unity.

---

## Project Structure

```
Assets/
├── Scenes/
│   ├── MainMenuScene
│   └── GameScene-ALU
├── Scripts/
│   ├── Boss Scripts/
│   ├── Camera Scripts/
│   ├── Collectable Scripts/
│   ├── Enemy Scripts/
│   ├── Game Scripts/
│   ├── Player Scripts/
│   ├── Settings/
│   └── Water Script/
└── Prefabs/
```

---

## Built With

- Unity 
- C#
- TextMeshPro

---