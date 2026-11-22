# Museum Manager: Restoration Edition

A browser version of the `FinalRound` build of Museum Manager (Unity 2017.3, last commit 2018-05-04), made by ryseymour, sourseymour and Cole Wrampelmeier. It keeps that build's loop: buy a painting at auction, clean it in the conservatory, hang it in an exhibit hall, and fundraise from guests and trivia until the museum has $5,000. Everything outside this folder is untouched.

Open `index.html` through any static web server (for example `python3 -m http.server` from the repo root, then visit `/restoration/`). It loads Three.js 0.160 from jsDelivr, so it needs a network connection. There is no build step. Add `?speed=4` to the URL to fast-forward guests while testing.

## What comes from the 2018 project

| FinalRound piece | In this edition |
| --- | --- |
| `Art` ScriptableObjects (`Assets/workshop/Art/*.asset`) | The same 12 paintings with their names, artists, start bids, raise amounts, conditions and scores |
| `AuctionScreen.cs` + `auctionClass.cs`: pages of 3 lots, raise your bid, the computer counters after 1.25s and withdraws at 1.75x the start | Same flow and timing. The rival's limit now varies from 1.4x to 2.05x, so some lots get away |
| `UI_Manager.CleaningTools` + `dirtspots.cs`: three swabs (dust, varnish, patch), 7 spots, and condition decides the spot layout | Conservatory with a Dust brush, Varnish remover and Patch kit. Each spot needs the right tool, and you scrub it off the real painting |
| "Your Masterpiece is Ready for an Exhibit Hall" screen | Shown after each restoration, using the original art |
| `Master_Art.CollectionPlace`: place restored paintings in collection spots | 12 frames across the West, North and East wings. Pick an empty frame from a bird's-eye view |
| `GuestScript.cs`: guests enter, visit 3 wings, view each painting, then go to the trivia zone and donate score + trivia | Same route. Guests show a happy face at good paintings, line up at the Trivia Time! desk, and donate on the way out |
| `textmanager.cs` trivia (+$500 right, -$25 wrong) | The five original questions, plus six written from the artist fact sheets. A right answer now adds 50% and $20, and a wrong one still costs $25 |
| Artist fact sheets, title, direction board, bid/exit paddles, A-D buttons, music | Used as-is (resized). The fact sheets open from each painting's details |
| "Earn $5000 to save our museum!" | The goal bar in the HUD |

## Changes and fixes

- The 2018 trivia rolled `Random.Range(0, 4)`, so the fifth question (Huizong) never appeared. All questions now come up, shuffled without repeats.
- `baseScore` was 1 for the three Le Brun portraits and the Da Vinci portrait and 10 for everything else, which looked like placeholder values. They're 6 here.
- The auction charges you when you win, instead of taking money on every raise and refunding half if you leave.
- A trivia question now gives you 20 seconds. Guests who aren't quizzed within 30 seconds donate without the bonus and leave.
- Guests donate $3 per point of painting appeal they saw, so hanging more paintings clearly pays off.
- Progress autosaves in the browser. Continue picks up where you left off.

## Controls

- Walk: arrow keys or WASD. Drag to look around. Click the floor to walk there.
- Overview: a bird's-eye view. Drag to orbit, scroll or pinch to zoom.
- Click a painting for details and artist facts. Click a guest with a **?**, or the desk, for trivia (keys A-D or 1-4 answer).

## Files

- `index.html`: the whole game (HTML, CSS and JS in one file).
- `assets/paintings/`: web-sized copies of the painting images from `Assets/workshop/Art/ArtImages/`.
- `assets/ui/`: web-sized copies of the interface art from the same folder.
- Music plays from the original `Assets/workshop/Art/ArtImages/MusicForGame.mp3`.
