# Presentation Slide Notes — Physics Playground

These short slide descriptions map to the demo and show what to put on each slide (title, short description, what lesson it maps to, and suggested image/demo screenshot). Use these as speaker notes or paste text into your slide app.

---

Slide 1 — Title
- Title: Physics Playground — Master Edition
- Subtitle: Week 4 Physics Demonstration
- Your name, date
- Image: Screenshot of whole scene (wide shot)
- Notes: "This project demonstrates Rigidbody types, joints, raycasting, particles, cloth and physics materials used during Week 4."

---

Slide 2 — Project Overview
- Title: Project Overview
- Bullet: "Sandbox with 6 zones demonstrating core physics concepts"
- Short mapping to lesson: "Rigidbody types, forces, collision/trigger, physics materials, joints, and raycasting"
- Image: Annotated map screenshot (show zones locations)
- Notes: "Explain the game concept briefly and that each zone focuses on one lesson topic."

---

Slide 3 — Zone 1: Bouncy Platform
- Title: Zone 1 — Bouncy Platform
- Short: "Demonstrates Physic Materials and bounce behavior"
- Lesson mapping: Physics Materials (Bounciness), collision response
- Image: Screenshot of ball bouncing on orange platform
- Notes: "Show inspector of Physic Material (BouncyMaterial) and point out bounciness values."

---

Slide 4 — Zone 2: Joints Mechanism
- Title: Zone 2 — Joints (Hinge, Spring, Fixed)
- Short: "Hinge door, spring-attached sphere, and fixed boxes"
- Lesson mapping: Joints (Hinge Joint, Spring Joint, Fixed Joint), Kinematic anchors
- Image: Short clip/screenshot of hinge door swinging
- Notes: "Mention Kinematic Rigidbody anchor requirement and troubleshooting tip."

---

Slide 5 — Zone 3: Shooting Range (Raycasting)
- Title: Zone 3 — Shooting Range
- Short: "Player aims with mouse, fires projectiles (left click). Raycast visualization for aim."
- Lesson mapping: Raycasting, ForceMode.Impulse, collision detection
- Image: Screenshot showing crosshair / camera + target hit
- Notes: "Explain shooting controls (Left Click) and how the ShootPoint follows camera direction. Show console log evidence of TargetHit and score update."

---

Slide 6 — Zone 4: Moving & Rotating Platforms
- Title: Zone 4 — Kinematic Platforms
- Short: "Demonstrates Kinematic rigidbodies moving platforms and rotation via MovePosition/MoveRotation"
- Lesson mapping: Kinematic Rigidbody vs Dynamic
- Image: Platform screenshot with player standing on it
- Notes: "Explain why platforms are kinematic (predictable movement, player rides)."

---

Slide 7 — Zone 5: Collectibles & Particles
- Title: Zone 5 — Particle Collectibles
- Short: "Collectibles trigger particle bursts and increase score"
- Lesson mapping: Trigger detection (OnTriggerEnter), Particle Systems, UI integration
- Image: Screenshot of collectible particle burst
- Notes: "Show GameManager updating score and Collectible script detaching particle system before destroy."

---

Slide 8 — Zone 6: Cloth Flag
- Title: Zone 6 — Cloth Simulation
- Short: "Plane with Cloth component reacts to wind and constraints"
- Lesson mapping: Cloth Simulation, vertex constraints
- Image: Flag waving screenshot or short clip
- Notes: "Explain constraint painting and tether settings for the anchor edge."

---

Slide 9 — Player & Camera
- Title: Player & Camera
- Short: "Capsule player (no rolling), camera-relative movement, mouse-controlled orbit and aiming"
- Lesson mapping: Rigidbody constraints, camera-relative movement, input mapping
- Image: Screenshot of player with camera overlay (show ShootPoint)
- Notes: "Explain freeze rotation on X/Z, movement in FixedUpdate using AddForce, and camera rotation locked to mouse."

---

Slide 10 — Code Highlights
- Title: Code Highlights
- Short bullets: PlayerController (camera-relative movement), ShootingController (left-click, shootPoint follow camera), ProjectileScript (TargetHit + GameManager), Collectible (particle burst)
- Image: Small code snippets screenshots (one-line each) or paste short snippets
- Notes: "Highlight use of FixedUpdate for physics and why we ignore collision between projectile and player."

---

Slide 11 — Challenges & Solutions
- Title: Challenges & Solutions
- Bullets: "Joint anchors needed Rigidbodies (fixed kinematic)", "Projectile collided with player (fixed by disabling trigger and ignoring collision)", "Cursor lock vs shooting (ESC to unlock, TAB/E to re-lock)"
- Image: Optional small console screenshot showing debug logs
- Notes: Briefly talk about debugging steps and console messages.

---

Slide 12 — Demo & How to Run
- Title: Live Demo
- Short: "Run scene in Unity: WASD move, Space jump, Left Click shoot, R reset"
- Image: Screen-recording thumbnail / placeholder
- Notes: "Point to inspector variables to adjust (moveForce, shootForce, maxSpeed)."

---

Slide 13 — Conclusion & Next Steps
- Title: Conclusion
- Short bullets: "All Week 4 topics demonstrated", "Extend with sounds, more zones, or challenges"
- Image: Final scene screenshot
- Notes: "Invite questions and mention repo/export instructions."

---

Usage: copy each slide block into a single slide. Replace placeholder images with screenshots or short clips from your recorded demo. Keep text minimal on slides — use the Notes area to expand during presentation.
