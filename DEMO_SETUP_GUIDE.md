# Demo Setup & Evaluation Guide

## 🚀 Quick Start Guide

This guide helps you run and evaluate the AI Behaviour Tree Demo to see the "Beyond Classroom" achievements in action.

---

## 📋 Prerequisites

### **Required Software**
- **Unity 2022.3.8f1** or later (LTS recommended)
- **Behavior Designer** asset (available on Unity Asset Store)
- **Git** for cloning the repository

### **System Requirements**
- **OS**: Windows 10/11, macOS 10.15+, or Ubuntu 18.04+
- **RAM**: 8GB minimum, 16GB recommended
- **GPU**: DirectX 11 compatible
- **Storage**: 2GB available space

---

## 🛠️ Setup Instructions

### **1. Clone Repository**
```bash
git clone https://github.com/comedianhhh/AI_BehaviourTree-Demo.git
cd AI_BehaviourTree-Demo
```

### **2. Open in Unity**
1. Launch Unity Hub
2. Click "Open" → Navigate to the cloned folder
3. Unity will import the project automatically
4. If prompted, upgrade to Unity 2022.3.8f1

### **3. Import Behavior Designer** *(Required)*
1. Open Unity Asset Store
2. Search for "Behavior Designer"
3. Import the asset into your project
4. Follow the import wizard instructions

### **4. Configure Scene**
1. Open scene: `Assets/Game/Scenes/Assignment 4.unity`
2. Locate the `AIPerformanceBenchmark` GameObject
3. Assign the AI Agent prefab if not already set
4. Configure spawn area if needed

---

## 🎮 Running the Demo

### **Basic Demo Experience**

#### **Option 1: Automatic Benchmark**
1. Enable "Auto Run Benchmark" in the AIPerformanceBenchmark component
2. Press Play
3. Watch the performance metrics in real-time
4. Observe AI behaviors through the Scene view

#### **Option 2: Manual Control**
1. Press Play to start the scene
2. Press **B** key to start benchmark
3. Press **S** key to stop benchmark
4. Press **R** key to generate detailed report

### **Advanced Evaluation**

#### **Visual Debugging**
1. Select any AI agent in the Scene view
2. Observe the **red/green sight cones** showing AI perception
3. Watch behavior tree execution in the Behavior Designer window
4. Monitor state changes in the Inspector

#### **Performance Analysis**
1. Open Unity Profiler (`Window > Analysis > Profiler`)
2. Run the benchmark with different agent counts
3. Observe CPU, Memory, and Rendering metrics
4. Compare against documented performance targets

---

## 📊 Key Metrics to Observe

### **Performance Benchmarks**
| Metric | Target | Excellent | Good | Needs Improvement |
|--------|--------|-----------|------|-------------------|
| **FPS** | 60+ | 60+ | 30-59 | <30 |
| **Agents** | 50+ | 50+ | 25-49 | <25 |
| **Frame Time** | <16.67ms | <16.67ms | <33.33ms | >33.33ms |
| **Memory** | <5MB | <5MB | <10MB | >10MB |

### **AI Behavior Quality**
- **Smooth Movement**: AI agents navigate without stuttering
- **Responsive Decisions**: Quick reactions to environmental changes
- **Visual Debugging**: Clear sight cone visualization
- **State Transitions**: Seamless behavior switching

---

## 🔍 Evaluation Checklist

### **Technical Excellence**
- [ ] **Performance**: 50+ AI agents running at 60 FPS
- [ ] **Memory Efficiency**: System uses <5MB total memory
- [ ] **Visual Debugging**: Real-time sight cone visualization works
- [ ] **Modular Code**: Clean, well-organized script architecture
- [ ] **Professional Quality**: No console errors or warnings

### **Beyond Classroom Features**
- [ ] **Custom Tools**: AIPerformanceBenchmark script demonstrates tool development
- [ ] **Advanced Patterns**: Multiple design patterns implemented correctly
- [ ] **Self-Directed Learning**: Behavior Designer integration shows independent study
- [ ] **Innovation**: Visual debugging system goes beyond basic requirements
- [ ] **Documentation**: Comprehensive project documentation suite

