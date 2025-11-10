# HOMEWORK: Physics-Based Object Interaction 🎮
**Deadline: November 8, 2025 (11:59 PM) - 13 Days Remaining**

---

## 🎯 Assignment Objective

Create a physics-based interactive object (2D or 3D) that demonstrates the use of **Rigidbody** and Unity's physics engine features.

## ✅ Mandatory Requirements

Your project **MUST** include ALL of the following:

### 1. **Rigidbody Physics** 
- [ ] Use Rigidbody component to simulate physics
- [ ] Objects must respond to gravity
- [ ] Demonstrate mass and drag properties

### 2. **User Input & Forces**
- [ ] Respond to user input (keyboard/mouse)
- [ ] Use `AddForce()` for movement
- [ ] OR use `AddTorque()` for rotation
- [ ] Show at least one ForceMode (Force, Impulse, etc.)

### 3. **Collision Detection**
- [ ] Implement `OnCollisionEnter()` OR `OnTriggerEnter()`
- [ ] Detect when objects collide
- [ ] Respond to collision events (destroy, score, feedback)

### 4. **Inspector Customization**
- [ ] Expose public variables for physics properties
- [ ] Allow customization of:
  - Mass
  - Drag / Angular Drag
  - Force amounts
  - Other physics parameters

## 📦 Submission Requirements

You **MUST** submit **THREE** items:

### 1. Presentation Slides (PDF) 📊
Include:
- Project title and your name
- Game concept explanation
- Screenshots of your game
- Technical implementation details
- Challenges faced and solutions
- Demo instructions

### 2. Demo Video 🎥
Requirements:
- 1-3 minutes long
- Show gameplay footage
- Demonstrate all physics features
- Show user interaction
- Voiceover or text explaining features (optional but recommended)
- Upload to YouTube/Google Drive and include link

### 3. Unity Project 📦
Submit either:
- **Unity Package** (.unitypackage file)
  - Export: Assets → Export Package → Include all assets
- **GitHub Repository URL**
  - Must be public or give access
  - Include README with setup instructions

---

## 🎮 Suggested Game Ideas

### Option 1: Ball Rolling Through Maze 🎱
**Concept:** Control a ball and navigate through a maze to reach the goal
- **Input:** Arrow keys to apply force
- **Physics:** Ball rolls using AddForce()
- **Collision:** Detect walls, goal, obstacles
- **Bonus:** Add moving platforms, holes to avoid

### Option 2: Pinball Game 🎯
**Concept:** Classic pinball with paddles, bumpers, and targets
- **Input:** Spacebar/buttons for paddles
- **Physics:** Ball bounces with high bounciness
- **Collision:** Bumpers add force, targets give points
- **Bonus:** Multiple balls, power-ups

### Option 3: Target Shooting Game 🎪
**Concept:** Shoot projectiles to knock down targets
- **Input:** Mouse aim, click to shoot
- **Physics:** Projectiles launched with AddForce()
- **Collision:** Targets fall when hit
- **Bonus:** Different target types, moving targets

### Option 4: Basketball/Soccer ⚽
**Concept:** Physics-based sports game
- **Input:** WASD for player, spacebar to kick/shoot
- **Physics:** Ball and player movement with forces
- **Collision:** Detect goal scoring
- **Bonus:** Multiple players, obstacles

### Option 5: Physics Puzzle 🧩
**Concept:** Stack or balance objects to solve puzzles
- **Input:** Click and drag to apply forces
- **Physics:** Objects stack and balance realistically
- **Collision:** Detect when puzzle is solved
- **Bonus:** Multiple levels, timer

### Option 6: Simple Bowling 🎳
**Concept:** Roll a ball to knock down pins
- **Input:** Mouse drag and release for force
- **Physics:** Ball and pins with realistic collisions
- **Collision:** Count knocked down pins
- **Bonus:** Multiple balls, score system

---

## 📋 Implementation Checklist

### Phase 1: Setup (Days 1-2)
- [ ] Create new Unity project or scene
- [ ] Design game concept (choose from above or create own)
- [ ] Sketch scene layout
- [ ] List required GameObjects

### Phase 2: Scene Creation (Days 3-4)
- [ ] Create ground/floor with Collider
- [ ] Add main game objects (ball, player, targets, etc.)
- [ ] Add walls or boundaries
- [ ] Add lighting and camera setup

### Phase 3: Add Physics (Days 5-7)
- [ ] Add Rigidbody to moving objects
- [ ] Add appropriate Colliders (Box, Sphere, Capsule)
- [ ] Test gravity and basic physics
- [ ] Create Physics Materials if needed (bouncy, slippery)
- [ ] Adjust mass, drag, and other properties

### Phase 4: Scripting (Days 8-10)
- [ ] Create player controller script
- [ ] Implement AddForce() or AddTorque()
- [ ] Add input handling (keyboard/mouse)
- [ ] Implement OnCollisionEnter() or OnTriggerEnter()
- [ ] Add game logic (score, win condition, etc.)
- [ ] Test and debug

### Phase 5: Polish (Days 11-12)
- [ ] Add UI (score, instructions)
- [ ] Add visual feedback (particle effects optional)
- [ ] Add sound effects (optional)
- [ ] Test thoroughly
- [ ] Fix bugs

### Phase 6: Documentation & Submission (Day 13)
- [ ] Create presentation slides
- [ ] Record demo video
- [ ] Export Unity package OR push to GitHub
- [ ] Test that package/GitHub works
- [ ] Submit before deadline!

---

## 💻 Essential Code Templates

