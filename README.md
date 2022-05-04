# FIGHT FOR THE THRONE!
Scripts used in making a wave-based fight platformer in Unity


## **2D Chess-Themed Platformer**

JUNE 2020

##

## Introduction &amp; Background

The objective is to create a 2D platform game where you fight enemies that come in waves. The player character will have basic movement, jump and attack. Dodging will be added in the later stages.

The game will be created in the Unity game engine with C# as the scripting language. The game will be created in 4 stages of production. Each step will take approximately two weeks to accomplish.

I will plan before implementing each separate module using a mixture between agile and waterfall management techniques.

## Production Timeline:

**Setting Up** :The level-design and artwork will be added.

**Pre-Alpha Stage** : The core game mechanics will be coded, such as movement and basic enemies.

**Alpha Stage** : The core mechanics will be improved upon with adequate testing and necessary changes. New mechanics will be added.

**Beta Stage** : Proper Graphics and Sound design will be added.

## Project Management

The general timeline of the project will be as follows, and a Trello board will be used to keep track of what needs to be implemented. 


## Setting Up

A sprite sheet was made using Adobe Photoshop that will be used to animate the movements of the player along with a tileset for the level design.

The trees were downloaded from the website, OpenGameArt and edited to match the aesthetic of the game; they are not copyrighted.


## Pre Alpha Stage ![]

A simple stage was created where the player would have to move their way up and face enemies.

Before coding the basic movements, I decided on having a set of public and private variables.

The public scope allows me to make changes to those variables from the unity game engine using a slider. The private ones are only used inside the script.

## Variables

| **Name** | **Scope** | **Type** | **Purpose** |
| --- | --- | --- | --- |
| isGrounded | private | boolean | Check if the player is touching the ground. |
| facingRight | private | boolean | Set to true if the player sprite is facing right. |
| jumpCounter | private | integer | Created in case I want to implement a double jump method |
| jumpPower | public | integer | Controls height of the jump |
| playerSpeed | public | integer | Controls speed of the jump |
| moveHor | private | float | Accessed from the unity engine that returns a +ve value if pressing the right arrow key/W and negative if left/A |
| rb | public | RigidBody2D | Unity engine datatype that allows manipulation of gameObjects |
| anim | public | Animator | Same as above but controls which animation to play |

## Classes and Inheritance

### Planning for Movement

The movement will be handled using a class. This will be a player movement class that will inherit from the Unity Engine Library. Two Methods are built-in when using classes from Unity which are: Start and Update. The start method is called once at the start of the game while Update is called every single frame. As movement will be coded, the update method will be the only one that will be used.

The update method for each script behaves as the main method of more traditional programs. So firstly I will plan out what methods will be called in Update().

| **Name** | Purpose | Dependencies |
| --- | --- | --- |
| PlayerMove() | Checks for key inputs using the moveHor variable and manipulates the position of the player using the RigidBody2D variable | moveHor, rb |
| FlipPlayer() | Flips the sprite of the player character based on in which direction the character is moving. | facingRight, rb |
| Jump() | This function simply adds a force upwards to the gameObject every single time a button is pressed | isGrounded, JumpCounter, rb |

#### Pseudo Code in Update:

1. If moveHor \&gt; 0, move player to the right, flip player to right and play walking animation
2. else if moveHor \&lt; 0, move player to the left, flip player to left and play walking animation
3. else play idle animation
4. If jump button is pressed, Jump()

Movement Implementation

The script was coded as planned however there were a few slight changes/additions which is that I made it so that the PlayerMove function was the only thing being called in the Update method with that function containing the things that were supposed to be in update..

I created a simple level with the tiles that I created and added box colliders to them so that the player could actually stand on it. The design was not planned; I decided to leave the level design for later stages of the development.

I made it so that whenever the player wants to move the velocity of the character&#39;s rigidbody changes depending on the public variable, playerSpeed. However, the animations were not set and the camera did not follow the player. (Watch video 1)

For this, I decided to next create a script that would be used on the camera so it always follows the player. I will create two variations and will do a survey and testing to see which my user base would prefer during the Alpha.

### Adding Animations

After implementing basic movement, I added idle, walking and attacking animations. Each animation consisted of 3 or 4 frames that the player object goes through given certain conditions. The conditions were not implemented into the code so I planned out how they were going to be coded.

