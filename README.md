# Tasks

#### Player:
1. Make the character control on wasd.✔️
2. Remove the auto attack.✔️
3. Add an attack button (replacing auto-attack) with a cooldown. At the same time, use the existing attack animation.✔️
    - If there are no enemies in the radius, the character will play the animation, but no damage is dealt to anyone✔️
    - If you spam with the button, the animations should be played one by one✔️
    - Damage should be dealt according to the animation, not the number of button presses✔️
4. Add a "super" attack to the player by pressing a button (the button must be created).
    - Use the sword double attack animation
    - Add a cooldown (2 seconds) to this attack and visually display it on the button
    - this attack should deal increased damage to enemies
    - if there are no enemies in the attack radius, the button is not active
5. Display the total number of waves and the current one.


#### Enemies:

1. Add more enemies to make the battle last longer. Add logic that adds HP to the player for each enemy kill.
2. Add a new enemy, when killed, it will "split" into 2 smaller ones with reduced parameters.