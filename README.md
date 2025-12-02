# 3D Stealth Game

A Unity 6.2 stealth game where players must navigate through a level while avoiding detection by AI observers. Reach the exit to win, but be careful - if you're caught, you'll have to start over!

**GitHub Repository**: [https://github.com/ethanhandler17/FinalAssignment3dStealthGame](https://github.com/ethanhandler17/FinalAssignment3dStealthGame)

**Gameplay Video**: [Watch on YouTube](https://youtube.com/shorts/QnBGe6-5jmM)

## 🎮 Game Features

### Core Mechanics
- **Player Movement**: Smooth third-person movement with walk/run mechanics
  - Walk with WASD/Arrow Keys
  - **Sprint Button**: Hold Left Shift to sprint and move faster
  - Smooth rotation and movement animations

- **Stealth System**: Avoid detection by AI observers
  - Observers patrol waypoints and detect the player using raycasting
  - If spotted, the game ends and restarts
  - **Enhanced Visuals**: More pronounced vignette effect for atmospheric tension

- **Shield Power-up**: Destroy enemies with temporary invincibility
  - Collect shield pickups to gain the ability to destroy ghosts on contact
  - Shield lasts for 10 seconds - use strategically to eliminate threats
  - When shielded, any observer that detects you will be destroyed instead of catching you

- **Waypoint Patrol System**: AI enemies follow predefined patrol routes
  - Configurable waypoint paths
  - Smooth movement and rotation

- **Game End Conditions**:
  - **Win**: Reach the exit point
  - **Lose**: Get detected by an observer

## 🛠️ Technical Details

### Unity Version
- **Unity 6.2**

### Key Scripts

#### `PlayerMovement.cs`
Handles player input and movement using Unity's Input System:
- WASD/Arrow key movement
- Left Shift for running
- Smooth character rotation
- Animation integration

#### `Observer.cs`
AI detection system for enemies:
- Trigger-based detection zones
- Raycast line-of-sight checking
- Integrates with GameEnding system

#### `WaypointPatrol.cs`
AI patrol behavior:
- Follows array of waypoint transforms
- Loops through waypoints continuously
- Uses Rigidbody for smooth movement

#### `Shield.cs`
Power-up system:
- When collected, enables player to destroy ghosts on contact
- 10-second duration (configurable)
- Uses static flag to track shield status across all observers
- Automatically expires after duration

#### `GameEnding.cs`
Manages win/lose conditions:
- Fade-in UI screens
- Audio feedback
- Scene restart on loss
- Application quit on win

## 📁 Project Structure

```
Assets/
└── _3DStealthGame/
    └── Scripts/
        ├── PlayerMovement.cs
        ├── Observer.cs
        ├── WaypointPatrol.cs
        ├── Shield.cs
        └── GameEnding.cs
```

## 🚀 Getting Started

### Prerequisites
- Unity 6.2 or later
- Unity Input System package

### Setup
1. Clone this repository
2. Open the project in Unity 6.2
3. Open the main scene
4. Press Play to start the game

### Controls
- **WASD** / **Arrow Keys**: Move
- **Left Shift**: Run
- **Mouse**: Look around (if camera controls are enabled)

## 🎯 Gameplay Tips

1. **Observe Patrol Patterns**: Watch the observers' movement patterns before moving
2. **Use Cover**: Stay behind objects to break line of sight
3. **Strategic Running**: Running is faster but may make you more noticeable
4. **Shield Timing**: Save shields for difficult sections with multiple observers
5. **Plan Your Route**: Scout the level to find the safest path to the exit

## 🎨 Recent Updates

- **Enhanced Vignette**: Added a more pronounced vignette effect for increased atmospheric tension
- **Sprint Button**: Implemented Left Shift sprint functionality for faster movement
- **Shield System**: Redesigned shield power-up to destroy enemies on contact for 10 seconds instead of just disabling detection

## 🐛 Known Issues

- Shadow atlas warning may appear in console (can be resolved by adjusting Quality Settings)

## 📝 License

This project is created for educational purposes as part of a final assignment.

## 👥 Team

**Ethan Handler** - Solo Developer

## 👤 Author

Created as a final assignment project by Ethan Handler.

---

**Note**: This is a Unity project. Make sure to have Unity 6.2 installed to open and run the project properly.

