# Katan_Project
Windows Form ver. of the popular board game Catan
- I haven't updated in a coupledays due to having to update the git from my laptop rather than my desktop. However, I have been slaving away at this darn game all week/weekend.
UPDATE:
- Settlements can be upgraded to Cities!
-Roads can be placed!
 >The correct displaying of possible road placements for the current player took WAAYY too long to figure out and implement (Over 8hrs actually). I was ultimately able to modify my algorithm for the Distance Rule and create a new one for the roads. However, constant issues with updating shared edges between tiles prolonged the work.Due to this unforseen delay, some features will have to be left out until later updates.
- Win scenario created!
- UI updated to display resources for all players
- UI updated to display current settlements and resources owned
- Settings>
  The seperate form kind of works... The checkboxes are tricky when it comes to music, but the implementation of Cheats and Random Map are working.
Be sure to open settings and check them before launching a new game.
- Message box created to announce winner and ask if users want to begin a new game.

Ultimately this game is basically a form filled with shown and hidden picture boxes. AND, because windows form is pretty limited and uninspiring I had create Onclick events for every.single.road.tile.settlement. So, the main window has probably somewhere around 1000-2000 lines of code just pertaining to onclick events...
- Also, since transparency isn't really a thing in forms, my game looks pretty distasteful in my opinion. If I was to just lay 1 form object on another, I can redraw the parent object as the backgroundto the child. Howver, this does not work for tiles that over lap 4 other tiles, so there isn't much I can do besides accept it.

This project was quite the monstrosity to accomplish, and I atleast have the basics of the game implemented and working.

What did not make cut before the deadline:

-The proper info box for dice rolls and other needed information
-Port
-Trading
-Development Cards
- Settlements requiring an adjacent road before placement. (This would've required an additional alogrithm I simply did not have the time to debug)

This is not due to procrastination or laziness, as I started this before Thanksgiving break, and have been consistently updating with a chunk of content.

I tried to look for ways to include polymorphism, but found it unnecessary by the game's design.

I hope to continue to see this through to completion, even after the due date.
