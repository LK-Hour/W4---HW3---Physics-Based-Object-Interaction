# Assignment Guide - Physics-Based Object Interaction
**Week 4 Physics Engine Assignment**  
**Deadline: November 8, 2025 (11:59 PM)**

## 📋 Assignment Requirements

### Objective
Create a physics-based interactive object (2D or 3D) that demonstrates the use of **Rigidbody** and Unity's physics engine features.

### Your Project MUST Include:
1. ✅ **Rigidbody component** to apply forces and simulate physics
2. ✅ **User input** to apply movement using `AddForce()` or `AddTorque()`
3. ✅ **Collision detection** using `OnCollisionEnter()` or `OnTriggerEnter()`
4. ✅ **Physics property customization** (mass, drag, etc.) through Inspector

### Submission Requirements:
You must submit **THREE files**:
1. 📊 **Presentation Slides** (PDF format)
2. 🎥 **Demo Video** showing your game working
3. 📦 **Unity Package** OR **GitHub URL**

## 🎮 Game Ideas (Choose One or Create Your Own)

### Suggested Game Concepts:
1. 🎱 **Ball Rolling Through Maze** - Navigate a ball through obstacles
2. 🎯 **Pinball Game** - Bouncing ball with paddles and bumpers
3. 🎪 **Target Shooting Game** - Shoot projectiles at targets that fall/bounce
4. 🏀 **Basketball/Soccer** - Physics-based ball game with goals
5. 🚗 **Simple Racing** - Vehicle with physics controls
6. 🧩 **Physics Puzzle** - Stack, balance, or manipulate objects

## 📝 Step-by-Step Implementation Guide

### Step 1: Planning Phase (Day 1)
- [ ] Create a new Unity scene
- [ ] Add a Plane/Ground (with Collider)
- [ ] Add a Directional Light
- [ ] Add Main Camera
- [ ] Configure Physics settings (Edit → Project Settings → Physics)

#### 2. **GameObject Setup**
- [ ] Add your game objects (cubes, spheres, etc.)
- [ ] Add Rigidbody component to moving objects
- [ ] Add appropriate Collider components
- [ ] Create Physics Materials for different surfaces
- [ ] Set up Layers for collision filtering (optional)

#### 3. **Script Setup**
- [ ] Create Scripts folder in Assets
- [ ] Write your physics scripts in C#
- [ ] Attach scripts to appropriate GameObjects
- [ ] Configure public variables in Inspector

### Essential Code Snippets

#### Basic Rigidbody Setup
```csharp
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Get or add Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        
        // Configure properties
        rb.mass = 1.0f;
        rb.drag = 0.5f;
        rb.angularDrag = 0.05f;
        rb.useGravity = true;
    }
}
```

#### Movement with Physics
```csharp
void FixedUpdate()
{
    // Keyboard input
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    
    // Apply force
    Vector3 movement = new Vector3(horizontal, 0, vertical);
    rb.AddForce(movement * moveSpeed);
    
    // Or set velocity directly
    rb.velocity = new Vector3(horizontal * moveSpeed, rb.velocity.y, vertical * moveSpeed);
}
```

#### Jumping Mechanic
```csharp
private bool isGrounded = false;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}

void OnCollisionEnter(Collision collision)
{
    // Check if landed on ground
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}
```

#### Collision Detection
```csharp
void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collided with: " + collision.gameObject.name);
    
    // Get collision point
    ContactPoint contact = collision.contacts[0];
    Vector3 hitPoint = contact.point;
    
    // Access other object's Rigidbody
    Rigidbody otherRb = collision.rigidbody;
    if (otherRb != null)
    {
        // Do something with other object
    }
}
```

#### Trigger Zones
```csharp
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player entered zone!");
        // Trigger event, collect item, etc.
    }
}

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player left zone!");
    }
}
```

#### Raycasting
```csharp
void CheckGround()
{
    RaycastHit hit;
    float rayDistance = 1.1f;
    
    // Cast ray downward
    if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
    {
        if (hit.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    else
    {
        isGrounded = false;
    }
    
    // Visualize in Scene view
    Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);
}
```