### **Portfolio Readiness**
- [ ] **Professional Presentation**: Clean UI and intuitive controls
- [ ] **Quantifiable Results**: Performance metrics clearly displayed
- [ ] **Technical Depth**: Advanced implementation details visible
- [ ] **Learning Evidence**: Documentation shows growth and skill development
- [ ] **Business Value**: Practical applications for game development

---

## 🎯 Demo Scenarios

### **Scenario 1: Performance Showcase**
**Objective**: Demonstrate scalability and optimization
1. Start with 1 AI agent, observe baseline metrics
2. Gradually increase to 25, 50, 75, 100 agents
3. Document FPS and memory usage at each stage
4. Generate performance report

**Expected Results**:
- 50+ agents maintain 60 FPS
- Memory usage remains under 5MB
- Frame time per agent <0.1ms

### **Scenario 2: AI Behavior Analysis**
**Objective**: Showcase sophisticated AI decision-making
1. Focus on single Miner Bob character
2. Observe mining → fatigue → sleep cycle
3. Watch thirst management and drinking behavior
4. Monitor gold accumulation and deposit decisions

**Expected Results**:
- Complex multi-variable decision making
- Smooth state transitions
- Realistic behavior patterns
- Visual debugging clarity

### **Scenario 3: Technical Architecture**
**Objective**: Demonstrate advanced programming concepts
1. Examine behavior tree structure in Behavior Designer
2. Review code organization and design patterns
3. Test modularity by disabling/enabling components
4. Analyze visual debugging implementation

**Expected Results**:
- Clean architecture with clear separation of concerns
- Professional-quality code organization
- Extensible and maintainable design
- Custom tool functionality

---

## 🔧 Troubleshooting

### **Common Issues**

#### **Behavior Designer Not Found**
- **Symptom**: Compilation errors about missing BehaviorDesigner namespace
- **Solution**: Import Behavior Designer asset from Unity Asset Store

#### **Poor Performance**
- **Symptom**: Low FPS with few agents
- **Solution**: Check GPU drivers, reduce quality settings in Unity

#### **Missing AI Behaviors**
- **Symptom**: AI agents don't move or react
- **Solution**: Ensure behavior tree assets are properly assigned

#### **Visual Debugging Not Showing**
- **Symptom**: No sight cones visible
- **Solution**: Enable Gizmos in Scene view, ensure editor mode

### **Performance Optimization Tips**
- Run in **Release mode** for accurate performance metrics
- Close unnecessary applications to free system resources
- Use **Unity Profiler** to identify bottlenecks
- Test on target hardware for realistic results

---

## 📈 Success Criteria

### **Minimum Viable Demo**
- [ ] Project opens without errors
- [ ] Basic AI behavior is functional
- [ ] Performance benchmark runs successfully
- [ ] Documentation is accessible and clear

### **Professional Portfolio Demo**
- [ ] Exceeds performance targets (50+ agents at 60 FPS)
- [ ] Demonstrates advanced technical features
- [ ] Shows clear evidence of learning and growth
- [ ] Includes comprehensive documentation suite
- [ ] Presents as production-quality work

### **Beyond Classroom Evidence**
- [ ] Custom tools and debugging systems
- [ ] Self-directed learning integration
- [ ] Innovation beyond standard requirements
- [ ] Professional development practices
- [ ] Quantifiable improvements and metrics

---

## 💡 Evaluation Tips

### **For Technical Reviewers**
- Focus on **code architecture** and design patterns
- Examine **performance optimization** techniques
- Evaluate **visual debugging** system implementation
- Review **documentation quality** and completeness

### **For Portfolio Assessment**
- Look for evidence of **self-directed learning**
- Assess **technical depth** beyond coursework
- Evaluate **professional presentation** quality
- Consider **practical application** value

### **For Educational Review**
- Identify **advanced concepts** applied
- Assess **learning progression** evidence
- Evaluate **problem-solving approach**
- Consider **knowledge transfer** capability

This demo setup guide ensures that evaluators can quickly experience the full scope of the AI Behaviour Tree Demo project and assess its "Beyond Classroom" achievements effectively.