# AI Behavior Tree Demo 🧠⚙️

A modular implementation of a **Behavior Tree system** for game AI, showcasing enemy AI logic for a 3D stealth game prototype. Built with [Unity/C++/Unreal/Godot].

[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-black?logo=unity)](link)
[![License](https://img.shields.io/badge/License-MIT-green)](link)

**Demo Video/GIF**  
<!-- Embed a short GIF/video showing the AI in action (e.g., patrolling, reacting to player) -->

---

## 🎯 Features
- **Core Behavior Tree Components**:
  - **Nodes**: Sequence, Selector, Parallel, Decorator (Conditionals), Action Nodes.
  - **Blackboard Integration**: Shared data context for decision-making.
  - **Customizable Behaviors**: Easily extendable with new node types.
- **Example AI Use Case**:
  - Guard NPC with **patrol, chase, attack, and return-to-post** states.
  - Dynamic reactions to player visibility, noise, and environmental changes.
- **Debug Tools**:
  - Visual runtime tree inspector (screenshot below).
  - Logging for node execution flow.

---

## 🛠️ Technical Breakdown
### **Architecture**
- **ScriptableObject-based Design** (Unity) or **Component-based** (Unreal/C++).
- **Composite Pattern** for node hierarchies.
- **Separation of Logic and Data**: Blackboard stores world state (e.g., `CanSeePlayer`, `LastKnownPosition`).

### **Key Code Snippets**
```csharp
// Example: Custom Decorator Node (Check if player is visible)
public class IsPlayerVisible : DecoratorNode {
    protected override void OnStart() {
        // Access Blackboard
        bool isVisible = blackboard.GetValue<bool>("PlayerVisible");
        // ... logic
    }
}
