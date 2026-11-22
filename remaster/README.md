# Museum Manager: web remaster

A browser remake of the 2018 Unity/ARCore prototype in this repo. The original project on `master` is untouched; this folder is self-contained.

Open `index.html` in any modern browser (it loads Three.js from jsDelivr, so it needs a network connection). No build step.

## What it keeps from the 2018 prototype

| 2018 Unity piece | In the remaster |
| --- | --- |
| `NewCity` scene: a museum on a small city block, viewed like a tabletop AR model | Same diorama framing: a table, a city block, a cut-away museum you orbit around |
| Three exhibit halls (`Exhibit Hall 1/2/3` buttons) and spotlights | Three halls with three pedestals each; each filled pedestal gets its own spotlight |
| `ArtifactPlace` + `exhibitplace`: pick Artifact 1/2/3, confirm, tap to place | Pick an artifact card, the free pedestals glow, tap one to place it (tap again to move or store it) |
| `GuestTimer`: a guest spawns every few seconds | Guests arrive from the street; more exhibits mean they arrive faster |
| `GuestWaypointMove`: guests loop the waypoints, stay longer if artifacts exist, then donate | Guests tour each hall, stop at every exhibit (longer for better pieces), and donate on the way out based on what they saw |
| `Button.donatevalue` and the Donations label | Donations counter with floating `+$` pops at the door |
| `CameraChange` / `guestviewmove` | **Guest view** rides along behind a random visitor |

## What's new

- Donations now buy things: six more artifacts to acquire (astrolabe, meteorite, Ming vase, golden idol, funerary mask, raptor skull), each with an appeal rating.
- Full-hall bonus: a hall with all three pedestals filled adds to every visitor's donation.
- Onboarding hints, a "Grand opening" moment when all nine pedestals are filled, optional sound, and autosave in the browser.
- Works with mouse or touch; drag to orbit, scroll or pinch to zoom.

## Controls

- Drag: orbit. Right-drag or two fingers: pan. Scroll or pinch: zoom.
- Tap a collection card, then a glowing pedestal, to display it.
- Tap a displayed artifact to move it or put it back in storage.
- Esc: cancel the current selection or leave guest view.