#### Force Application Examples
```csharp
// Continuous force
rb.AddForce(transform.forward * force);

// Explosion force
rb.AddExplosionForce(explosionPower, explosionPosition, explosionRadius);

// Direct velocity change
rb.velocity = new Vector3(5, rb.velocity.y, 5);

// Torque (rotation)
rb.AddTorque(transform.up * rotationSpeed);
```

### Common Project Structures

#### Option 1: Physics Playground
```
Assets/
├── Scripts/
│   ├── PhysicsObject.cs
│   ├── ForceApplier.cs
│   └── ResetObject.cs
├── Materials/
│   ├── BouncyMaterial.physicMaterial
│   ├── SlipperyMaterial.physicMaterial
│   └── RoughMaterial.physicMaterial
└── Prefabs/
    ├── Ball.prefab
    ├── Box.prefab
    └── Ramp.prefab
```

#### Option 2: Character Controller
```
Assets/
├── Scripts/
│   ├── PlayerController.cs
│   ├── CameraFollow.cs
│   └── GroundCheck.cs
├── Materials/
│   └── PlayerMaterial.physicMaterial
└── Prefabs/
    └── Player.prefab
```

#### Option 3: Projectile System
```
Assets/
├── Scripts/
│   ├── Launcher.cs
│   ├── Projectile.cs
│   ├── Target.cs
│   └── TrajectoryPredictor.cs
├── Materials/
│   └── ProjectileMaterial.physicMaterial
└── Prefabs/
    ├── Cannon.prefab
    ├── Ball.prefab
    └── Target.prefab
```

### Testing Checklist

Before submission, test these:
- [ ] Objects respond to gravity correctly
- [ ] Collisions are detected properly
- [ ] Forces are applied as expected
- [ ] No objects fall through floors
- [ ] Performance is acceptable (check FPS)
- [ ] All public variables are set in Inspector
- [ ] Code has no errors or warnings
- [ ] Scene is properly saved

### Documentation Checklist

Include in your project:
- [ ] README explaining how to use your project
- [ ] Comments in your code
- [ ] Description of physics concepts demonstrated
- [ ] Controls explanation (if interactive)
- [ ] List any issues or limitations

### Submission Format

Your project should include:
1. **Unity Project Folder** (or packaged .unitypackage)
2. **Documentation** (README.md or PDF)
3. **Screenshots/Video** showing your project working
4. **Code Files** (if submitting separately)

### Quick Tips for Success

✅ **DO:**
- Start simple, then add complexity
- Test frequently as you build
- Use Debug.Log() to troubleshoot
- Adjust physics values in Play mode, then copy to Inspector
- Use layers to organize collision detection
- Comment your code

❌ **DON'T:**
- Move Rigidbodies with Transform.position in Update()
- Forget to set "Is Trigger" when needed
- Use Mesh Colliders for everything (performance)
- Forget to check for null references
- Mix 2D and 3D physics components

### Example: Complete Simple Project

**Bouncy Ball Demo**
```csharp
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float bounceForce = 10f;
    public float resetHeight = -10f;
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        
        // Create bouncy physics material
        PhysicMaterial bouncyMat = new PhysicMaterial("Bouncy");
        bouncyMat.bounciness = 0.9f;
        bouncyMat.frictionCombine = PhysicMaterialCombine.Minimum;
        bouncyMat.bounceCombine = PhysicMaterialCombine.Maximum;
        
        GetComponent<Collider>().material = bouncyMat;
    }

    void Update()
    {
        // Reset if falls too far
        if (transform.position.y < resetHeight)
        {
            ResetBall();
        }
        
        // Manual launch on spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Visual feedback
        Debug.Log($"Ball hit {collision.gameObject.name} with force: {collision.impulse.magnitude}");
    }

    void ResetBall()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
```

### Need Help?

If stuck, check:
1. Unity Manual: https://docs.unity3d.com/Manual/PhysicsSection.html
2. Unity Scripting Reference: https://docs.unity3d.com/ScriptReference/
3. Unity Forums and Unity Answers
4. Your LEARNING_SUMMARY.md file

---

## Final Reminders

- **Physics runs in FixedUpdate()**, not Update()
- **Use ForceMode.Impulse** for instant forces (like jumping)
- **Tag your ground objects** for easy detection
- **Visualize with Debug.DrawRay()** during development
- **Save your scene often!**

Good luck with your assignment! 🚀🎮
