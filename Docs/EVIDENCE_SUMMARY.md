EVIDENCE SUMMARY — Week 4 Physics Project

Purpose
- Quick one-page checklist of exact files and lines to open during a demo or submission. These show key implemented features: AddForce movement, jump, frozen rotations (capsule player), camera-relative shooting, projectile behavior, collectible pickup, and GameManager scoring hooks.

How to demo (quick):
1. Open Unity, enter Play mode.
2. Walk/Jump and shoot (Left Mouse) at targets/collectibles.
3. Watch the Console for these debug messages (shows correct wiring):
   - "GameManager.TargetHit() called!"
   - "GameManager.CollectiblePicked() called!"

Key files & exact lines to show in editor (open these files and scroll to the line numbers listed):

1) Player movement & constraints
- `Assets/Scripts/PlayerController.cs`
  - rb constraints (freeze roll): line 33
    - line 33: rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
  - AddForce horizontal movement: line 68
    - line 68: rb.AddForce(movement * moveForce);
  - Jump (vertical impulse): line 82
    - line 82: rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
  - OnCollisionEnter (ground/other collision handling): line 106
  - OnTriggerEnter (trigger pickups or zones): line 118

2) Shooting & spawn-ignore-collision
- `Assets/Scripts/ShootingController.cs`
  - Shoot() method (left-click handler): line 45
  - Ignore collision between projectile and player at spawn: line 55
    - line 55: Physics.IgnoreCollision(projectileCollider, playerCollider);
  - Apply impulse to projectile (spawn force): line 62
    - line 62: rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);

3) Projectile behavior & scoring hookup
- `Assets/Scripts/ProjectileScript.cs`
  - OnCollisionEnter (impact handling): line 5
  - Apply knockback to target rigidbody: line 20
    - line 20: targetRb.AddForce(forceDirection * 500f);
  - Call GameManager when hitting target: lines 31-32
    - line 31: GameManager.Instance.TargetHit();
    - line 32: Debug.Log("GameManager.TargetHit() called!");

4) Collectibles pickups -> GameManager
- `Assets/Scripts/Collectible.cs`
  - OnTriggerEnter (player pickup): line 26
  - GameManager call + debug: lines 55-56
    - line 55: GameManager.Instance.CollectiblePicked();
    - line 56: Debug.Log("GameManager.CollectiblePicked() called!");

5) Game manager score methods
- `Assets/Scripts/GameManager.cs`
  - public void CollectiblePicked(): line 42
  - public void TargetHit(): line 48

6) Supporting: guide snippets (optional to show)
- `COMPLETE_BEGINNER_GUIDE.md` — includes the same snippets as the scripts if you want a human-readable explanation with code examples. (Search for AddForce / Shoot / OnCollisionEnter in the guide.)

Quick inspector checks to show (in Unity Editor during demo)
- Projectile prefab (select in Project window): verify Collider component is NOT "Is Trigger" (so OnCollisionEnter fires), and `ProjectileScript` is attached.
- Player object: Rigidbody constraints show X/Z rotation frozen.
- GameManager: show GameManager instance in the scene (usually a singleton GameObject with `GameManager` script attached) and the score TextMeshPro field.
- Target objects: have `Rigidbody` and `Collider`, and Tag set to `Target` (or whichever tag your code compares to). Collectibles should have `Is Trigger` enabled on their Collider.

What to show in Console
- While playing, demonstrate hitting a target and picking up a collectible and point at the Console entries:
  - "GameManager.TargetHit() called!" (from `ProjectileScript`) — confirms scoring hook runs on projectile impact.
  - "GameManager.CollectiblePicked() called!" (from `Collectible.cs`) — confirms collectible wiring.

Optional verification commands (if you prefer to inspect files from terminal):
- Print the lines around the function (example for `PlayerController.cs`):

  sed -n '1,140p' "Assets/Scripts/PlayerController.cs" | nl -ba | sed -n '1,140p'

(Replace the line ranges if your editor uses different line counts — Unity metadata edits can shift lines; the lines above are based on the current workspace content.)

Notes / caveats
- Line numbers were pulled from the workspace at the time this summary was created. If you edit a file afterward (or Unity regenerates metadata), lines can shift slightly. If a line doesn't match exactly, search for the function name (for example `void Shoot()` or `GameManager.Instance.TargetHit()`) — that will locate the code immediately.
- If Console messages don't appear, check that the GameManager singleton exists in the scene (the scripts call `GameManager.Instance...`) and that tags (Target/Player/Collectible) match what the scripts check.

Next actions (recommended)
- Run Play mode and perform the demo steps above. Note any missing console messages or null-reference errors.
- If you want, I can create a one-page PDF from this file or produce a slide-ready PNG with the exact code snippets and screenshots.

---
Generated: November 13, 2025
