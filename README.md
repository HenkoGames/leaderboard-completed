# This project consists of 
## New Scripts 
- PopupManager - Behaviour script that contains instance of PopupManagerService and tools to work with it. This script uses Singleton and Facade patterns.
- Leaderboard - Behaviour script of leaderboard panel. It can be modified to show different types of leaderboards with different player sets and panel types.
This script work with Unity UI primitive ScrollView and resizes the content window to show all of players correctly 
- LeaderboardPlayerPanel - Behaviour script of player panel. Show properties of Player in panel. Leaderboard instantinate the objects of player panels and set player variable.
- Player - C# script that describes Player class and tools to create players from differen types of data.
- LoadingBarRoller - Behaviour script of Loading bar object. Just rolls the object.
## New prefabs
- LeaderBoard 
- PanelLoadingBar
- PlayerPanel
- PopupManager - Popup manager system that provide opportunity to connect PopupManagerService to prefabs
# Modified Service
I modified popup manager service with new OpenPopup method overload, that takes parent as additional argument. This decision simplifies work with UI primitives and don`t cut functions of service. 
Usage of method with params argument for this task creates problem with additional overenginered part of code and GameObject structure to solve the problem with resizing of panels while setting up as canvas members. 
So, simple overloadm in my opinion is best decision here.
# Time
This task took 2 days of work, most of time went to planning architecture.
