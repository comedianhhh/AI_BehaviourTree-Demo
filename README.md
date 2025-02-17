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
// Example: ai action check
[TaskName("Miner Bob Deposit")]
[TaskCategory("Miner Bob")]
[TaskDescription("Miner Bob will deposit a percentage of gold")]
public class MinerBobDepositAction : MinerBobBaseAction
{
    public SharedFloat depositPercentage = 1.0f;

    public override TaskStatus OnUpdate()
    {
        base.OnUpdate();

        minerBob.Deposit(minerBob.currentGold * depositPercentage.Value);
        Debug.Log($"Deposited gold! I have {minerBob.bankAccount} in the bank, getting close to retirement");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        base.OnReset();
        depositPercentage.Value = 1.0f;
    }
}
