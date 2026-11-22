# Museum Manager: Curator edition

A design-expanded take on the 2018 Unity/ARCore prototype in this repo. It starts from the same loop as the faithful remaster (place artifacts in three halls, guests tour and donate) and adds the management layer the prototype was heading toward. The Unity project on `master` is untouched.

Open `index.html` in any modern browser (it loads Three.js from jsDelivr). No build step.

## The goal

Ten in-game days (about 80 seconds each) to grow the museum to a five-star reputation.

## Systems added on top of the 2018 loop

- **Hall themes.** Hall I is Antiquities, Hall II is Natural History, Hall III is Treasures. Each artifact belongs to one theme and gets 1.5x appeal in its matching hall. A hall with three on-theme pieces is *curated* and adds a donation and reputation bonus.
- **Guest interests.** Each visitor has a favourite theme (their shirt colour matches the hall colour). They head to that hall first and enjoy its pieces 1.4x more.
- **Ticket price.** Set from $0 to $10 in the HUD. Guests pay on entry. A higher price earns more per head but slows arrivals, and a guest leaves happy only if what they saw outweighs what they paid.
- **Reputation.** Happy guests raise it, disappointed guests ("meh") lower it. Reputation drives how quickly guests arrive and is the win condition (five stars from 90/100).
- **Days and upkeep.** The light warms toward evening, doors close near the end of the day, and a report card shows visitors, happy ratio, ticket sales, donations, upkeep ($2 per displayed piece) and the reputation change, with a tip based on how the day went.
- **Season end.** After day 10 you get a star rating and can start a new season.

Everything from the remaster carries over: artifact acquisition with funds, guest view, spotlights, sound, autosave.