### Template 1: Ball Controller with AddForce
```csharp
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Customize physics properties
        rb.mass = 1f;
        rb.drag = 0.5f;
        rb.angularDrag = 0.05f;
    }

    void FixedUpdate()
    {
        // Get player input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Apply force to move the ball
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * moveForce);
    }

    // Collision detection
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal Reached!");
            // Add win logic here
        }
    }
}
```

### Template 2: Projectile Shooter
```csharp
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 500f;

    void Update()
    {
        // Shoot on spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create projectile
        GameObject projectile = Instantiate(
            projectilePrefab, 
            shootPoint.position, 
            shootPoint.rotation
        );
        
        // Get Rigidbody and apply force
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce);
        
        // Destroy after 5 seconds
        Destroy(projectile, 5f);
    }
}

// Attach this to projectile prefab
public class Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Target"))
        {
            // Destroy target
            Destroy(collision.gameObject);
        }
        
        // Destroy projectile
        Destroy(gameObject);
    }
}
```

### Template 3: Trigger Zone Detector
```csharp
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached goal!");
            // Add win logic
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        // Your victory logic here
        Debug.Log("You Win!");
    }
}
```

### Template 4: Score Manager
```csharp
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    [Header("UI")]
    public Text scoreText;
    
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

// Use in other scripts:
// ScoreManager.Instance.AddScore(10);
```

---

## 🎯 Grading Criteria (Expected)

| Criteria | Points | Description |
|----------|--------|-------------|
| **Rigidbody Usage** | 20% | Proper implementation of Rigidbody physics |
| **Force Application** | 20% | Correct use of AddForce()/AddTorque() |
| **Collision Detection** | 20% | Working OnCollisionEnter/OnTriggerEnter |
| **Customization** | 15% | Inspector variables for physics properties |
| **Code Quality** | 10% | Clean code with comments |
| **Presentation** | 10% | Clear slides explaining project |
| **Demo Video** | 5% | Quality demonstration of features |

---

## ✅ Pre-Submission Checklist

Before submitting, make sure:

### Code Checklist
- [ ] All scripts compile without errors
- [ ] No warnings in console
- [ ] Code has comments explaining key parts
- [ ] Public variables have descriptive names
- [ ] AddForce() or AddTorque() is used
- [ ] Collision detection works correctly
- [ ] Game can be played from start to finish

### Unity Checklist
- [ ] Scene is saved
- [ ] All GameObjects have appropriate names
- [ ] Tags are set correctly (Player, Ground, Goal, etc.)
- [ ] Rigidbody is added to moving objects
- [ ] Colliders are added to all interactive objects
- [ ] Physics properties are customized in Inspector
- [ ] Project builds without errors

### Documentation Checklist
- [ ] Presentation slides are complete (PDF)
- [ ] Demo video is recorded and accessible
- [ ] Unity package exports correctly
- [ ] OR GitHub repository is public and includes README
- [ ] All required features are demonstrated

---

## 📚 Quick Reference

### Key Components to Use
```
GameObject → Add Component → Physics → Rigidbody
GameObject → Add Component → Physics → Box Collider (or other)
```

### Important Methods
```csharp
rb.AddForce(direction * force);
rb.AddForce(direction * force, ForceMode.Impulse);
rb.AddTorque(axis * torque);

OnCollisionEnter(Collision collision) { }
OnTriggerEnter(Collider other) { }
```

### Tags Setup
1. Select GameObject
2. Inspector → Tag → Add Tag
3. Create tags: "Player", "Ground", "Goal", "Enemy", etc.
4. Assign tags to appropriate objects

---

## 💡 Tips for Success

### ✅ DO:
- Start simple, add features gradually
- Test frequently after each change
- Use Debug.Log() to troubleshoot
- Adjust values in Play mode, then copy to Inspector
- Keep backups of your work
- Ask questions if stuck
- Watch Unity physics tutorials
- Experiment with different force values

### ❌ DON'T:
- Wait until last day to start
- Move Rigidbody with Transform.position
- Forget to add required components
- Over-complicate your game
- Forget to test collision detection
- Skip documentation
- Miss the deadline!

---

## 🆘 Troubleshooting Common Issues

### Problem: Object falls through floor
**Solution:** 
- Check floor has Collider
- Check object has Rigidbody
- Try Continuous collision detection

### Problem: Object doesn't move
**Solution:**
- Check Rigidbody is not Kinematic
- Check force value is not too small
- Use Debug.Log() to verify input is detected

### Problem: Collision not detected
**Solution:**
- Check both objects have Colliders
- Check at least one has Rigidbody
- Check tags are set correctly
- Verify OnCollisionEnter() is spelled correctly

### Problem: Object moves too fast/slow
**Solution:**
- Adjust force value in Inspector
- Adjust mass and drag
- Try different ForceMode

---

## 📞 Need Help?

Resources:
- 📖 Unity Manual: https://docs.unity3d.com/Manual/PhysicsSection.html
- 💬 Unity Forums: https://forum.unity.com/
- 🎥 Unity Learn: https://learn.unity.com/
- 📧 Ask your instructor: Dr. VA Hongly
- 👥 Discuss with classmates

---

## 🎉 Final Reminders

- **Deadline:** November 8, 2025 (11:59 PM)
- **Days Remaining:** 13 days
- **Required Submissions:** 3 files (Slides PDF, Video, Unity Package/GitHub)
- **Start Early:** Don't wait until the last minute!
- **Have Fun:** Physics simulation is awesome! Experiment and enjoy! 🚀

**Good luck with your assignment!** 🎮⚡
