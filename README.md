# CodeNameAB
 Testing Mirror  
This is using Unity 2019.4.14f1  

#### Version 0.247


---------------------------------------------
## Network
The IP adress set in the scene is the host adress.  
It means you need to start the headset with this IP **first** so it will start as the host.  
Other headset will then try to connect to this IP when launching the game.  
To find headset IP's use the command on Quest 1:
```
adb shell netcfg
```
Or the following on Quest 2:
```
adb shell ip route
```
---------------------------------------------
## Mobs
They are prefabs with a list of parts that determines their ability.  
At the moment current ability are life, armour and speed.  
1- normal  
2- With a plate armour  
3- With 2 Legs  
4- Medics which are roaming around other mob to heal them.

---------------------------------------------
## Player
Life, ammo, fire rate

---------------------------------------------
## Waves
9 different waves at the moment  
We should have this loaded from a json file.  

---------------------------------------------
## ToDo
Add a game over when life goes to 0.  
Add a play again.  
Choose difficulty.  
From 18.03.2021:  
+  Ajouter un gros bonus genre sphere qui spawn avec les mobs, en même temps et qui file sur le joueur.
Le but est d'attraper ce bonus à la main (ou juste contact ?).
+  Synchronisation des mains des joueurs.
+  Ajouter des gros boulet à éviter avec la tête.
+  La vie des joueurs est partagée. Donc tout le monde meurt au même moment.
Pour la mort, un freeze de l'écran, fade to grey et généric de fin.

---------------------------------------------
## Version Notes
### Version 0.22  
Lower the player height.  
Put the bonuses closer to the players.  
Fix second mob spawn position. Must rework this in a better way.  
### Version 0.23  
Sync hands.  
Fix client grabbing peer element.  
### Version 0.24  
Adds giant wrecking balls.  
##### Version 0.241
Adds fade to red with life.  
##### Version 0.242
Adds camera shake when colliding with a wrecking ball.  
##### Version 0.243
Adds dropped bonus to catch. **WIP**  
##### Version 0.244
Fix for the client to be able to grab Bonuses.  
##### Version 0.245
Adds death + Big clock + Fix elements positions + Bullet hitting eachother + Trigger elements by shaking.  
##### Version 0.246
Remove hands tracking to play with controllers for more precision.  
##### Version 0.247
Add water system. Add a switch to refill health at the end of each waves.   



