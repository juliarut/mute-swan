# mute-swan

**Instructions**



Version history

**v.0.1.0**
First prototype with basic elements: text display, boat animation, greyboxed placeholder models, gate animation and frog interaction

Known issues:
- Low FPS 36 and below
- Text jitter and jumping
- High cpu usage from rendering and scripts

**v.0.1.1 Patch**
- Fixed text display jitter and timing
- Added fade animation
- Skybox asset added
- New bridge model added to assets
- Oculus SDK imported to project

**v.0.1.2**
- Add ambience loop
- Add new boat model to main scene
- Add new bridge model to scene

  Unit tests
  1. Change backend from OpenXR to Oculus Integration (v.0.1.3) Result: + 12 FPS (Avg 48 fps)
  2. Disable timeline (v.0.1.4) Result: Result + 12 FPS (Avg 56 FPS)
  3. Disable terrain (v.0.1.5) Result: + 16 FPS (Avg 72 FPS but with drops to abou 56)
  4. Use OpenGLES instead of Vulcan (v.0.1.6) Result: No significant change
  5. Go back to Vulcan, disable shadows on objects and bake light (v.0.1.7) Result: Solid AVG 72 FPS
  6. Revert to previous settings (before unit tests), but bake lighting. New models in main scene. Result: 36 FPS
  7. Disable timeline. Result: 48 FPS Avg.
  8. Re-enable timeline, disable terrain. Result: close to 72 FPS Average.
  9. Switch to Oculus inteagration. Result: more solid 72 FPS.
