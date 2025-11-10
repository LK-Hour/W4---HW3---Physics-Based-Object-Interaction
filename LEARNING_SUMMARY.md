# Week 4 - Physics Engine Learning Summary
**Lecturer: Dr. VA Hongly**

## Overview
This document summarizes what we've learned about Physics Engines in game development during Week 4, covering Rigidbody, Colliders, Joints, Particle Systems, and Cloth simulation in Unity.

## Session Objectives
✓ Understand Rigid Body physics  
✓ Master Collider components  
✓ Implement Joints  
✓ Create Particle Systems  
✓ Work with Cloth simulation  

## Key Concepts Learned

### 1. **What is Physics in Unity?**
Understanding the fundamental questions:
- **What is a Rigid Body?** - An object that has physics properties (mass, velocity, forces)
- **What is Gravity?** - The force that pulls objects downward (Isaac Newton's discovery)
- **What is a Collider?** - The invisible "skin" that defines an object's physical boundaries
- **What is a Joint?** - A connection between two physics objects

### 2. **Rigidbody 3D Component**

#### **Key Properties Explained:**

| Property | Description |
|----------|-------------|
| **Mass** | Defines the mass of the GameObject (in kilograms) |
| **Linear Drag** | Decay rate of linear velocity - simulates air resistance or friction during movement |
| **Angular Drag** | Decay rate of rotational velocity - simulates friction against rotation |
| **Automatic Center of Mass** | If enabled, Unity predicts the center of mass based on shape and scale |
| **Automatic Tensor** | If enabled, uses physics system's predicted tensor and tensor rotation |
| **Use Gravity** | Whether gravity force is applied to the object |
| **Is Kinematic** | Allows object to move without force or velocity (animation-driven) |
| **Interpolate** | Smoothing movement option:<br>• **None**: No smoothing<br>• **Interpolate**: Based on previous frame<br>• **Extrapolate**: Based on estimated next frame position |
| **Collision Detection** | **Discrete** vs **Continuous** collision checking |

**Important Physics Fact:** 
> **Gravity is independent of Mass in free fall** - All objects fall at the same rate regardless of their mass!

### 3. **Rigidbody Types**

Unity has three types of physics bodies:

#### **Dynamic Rigidbody**
- **Responds to physics** (forces, collisions, gravity)
- **Use for:** Objects that need to move freely and interact with forces
- **Examples:** 
  - Falling objects
  - Rolling balls
  - Moving characters
  - Projectiles
  - Physics-based vehicles

#### **Kinematic Rigidbody**
- **Does NOT respond** to collisions or forces
- Movement controlled by animation or script
- **Use for:** Objects with specific movement/animations that shouldn't react to forces
- **Examples:**
  - Animated platforms
  - Moving elevators
  - Scripted doors
  - Cutscene objects

#### **Static (No Rigidbody)**
- **Non-moving object** with NO Rigidbody component
- **Use for:** Immovable objects or background elements
- **Examples:**
  - Walls and floors
  - Buildings
  - Terrain
  - Non-interactive decorations

### 4. **Collision Detection Modes**

**Proper use of collision modes:**
- ✅ **Use Discrete** if possible (most efficient)
- ✅ **Use Continuous Speculative** if your object has fast angular motion
- ✅ **Use Continuous** if ghost collisions are a problem
- ✅ **Use Continuous Dynamic** if multiple fast dynamic objects collide

### 5. **Colliders - The Invisible Touchable Skin**

Colliders are like an **invisible and touchable skin** covering objects.

#### **Basic Colliders:**
- **Box Collider / Box Collider 2D** - Rectangular shapes
- **Sphere Collider / Circle Collider 2D** - Spherical/circular objects
- **Capsule Collider / Capsule Collider 2D** - Characters, pill-shaped objects

#### **Advanced Colliders:**
- **Mesh Collider** - Complex 3D shapes (like a detailed car model)
- **Polygon Collider 2D** - Custom 2D shapes
- **Wheel Collider** - Specialized for vehicle wheels
- **Terrain Collider** - For terrain objects
- **Edge Collider 2D** - 2D lines and edges

#### **Collider Examples in Games:**
- **Character:** Capsule Collider (for body)
- **Gun/Weapon:** Box Collider
- **Vehicle:** Mesh Collider or combination of Box Colliders
- **Obstacles:** Box Collider 2D
- **Complex characters:** Nested colliders (multiple colliders on different body parts)

### 6. **Joints - Connecting Physics Objects**

There are **3 common types of joints** in Unity:

#### **Fixed Joint**
- Locks two objects together rigidly
- Objects stay at fixed distance and angle
- **Example:** Two cubes connected together

#### **Hinge Joint**
- Allows rotation around one axis (like a door)
- **Example:** A series of cubes connected in a chain
- Door hinges, swinging objects

#### **Spring Joint**
- Creates an elastic connection between objects
- Objects can stretch and bounce back
- **Example:** Pentagon connected to Cube with spring-like behavior
- Bungee cords, elastic connections

### 7. **Casting - Physics Raycasting**

**Casting** is the act of casting rays toward 2D or 3D colliders to send or receive messages to/from physics objects.

#### **Types of Casting in Unity:**
- **Raycast** - Single ray detection (most common)
- **SphereCast** - Sphere-shaped detection
- **BoxCast** - Box-shaped detection
- **CircleCast** - Circle-shaped detection (2D)
- **CapsuleCast** - Capsule-shaped detection
- **LineCast** - Line between two points

**Use Cases:**
- Enemy AI seeking player (line of sight)
- Shooting mechanics
- Ground detection
- Object interaction range checking

### 8. **Particle System**

#### **What is a Particle System?**
A system to control a collection of individual elements (points, lines, triangles, or textures) which act independently but share common attributes.

#### **Particle Common Attributes:**
- **Position** (3D coordinates)
- **Velocity** (vector: speed and direction)
- **Color** (+ transparency)
- **Lifetime** (how long particle exists)
- **Size & Shape**

#### **Key Concepts:**
- Particle System is a **Component** added to a GameObject
- Uses **Modules** for controlling behavior
- Has an **Emitter** that spawns particles
- Each particle is **NOT a Game Object** (for performance)

**Process:** Emission → Behavior → Rendering → Death

**Use Cases:**
- Fire effects
- Smoke
- Explosions
- Magic spells
- Rain/Snow
- Sparks
- Dust clouds

### 9. **Cloth Simulation**

#### **Cloth Component Properties:**

| Property | Explanation |
|----------|-------------|
| **Stretching Stiffness** | How resistant the cloth is to stretching |
| **Bending Stiffness** | How resistant the cloth is to bending |
| **Use Tethers** | Constraints to prevent cloth particles from going too far from fixed points (reduces excess stretching) |
| **Use Gravity** | Whether gravitational acceleration is applied |
| **Damping** | Motion damping coefficient (slows movement) |
| **External Acceleration** | Constant external force applied (like wind) |
| **Random Acceleration** | Random external forces for natural movement |

#### **Simulation Method:**
- **Physical Method:** Treats cloth as a grid of nodes connected by springs
- **Advanced:** Obi Cloth for improved simulation

#### **Performance Comparison:**
Based on NVIDIA GeForce RTX 2070 SUPER 8GB:

| Vertices | Constraints | Mesh-based PBD | Unity Cloth | Shader-based PBD |
|----------|-------------|----------------|-------------|------------------|
| 1,024    | 5,766       | 88.57 fps      | 146.42 fps  | 160.75 fps       |
| 4,096    | 23,814      | 54.45 fps      | 141.27 fps  | 151.57 fps       |
| 16,384   | 96,774      | 20.19 fps      | 105.34 fps  | 146.20 fps       |
| 65,536   | 390,150     | 5.34 fps       | 46.57 fps   | 130.07 fps       |

**Use Cases:**
- Character clothing (capes, flags)
- Curtains
- Tablecloths
- Soft body objects

### 10. **Key Implementation Code Examples**

#### **Applying Forces**
```csharp
// Add continuous force (considering mass)
rigidbody.AddForce(Vector3.forward * force);

// Add impulse (instant force, good for jumping)
rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

// Add torque (rotational force)
rigidbody.AddTorque(Vector3.up * torqueAmount);
```

#### **Collision Detection**
```csharp
// When collision starts
void OnCollisionEnter(Collision collision) {
    Debug.Log("Hit: " + collision.gameObject.name);
}

// When collision ends
void OnCollisionExit(Collision collision) {
    Debug.Log("Stopped touching: " + collision.gameObject.name);
}
```

#### **Trigger Detection**
```csharp
// Triggers don't cause physical collision (set "Is Trigger" checkbox)
void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
        Debug.Log("Player entered zone!");
    }
}

void OnTriggerExit(Collider other) {
    if (other.CompareTag("Player")) {
        Debug.Log("Player left zone!");
    }
}
```

#### **Raycasting Example**
```csharp
// Cast a ray to detect objects
RaycastHit hit;
if (Physics.Raycast(transform.position, transform.forward, out hit, 100f)) {
    Debug.Log("Ray hit: " + hit.collider.name);
    Debug.Log("Distance: " + hit.distance);
}

// Visualize ray in Scene view
Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
```
## Review Questions (from lecture)

**Q1:** Give an example of a **Dynamic object** used in a game.
- Answer: Balls, falling objects, projectiles, physics-based vehicles, moving characters

**Q2:** Give an example of a **Kinematic object** used in a game.
- Answer: Animated platforms, moving elevators, scripted doors, cutscene objects

**Q3:** Give an example of a **Static object** used in a game.
- Answer: Walls, floors, buildings, terrain, non-interactive decorations

## HOMEWORK ASSIGNMENT 📝

**Title:** Physics-Based Object Interaction  
**Deadline:** November 8, 2025 (11:59 PM) - **13 days**

### Objective:
Create a physics-based interactive object (2D or 3D) that demonstrates the use of **Rigidbody** and Unity's physics engine features.

### Requirements:
Your object MUST:
1. ✅ Use **Rigidbody** to apply forces and simulate physics
2. ✅ Respond to **user input** to apply movement using `AddForce()` or `AddTorque()`
3. ✅ Detect collisions using `OnCollisionEnter()` or `OnTriggerEnter()`
4. ✅ Include customization of physics properties (e.g., mass, drag) through the Inspector

### Instructions:

#### 1. Think of a Simple Game Concept
Design a small game idea that involves physics such as:
- 🎱 A ball rolling through a maze
- 🎯 A pinball game
- 🎪 A target shooting game where objects fall or bounce
- 🏀 A basketball game
- 🚗 A simple physics-based racing game
- 🧩 A physics puzzle game

#### 2. Setup Your Scene
- Game concept and design
- Environment setup
- Object placement

#### 3. Create Game Mechanics (using scripts)
- Player movement
- Collision detection
- Physics interactions
- Score system (optional)

### Submission Requirements:

You **MUST submit** the following files:
1. 📊 **Slide for presentation** (PDF format)
2. 🎥 **A demo video** showing your game working
3. 📦 **Unity Package** OR **GitHub URL** of your project

### Assessment Criteria:
- Proper use of Rigidbody component
- Correct implementation of AddForce()/AddTorque()
- Working collision detection
- Physics properties customization
- Code quality and comments
- Creativity and game design

## Complete Example Projects

### Example 1: Character Movement with Physics
```csharp
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Movement using AddForce
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * moveSpeed);
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
```

### Example 2: Projectile with Physics
```csharp
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Launch forward using AddForce
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        
        Destroy(gameObject, 5f); // Destroy after 5 seconds
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);
        Destroy(gameObject); // Destroy on impact
    }
}
```

### Example 3: Rolling Ball Maze Game
```csharp
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
        }
    }
}
```

### Example 4: Target Shooting Game
```csharp
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);
    }
}

// Target script
public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Target Hit!");
            Destroy(gameObject); // Destroy target
            Destroy(collision.gameObject); // Destroy projectile
        }
    }
}
```

## Best Practices from Lecture

### ✅ DO:
- Use physics in `FixedUpdate()` not `Update()`
- Apply forces using `AddForce()` or `AddTorque()`
- Use appropriate Rigidbody type (Dynamic/Kinematic/Static)
- Choose the right collision detection mode
- Test and adjust physics properties in Inspector
- Use simple colliders when possible for performance
- Add comments to your code

### ❌ DON'T:
- Move Rigidbodies using `Transform.position` (use forces/velocity)
- Forget to add Rigidbody component to physics objects
- Use Mesh Colliders unnecessarily (performance issue)
- Forget to detect collisions (OnCollisionEnter/OnTriggerEnter)
- Ignore physics properties (mass, drag, etc.)

## Key Takeaways from Week 4

1. 🎯 **Rigidbody** is essential for physics simulation (mass, drag, gravity)
2. 🎯 **Three Rigidbody types:** Dynamic (moves with physics), Kinematic (scripted), Static (no Rigidbody)
3. 🎯 **Colliders** define physical boundaries (Box, Sphere, Capsule, Mesh, etc.)
4. 🎯 **Joints** connect physics objects (Fixed, Hinge, Spring)
5. 🎯 **Collision Detection:** Use `OnCollisionEnter()` and `OnTriggerEnter()`
6. 🎯 **Forces:** Apply movement with `AddForce()` and `AddTorque()`
7. 🎯 **Raycasting:** Detect objects along a ray (line of sight, shooting)
8. 🎯 **Particle Systems:** Create visual effects (fire, smoke, explosions)
9. 🎯 **Cloth Simulation:** Realistic fabric movement
10. 🎯 **Gravity is independent of mass** in free fall!

## Additional Resources

- 📖 Unity Manual: [Rigidbody](https://docs.unity3d.com/2022.3/Documentation/Manual/class-Rigidbody.html)
- 📖 Unity Manual: [Cloth Component](https://docs.unity3d.com/2022.3/Documentation/Manual/class-Cloth.html)
- 🎓 Unity Learn: Physics tutorials
- 💡 Obi Cloth: Advanced cloth simulation
- 🔬 Experiment with different physics properties in Inspector

## Practice Makes Perfect! 🎮

Remember the lecture motto:
> "If you ever do this, your childhood was awesome!" 

Experiment with physics to make amazing interactive games!

---

**Note:** You have **13 days** (until November 8, 2025) to complete your assignment. Start early, experiment with different ideas, and have fun with physics! Good luck! 🚀