| Name | Purpose |
| --- | --- |
| isRunning | A boolean that plays the idle animation if false and running animation if true |
| Attack | An animation trigger that plays if the attack button is pressed |

#### Animation Implementation

The animations were coded (Watch video 2) as planned except for the attacks which I thought would be better to use a different script and class to implement rather than in the PlayerMovement class. Attacks will be added in the next stage but for animation testing, I made it so that the attack Animation is played every time the J button is pressed.

### Enemies and Scoring

I wasn&#39;t particularly sure on how to implement enemies that would follow the player around and attack. After some searching, I found this open-source project called the

&quot;A\* Pathfinding Project&quot;. This would allow the enemies to find the player and chase them if the gameObject is a certain distance away. As this was a foreign concept to me, I followed a youtube tutorial on how to set it up and did very little in terms of planning. The only planning for the enemies that were present was the following variables and pseudo code.

| **Name** | **Type** | **Purpose** |
| --- | --- | --- |
| distanceToPlayer | float | Checks how far the player is away from the enemy |
| movementSpeed | int | How fast the enemy moves |
| attackDamage | int | How powerful the enemy attacks are |
| enemyHealth | int | How many hits the enemy can take |

####

####

#### Pseudo-Code:

1. If distanceToPlayer \&lt; 30 then move towards the player
2. Else if distanceToPlayer \&lt; 2 then attack
3. Else standstill

Pathfinding and Enemy Implementation

My planning in this situation turned out to be very unnecessary because everything was built into the modules for the pathfinding script. I will not go into detail on how they work as they are from an external library but in principle, the logic is the same as my pseudo code.

### Enemy Health, Damage and Knockback

The enemy then needed to deal damage and be damaged. I will focus on only the dealing damage part for this stage as attacks for the player have not been implemented yet.

First I know I will need some public variables for the amount of health the enemy has and the damage the enemy deals. Also there needs to be delay before the enemy can next deal damage.

| **Name** | **Type** | **Purpose** |
| --- | --- | --- |
| enemyHealth | int | Amount of health the enemy has |
| enemyDamage | int | Amount of damage the enemy deals to the player |
| knockForce | float | Controls the |
| coolDown | float | Time until enemy can next deal damage |

For the enemy to deal damage, first the collision between the enemy and the player must be detected, damage must be subtracted from the player, an animation must be played and the player must be knocked back. Unity classes have a built-in method called OnCollision2D() which detects collisions. I will use this to code the enemy.

####

#### Pseudo- Code:

1. If collided with player,
2. Deal damage and knockback
3. Else do nothing

I must also add a player damaged animation so the user gets proper feedback.

Before I implement this, the player must have health and have the ability to die.

Player Health, Damage and Enemy Damage Implementation

