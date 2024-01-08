# Console_Crawler
## _A textbased Dungeon-Crawler running in the Console._
&nbsp;

### Table of Contents
- [Project Overview](#project-overview)
- [Thoughts on Development](#thoughts-on-the-development)
- [Old Repository](#old-repository)
- [Run the Project](#run-the-project)
- [Contribution](#contribution)

### Project Overview

##### Tech Stack
- C# .Net Core 8.0
- NUnit for Unit-Tests

##### Gameplay
The main objective of this little game is to survive the boss dungeon, which will be unlocked at level 20. 
The dungeons are sparated into rooms in which there are different types of enemies. 
In order to reach the end of a dungeon and collect the reward chest, all enemies must be defeated.

>[!WARNING]
>***Game is currently unbalanced***

##### Main Features
- Turn based Battle System
- text based Tutorial
- Choose between 3 starter Weapons
- Purchaseable Potions
- in total 8 different Enemytypes with different Special Attacks

##### Future Features
new features probaly will need a while to be implemented
- Posibility to save and load Gamescores
- Extra Items
- Extra Enemies / Bosses

### Thoughts on the development
I started this project to teach myself the basics of C# and to internalize the basics of Object Oriented Programming. Since I spent the last 9 
months learning Javascript and have therefore been able to acquire the basics of programming very well, I decided to work more closely with AI on this project. 
By working closely with GitHub Copilot, the project definitely came together much faster than if I had learned C# the traditional way. CoPilot has been helpful
when I came across new keywords that I had never seen before in Javascript or when I wanted to perform a certain operation but didn't know the syntax.

As is the case with projects that are a lot of fun, the ideas just popped into my head. So the codebase that I built up in about 1 week quickly became illegible. That's why I decided to rewrite everything in Visual Studio 2022, with readability in mind. This turned out to be a very good decision that led to this final project.

##### Examples of why i decided to do this:
- The DisplayManager class, which is there to output things to the console, became very large and therefore very hard to read.
- Much of the game logic has been moved to the DisplayManager class or to Global Variables (ex. Enemystat Calculation).
- I used global variables to override the player instance properties.

##### Examples of improvments:
- **Unit tests have been added for all main classes.**
- The whole project is now better suited for expansions.
- The DisplayManager class is now a partial class that has been split into different files for better maintainablity.
- There is a separate class for the damage calculation.
- The Enemy class has been created with level scaling in mind and the selection of random enemy moves has been improved.

### Old Repository
If you are interested in the old Repository, wich i call a big proof of concept, here you go:
https://github.com/SlowMoschen/Mini_Console_Crawler

### Run the Project

Clone the Project
```
git clone https://github.com/SlowMoschen/Mini_Console_Crawler.git
```

Run the Program through dotnet
```
cd *Project Folder*
dotnet run
```

 or
 
 Run the Program trough the .EXE in the bin Folder
 go to
 ```
 Console_Crawler\bin\Debug\net8.0
 ```
 
or

Download the Setup.Exe here
<a href="publish.zip" download="publish.zip">Download Zip File</a>

### Contribution
If you want to contribute to the Project feel free to fork the Repo and make some changes.
Feel free to add you to the Credits in the GameUtilities/DisplayManager/GameInfos DisplayCredits Method.