To add player health and a health bar UI, I will follow a youtube tutorial. The assets required for the UI will be taken from this github repository: [Health-Bar](https://github.com/Brackeys/Health-Bar).


I will add a simple int variable called playerHealth that will determine how much of the health bar is filled at a given moment. I will create a public function called TakeDamage(int damageAmount) that can be called from any class/script so that the player&#39;s health can be reduced. I will test this out by first simply adding a button that when pressed lowers the player&#39;s health. The player&#39;s death will be handled like so: _If playerHealth\&lt;0, restart the level._ This will only be a placeholder until a final score screen and gameover screen is added. I implemented this (watch testing for playerHealth and damage).

As the player could now take damage, I decided to add touch damage to the enemy. However through research I found out there are multiple ways to do so. Either with simple collision detection or raycasting. I will implement both and trial to see which one is more efficient.

**Trial 1: Collision Detection**

First I added in The Collision detection method which just checks if the enemy is in contact with the player&#39;s box-collider and then deals damage. See testing for collision detection video. I asked a few of my classmates to test and give feedback.

The issues they mentioned were as follows: &quot;If you stay pressed against an enemy you don&#39;t take continuous damage. Why do i get damaged when i jump on top of him, shouldn&#39;t he get damaged instead? Why doesn&#39;t the player character have a hurt animation so I can get proper feedback?&quot;

**Trial 2: Raycasting**

I implemented raycasting to the right and left of the pawn so that the player can now not be damaged when jumping on top of the pawn&#39;s head. The player can now take continuous damage if left next to the pawn. A knockback was also added, however, it has issues which can be seen in the testing video (Raycasting and Knockback).

The issue stems from the fact that the character simply feels a force upwards and backwards when colliding with the pawn but this force occurs in such a short period of time that it looks glitchy. To solve this problem, I searched on stackoverflow and found a method that works too however it is essentially the same thing I did which did not solve the issue. But while trying to make the method work, I realized that my code can work if I shift the gravity values for a certain amount of time everytime a collision occurs.

**Conclusion after trailing**

I&#39;ve chosen to use raycasting instead of collision detection because it allowed the player to jump on the enemy&#39;s head and the test group preferred this. I now needed to add in a player getting damaged and an enemy getting damaged animation.

### Adding Player Feedback

I made new sprites for both the player and the enemy where I simply overlayed red over the idle animations for 2 frames to create an animation for the characters getting damaged. I will set them up in the GetDamaged() function of the objects, so that every time it is called, the animation will play.

### Planning for Player Attacks

I&#39;ve considered implementing the attacks in three ways. Using raycasting, collision or an attack point collision.

| _ **Raycasting** _ | _ **Collision Detection** _ | _ **Attackpoint** _ |
| --- | --- | --- |
| Send out beam and damage if close | Make player invulnerable and if collider in contact with enemy, damage | Have a separate collider which would point on the edge of the sword. That would damage only if a button was pressed |

It would be highly inefficient to code all of these methods and trail them which would waste a lot of time. In this particular scenario, Collision Detection seems like the worst way to code this although it would be the simplest.

Raycasting seems like a good idea, however, I&#39;ve already used raycasting for the enemies and thought that I would be best if I used the AttackPoint method this time.

To implement this, I would have to create an empty gameObject which would be the center of the attack, it would be a child of the player object so it&#39;s position would always be relative to the player. When the attack button is pressed, a circle collider will be made and if an enemy is in range, they will be damaged.

Visualization: ![](RackMultipart20220504-1-6b7d0h_html_5510cf92e69a0fbe.png)

The red dot would be the centre and the circumference represents the outer edge of the collision region.

**Variables** :

| **Name** | **Type** | **Purpose** |
| --- | --- | --- |
| attackDamage | int | Amount of Damage dealt to enemies |
| attackRange | float | Radius of the circle |
| attackPoint | Transform(unity Gameobject) | Centre of the circle |
| enemyLayers | LayerMask | The layer in which the collisions will occur |
| animator | Animator | Player attack animation can occur |

\*All variables will be public

Method:

There will be a single method called Attack() that will run if the player presses the attack button. The check for button inputs will occur in the update method.

The Attack method will create the collider using the variables values and log each object that collides, it will then damage them (As enemy health and and damage has not been implemented yet, it will only log the name of the enemy to the console.)

Implementation:

This took a bit more effort than I had anticipated but I discovered that Unity had a built-in feature that could create the circle collider given the position of the center and then put all the collisions in an array.

I also added the attack animation from the original sprite sheet, so that animation plays every single time the attack button is pressed.

However, I noticed that the player could spam the attack too many times and thus I added a very small cooldown rate until the player could attack again.

These were the additional variables that were not planned

| Name | Type | Purpose |
| --- | --- | --- |
| attackRate | float | Dictates how frequently the player can attack |
| nextAttackTime | float | Is the cooldown period which is calculated using the attackRate |

The unplanned code was as follows:
 If the current time is greater or equal to the cooldown period,

Attack is allowed and the new cooldown period is set based on the attack rate

Else do nothing.

In the end, I liked how the attacks were. I wanted to add in combos but left that possibility for future builds.

### Attack Feedback, Enemy Health and Death

My character could now attack but it doesn&#39;t mean anything if the enemies don&#39;t react to it. I implemented the enemy damage animation before while adding the player one, so all that was left to do was just play that animation whenever the enemy was attacked.

I now needed to create a script/class that will allow the enemy to have health, die and give a score to the player. The enemy will also need a slight knockback when damaged, I will add a force to the rigidbody whenever an attack connects.

This will be quite simple as I&#39;ve already coded this before when making the player health system. I will create a public integer variable that will hold the enemy health and if it falls below 0, it will die.

Death will cause the collider of the enemy to disable which will make the character to fall off the screen and then the object will be destroyed outside of the player&#39;s view.

I will also add a player score system, which I will calculate based on how much damage the player has done.

The score will be displayed on the top centre or right of the screen depending on which seemed more natural.

### Implementation

Coded as planned, watch testing video

### End of Pre-Alpha

All the core gameplay mechanics have been coded. The player can now die, damage and get a score. I will now move into the Alpha stage where I will improve the code and add some sound design.

## User Feedback:

## ![](RackMultipart20220504-1-6b7d0h_html_d46370dee30f8606.png)

I sent a build of the game to a friend and he added some suggestions on where to go next with the game.

##

## **Considerations** of Alternatives:

During the designing phase, alternative colour schemes were considered, such as the colour of the king&#39;s cape. Purple was chosen because it is the colour of loyalty as a user pointed out and it had nice contrast with the rest of the game. Blue and Red were considered, however blue would blend in with the sky and red would be overpowering as the damage animation would have a red overlay.

## ![Shape9](RackMultipart20220504-1-6b7d0h_html_b85e71fc7d8a7822.gif)

## Alpha Stage

I wanted to start out by fixing the movement of the player character. It felt a bit unresponsive as described by the 5 people who tested out my program.

Since I was making changes to code I&#39;ve written, I wanted to keep versions of my code, so I used GitHub for every change I made to the code.

The code can be found here: [https://github.com/sharnobyl/chess-platformer](https://github.com/sharnobyl/chess-platformer)

### Improved Movement

##### Horizontal

The movement implemented in the pre-alpha stage was only a placeholder. I was not satisfied with how it felt. To make the movement feel more robust, I researched on how existing platformers handle it. For example, in the original Sonic the Hedgehog, it is really easy to accelerate at the start but the faster you go, the harder it is to go faster. Now obviously this game is at a much much smaller scale and pace than Sonic, however, that principle could still be applied.

So what I plan to do is add &quot;damping&quot; to the acceleration in the horizontal movement and when the player presses the movement buttons, the velocity is increased upto a certain point depending on the damping.

_While researching this, I also found that to make the variables available in the unity editor, it is not necessary for them to be public. They can be private and you can force unity to show them in the editor using the &quot;SerializeField&quot; command._

**Variables**

| **Name** | **Type** | **Purpose** |
| --- | --- | --- |
| fHorizontalAcceleration | float | This sets the rate at which the player character can accelerate |
| fHorizontalDampingBasic | float | This lowers the acceleration based on how fast the player moves |
| fHorizontalDampingWhenStopping | float | This adds the damping rate when the player wants to stop |
| fHorizontalDampingWhenTurning | float | Same as above but when turning |

**Implementation**

I coded it as intended, however, I made an adjustment to the code so that it runs the same no matter the hardware of the device that runs the game. I made the velocity that the player gets and set it to the power of the built-in variable Time.deltatime which makes use of the framerate to calculate the movement of the player.

Watch the testing on movement video where you can notice that the knockback looks much better.

What I implemented at first did not work which I figured was due to the friction between the player object and the ground. To fix this I created a new 2D physics material in the unity editor and set the friction value to Zero, after which the movement worked perfectly.

Friction is no longer needed as the damping behaves as the friction. However this created the unintended side effect of the enemy sliding away whenever they were attacked, I will deal with this after I&#39;m done with the jumping

#### Vertical

For movement in the vertical axis i.e Jumping. I wanted to do what Super Mario Bros did. Currently, pressing the jump button just adds a vertical force to the player object which causes it to go up, this isn&#39;t what I want. I would prefer a jump system that has a bit more control; control over the height and horizontal movement in the air as well.

One way to do this would be to set the gravity to low values when the player first presses the jump button and set it to a high value when the button is let go. This practice is common in game development, so I will consider this. There is also another method which is very similar. Instead of changing the gravity values when the jump button is let go, a velocity in the downwards direction can be added.

I doubt the user will be able to tell the difference between these two methods so just to be sure I&#39;ll code both of them.

| **Name** | **Type** | **Purpose** |
| --- | --- | --- |
| fallMultiplier | float | The multiplier which will change gravity when the player starts to fall |
| lowJumpMultiplier | float | This is the same as above but is only applied when the button is pressed not held |

I will rename some of the variables that were initially made for the improved version.

| Original | Improved | Reason |
| --- | --- | --- |
| Int JumpPower | float fJumpVelocity | Changed to a float; velocity will now be added in the vertical instead of applying a force |
| isGrounded | bGrounded | Reflects that it is a float, new method will be used to check if grounded |
|
 | float fJumpHeightCut | This multiplies with the y velocity when the Jump button is let go. As the value is less than 1, the velocity will lower and the player will slow down and start to fall. If I set this to 0, the player will immediately fall to the ground |

Pseudo Code:

If Jump button is pressed and is grounded

Set the vertical velocity of the character rigidbody to fJumpVelocity

If Jump button is let go

Multiply the vertical velocity by fJumpHeightCut

If Player is falling

Change gravity by the fall multiplier amount/ Add downwards velocity

#### **Implementation**

There were a few things I changed that I hadn&#39;t planned for. The checking for the jump button input used to be in the update method, I moved to the Jump method which is called in the update method. Other than that, the implementation went as smoothly as planned.

I did testing on my own and fine tuned the variable values until they felt alright.

Watch the test videos for the updated jump, one with the gravity change, one without and one with downwards velocity.

I made 4 of my friends try out each of the changes. All of them preferred the build where there is a downwards velocity or gravity rather than the one without. They were not able to tell the difference between the velocity one and the gravity one so I decided to keep the gravity one in the final build.

### Adding A Score System

I now needed to add a sense of progress and accomplishment to the game. The attacks worked and things could be damaged, so now I had to think of a way to make the player feel like they were getting better at the game or beating their previous best scores.

I first thought about adding just a counter for how many enemies that the player killed because it would feel great to kill more enemies than the previous try. However this would mean that all enemies, even if they are tougher, add the same amount to the score. This would be unfair as the bishop is not equivalent to the pawn in a real chess game. Therefore I decided to use a point system where each enemy type has a different value. I will use the chess point system where a pawn is worth one point, a bishop or knight 3 points and the rook 5 points. I don&#39;t think I will implement more enemies after implementing the bishop, however, I will leave the floor open incase I do decide to do it later.

In terms of planning, I just need to add a new int variable for the score, where the score will be added. I will call it playerScore and store it in the PlayerCombat Script/Class. I will then take that score and display it on the UI for the user to see. Since the general aesthetic of my game is pixel art, I will use a pixel game based font called 04b\_30 by Yuji Oshimoto that I found on an article for free pixel fonts.

**Implementation**

Extremely simple execution, just added a line of code to when the enemy died to add to the player&#39;s score. 1 point per pawn felt a bit too low so I made it 100 to make it feel better.

I still had to implement a system for the high score but I will leave that for the final build.

**Extra**

I added a simple dash mechanic while improving the movement code. Pressing the spacebar would now move the player slightly forward.

## End of Alpha ![](RackMultipart20220504-1-6b7d0h_html_533069e373e6e716.png)

The purpose of the Alpha was fulfilled as the core mechanics were improved upon and adequate testing was done to check if the code was robust.

The things left on the trello board will be handled in the Beta, starting off with the sound design.

##

## ![Shape10](RackMultipart20220504-1-6b7d0h_html_b85e71fc7d8a7822.gif)

## Beta Stage

## Responsive Gameplay

To add depth to the game, I would have to add sound effects and music because the group suggested it would be an enhancement and make the game more fun. I recognise some sounds may be jarring and cause discomfort especially stabbing sounds, therefore I will tread lightly and use sounds that will not offend possible users. Only sounds which I have permission to use will be implemented, thus I will use opengameart.org to download these assets.

The required sounds effects would be:

- Sword Swing
- Sword Hit
- Jump
- Movement
- Player Damaged
- Background Music

I will use a script that unity game developers use for audio management. It will be a class that will let me load audio files and play them from any other class.

**Downloading the Assets**

I downloaded the sounds from opengameart. I realized that I needed an audio editor for the footsteps sounds as they were left and right foot sounds. I realized it would be easier if it was a single sound, so I used Audacity, an open source audio editor, to merge the two sounds together.

**Adding the Audio Feedback**

I started off with adding the sound for movement which was rather difficult as I hadn&#39;t worked with audio in games before. Instead of using the audio manager for this sound, I applied the sound directly to the player object due to the trouble I was having with the AudioManager for getting the footsteps sound to work. This problem was in my pseudocode which I had planned in my head: If Player is Moving then play the sound. I thought it was simple, however the issue was that the sound would play on top of each other every single time the player moved. So I realised that the sound should be played only if the sound wasn&#39;t already playing. Fortunately, unity has a built in method that checks if a sound is playing and returns a bool. So I fixed the code by adding another if statement that first checked if the sound was playing, if not then it would start the sound.

I then adjusted the pitch and volume of the sounds until it sounded natural.

I added in the jump and player damage sound by simply calling in the sound every single time the jump button was pressed/player was damaged.

For combat, it was the same as the jump however if there was a collision a different sound would be played.

The theme would play every time the game was started.

## Re-Making the Arena

I was not satisfied with how the game looked, especially the place most of the fighting took place so I decided to re-design to be smaller and vertical in nature.

## Camera

I have implemented a proper camera follow script instead of the inferior one I was using for testing. ![](RackMultipart20220504-1-6b7d0h_html_4dbf213dbcb9fda0.png)

## Changed the Enemy Design

Originally, I had implemented the bishop with the design on the right because my thought process was that bishops meant the following: ![](RackMultipart20220504-1-6b7d0h_html_a29a06299575c802.png)

![](RackMultipart20220504-1-6b7d0h_html_30cba6e15b062269.png)

However, a tester pointed out that this has cultural significance and it would be politically incorrect to make christians an enemy of the game because religion is a culture apparently, the crusades never happened and every single nation was born out of sunshine and rainbows.

That is why I changed the design to what it is now:

A design that would offend less people.

## Enemy Spawning

There will be three spawn points around the map.

The first wave will be pawns, then bishops and the cycle will repeat until the player dies.

I&#39;ve created prefabs for both the enemy types and what the spawner script will do is simply create those enemies in the scene at the specified spawn points.

Unity has a built-in function called Instantiate that was specifically made for spawning prefabs, this will be used to call in the enemies.

**Final Bugs, Testing and Issues of Beta**

With the wave spawner implemented, the game was essentially complete. After playing for a few rounds, several changes were made and even more issues were found. Below is how I dealt with each issue.

| **Issue** | **Reason** | **Fix** |
| --- | --- | --- |
| Player Movement Restricted | The player&#39;s jumps were cut short due to collisions with platforms | The jump height was shortened and platforms were either removed or more spaced out |
| Enemies kept falling off arena | Edge Detection was not coded and enemies will simply follow the player until they die | Initially, gave the player half points for knocking enemies off stage. This made the game too easy so now enemies will respawn if they go below a certain height |
| The Jump inputs felt unresponsive | The checking for user input for the jump button was in the FixedUpdate method | Normal Update method was used instead of FixedUpdate. |
| Game felt too hard | Player had a single life and limited health pool | Added a slight chance that killing an enemy may restore health |

**Glitch**

Sometimes, the bishops would end up in the ground after they fell from the map. This happens because the collision box moves faster than the collision detection. I fixed this by making the enemy velocity zero when they spawn back after falling.

![](RackMultipart20220504-1-6b7d0h_html_92deaccb1f37afdd.png)

**Finalization**

The game finally felt fun to play and now 3 things were left for the game to be complete. The Start screen, high score and Gameover screen. ![](RackMultipart20220504-1-6b7d0h_html_74e9f5eae006e294.png) ![](RackMultipart20220504-1-6b7d0h_html_4b94f6236214e6e5.png)

I made a new scene with the map as shown above and disabled all the player controls. From there, I added buttons on starting and quitting the game. I made a copy of that scene and changed the middle section so that the player score and high score would be shown.

I added a reset button so the high score could be set to zero.

## Final Testing and Feedback

I exported a build of the game and sent it to classmates to play. They recommended I add a pause button, make the enemies weaker and make the number of bishops lower to make the difficulty of the game manageable.

I made the suggested changes, I also added in a slight chance that the player will get some health back when defeating an enemy.

Watch the video on final build testing.

In the video, you can notice how sometimes the player would be damaged but the health would still be full, this is because there is no cap on the max health it can overflow. I fixed this by adding this cap.

After fixing this, I was satisfied with how the game turned out and believed it was ready for submission.

### Links

To play the game on windows: [https://bit.ly/3jKTrPC](https://bit.ly/3jKTrPC)

To view all the project files: [https://bit.ly/36Mv5RP](https://bit.ly/36Mv5RP)

To watch the testing videos: [https://bit.ly/34Cqpv6](https://bit.ly/34Cqpv6)

