
ORK Framework
http://orkframework.com


-------------------------------------------------------------------------------------------------------------------------------------------------------
Content
-------------------------------------------------------------------------------------------------------------------------------------------------------

- General Information
- Editor and Scene Wizard
- Tutorials
- Support
- Documentation
- Demo
- Package Description
- iOS Hints
- ORK Version Changelog



-------------------------------------------------------------------------------------------------------------------------------------------------------
General Information
-------------------------------------------------------------------------------------------------------------------------------------------------------

- DLL information
ORK Framework is included in your Unity project using DLLs.
This will dramatically increase your project's compile time if you change any of your own scripts.
The source code for gameplay related code is included - see the 'Package Description' section for details.

- ORK Project asset
When you first open the ORK Framework editor, a new ORK Project asset will be created.
This asset will contain all your ORK Framework settings made in the editor.
It's located at 'Assets/ORK Framework/ORKProject.asset'.

- Event assets
When you create events (e.g. game events, battle events, etc.), each event is stored in a separate file.
You can save the event assets anywhere in your Unity project.
To keep things organized, it's recommended to create a folder structure mirroring the purpose of the events.
E.g. separating game events by location.



-------------------------------------------------------------------------------------------------------------------------------------------------------
Editor and Scene Wizard
-------------------------------------------------------------------------------------------------------------------------------------------------------

- ORK Framework editor
In ORK Framework you'll create your game's data in the ORK Framework editor.
You can open the editor using Unity's menu: Window > ORK Framework.
You can also open the editor using the hot-key 'CTRL + ALT + O'.

The editor is separated into different sections, each section contains multiple sub-sections.
When saving, the editor will display what will change and, depending on what's been changed, offers to update events, scenes and prefabs.
When scenes are updated, please make sure to save your current scene first.

- ORK Scene Wizard
The ORK Scene Wizard is used to add your data to your scenes to create gameplay.
You can open the scene wizard using Unity's menu: Window > Scene Wizard.
You can also open the scene wizard using the hot-key 'CTRL + ALT + W'.



-------------------------------------------------------------------------------------------------------------------------------------------------------
Tutorials
-------------------------------------------------------------------------------------------------------------------------------------------------------

You can find different types of tutorials here:
http://orkframework.com/tutorials/

It's recommended to start with the Game Tutorials to learn using ORK Framework.
This series of tutorials covers creating a game with ORK Framework from start to finish.
You can find them here:
http://orkframework.com/tutorials/game/

If you're seeking information/help with a specific feature, take a look at the how-tos:
http://orkframework.com/tutorials/howto/

If you have any tutorial requests, don't hesitate and contact me:
contact@orkframework.com



-------------------------------------------------------------------------------------------------------------------------------------------------------
Support
-------------------------------------------------------------------------------------------------------------------------------------------------------

Need help or found a bug?

Please search for a solution in the ORK Community forum:
http://forum.orkframework.com/

Didn't find anything? Contact me:
contact@orkframework.com



-------------------------------------------------------------------------------------------------------------------------------------------------------
Documentation
-------------------------------------------------------------------------------------------------------------------------------------------------------

The documentation is built into the ORK Framework editor.
All settings are explained in the help window in the ORK Framework editor.

Information and help texts will be displayed if you hover with the mouse over a setting or foldout.
You can change this behaviour in the editor settings (Editor > Editor Settings).

There currently is no separate documentation available.



-------------------------------------------------------------------------------------------------------------------------------------------------------
Demo
-------------------------------------------------------------------------------------------------------------------------------------------------------

The demo.unitypackage file contains a demo project.

- Setting up the demo
To get the demo running, import the contents of demo.unitypackage into an empty project.
Make sure that ORK Framework is NOT imported before importing the demo.

Now, add all Unity scenes found in 'Assets/Tutorial Resources/Scenes/' to the project's build settings.
Use the Unity menu to open the build settings (File > Build Settings...) and drag the scenes on the 'Scenes In Build' area.

- Starting the demo
To start the demo, open the main menu scene (0 Main Menu) and press play.

- Controls
Use the 'Arrow' keys to move your player and change menu selections.
The 'Escape' key opens the menu. Use 'Enter' to accept and 'Right-Ctrl' to cancel.
In real time combat, use 'Space' to attack and 'Left-Ctrl' to open the battle menu.



-------------------------------------------------------------------------------------------------------------------------------------------------------
Package Description
-------------------------------------------------------------------------------------------------------------------------------------------------------

- Gizmos (folder)
Contains the gizmo icons (32x32) used by ORK Framework.

- DLL (folder)
3 DLLs containing ORKFramework.

- demo.unitypackage
Contains a complete demo project.
Please see the 'Demo' section for details.

- gameplay_source_code.zip
Contains the gameplay related source code and a plugin template as MonoDevelop projects.
Please read the included README.txt for details.
There currently is no separate documentation available.



-------------------------------------------------------------------------------------------------------------------------------------------------------
iOS Hints
-------------------------------------------------------------------------------------------------------------------------------------------------------

If you're building your project for iOS, you may run into some problems:

- Crash after splash screen: "You are using Unity iPhone Basic. You are not allowed to remove the Unity splash screen from your game"
To fix this, change in XCode's build settings the 'Compress PNG files' setting to NO and build the project again.

- Crash after splash screen: "Ran out of trampolines of type 2"
This is caused by use of generics, you have to tell the AOT compiler allocate more trampolines.
To fix this, change in Unity's Player Settings > Other Settings the 'AOT Compiler Options' to nimt-trampolines=512.
If you're still receiving a trampoline error, increase the number, e.g. 1024.

- Crash/stop after or before splash screen: 'EXC_BAD_ACCESS'
This can be caused by Unity engine code being stripped when using 'IL2CPP' scripting backend.
To fix this, disable 'Strip Engine Code' in Unity's PlayerSettings > Other Settings in your iOS player settings.

- Using the new UI (Unity 4.6+) and content is displayed outside of masks (e.g. text extends outside of GUI box).
Go to 'Edit > Project Settings > Player' and enable 'Use 24-bit Depth Buffer' in the iOS 'Resolution and Presentation' settings.


You can find more detailed instructions on the Unity trouble shooting page:

http://docs.unity3d.com/Manual/TroubleShootingIPhone.html



-------------------------------------------------------------------------------------------------------------------------------------------------------
ORK Version Changelog
-------------------------------------------------------------------------------------------------------------------------------------------------------

Version 2.5.9:
- new: Music Channels: The volume of each music channel can now be changed individually.
- new: Main Menu, Menu Screens: 'Use Channel' settings available for 'Music Volume' settings in option menus. Optionally change the volume of a defined music channel instead of the master music volume (affecting all channels).
- new: Quest Tasks: Requirements: 'Count' requirements available in activate, finish and fail requirements. Optionally use a custom count requirement, identified by a tag. The count can be changed using the event system - count requirements matching the used tag will be changed.
- new: Status Requirements: Level: Advanced 'Class Level' settings available. Optionally check the class level of a defined class. If the combatant never used the class, the class level will be 0.
- new: Status Requirements: 'In Battle' requirement selection available. Checks if a combatant is or isn't in battle.
- new: Status Requirements: 'In Action' requirement selection available. Checks if a combatant is or isn't in battle (e.g. performing an ability).
- new: Status Requirements: 'Is Casting' requirement selection available. Checks if a combatant is or isn't casting an ability.
- new: Abilities, Items, Battle Settings: Use Range: 'Minimum Use Range' settings available. Use ranges now have a minimum and maximum use range.
- new: Console Settings, Console Types: 'Before Line Text' and 'After Line Text' settings available. Optionally add text before and after each console line. The console type's texts will be added before and after the console settings texts.
- new: Weapons, Armors: 'Override Price' settings available in equipment levels. An equipment's level can optionally override the price settings of the equipment.
- new: Weapons, Armors: 'Override Equip Requirements' settings available in equipment levels. An equipment's level can optionally override the equip requirements of the equipment.
- new: Weapons, Armors: 'Add Previous Levels' setting available for random status value bonuses of equipment levels. Adding the random bonuses of previous equipment levels is now optional when creating a new weapon/armor at a defined level. By default enabled (i.e. adding previous level bonuses).
- new: Value Bars: 'Positive Changes' and 'Negative Changes' settings available in value bar images. Optionally display the difference between the displayed value and the actual value with a different image/color in the value bar. This can be used with the 'Count to Value' setting of status values to animate the damage/refresh with a different image/color in the value bar.
- new: Shops: 'Exchange Rate' settings available. You can optionally define a currency exchange rate for a shop. Otherwise the current exchange rate for the currency will be used.
- new: Event System: Base Steps: 'Change Found Objects' step available. Changes a 'Found Objects' or 'Global Objects' list using a defined game object (e.g. an event actor).
- new: Event System: Base Steps: 'Raycast All' setting available in 'Raycast Object' steps. Optionally use all game objects hit by a raycast instead of the first game object that was hit.
- new: Event System: Battle Steps: 'Search Combatants' step available. Finds game objects of combatants in the scene. Optionally checks for allied/death/battle state, range or status requirements.
- new: Event System: Audio Steps: 'Use Channel' settings available in 'Change Music Volume' steps. Optionally change the volume of a defined music channel instead of the master music volume (affecting all channels).
- new: Event System: Quest Steps: 'Change Task Count' step available. Changes the current count of a task's count requirement. Only count requirements matching the defined task will be changed.
- new: Battle Events: Battle Steps: 'Other Targets' settings available in 'Calculate' steps. Optionally use other combatants as targets instead of using the targets originally found by the action.
- change: Menu Screens: Ability, Equipment, Inventory: Clicking on a choice will now also call the sub-menu when it's using the same input key as the 'Accept' key.
- change: Editor: Changed how event assets are updated to prevent crashes in very large projects.
- fix: Menu Screens: Fixed an issue where settings wheren't displayed when selecting 'Stop' music play type in the music settings of a menu screen.
- fix: Event System: Movement Steps: Fixed an issue in the 'Change Position' step when moving by speed only along the Y-axis.
- fix: Menu Settings: Bonus Display: Fixed an issue with defence attribute text display causing an error.
- fix: Menu Screens: Equipment: Fixed an issue where 'Back' and 'Unequip' buttons where switched (back unequipping and unequip going back) in some cases.
- fix: Equipment: Fixed an issue when having 'Random Status Value Bonuses' using bonus range 'Random' without any added status value bonuses.
- fix: Text Codes: Fixed an issue where some text codes (e.g. for changing text color) could add an additional space to the text.
- fix: HUDs: Console: Fixed an issue where the scrolling area didn't adjust it's size when using the new UI.
- fix: HUDs: Console: Fixed an issue where a 'Console' type HUD's tab titles wheren't updated when changing the language.
- fix: HUDs: Fixed an issue where the name box of HUDs didn't show after the HUD was closed and opened again when using the new UI.
- fix: Combatant Spawners: Fixed an issue where using 'Set Scene ID' allowed starting a battle of a respawned combatant and blocked during the battle start event.
- fix: iOS: Fixed an issue where running a project in XCode on iOS resulted in a crash.
- fix: New UI: Fixed an issue when updating content of a scrollable GUI box that caused text/images to be hidden.


Version 2.5.8:
- new: Temporary Abilities: Abilities can now be added to combatants as temporary abilities through the event system and the battle AI. Use this for special situations, e.g. when you want to have the option to talk to an enemy (using an ability's battle events) without having to learn the ability to the combatant.
- new: Menu Screens: Ability: 'Add Temporary Abilities' setting available in 'Ability' menu screen parts. Defines if temporary abilities of a combatant are displayed, not displayed or if only temporary abilities will be displayed.
- new: Battle Menus: Ability: 'Add Temporary Abilities' setting available in 'Ability' battle menu items. Defines if temporary abilities of a combatant are displayed, not displayed or if only temporary abilities will be displayed.
- new: Status Requirements: 'Temporary' check selection available for 'Ability' status requirements. Checks if the ability is added as a temporary ability to the combatant.
- new: Damage Zones: 'Game Event Settings' available. Damage zones can optionally start game events upon being hit by a damage dealer.
- new: Battle Settings: Target Selection: 'Blink Target HUD' settings available. Like blinking the target's game object, the target selection can now optionally blink the HUDs of the selected target.
- new: Event System: Save Game Steps: 'Check Auto Save Slot' step available. Checks the currently used auto save slot number.
- new: Event System: Battle Steps: 'Cancel Ability Cast' step available. Cancels casting an ability on a combatant.
- new: Event System: Battle Steps: 'Is Casting Ability' step available. Checks if the combatant is casting any ability, a defined ability or an ability of a defined type or root type.
- new: Event System: Status Steps: 'Add Temporary Ability' step available. Adds a temporary ability to a combatant, optionally only for a limited amount of turns or time.
- new: Event System: Status Steps: 'Remove Temporary Ability' step available. Removes a temporary ability from a combatant.
- new: Battle AI: Status Steps: 'Add Temporary Ability' step available. Adds a temporary ability to a combatant, optionally only for a limited amount of turns or time.
- new: Battle AI: Status Steps: 'Remove Temporary Ability' step available. Removes a temporary ability from a combatant.
- fix: Music: Fixed an issue where playing a non-existing stored clip throws an error.
- fix: Combatant Spawners: Fixed an issue where 'Autostart' combatant spawners throw an error.
- fix: Battle Events: The 'Calculate' step didn't use the correct next step based on the action's result (e.g. upon 'Miss') when used to animate damage dealers.
- fix: New UI: Scrolling: Fixed an issue where dragging on an empty part of a scrolling area didn't scroll.
- fix: Event System: Battle Steps: Fixed an issue where using a combatant's game object in a 'Start Battle' step didn't start the battle when the player controls are blocked.
- fix: HUDs: Shortcuts: Fixed an issue where a shortcut could be used multiple times by clicking on it, ignoring use blocks or the time used to animate using it.


Version 2.5.7:
- new: Combatant Types: 'Combatant Types' sub-section available in the 'Combatants' section. Define combatant types to separate combatants by type.
- new: Combatants: 'Combatant Type' setting available. Define the combatant's type.
- new: Status Requirements: 'Combatant Type' requirement selection available. Checks if a combatant is of a selected combatant type or not.
- new: Status Requirements: 'Is Class' setting available for 'Class' requirement checks. You can now checks if the combatant is or isn't of the defined class, previously you could only check if the combatant is of the class. By default enabled.
- new: Quest Tasks: Requirements: 'Use Combatant Type' settings available in 'Enemy Kills' requirements. Optionally kill a defined amount of combatants based on the combatant type instead of a defined combatant. This allows using different combatants (of the same type) as targets for quest tasks.
- new: Quest Tasks: 'Task Status Icons' settings available. Optionally override the quest task's icon for inactive, active, finished and failed task status.
- new: Quests: 'Quest Status Icons' settings available. Optionally override the quest's icon for inactive, active, finished and failed quest status.
- new: HUDs: Combatant, Turn Order: New text codes available in 'Information' HUD elements for 'Combatant' and 'Turn Order' type HUDs. Display the name (%tn), description (%td) and icon (%ti) of the combatant's combatant type.
- new: Menu Screens: 'Bestiary (Type)' menu part available. Displays information on bestiary entries using HUD elements. The bestiary entries are separated by combatant types.
- new: Music Channels: Play different music clips at the same time using music channels. Each channel can play one clip at a time and fade between clips. The default channel is 0.
- new: Music: Stored Music: You can now store different currently playing clips per channel using IDs. As before, you can store the currently playing clip and playback time of a music channel, but you can separate multiple stored clips using stored IDs and playback them at a later time.
- new: Music Player: 'Music Channel' setting available in the 'Music Player' component. Defines the music channel that will be used to play or change the music.
- new: Menu Screens, Shops: 'Music Channel' and 'Stored ID' settings available when using the music options. Define the music channel that will be used and the ID used to store the currently playing clip of that channel. By default uses channel 0 and stored ID 1.
- new: Save Game Menu: 'Music' setting available in 'Save Settings'. Saving the currently playing music clips and playback positions is now optional. By default enabled.
- new: Crafting Recipes: 'Critical Chance' and 'Critical Outcomes' settings available. Optionally use a critical success chance to create critical outcome items instead of normal outcome items.
- new: Player Controls: Mouse: 'Cursor Respawn' setting available. Optionally creates a new instance of the cursor prefab each time instead of reusing the already spawned instance. Use this option if your cursor is a one time particle effect.
- new: Weapons, Armors: Prefabs: 'Local Rotation' setting available for equipment viewer prefabs. Optionally sets the rotation offset as local rotation of the spawned prefab instance.
- new: Abilities, Items: 'Block Scope' setting available in 'Reuse Settings' of abilities and items. Define the scope of abilities/items that will be blocked - single (the ability/item), type (all abilities/items of the same type), root type (all abilities/items of the root type and all it's sub-types), all (all abilities/items).
- new: Battle System: Bonus Settings: 'Status Effect' changes available for start battle, turn, end battle and revive bonuses in all battle system types. Optionally change status effects of combatants when the battle starts/ends, when they start a new turn or are revived after battle.
- new: Event Steps: Audio Steps: 'Music Channel' and 'Stored ID' settings available in 'Change Music' steps. Define the music channel that will be used and (when playing a stored clip) which stored ID will be used.
- new: Event Steps: Audio Steps: 'Music Channel' and 'Stored ID' settings available in 'Store Music' steps. Define the music channel and ID that will be stored.
- new: Event Steps: Status Steps: 'Block Scope' setting available in 'Block Ability Reuse' and 'Block Item Reuse' steps. Define the scope of abilities/items that will be blocked - single (the ability/item), type (all abilities/items of the same type), root type (all abilities/items of the root type and all it's sub-types), all (all abilities/items).
- new: Combatant Spawners: 'Position Rounding' setting available in area spawners (i.e. using triggers for random placement). Optionally rounds the spawn position (X and Z axis) to whole numbers. Use this option e.g. when creating classic 2D grid like games.
- new: Item Collectors: Box: 'Auto Take All' setting available for 'Box' type item collectors. Optionally adds all items in the box to the player's inventory upon interaction instead of showing the item box dialogue.
- fix: Event System, Combatant Spawners: 'Start Combatant Spawner' steps could throw an error in some cases when used in an 'Autostart' type event interaction without any delay.
- fix: Equipment Viewers: Fixed an issue with viewer materials not working correctly.


Version 2.5.6:
- new: Unity 5.2: ORK Framework now requires Unity 5.2.
- new: Texture Fields: All 'Texture' selection fields now support all kinds of texture assets (except for mouse cursor texture fields). Besides 'Texture2D' (default till now), you can e.g. also use 'RenderTexture' (rendering a camera to a texture), 'MovieTexture'.
- new: GUI Boxes: 'Screen Adjustment' settings available. Optionally adjust the position of the GUI box to fit the content box within the screen space. Use this e.g. for tooltip HUDs that follow the mouse cursor.
- fix: Game Over: Menu screens will now be closed upon game over.
- fix: Main Menu: Background images for the auto save slot selection will now be removed after the override confirmation question.
- fix: Event System: Status Steps: The 'Regenerate' event step will no longer regenerate status values of dead combatants (unless 'Revive Dead' is enabled).


Version 2.5.5:
- new: Combatants: AI Settings: 'Start AI Blocked' setting available. Optionally block the battle AI of a combatant when it's instantiated. An AI controlled combatant will only use the 'None' action when the battle AI is blocked (i.e. do nothing). The battle AI can be blocked/unblocked in the event system.
- new: Event System: Battle Steps: 'Block Battle AI' step available. Blocks or unblocks the battle AI of a combatant. An AI controlled combatant will only use the 'None' action when the battle AI is blocked (i.e. do nothing).
- new: Event System: Battle Steps: 'Is Battle AI Blocked' step available. Checks if a combatant's battle AI is blocked.
- change: Combatants: Loot Settings: 'Loot Origin' setting replaces 'Use Start Inventory' setting. You can now optionally use the 'Start Inventory', 'Loot' tables or 'Both' to define a combatant's loot.
- fix: Formulas: Removed console output in 'Status Value' steps that was left in the release build by accident.


Version 2.5.4:
- new: Unity 5.1.3: ORK Framework now requires Unity 5.1.3.
- new: Items: 'Reuse Settings' available. An item can optionally be blocked for a defined amount of turns or time.
- new: Status Effect Changes: 'Remove Single' setting available when removing status effects (e.g. ability status changes, auto effects, etc.). Optionally only removes a single instance of the status effect instead of all applied instances. Use this option if you only want to remove one effect from stacked effects.
- new: Status Development: Upgrade Settings: 'Own Costs Description' settings available for status value upgrades. Optionally override the description if an upgrade can't be used due to the upgrade posts.
- new: Status Development: Upgrade Settings: 'Own Requirements Description' settings available for status value upgrades. Optionally override the description if an upgrade can't be used due to the requirements.
- new: Status Requirements: Status Value: 'Used Type' settings available. You can now use the current, base, min, max, display, preview and preview max value of the status value for status value requirements.
- new: Status Requirements: Attack/Defence Attribute: 'Used Type' setting available. You can now use the current, base, min, max, start and preview value of the attribute for attack/defence attribute requirements.
- new: Status Requirements: Death: 'Combatant Scope' setting available. You can now check either the checked combatant, the battle group or whole group. When checking the group, 'Is Dead' is valid if all members are dead, not 'Is Dead' is valid if at least one member is alive.
- new: Status Requirements: Combatant: 'Combatant Scope' setting available. You can now check either the checked combatant, the battle group or whole group. When checking the group, 'Is Combatant' is valid if at least one member is the selected combatant, not 'Is Combatant' is valid if no member is the selected combatant.
- new: Event System: Spawn Steps: 'Found/Global Objects' settings available in 'Spawn Prefab' steps. You can now optionally use the spawned prefab to change a found object or global object list.
- new: Event System: Save Game Steps: 'Delete Auto Save' step available. Deletes the AUTO save slot's save game or the temporary retry save game.
- new: Event System: Save Game Steps: 'Delete Save Game' step available. Deletes a defined save game or AUTO save game.
- new: Event System: Status Steps: 'Block Ability Reuse' step available. Blocks a defined ability's reuse for a defined amout of turns or time, or removes the reuse block from a combatant.
- new: Event System: Status Steps: 'Block Item Reuse' step available. Blocks a defined item's reuse for a defined amout of turns or time, or removes the reuse block from a combatant.
- new: Event System: Status Steps: 'Clear Item Reuse' step available. Clears the item reuse blocks of a combatant.
- new: Event System: Battle Steps: 'Start Combatant Spawner' step available. Starts a combatant spawner, i.e. spawns the combatants if they aren't yet spawned. The used game object must have a correctly set up 'Combatant Spawner' component attached.
- new: Event System: Battle Steps: 'End Battle' step available. Ends the currently running battle with a selected outcome (victory, escape, defeat, leave arena). Nothing happens if no battle is running.
- new: Combatant Spawners: 'Repeat Check' settings available for 'Autostart' start type when not using 'Auto Destroy'. Optionally repeats the autostart check until the conditions are valid. Use this for spawners that e.g. should be activated automatically after speaking to an NPC in the scene.
- new: Item Collectors: 'Use Condition' settings available in the 'Prefab Settings' when not using 'Auto Destroy'. Optionally only spawns the prefab when the conditions are valid, the check can be repeated. Use this for collectors that e.g. should spawn after starting a quest in the scene.
- new: HUDs: Combatant: 'Use Click Use' setting availalble in 'Shortcut' HUD elements when using 'Enable Clicking'. Optionally uses the shortcut when no group/individual/auto target is used or found. Items/abilities will trigger the target selection (or used on 'Self'), equipment will be equipped on the user.
- new: Menu Screens: Status Value Upgrade: 'Hide Maxed' setting available. Optionally hide status value upgrades for status value that reached their maximum value (i.e. their base value equals the maximum value).
- change: Player Controls: Mouse: The cursor is now spawned using the prefab's rotation.
- fix: Menu Screens: Combatant: Showing Ok/cancel buttons in 'Combatant' menu parts with only one page where blocked and not controlable.
- fix: Menu Screens: Equipment: Fixed bugs related to the 'Unequip' buttons.
- fix: Player: Changing the player through removing the current player from the group (e.g. using 'Leave On Death' option in the combatant's settings) could lead to the wrong combatant being used as player and the components being added to another.
- fix: HUDs: Turn Order: A combatant's death will now update 'Turn Order' type HUDs.
- fix: Battle Menus: Clicking on combatants for target selection now takes target conditions into account.
- fix: New UI: Solved exception thrown due to function changes in Unity 5.1.3.
- fix: Move AI: 'Detect On Damage' now only detects when the combatant is actually damaged, not when an ability is used on the combatant.


Version 2.5.3:
- new: Menu Settings: Use Cost Display: '%c' and '%m' text codes available for status value change display. Display the current value ('%c') and maximum value ('%m') of a status value.
- new: Animation Types: 'Action Choose Idle' animation type available. Select an animation type that will be used when a combatant is choosing the next action, e.g. when the player selects the combatant's action in the battle menu. By default uses animation type ID 0.
- new: Animations: Mecanim: 'Auto Rotation Parameters' settings available 'Mecanim' animations. Optionally automatically set the rotation of the combatant's X/Y/Z axes to parameters of the animator. Either set a float parameter to the actual rotation angle (0-360) or an int parameter to a 4-direction (0-3) or 8-directional (0-7) number representation.
- new: Ability Trees: 'Ability Level' setting available. Ability trees can now also learn different ability levels instead of just new abilities.
- new: Equipment Parts: 'Allow Unequip' setting available. Optionally define if weapons/armors equipped on an equipment part can be unequipped. If disabled, the equipment part can't be empty once it has been equipped with something (unless through changing a multi-equip or blocked-equip part). By default enabled (i.e. allows unequipping).
- new: GUI Boxes: Move Settings: 'Relative Move' settings available in 'Move In' and 'Move Out' settings. Optionally define the 'Start Position' or 'End Position' relative to the bounds of the content box.
- new: GUI Boxes: Move Settings: 'Use Curve' settings available when moving the box in/out. Optionally use animation curves for moving the GUI box in or out. This allows more complex movement operations, e.g. bouncing.
- new: GUI Boxes: Scale Settings: 'Use Curve' settings available when scaling the box in/out. Optionally use animation curves for scaling the GUI box in or out. This allows more complex scaling operations, e.g. pulsating.
- new: Menu Screens: 'Block Control Maps' setting available. Optionally block control maps while a menu screen is opened.
- new: Shops: 'Block Control Maps' setting available. Optionally block control maps while a shop is opened.
- new: Shop Layouts: 'Show in Buy/Sell Box', 'Show in Type Box' and 'Show in List Box' settings available in 'Description Box'. Showing descriptions can now be disabled for the individual parts of shop layouts. By default enabled (i.e. displaying descriptions).
- new: Shop Layouts: 'Show Backgrounds' setting available in 'Buy/Sell Box' settings. Showing background images is now optional in the buy/sell selection box. By default enabled (i.e. displaying backgrounds).
- new: Quests, Quest Tasks: Rewards: 'Normal Status Value Rewards' settings available. Quests and quest tasks can optionally give 'Normal' type status value rewards. This will add permanent bonuses to 'Normal' type status values.
- new: Combatants: Status Settings: 'Normal Status Value Rewards' settings available. Combatants can give 'Normal' status value rewards upon being defeated. 'Normal' type status value rewards give permanent bonuses to the status values of the player's combatants.
- new: Combatants: Status Settings: 'Reward Chance' settings available for 'Experience Reward' settings. Optionally use a chance to determine if an experience reward is received or not.
- new: Move AI: Enemy Detection: 'Detect On Damage' setting available. Optionally detects combatants that damage the move AI's combatant.
- new: Battle End: 'Normal Status Value Reward Settings' available. 'Normal' status value rewards can optionally be split by the battle group or whole group, and given to dead group members.
- new: Battle End: 'Normal Status Value Text' settings available. Defines the text used to display 'Normal' status value rewards in the battle gains dialogue.
- new: Battle AI: 'None' target selection available in all condition/check steps. Checks no combatants, e.g. use this target selection if you only want to check the already found targets.
- new: Battle AI: Position Steps: 'Check Move AI Detection' step available. Checks if targets are detected by the combatant's move AI.
- new: Battle AI: Position Steps: 'Check Move AI Hunting' step available. Checks if targets are valid hunting targets due to the combatant's move AI hunting conditions.
- new: Battle AI: Position Steps: 'Check Move AI Flee' step available. Checks if targets are valid fleeing targets due to the combatant's move AI flee conditions.
- new: Battle AI: Position Steps: 'Check Move AI Target' step available. Checks if targets are the current target of the combatant's move AI.
- new: Game Events, Battle Events, Battle Start Events, Battle End Events, Phase Change Events: 'Block Control Maps' setting available in 'Event Settings'. Optionally block control maps while the event is running.
- new: Battle Events, Phase Change Events: 'Block Move AI' settings available in 'Event Settings'. Optionally block the move AI while the event is running. Either blocks the move AI completely (i.e. for all combatants) or only for actors of the event.
- new: Event System: Object Selections: 'Global Objects' selection available. You can now use 'Global Objects' lists. Global objects are available in all events, all the time, instead of only in the running event and being gone when the event ends.
- new: Event System: Object Selections: 'Object Key' setting available. You can now store multiple lists of 'Found Objects' and 'Global Objects' by identifying them with an object key (string value).
- new: Event System: Base Steps: 'Object Key' and 'Use Global Objects' settings available in 'Search Objects' and 'Raycast Object' steps. Optionally change 'Global Objects' instead of 'Found Objects' lists and manage multiple object lists using object keys.
- new: Event System: Base Steps: 'Found Objects Count' step available. Checks the number of game objects stored in a 'Found Objects' or 'Global Objects' list.
- new: Event System: Function Steps: 'Check Object Name' step available. Checks a game object's name or tag.
- new: Event System: Equipment Steps: 'From Inventory' setting available in 'Change Equipment' steps. Optionally uses an equipment from the inventory, if the equipment isn't in the inventory, nothing will be equipped.
- new: Event System: Battle Steps: 'Block Control Maps' step available. Blocks or unblocks the control maps. Combatants can't use control maps while they're blocked.
- new: Event System: Battle Steps: 'Add Normal SV Reward' step available. Adds additional 'Normal' status value rewards to the battle's gains. 'Normal' type status value rewards give permanent bonuses to the player combatant's status values.
- new: Event System: Move AI Steps: 'Set Move AI Target' step available. Sets the target of a combatant's move AI. The move AI's settings kick in afterwards, e.g. when the target is hunted, the hunting settings will be used.
- new: Event System: Move AI Steps: 'Stop Move AI' step available. Stops the current action of a combatant's move AI. The move AI's settings kick in afterwards, e.g. following waypoints.
- new: Event System: Move AI Steps: 'Check Move AI Detection' step available. Checks if combatants are detected by another combatant's move AI.
- new: Event System: Move AI Steps: 'Check Move AI Hunting' step available. Checks if combatants are valid hunting targets due to another combatant's move AI hunting conditions.
- new: Event System: Move AI Steps: 'Check Move AI Flee' step available. Checks if combatants are valid fleeing targets due to another combatant's move AI flee conditions.
- new: Event System: Move AI Steps: 'Check Move AI Target' step available. Checks if a combatant is the current target of another combatant's move AI.
- new: Item Collectors: 'Use Loot' setting available when using 'Box' collection type. Optionally uses loot tables for filling the item box. Using loot tables will use the player combatant for level and variable conditions, the player combatant must already be added to the player group at the start of the scene.
- new: Add Combatant Components: 'Battle Object' settings available for 'Add Combatant' components. Like 'Combatant Spawner' components, 'Add Combatant' components can now also use a defined or near game object with a 'Battle' component as battle arena. 'Add Combatant' component settings have been rearranged/grouped.
- change: Event System: Move AI Steps: The 'Block Move AI' step can now be found in the 'Move AI Steps' instead of the 'Movement Steps'.
- change: Inventory Settings: The 'Auto Stack' settings have been replaced with the 'Add Type' settings. You can now add items, weapons and armors to the inventory as is, automatically stack them or automatically split them (i.e. add them as single items).
- change: Inventory Settings: Item Box: The 'Auto Stack' setting has been replaced by the 'Use Add Type' setting. Items and equipment added to the item box will use the inventory add type defined in the inventory settings or individual items/equipment.
- change: Turn Based Battles, Active Time Battles, Real Time Battles, Phase Battles: Batte Gains Collection: The 'Stack Loot' setting has been replaced by the 'Use Add Type' setting. Items and equipment added to the battle gains will use the inventory add type defined in the inventory settings or individual items/equipment.
- change: Items, Weapons, Armors: The 'Override Auto Stack' settings have been replaced by the 'Override Add Type' settings to match the new 'Add Type' settings of the inventory settings.
- change: GUI Boxes: 'Fade In/Out' and 'Move In/Out' settings have been rearranged into 'Open Box Behaviour' and 'Close Box Behaviour'. Scaling in/out can now be done independent of moving in/out.
- change: Animations: Mecanim: The 'Use Play' setting has been replaced by 'Play Mode' selection. You can now select if the state is not played directly ('None'), use 'Play' to directly play the state or use 'Cross Fade' to create a dynamic transition to the state.
- fix: GUI Boxes: Dragging a GUI box ('Drag Settings' settings) now works correctly.
- fix: Status Development: Fixed an issue with too high status changes on level up.
- fix: Event System: Camera Steps: Fixed an issue when not fading camera changes in 'Change Camera Position' steps.
- fix: Combatant Spawners: Respawn times where ignored when restarting a spawner (e.g. through 'Trigger Enter').
- fix: Interaction Components: Disabled interaction components could still start through trigger/collision start types.
- fix: Game Controls: Player: The 'Sprint Factor' of the 'Button' type player controls is now correctly forwarded to the component.
- fix: Menu Screens: Status Value Upgrade: Enabling 'Show No Upgrade' caused an error when status values without available upgrades where displayed.
- fix: Event System: Equipment Steps: 'Change Equipment' now unequips already equipped equipment into the combatant's inventory before equipping something new (when not using the new 'From Inventory' setting).
- fix: Combatants: Spawning a combatant's prefab with a 'Nav Mesh Agent' component could lead to the combatant being spawned at a different position.
- fix: HUDs: Navigation: Fixed an issue where 'Interaction' HUD elements wheren't displayed when having multiple added to the HUD and using the new UI.


Version 2.5.2:
- new: Abilities, Items: Target Settings: 'Orientation Requirements' settings available. Optionally check the orientation from user to target and target to user. Can be used to e.g. only make an ability useable when facing the back of a target.
- new: Weapons, Armors: Equipment Abilities: 'Learn Ability' settings available. An equipment ability can optionally be learned by the wearer. Either automatically when receiving experience points, spending experience points on it or by using it.
- new: Console Settings, Weapons, Armors: 'Increase Durability' and 'Decrease Durability' console text settings available. Add a text to the console if an equipment's durability increased or decreased. Weapons/armors can optionally override the default durability change console texts.
- new: Inventory Settings, Weapons, Armors: 'Durability Notification' settings available. Show notifications when the durability increased, decreased or an equipment is outworn. Weapons and armors can optionally override the default notifications.
- new: Weapons, Armors: 'Override Prefabs' settings available in equipment levels. Optionally override the prefab and viewer prefab/material of an equipment in the individual equipment levels.
- new: Battle Settings, Classes, Combatants: Level Up: 'Start Game Event' settings available in the level up bonus settings. Optionally start a game event when a combatant's base or class level increases. Can be limited to members of the player group.
- new: Move AI: Hunting: 'Stop Range' settings available. Optionally stops hunting the target when being within a defined range.
- new: Event System: Status Steps: 'Set In' setting available in 'Change Status Value' steps. Optionally change the status value in percent instead of the defined value.
- new: Event System: Active Group Steps: 'Switch Player' step available. Changes the player to the next or previous member of the active player group.
- new: Add Combatant Components: 'Move AI Settings' available. Optionally block or override the move AI of the added combatant.
- new: Game Controls: Group Member Keys: 'Not Dead' setting available. Optionally only use alive members when switching the player using the member change keys.
- new: HUDs: Combatant: 'No Outer Assign' setting available in 'Shortcut' HUD elements. Optionally block assigning shortcuts through drag and drop from outside sources (e.g. menu screens or other HUDs).
- change: Status Development: Using 'Formula' development type will now use the defined formula when initializing a combatant the needed amount of times. The 'Initial Value' of the development will be used for the minimum level.
- change: Event System: Movement Steps: 'Change Nav Mesh Target' now calls 'Resume' after setting the destination. This is needed in case the NavMesh agent was stopped.
- change: Event System: Base Steps: 'Time (s)' field has been replaced by advanced float value field in 'Wait', 'Wait For Input', Wait For Input Fork' and 'Raycast Object' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Spawn Steps: 'Time (s)' field has been replaced by advanced float value field in 'Destroy Prefab' and 'Destroy Object' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Function Steps: 'Emit After (s)' field has been replaced by advanced float value field in 'Emit Particles' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Camera Steps: 'Time (s)' field has been replaced by advanced float value field in 'Change Camera Position', 'Initial Camera Position', 'Shake Camera' and 'Rotate Camera Around' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Movement Steps: 'Time (s)' field has been replaced by advanced float value field in 'Change Position', 'Move Into Direction' and 'Change Scale' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Rotation Steps: 'Time (s)' field has been replaced by advanced float value field in 'Change Rotation' and 'Rotate To' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Variable Steps: 'Time (s)' field has been replaced by advanced float value field in 'Raycast To Variable' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Dialogue Steps: 'Close After (s)' field has been replaced by advanced float value field in 'Show Dialogue' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Image Steps: 'Time (s)' field has been replaced by advanced float value field in 'Change Image Position' steps. You can now use formulas, variables and other sources as float values.
- change: Event System: Rigidbody Steps: 'Time (s)' field has been replaced by advanced float value field in 'Add Force Rigidbody', 'Add Torque Rigidbody' and 'Position Force Rigidbody' steps. You can now use formulas, variables and other sources as float values.
- change: Weapons: Level Up: Counter attacks now also count as uses for 'Uses' type level up.
- fix: Update UI Text/Slider Components: Fixed an issue where the object update time couldn't be changed.
- fix: Player Controls: Mouse: The NavMesh agent (when using 'NavMesh Agent' move type) is now stopped when the player control is disabled.
- fix: New UI: Portraits: Displaying a portrait behind a GUI box now works correctly.
- fix: Event System: Image Steps: Images now scale and position correctly when using the new UI.
- fix: Event System: Battle Steps: 'Use Battle Action' step could throw errors when a combatant didn't know the ability or owns the item.
- fix: Game Variables: Fixed an issue where Vector3 variables haven't been saved correctly.


Version 2.5.1:
- new: Unity 5.1: ORK Framework now requires Unity 5.1.
- new: Interaction Components: 'UI' start type available in all interaction components. Start the interaction through a UnityEvent from the new UI (e.g. when clicking a button). Use the 'UIStart' function in the UI's event setting - either 'UIStart()' to use the player as starting object, or 'UIStart(GameObject)' to use a defind game object as starting object.
- new: Update UI Text Components: 'Update UI Text' component available. Updates the text of a selected 'Text' component. Can use text codes to show ORK information and special text codes to display combatant information (e.g. status values, etc.).
- new: Update UI Slider Components: 'Update UI Slider' component available. Updates the value (and min/max values) of a selected 'Slider' component. Can use a status value or attack/defence attribute of a combatant.
- new: Player Controls: Mouse: 'Move Type' setting available. Move the player either using a 'Character Controller', position interpolation or a 'NavMesh Agent' component.
- new: Quest Tasks: 'Activate Game Event', 'Inactivate Game Event', 'Finish Game Event' and 'Fail Game Event' settings available. Optionally starts a defined game event when the quest task is activated, inactivated, finished or failed.
- new: Menu Screens: 'Open Game Event' and 'Close Game Event' settings available. Optionally calls a game event when opening or closing a menu screen. You can use this to e.g. enable/disable image effects on the camera during menu screens.
- new: Menu Screens: Ability, Ability Tree, Crafting List, Inventory, Status Value Upgrade: 'Close All' setting available when using 'Close After Use' and 'No Return' options. Closes all currently open menu screens after using a menu item.
- new: Menu Settings: 'Default Mask Texture' setting available. Select the material that will be used for texture masks. Can optionally be overridden by each image that uses texture masks.
- new: Abilities: 'Cursor Settings' available when using 'None' target range and raycast targeting. Optionally change the cursor while the player can click somewhere for a raycast target.
- new: Status Effects: 'Next Action Change' setting available when using 'End Action'. Select how the status effect's end action will be added to the combatant's next action list. Either add the action at the end, remove all actions before adding the action or insert the action at the start of the list.
- new: Items: 'Action Type' setting available when using 'Use' item ability. Select the action type of the used ability - either base attack, counter attack or ability. The selected action type can influence the used ability (e.g. if the target blocks changes from base attacks).
- new: Event System: Status Steps, Variable Steps: 'Status Value To Variable' step available. Stores the value of a combatant's status value (current, base, min, max, displayed, preview or preview max value) into a float game variable.
- new: Event System: Status Steps, Variable Steps: 'Atk Attribute To Variable' step available. Stores the value of a combatant's attack attribute (current, base, min, max, start or preview value) into a float game variable.
- new: Event System: Status Steps, Variable Steps: 'Def Attribute To Variable' step available. Stores the value of a combatant's defence attribute (current, base, min, max, start or preview value) into a float game variable.
- new: Event System: Variable Steps: 'Formula To Variable' step available. Stores the result of a formula into a float game variable. Uses defined combatants as user and target of the formula.
- new: Event System: Battle Steps: 'Use Battle Action' step available. Tries to use a battle action or adds it to a combatant's next action list. If the action is used depends on the state of the combatant and battle system.
- new: Event System: Battle Steps: 'Action Type' setting available in 'Use Ability Calculation' steps. Select the action type of the used ability calculation - either base attack, counter attack or ability. The selected action type can influence the used ability (e.g. if the target blocks changes from base attacks).
- new: Battle Components: 'Appearing Chance' setting available when not using 'None' start type. Optionally define a chance a battle will appear in the scene when the scene is loaded. Failing the chance will remove the battle from the scene (optionally also set the 'Scene ID' to remove the battle permanently).
- new: Combatant Spawners: 'Appearing Chance' setting available when not using 'None' start type. Optionally define a chance a spawner will appear in the scene when the scene is loaded. Failing the chance will remove the spawner from the scene (optionally also set the 'Scene ID' to remove the spawner permanently).
- new: Global Events: 'Scene Change Type' setting available for 'Scene' type global events. Select the type of scene changes that will start the global event - either 'All', 'Scene Change' (i.e. normal changes during a running game), 'Battle' (battle related scene changes, e.g. battle start/end events), 'New Game' or 'Load Game' scene changes.
- new: Editor: You can now open an ORK project asset or event assets by double clicking on them in the Unity editor.
- new: Editor: You can now open other or create new ORK projects in the 'Editor > About' section. The last opened ORK project will be remembered (stored in the 'EditorData' asset) and opened next time you open the editor (when not opening a specific project). The scene wizard will by default select the last opened project for the 'Add Game Starter' functionality.
- new: Editor: You can now select individual scenes to be updated when saving the ORK project.
- change: Event System: Battle Steps: 'Use Ability Calculation' and 'Use Item Calculation' steps are now also available in game events.
- change: Images: Texture Masks: Due to creating materials through a shader in string form is deprecated, the 'Alpha Mask Texture' setting has been removed in all image settings. You now have to use a material instead, either define a default material in 'Menus > Menu Settings' or in the image's settings.
- change: Float Operators: Float operator fields now use 'Set' as default selection. This will only affect new settings (e.g. new event steps), not change already saved settings.
- change: Editor: Editor data (e.g. last opened sections or event files) are now stored in 'Assets/ORKFramework/EditorData.asset'. Deleting this file will not harm your project.
- fix: Player Controls: Mouse: Fixed an issue with the player moving to X=0, Y=0, Z=0 when the raycast didn't hit the ground.
- fix: Menu Screens: Ability: Passive abilities are now correctly displayed in 'Ability' menu parts when enabled in the settings.
- fix: Move AI: AI battle actions with targets out of range could cause the move AI to stop shortly.
- fix: Item Collection: Fixed an issue when using 'Auto Close' item collection dialogue without blocking the accept button and collecting multiple items.


Version 2.5.0:
- new: Item Types: 'Sub Type' settings available. Item types can now be sub types of other item types. 'Inventory' menu screen parts and battle menus allow navigating through the sub type tree structure.
- new: Ability Types: 'Sub Type' settings available. Ability types can now be sub types of other ability types. 'Ability' menu screen parts and battle menus allow navigating through the sub type tree structure.
- new: Ability Trees: 'Sub Tree' settings available. Ability trees can now be sub trees of other ability trees. 'Ability Tree' menu screen parts allow navigating through the sub tree structure.
- new: Quest Types: 'Sub Type' settings available. Quest types can now be sub types of other quest types. 'Quest' menu screen parts allow navigating through the sub type tree structure.
- new: Area Types: 'Sub Type' settings available. Area types can now be sub types of other area types. 'Bestiary (Area)' menu screen parts allow navigating through the sub type tree structure.
- new: Log Types: 'Sub Type' settings available. Log types can now be sub types of other log types. 'Log' menu screen parts allow navigating through the sub type tree structure.
- new: Crafting Types: 'Sub Type' settings available. Crafting types can now be sub types of other crafting types. 'Crafting' menu screen parts allow navigating through the sub type tree structure.
- new: Menu Screens: Inventory: 'Start Parent Type' settings available. Optionally set the parent item type the menu will be displayed with. The menu will only show items of the parent type and its sub types.
- new: Menu Screens: Ability: 'Start Parent Type' settings available. Optionally set the parent ability type the menu will be displayed with. The menu will only show abilities of the parent type and its sub types.
- new: Menu Screens: Ability Tree: 'Start Parent Tree' settings available. Optionally set the parent ability tree the menu will be displayed with. The menu will only show ability trees of the parent tree and its sub trees.
- new: Menu Screens: Quest: 'Start Parent Type' settings available. Optionally set the parent quest type the menu will be displayed with. The menu will only show quests of the parent type and its sub types.
- new: Menu Screens: Bestiary (Area): 'Start Parent Type' settings available. Optionally set the parent area type the menu will be displayed with. The menu will only show areas of the parent type and its sub types.
- new: Menu Screens: Log: 'Start Parent Type' settings available. Optionally set the parent log type the menu will be displayed with. The menu will only show logs of the parent type and its sub types.
- new: Menu Screens: Crafting: 'Start Parent Type' settings available. Optionally set the parent crafting type the menu will be displayed with. The menu will only show recipes of the parent type and its sub types.
- new: Move AI: Enemy Detection: 'Use Attack Allies' setting available. Optionally will detect allied combatants when a status effect with 'Attack Allies' enabled is applied to the combatant.
- new: Menu Settings, GUI Boxes: GUI Skins: 'Fade Button Children' setting available when using 'New UI' gui system type. Optionally fades the alpha or color of button child objects (i.e. text, images) on state change (selected, inactive, ...). Setting available for each button prefab individually (when used).
- new: Interaction Components: 'Start By Collider' setting available when using 'Trigger Enter', 'Trigger Stay' or 'Trigger Exit' start types. Allows trigger start types to be started by colliders with 'Is Trigger' disabled. By default enabled.
- new: Interaction Components: 'Start By Trigger' setting available when using 'Trigger Enter', 'Trigger Stay' or 'Trigger Exit' start types. Allows trigger start types to be started by colliders with 'Is Trigger' enabled. By default enabled.
- new: Interaction Components: 'Start By Root' setting available when using trigger or collision start types. Optionally starts only when the root of a game object causes the trigger/collision event. By default disabled.
- new: Vector3 Values: 'Random' Vector3 value type available. Allows creating a Vector3 with random axes defined by min/max values for each axis.
- new: Input Keys: Unity Input Manager: 'Is Joypad Axis' setting available. Enable this when the used Unity input manager key is a joypad axis to support down, hold and up actions.
- new: Event System: Camera Steps: 'Shake X-Axis', 'Shake Y-Axis' and 'Shake Z-Axis' settings available in 'Shake Camera' step. You can now optionally shake the camera on each axis. By default shakes on the X-axis.
- new: Event System: Movement Steps: 'Check Combatant Speed' step available. Checks the current horizontal or vertical movement speed of a combatant.
- new: Event System: Bestiary Steps: 'Check Bestiary Count' step available. Checks the number of entries in the bestiary.
- new: Event System: Bestiary Steps: 'Bestiary Count To Variable' step available. Stores the number of bestiary entries into a float game variable.
- new: Event System: Audio Steps: 'Change Music Volume' step available. Changes the music volume - either sets or fades the volume. This will change the overall music volume, not the volume of the currently playing music.
- new: Event System: Audio Steps: 'Change Sound VOlume' step available. Changes the sound volume - either sets or fades the volume. Already playing audio clps will not be updated by this.
- new: Event System: Variable Steps, Function Steps: 'Field To Variable' step available. Stores the value of a flied or property into a game variable. Supports string, bool, int/float and Vector2/3 values.
- new: Battle Events: Battle Steps: 'No Time Consume' step available. Stopts the action from consuming time, i.e. the timebar will not be reduced by the actions costs in 'Active Time Battles', the turn value will not be reset in 'Turn Based Battles' using 'Multi-Turns'.
- new: Battle Events: Battle Steps: 'Change Turn Value' step available. Changes the turn value of a combatant. The turn value is used to generate the turn order in 'Turn Based Battles' using 'Multi-Turns'.
- new: Battle Events: Battle Steps: 'Check Turn Value' step available. Checks the turn value of a combatant. The turn value is used to generate the turn order in 'Turn Based Battles' using 'Multi-Turns'.
- new: Battle Events: Battle Steps: 'Use Average' settings available in 'Check Turn' step. Optionally checks the average turn of the combatant's group or battle group instead of the combatant's turn.
- new: Formulas: Combatant Steps: 'Check Turn Value' step available. Checks the turn value of a combatant. The turn value is used to generate the turn order in 'Turn Based Battles' using 'Multi-Turns'.
- new: Battle AIs: Status Steps: 'Check Turn Value' step available. Checks the turn value of a combatant. The turn value is used to generate the turn order in 'Turn Based Battles' using 'Multi-Turns'.
- new: Main Menu: Auto Slot Selection: 'Background Image' settings available in the 'Auto Slot Selection' settings. Optionally display the save menu background images or own backgrounds when displaying the auto slot selection (and optionally override question).
- new: Save Game Menu: Load Game Menu: 'All Auto Save Slots' setting available in the 'Load Game Menu' settings. Optionally displays all auto save slots in load menus, including unused slots (displayed as inactive buttons).
- new: GUI Boxes: Choice Settings: 'Define Choice Height' settings available. Optionally defines the height of choices - content exceeding the height will not be visible. If disabled, the choice height is adjusted to the content of the choice.
- new: Status Effects: 'Set Max Stack' settings available when using effect stacking. Optionally set the maximum number of times a status effect can be stacked.
- change: Combatants: A combatant with an 'Attack Allies' effect applied will now also use the AI timeout when the combatant is AI controlled.
- change: Real Time Battle Areas: Disabling a real time battle area's game object will now leave the real time battle (if it's the only active real time battle area).
- fix: Event System: Dialogue Steps: There was a small delay when setting variables in a 'Value Input Dialogue' step, leading to a following variable check sometimes checking old values.
- fix: Move AI: Using 'NavMesh Agent' components moves the combatant again.
- fix: Move AI: Using raycasts in enemy detection is now working correctly.
- fix: Event System: Editor: Integer value selections will now display the correct formula.
- fix: Event System: Variable Steps: 'Variable To Variable' now correctly displays the variable options for source and target when using 'Object' variables.
- fix: Event System: Dialogues: Actor text codes for displaying combatant information using an actor without a combatant no longer crashes Unity.
- fix: UI: Fixed an issue when using Unity 5.1 and the new UI.
- fix: Input Keys: Fixed some issues with hold times and timeouts.
- fix: Battle Spots: Not using 'Place On Ground' no longer replaces the Y-axis position of battle spots when fighting in another scene.
- fix: Status Effects: Using 'Enabled' stackablae effects as auto effects could cause crashes.
- fix: Inventory: Fixed an issue with inventory limit not being updated when joining a new member to the group and adding items from the combatant's inventory.


Version 2.4.4:
- new: Status Development: Upgrade Settings: 'Own Name' and 'Own Description' settings available. Optionally override the name or description of the status value that will be upgraded.
- new: Ability Trees: 'Own Name' and 'Own Description' settings available. Optionally override the name or description of the ability that will be learned.
- new: Status Effects: 'None' option available in the 'On Recast' setting. This option will not change turns/time of an already applied status effect when reapplying it.
- new: Items, Weapons, Armors: 'Own Auto Stack' settings available. Items, weapons and armors can optionally override the auto stack settings defind in the 'Inventory Settings'.
- new: GUI Boxes: 'Use Minimum Height' setting available when using 'Auto' height adjustment. Optionally uses the height (H) defind by the content box bounds will be used as minimum height of the GUI box.
- new: Menu Screens: Sub Menus: 'Only For Usable' settings available. Optionally makes the sub menu only available for usable choices. E.g. the sub menu item will only be displayed when the ability is usable.
- new: Menu Screens: Equipment: 'Show Portrait' setting available in 'Part Box Settings'. Displays the portrait of a weapon/armor currently equipped on an equipment part.
- new: Menu Screens: Ability, Ability Tree, Equipment, Inventory: 'Information' element available in 'HUD Info Display' settings. Displays information about abilities/equipment using text codes, e.g. '%n' for name, '%tn' for type name.
- new: Text Codes: 'X' position and offset text codes available (found under 'Special' in the text editor). Use #xN# to define the X position (horizontal position) N of the following text. Use #+xN# to define the X offset (horizontal offset) N of the following text to the current text.
- new: Text Codes: 'Y' position and offset text codes available (found under 'Special' in the text editor). Use #yN# to define the Y position (vertical position) N of the following text. Use #+yN# to define the Y offset (vertical offset) N of the following text to the current text.
- new: Input Keys: Touch: 'Consume Fingers' setting available. Optionally consumes the fingers used for the touch input, making them unavailable for other touch interactions (e.g. 'Control' type HUDs).
- change: Inventory Settings: The 'Auto Stack' setting has been replaced by the 'Auto Stack Items', 'Auto Stack Weapons' and 'Auto Stack Armors' settings. You can now define auto stacking for them individually. Items, weapons and armors can optionally override these settings.
- change: Encryption: The class encrypting game data and save games has been moved from the core to the framework package. You can now use custom encryption by implementing the new 'ISecurityHandler' interface and registering your class in when ORK is initialized in the 'ORK' class.
- fix: HUDs: Combatant: Individual 'Combatant' type HUDs where not displayed after switching to a conditional prefab.
- fix: HUDs: Control: Mouse/touch position could be off when using a GUI box placed on a full screen GUI layer.
- fix: Inventory Notifications: The inventory notifications are now correctly displayed after loading a save game.
- fix: Quests: Automatic quest updates are now happening correctly after loading a save game.


Version 2.4.3:
- new: Group Shortcuts: The shortcut slot lists are now also available for groups. Group shortcuts can assign abilities, items, equipment and currency from multiple combatants.
- new: Control Maps: 'Group Shortcut' setting available for 'Shortcut' action type. Optionally uses the combatant's group shortcuts instead of individual shortcuts.
- new: Combatants, Classes: Default Shortcuts: 'Group Shortcut' setting available. Uses the combatant's group shortcuts instead of individual shortcuts for default shortcut assignments.
- new: Game Settings: Player/Group Settings: 'Shortcut List Count' setting available. Defines the number of available group shortcut lists.
- new: Menu Screens: Sub Menus: 'Group Shortcut' setting available for 'Assign Shortcut' sub-menu items. Optionally uses the menu screen user's group shortcuts instead of individual shortcuts.
- new: HUDs: Combatant: 'Group Shortcut' setting available in 'Shortcut' element types. Optionally uses the combatant's group shortcuts instead of individual shortcuts.
- new: Event System: Shortcut Steps: 'Group Shortcut' setting available in 'Change Shortcut', 'Check Shortcut' and 'Change Shortcut List' steps. Uses the combatant's group shortcuts instead of individual shortcuts.
- new: Event System: Save Game Steps: 'Has Auto Save Game' step available. Checks if a save game exists in the current auto save slot.
- new: Event System: Save Game Steps: 'Can Continue' step available. Checks if the game can be continued, i.e. a last used save game (or auto save slot) exists.
- new: Event System: Save Game Steps: 'Continue' step available. Loads the last used save game (or auto save slot). The event ends after this step.
- new: Event System: Animation Steps: 'Death Animation' step available. Plays the death animation on dead combatants. E.g. use this step to keep your dead player group members dead at the start of a battle.
- new: Event System: Animation Steps: 'Revive Animation' step available. Plays the revive animation on dead combatants. E.g. use this step to return your dead player's animation to the default at the end of a battle.
- new: Battle AI: Variable Steps: 'Get Object Variable' step available. Adds the combatant with the highest or lowest value of a defined float object variable to the target list.
- new: Battle AI: Action Steps: 'Force Found Targets' setting available in 'Attack', 'Ability', 'Class Ability' and 'Item' action steps. Optionally forces the action to only have the found targets available. The action can't fall back to other targets based on the combatant's AI settings if none of the targets is in range.
- new: Main Menu: 'URL Button' settings available. Optionally displays a button in the main menu (below the 'About' button) to open an URL in the default web browser.
- new: Shop Layouts: '%n' text code available in the 'Type Box' title text. Displays the buy/sell choice name that was selected in the type box title.
- new: Combatant Spawners: You can optionally use game objects as random spawn points for single combatant spawners (i.e. not using colliders to define a spawn area).
- change: Event System: 'Call Save Menu', 'Auto Save Game' and 'Auto Load Game' steps can now be found in the 'Save Game Steps'.
- change: Event System: Using formulas as int or float values can now also use unspawned player group members (actor type 'Player' or 'Member') for calculation.
- change: Auto Battles: Starting a battle when coming near an enemy now checks if any member of the player's battle group is alive. Until now, only the player (group leader) was checked, resulting in battles not starting when the player was dead.
- fix: Combatant Spawners: Remember Combatants could cause unspawned group members to be spawned upon returning to the scene.
- fix: Input Keys: Using the 'ORK Input Key' input origin with needing 'All' multiple input keys now works correctly when using the input key as axis.
- fix: Battle Events, Battle Start Events, Battle End Events, Phase Change Events: The 'Remove Temporary' step now removes all temporary combatants.
- fix: Saving Project: Added safeguards when saving the project to prevent unsaved data through errors when updating prefabs and scenes.
- fix: Auto Effects: Fixed a stack overflow happening through bad auto effect change loops.
- fix: Combatants: Adding a combatant to the player group using the 'Player' level settings for initialization already counted the new combatant to the group, tearing down the average level.
- fix: HUDs: Fading in sometimes caused a short flicker when using the new UI.
- fix: Move AI: Actions without targets could cause the move AI to return to following waypoints instead of continue hunting a target.
- fix: Combatant Selections: Adding a 'Back' option caused an error the 2nd time a combatant selection was used.


Version 2.4.2:
- new: Status Values: 'Earn on Level Up' setting available for 'Experience' type status values with 'None' experience type. Optionally increases the experience points on level up by the difference between current and previous level (like 'Normal' type status values).
- new: Attack Attributes: 'Immunity Notification' settings available. Optionally display a notification when a combatant is immune to damage due to an attribute being 0. Checks the target's attribute value and is displayed at the target's position. Can be overridden by each sub-attribute individually.
- new: Defence Attributes: 'Immunity Notification' settings available. Optionally display a notification when a combatant is immune to damage due to an attribute being 0. Checks the attacker's attribute value and is displayed at the target's position. Can be overridden by each sub-attribute individually.
- new: Combatants: Auto Start Battle Settings: 'Start on Move Detection' settings available. Optionally use move detection (sight, movement) with range and angle checks (like 'Move AI' enemy detection) to automatically start battles.
- new: Combatants, Classes: Default Shortcuts: 'Attack' and 'Counter Attack' shortcut types available. Uses the combatant's base attack or counter attack as default shortcut.
- new: Move AI: Enemy Detection: 'From Child' setting available for move detections. Optionally uses a child object of the combatant for range and angle checks. E.g. using this to check from the combatant's head for a sight radius will also use head turnings from animations.
- new: Camera Controls: 'Initial Damping' setting available for the 'Top Down Border' camera controls. Uses damping (position/height) when first adjusting the camera position to the player. By default enabled.
- new: Input Keys: 'Input Handling' settings available for 'Mouse' and 'Touch' input origins. Define when to receive the input (e.g. down, hold, ...) and timeouts, same settings as in 'Unity Input Manager' and 'Key Code' input origins.
- new: Event System: Status Steps: 'Clear Ability Reuse' step available. Removes all ability reuse blocks from a combatant, allowing an ability that's blocked for a defind amount of turns/time to be used again.
- new: Event System: Shortcut Steps: 'Attack' and 'Counter Attack' shortcut types available. Shortcut steps can now use a combatant's base attack and counter attack when changing or checking a shortcut slot.
- new: Battle Events, Battle Start Events, Battle End Events, Phase Change Events: Battle Steps: 'Mark As Temporary' step available. Marks a defined combatant as temporary - temporary combatants can be removed using the 'Remove Temporary' step. This mechanic can be used e.g. for summon game mechanics.
- new: Battle Events, Battle Start Events, Battle End Events, Phase Change Events: Battle Steps: 'Remove Temporaray' step available. Removes temporary combatants from the battle and their groups. This mechanic can be used e.g. for summon game mechanics.
- new: Battle Events: Battle Steps: 'Mark As Temporary' setting available in 'Join Battle' steps. Optionally marks the new combatant as temporary - temporary combatants can be removed using the 'Remove Temporary' step. This mechanic can be used e.g. for summon game mechanics.
- new: Battle Events: Battle Steps: 'New Group' setting available in 'Join Battle' steps. Optionally creates a new group for the combatant instead of joining an existing group.
- new: Battle Events: Battle Steps: 'Remove From Group' setting avaialble in 'Leave Battle' steps. Optionally removes the combatant leaving battle from the group it belongs to.
- new: HUDs: Combatant: 'Remove On Drop' settings available in 'Shortcut' HUD elements. Optionally removes an assigned shortcut when dropped into the game world (i.e. not on a combatant to be used).
- change: Auto Status Effects: Adding status effects using 'Auto Effect' settings (e.g. combatants, classes) is no longer limited to first spawn and battle start.
- fix: Status Values: Status recalculation order could cause combined status values to have the wrong value when influenced by status effects.
- fix: Combatant Spawners: Remembered combatants now use the waypoints set up in the combatant spawner's settings.
- fix: Combatant Spawners: Respawning could, in some cases, respawn all missing combatants at once instead of waiting the individual times.
- fix: Input Keys: 'Touch' input origins didn't work properly as buttons.
- fix: Input Keys: Hold timeouts could in some cases not work when using 'Up' input handling.
- fix: Abilities: Using 'Turn' ability reuse with multiple abilities could lead to blocks not being removed after the battle.
- fix: Menu Screens: 'Equipment' menu parts displayed the name of an equipment instead of the equipment part when using '%n' in the equipment box title.


Version 2.4.1:
- new: Value Bars: 'Icon Value' settings available when enabling 'Use Icons' in value bars. Defines the value one icon will display and if the value is in percent of the full bar. E.g. can be used to have one icon for the whole HP (100 %) or one icon per 10 HP.
- new: Currency, Items, Weapons, Armors: 'Spawn Offset' setting available. Optionally adds an offset to the position of the prefab spawned by an item collector.
- new: Combatant Spawners, Random Battle Area: 'Use Nearest Battle' setting available. Optionally uses the nearest game object with a 'Battle' component attached within a defined range.
- new: Combatants: 'AI Controlled Player' setting available. Optionally makes the player combatant AI controlled in battle, i.e. the player can't give commands to the combatant.
- change: Menu Screens: Changing between menu screens with both using 'Own Music' will no longer shortly resume the previous music.
- change: Battle Start Events: Loading a new scene in a battle start event (i.e. fighting in a different scene) will place already created battle spots on the ground.
- change: Battle Start Events: Loading a new scene in a battle start event (i.e. fighting in a different scene) will trigger respawn in a combatant's spawner to remove the remembered combatant and store it's respawn time.
- change: Player Group: Changing the player (i.e. leader of the player group) will only spawn the new player when the old player was already spawned.
- fix: Saving: Auto updating data references in prefabs and scenes when saving the project could result in an error.
- fix: HUDs: Background images will now be placed correctly behind the GUI box.
- fix: Game Controls: Using jump settings in 'Button' player controls without the combatant speed resulted in an error when jumping.
- fix: Menu Screens: Calling a menu screen that has previously been opened with a removed group member from the event system will reset to the player combatant.
- fix: Move AIs: Ending a battle action will no longer trigger an idle action when in waypoint mode - this resulted in selecting the next waypoint after each battle action.
- fix: Battle AI: Completed bestiary entries could cause an error in some battle AI steps.


Version 2.4.0:
- new: Unity 5: ORK Framework now requires Unity 5.


Version 2.3.1:
- new: Combatant Spawners: 'Remember Combatants' setting available. Optionally remembers the spawned combatants (status and position) and respawn times when leaving the scene. The combatants will be respawned where they where when reloading the scene.
- new: Save Game Menu: 'Spawned Combatants' setting available in the 'Save Settings'. Optionally saves the combatants spawned by 'Combatant Spawner' components with 'Remember Combatants' enabled with the save game. Either saves the combatants of the 'Current' scene, 'All' scenes or 'None' scene at all.
- new: Input Keys: 'Invert Axis' setting available for all input origins. Optionally inverts the input axis, i.e. 1 will become -1, -1 will become 1.
- new: Weapons, Armors: 'Chance' settings available for random status value bonuses. Optionally only adds random bonuses to status values based on chance.
- new: Weapons, Armors: 'Add Bonus Range' setting available for random status value bonuses. Either adds 'All' random bonuses, a 'Random' bonus (no bonus is added if chance fails), or adds the 'First' bonus due do chance settings.
- new: Float Values: 'Random' value type available. Uses a random value between two defined values. Available throughout the framework.
- new: GUI Boxes: Choice Settings: 'Position' choice mode available. Optionally define positions for choices. When exceeding the defined number of positions, the remaining choices will be displayed in 'List' mode.
- new: HUDs: Combatant: 'Position' cell mode available for 'Shortcut' HUD elements. Optionally define the positions of each shorcut slot cell.
- new: HUDs: Combatant: 'Use Auto Target' setting available for 'Shortcut' HUD elements. Optionally uses shortcuts when clicked on automatically selected targets.
- new: HUDs: Combatant: 'Set Size' settings available for 'Shortcut' HUD element info labels. You can now optionally set the size of info labels used to display empty or assigned shortcut slots.
- new: HUDs: Combatant: 'Use Icon' settings available for 'Shortcut' HUD element info labels. Optionally gives more control over displaying a shortcut's icon (e.g. scale mode) than using the '%i' text code in text.
- new: HUDs: Tooltip: 'Use Bar' settings available. Tooltip HUDs can now display level points (ability, equipment) and durability (equipment) value bars instead of text.
- new: HUDs: Tooltip: New text codes available to display level points (ability, equipment) and durability (equipment) information.
- new: Event System: Scene Steps: 'Remove Spawned Combatants' setting available in the 'Remove Scene Data' step. Optionally removes stored data of spawned combatants from the scene. Useful if you e.g. want to clear all spawners when leaving a dungeon.
- new: Battle Events: Battle Steps: 'Consume Costs' step available. Consumes the use costs of an action (e.g ability use costs, consumes an item). The step will consume the costs each time it's used.
- new: Abilities, Items: Target Settings: 'Auto Target' settings available. Optionally uses status requirements and variable conditions to automatically select a target. This is used in battle menus to select the a combatant (still requires the player to accept the choice), control maps with auto target and AI target selection.
- new: Combatants: AI Settings: 'Auto Target' setting available. Uses the 'Auto Target' settings of a used ability or item when selecting an AI target. If not used by the ability/item or not found, the nearest (if enabled) or a random target will be used.
- new: Camera Events: 'In Blocked Controls' setting available. The camera event component will be executed while the player controls are blocked (e.g. in events). By default enabled.
- new: Save Game Menu: 'Add Cancel' settings available in the 'Save Game Menu' and 'Load Game Menu' settings. Adding the 'Cancel' choice to the file list is now optional. By default enabled.
- new: Menu Settings: 'Bonus Display' settings available. Define the text representation of status value bonuses and attack/defence attribute bonuses. Can be displayed in descriptions of bonus giving things using the '%bonus' text code.
- new: Status Effects, Passive Abilities, Weapons, Amrors, Combatants, Classes: '%bonus' text code available in descriptions. Displays the status value and attack/defence attribute bonuses as defined in the 'Bonus Display' settings.
- new: Text Codes: '#percent' text code available to display a '%' sign. Use this text code to display '%' in texts that use special text codes (e.g. '%' to display the quantity of an item).
- change: Click Controls: All 'Enable Double Click' settings have been replaced by 'Enable Clicking' and 'Click Count' settings. You can now define the number of clicks if needed. By default set to 2 clicks (i.e. restores the old double click setting).
- change: HUDs: Combatant: 'Enable Drop' no longer needs to be enabled to use drag+drop to change shortcuts in 'Shortcut' HUD elements.
- fix: Group: Getting average group levels/turns no longer throws errors when no members are in a group.
- fix: Real Time Battle Areas: Using colliders to limit the area could result in the battle not starting when spawning inside the area due to first entering with the interaction controller.
- fix: Menu Screens: Equipment, Inventory: 'Durability' HUD info displays will now also be displayed when 'Enable Dragging', 'Enable Double Click' and 'Enable Tooltip' are disabled.
- fix: Move AIs: Close distance target position checks could lead to the check interval not being reset, resulting in the combatant not using an updated target position.
- fix: Mounting Objects: Setting the scale when mounting an object on another object will now use the correct scale in relation to the parent object.


Version 2.3.0:
- new: Group Abilities: Abilities can now optionally be learned by the group of a combatant instead of a single combatant. Group abilities are available to all members of the group and can be used like normal abilities.
- new: Abilitiy Learning: 'Group Ability' setting available. Optionally learns the ability to the combatant's group instead to the combatant. Available throughout the framework.
- new: Abilitiy Forgetting: 'Group Ability' setting available. Optionally forgets the ability of the combatant's group instead of the combatant. Available throughout the framework.
- new: Shops: 'Abilities' settings available. Shops can now also sell abilities and group abilities. A bought ability will be learned by the shop's user combatant, or the user's group (when using group abilities). An ability can only be sold once per combatant/group, there is no quantity selection displayed.
- new: Status Effect Types: 'Status Effect Types' sub-section now available in the 'Status' section. Status effect types can be used to separate status effects. Effect changes can optionally use all status effects of a selected type, the HUD can optionally display only selected status effect types.
- new: Status Effects: 'Status Effect Type' setting available. Defines the status effect type of the status effect. The type is used to separate status effects, e.g. when displayed in a HUD or change all effects of a selected type.
- new: Status Effect Changes: 'Use Type' and settings available when changing status effects (e.g. ability status changes, auto effects, etc.). Optionally checks uses all status effects of a selected status effect type when changing effects (e.g. remove all 'Negative' type effects).
- new: Status Requirements: 'Status Effect Type' status check available. Checks if a status effect of the selected status effect type is or isn't applied to the combatant.
- new: Status Requirements: 'Weapon Item Type' and 'Armor Item Type' status checks available. Checks if a weapon/armor of the selected item type is or isn't equipped on the combatant.
- new: Classes, Combatants, Passive Abilities, Weapons, Armors, Status Effects: 'Attack Status Effects' settings available. Abilities and items can automatically use the user's attack status effect changes on the target.
- new: Classes, Combatants, Passive Abilities, Weapons, Armors, Status Effects: 'Defence Status Effects' settings available. Abilities and items can automatically use the target's defence status effect changes on the user.
- new: Abilities, Items: 'Use Attack Effects' and 'Use Defence Effects' settings available for value changes of active abilities and items. Optionally uses the user's 'Attack Status Effects' and the target's 'Defence Status Effects'. By default disabled.
- new: Weapons, Armors: 'Durability' settings available for the different level settings of equipment. A weapon or armor can optionally have a durability and wear off. If an equipment is outworn (i.e. durability reaches 0), it can either not give any bonuses any more, be unequipped or destroyed. Durability can be changes using the event system.
- new: Weapons, Armors: 'Own Outworn Text' settings available in the equipment's console texts. Optionally overrides the default console text displayed when an equipment's durability reaches 0.
- new: Input Keys: 'Custom' input origin settings available. Input keys can now use custom scripts to get button and axis values. Calls a static function of a class using reflection - button function must return a bool value, axis function must return a float value.
- new: Status Values: 'From Minimum' setting available for 'Experience' type status values. Optionally restarts the status value from it's minimum value when leveling up instead of continuing to grow (using the previous level's maximum value as minimum).
- new: GUI Boxes: Choice Settings: 'Choice Mode' settings available. Choices can be displayed in 'List' and 'Circle' mode. 'List' mode displays choices in a list (as it has been until now). 'Circle' mode displays choices in a circle around a center position in the GUI box.
- new: GUI Boxes: Choice Settings: 'Header Settings' available. A GUI box can now optionally display headers above choice buttons.
- new: Menu System: 'Header Texts' settings available in most menu parts. Optionally display headers above the choice buttons.
- new: Shop Layouts: 'Header Texts' settings available in 'Buy/Sell Box', 'Type Box' and 'List Box' settings. Optionally display headers above the choice buttons.
- new: Battle Menus: 'Header Texts' settings available. Optionally display headers above the choice buttons. Sub-menus can optionally have different header texts.
- new: Battle Menus: 'Whole Group' setting available for 'Auto' battle menu items. The 'Auto' command can now optionally be used for the whole battle group of the combatant - each member of the group will use the 'Auto' command once. Not used in 'Real Time' battles.
- new: HUDs: Combatant, Turn Order: 'Type Display Limit' settings available for 'Status Effect' HUD elements. Optionally only displays status effects of selected status effect types. Can be used to e.g. separate positive and negative effects.
- new: HUDs: Combatant, Turn Order: New text codes available for 'Status Value' HUD elements. '%m2' displays the minimum value, '%r' displays the remaining value to the maximum value (i.e. max - current value), '%r2' displays the remaining value to the minimum value (i.e. current - min value).
- new: HUDs: Combatant, Turn Order: 'Check Attribute Value' settings available for 'Attack Attribute' and 'Defence Attribute' HUD elements when listing attributes. Optionally checks the value of each attribute before displaying it, e.g. to only display attributes greater than 100.
- new: HUDs: Combatant, Turn Order: 'Relative Offset' settings available when using 'Group' combatant HUDs or turn order HUDs. The offset of the GUI boxes used for the individual HUDs can optionally be relative to the GUI box of the previous combatant. The position will be automatically adjusted, e.g. if the HUD size of one combatant is changed.
- new: HUDs: Combatant: 'Cell Mode' settings available for 'Shortcut' HUD elements. Like choices, shortcut slots can now also either be displayed as a 'List' (like until now) or in a 'Circle' around a defined position in the HUD element.
- new: Event System: Check Steps: 'Check Language' step available. Checks the currently used language of the game.
- new: Event System: Animation Steps: 'Auto Animation' step available. Use this step to enable or disable the auto move animation of a combatant.
- new: Event System: Function Steps: 'Is Static' setting available in the 'Call Function', 'Check Function' and 'Function To Variable' steps. Optionally calls a static function of a class - i.e. it doesn't require a component added to a game object.
- new: Event System: Function Steps: 'Is Static' setting available in the 'Change Fields' and 'Check Fields' step. Optionally uses static fields/properties of a class - i.e. it doesn't require a component added to a game object.
- new: Event System: Function Steps: 'Emit After (s)' setting available in the 'Emit Particles' step. Optionally starts/stops emitting particles on a game object after a defined amount of time.
- new: Event System: Movement Steps: 'Ignore Y' setting available in the 'Change Position' and 'Move Into Direction' steps. Ignores the Y-axis difference when moving/facing the target, i.e. the mover will maintain its Y-axis position (unless gravity is applied). By default enabled.
- new: Event System: Equipment Steps: 'Change Equip Durability' step available. Changes the durability of an equipment currently equipped on an equipment part or all parts of a combatant.
- new: Event System: Equipment Steps, Check Steps: 'Check Equip Durability' step available. Checks the durability of an equipment currently equipped on an equipment part or all parts of a combatant.
- new: Event System: Equipment Steps, Inventory Steps: 'Change Inventory Durability' step available. Changes the durability of an equipment currently placed in the inventory of a combatant.
- new: Event System: Equipment Steps, Inventory Steps, Check Steps: 'Check Inventory Durability' step available. Checks the durability of an equipment currently placed in the inventory of a combatant.
- new: Event System: Active Group Steps: 'Destroy Prefab' setting available in the 'Leave Active Group' and 'Leave Battle Group' steps. Optionally destroys a spawned prefab of a combatant that'll leave the group. By default enabled.
- new: Event System: Variable Steps: 'Variable To Transform' step available. Sets a game object's position, rotation or scale to the value of a Vector3 game variable.
- new: Battle Events: Battle Steps: 'Reconsume' setting available in the 'Calculate' step. Optionally consumes use costs or items again, even if they already have been consumed.
- new: Battle Events: Battle Steps: 'Can Use Action' step available. Checks if the user can use the action of the battle event.
- new: Main Menu: Custom Choices: 'Is Static' setting available for custom choices. Optionally calls a static function of a class - i.e. it doesn't require a component added to a game object.
- new: Combatants: AI Settings: 'Real Time AI Range' settings available. Using the battle AI can optionally be limited to a defined range to the leader of the combatant's group. You can use this setting to let AI controlled player group members stop fighting when the player moves away.
- new: Move AI: 'Prioritise Leader' settings available. Following the leader can optionally take priority over other targets when outside a defined range to the leader of the combatant's group.
- new: Status Bonuses: 'Status Change Modifier' bonus settings available. Optionally add bonuses to status value changes by abilities or items (value change settings), the bonus can be given for positive, negative or all changes. The default change modifier is 100 (i.e. 100 %), the bonuses are added to it. E.g. adding -10 bonus to negative MP changes will reduce the MP use costs to 90 %.
- new: Abilities, Items: 'Ignore Change Modifier' setting available for all value change settings (e.g. use costs, target changes). A status value change can optionally ignore the status change modifier bonuses and use the default 100 % modifier.
- new: Abilities: 'Own Group Learning Text' and 'Own Group Forgetting Text' settings available in the 'Console Texts' of the ability. Optionally overrides the default console texts for learning/forgetting a group ability.
- new: Abilities: 'Buy Price' setting available per ability level. Defines the price an ability will be sold for at shops. Can optionally be overridden by the shop's item list.
- new: Console Settings: 'Group Ability Text' settings available in 'Learning Texts' and 'Forgetting Texts' settings. Define the console texts that will be displayed when a group ability is learned or forgotten.
- new: Console Settings: 'Weapon Outworn Text' and 'Armor Outworn Text' settings availble in 'Inventory Texts' settings. Deinfe the console texts that will be displayed when a weapon's or armor's durability reaches 0.
- new: Battle End: New text codes available for 'Money Text', 'Item Text', 'Status Value Text', 'Ability Learn Text' and 'Ability Tree Learn Text' settings. Use '%cn' (name), '%cd' (description) and '%ci' (icon) to display information about the combatant.
- new: Battle End: 'Group Ability Learn Text' setting available. Will be displayed if a new group ability is learned through level up.
- change: Status Requirements: 'Ability Check' and 'Is Valid' settings replace the old ability status check. You can know check if an ability is known to the combatant (i.e. learned, temporary or group ability), learned or a group ability. Old settings will automatically be upated.
- change: Menu Screens: Equipment, Inventory: The 'Level Points Display' settings are now named 'HUD Info Display' and can also display durability information of an equipment.
- fix: Combatant Spawners: Spawning single combatants on a position (i.e. not using a collider for area spawning) could result in creating multiple combatants when respawning.
- fix: GUI System: New UI: The event system's 'Image Steps' are now working correctly when using the new UI.
- fix: GUI System: New UI: 'Selected Choice Offset' setting is now working correctly when using the new UI.
- fix: GUI System: Legacy GUI: The drag box will no longer be displayed twice, with one being displayed even after the drag finished.
- fix: Event System: Movement Steps: The 'Change Position' step's movement behaved differently when enabling/disabling 'Face Direction'.
- fix: Blocking Controls: Changing group members involving the player could result in the control components not being blocked when the control was blocked while changing members.
- fix: Turn Based Battles: A combatant dying while having the battle menu open could result in the battle not progressing.


Version 2.2.4:
- new: Status Requirements: 'Inventory' status check available. The combatant (or group) must or mustn't have a defind item, weapon, armor or currency in the inventory.
- new: Crafting System: The crafting system now also allows creating new items by adding items, equipment and currency to a combatant's crafting list. When creating using the crafting list, the first crafting recipe matching the items in the crafting list will be used. Either uses only known recipes or checks all recipes and learns unknown recipes upon successful creation.
- new: Menu Screens: 'Crafting List' menu part available. Displays the items, equipment and currency added to the user's crafting list. When using the crafting list for crafting, the first recipe that matches the items added to the list will be used.
- new: Menu Screens: Sub Menus: 'Crafting List' sub menu action available. Adds a selected item, equipment or currency to the user's crafting list.
- new: Menu Screens: Bestiary (Area): 'Show OK Button' and 'Show Cancel Button' settings available. Optionally displays the ok/cancel buttons of the GUI box.
- new: Event System: Dialogue Steps: 'Show OK Button' and 'Show Cancel Button' settings available in the 'Bestiary Dialogue' step. Optionally displays the ok/cancel buttons of the GUI box.
- new: Event System: Dialogue Steps: 'Quest Conditions' settings available in 'Choice' type 'Show Dialogue' steps. A choice can optionally use quest or task status conditions to determine if it will be displayed.
- new: Event System: Dialogue Steps: 'Status Requirements' settings available in 'Coice' type 'Show Dialogue' steps. A choice can optionally use status requirements to determine if it will be displayed.
- new: Event System: Active Group Steps: 'Spawn Group Members' step available. Spawns the other members of the active player group or battle group. Requires the player to already be spawned in the scene.
- new: Event System: Active Group Steps: 'Destroy Group Members' step available. Destroys all spawned members of the active player group except the player.
- new: Event System: Crafting Steps: 'Add Recipe Outcome' step available. Adds the outcome of a selected crafting recipe to a combatant's inventory. This doesn't consume ingredients or checks for requirements or crafting chance.
- new: Event System: Crafting Steps: 'Remove Needed Ingredients' step available. Removes the ingredients needed for a selected crafting recipe from a combatant's inventory.
- new: Event System: Base Steps, Function Steps: 'Add Control Component' step available. Adds a defined component of a game object to the player or camera control list. The component will be enabled/disabled with the selected controls.
- new: Event System: Base Steps, Function Steps: 'Remove Control Component' step available. Removes a defined component of a game object from the player or camera control list.
- new: Value Bars: 'Hide Empty Bar' setting available. Value bars (e.g. displaying status values in HUDs) can optionally be hidden if the displayed value is at the minimum value or below.
- new: Value Bars: 'Interpolate Colors' and 'Interpolate Empty Colors' settings available. Optionally interpolates between the colors used for the different percentages of the value bar. Only used when using colors instead of images.
- new: HUDs: Combatant, Turn Order: 'Limit Bar Display' settings available. Status value bars can optionally be limited to a defined value range (percent or absolute values). This allows creating split value bars, e.g. 2 HP bars from 0-50 % and 50-100%.
- new: Combatants: Death Settings: 'Variable Origin' setting available for death variable changes. The variable changes when a combatant dies can now be made on global variables, the combatant's object variables or the combatant spawner's object variables. By default using global variables.
- new: Abilities, Weapons, Armors: 'Own Description' settings available for the different level settings of abilities, weapons and armors. Optionally overrides the description of the ability, weapon or armor with a new description for a defined level.
- new: Abilities, Items: 'Active Time Order Changes' settings available. An ability/item can now optionally change the timebar of the target. A positive value will increase, a negative value will decrease the timebar.
- change: HUDs: Combatant: The 'No Inner Assign' setting has been replaced by the 'Inner Assign' setting in 'Shortcut' HUD elements. When a shortcut slot is assigned from the same HUD element, you can now either 'Keep' the old assignment, 'Remove' the old assignment, 'Spap' old and new slot assignment or prevent inner assignment ('None').
- change: Editor: Menu Screens: The 'Add Menu Part' list is now sorted alphabetically.
- fix: GUI System: New UI: Fixed problems with drag+drop when using the new UI.
- fix: GUI System: New UI: When first displaying a GUI box or changing focus, the selected choice will now be marked as selected object in the new UI event system.
- fix: Turn Based Battles: Using 'Death Immediately' without 'End Immediately' could lead to starting multiple new turns while the player was dying.
- fix: HUDs: Combatants: Only using backgrounds for 'Shortcut' element slots could result in a wrongly calculated content size, hiding parts of the HUD.
- fix: Event System: Spawn Steps: Using the 'Spawn Prefab' step without using the audio options and spawning at a position could lead to an error.


Version 2.2.3:
- new: Abilities, Items: 'Use Requirement' settings available for status value changes of active abilities and items. Optionally checks 'Status Requirements' and 'Variable Conditions' on the user or target, the changes will only be performed if the check is valid.
- new: Status Effect Changes: 'Use Requirement' settings available when changing status effects (e.g. ability status changes, auto effects, etc.). Optionally checks 'Status Requirements' and 'Variable Conditions' on the user or target, the changes will only be performed if the check is valid.
- new: Combatants: Battle Settings: 'Use Requirement' settings available for 'Auto Start Battle' settings. Optionally checks 'Status Requirements' and 'Variable Conditions' on the user (enemy) or target (player), the auto battles will only start if the check is valid.
- new: Combatants: Conditional Prefabs: 'Use Spawned Scale' setting available. Optionally uses the scale of the currently spawned prefab when changing prefabs. By default enabled.
- new: Battle Events: Battle Steps: 'Change Last Target' step available. Changes the last targets of a combatant. This can influence various things, e.g. AI target selection.
- new: Formulas: Variable Steps: 'Store Formula Value' step available. Stores the current value of the formula into a float game variable.
- new: Text Input: 'Is Password' setting available for game options and input dialogues. Optionally uses a text input field as password input, masking the user's input with a '*'.
- new: Music: 'Use PCM' settings available for music clip loops. Optionally checks and sets the playback position in PCM samples instead of time.
- new: GUI System: New UI: 'Keep Prefab Height' settings available for text, toggle and slider input prefabs. Optionally keeps the height of the used prefabs instead of adjusting the height to the used font size.
- new: Menu System: Crafting: 'Info Only' setting available in the 'Crafting Box Settings'. Optionally only displays the crafting recipe information and doesn't allow using them.
- new: Crafting Recipes: 'Use Requirements' settings available. Optionally checks 'Status Requirements' and 'Variable Conditions' on the user of the recipe to determine if it can be used.
- new: Event System: Crafting Steps: 'Can Use Recipe' step available. Checks if a combatant can use a selected crafting recipe.
- new: Event System: Camera Steps: 'Change Camera Options' step available. Changes various settings on a camera that can't be changed with the 'Change Field' step.
- new: Event System: Function Steps: 'Set Object Layer' step available. Sets the layer of a game object.
- new: Event System: Function Steps: 'Check Object Layer' step available. Checks the layer of a game object.
- new: Event System: Function Steps: 'Place Object' setting avaialble in the 'Mount Object' step. Placing a game object when mounting it to another object is now optional. By default enabled.
- new: Event System: Status Steps: 'Change Defence Attribute' step available. Changes a defence attribute of a combatant permanently.
- new: Event System: Battle Steps: 'Add Loot' step available. Adds items, weapons, armors or currency to the battle's loot.
- new: Event System: Battle Steps: 'Add Experience Reward' step available. Adds experience to the battle's experience gains.
- new: Event System: Status Steps: 'Revive' step available. Revives a combatant or the combatant's group. The step doesn't change 'Consumable' type status values, i.e. the combatant will die again if the status value causing the death is still the same.
- new: Status Effects: 'Animate Damage' settings available for status conditions. Negative status changes can now optionally play a damage animation on the combatant.
- new: Status Requirements: 'Group Leader' status check available. The combatant must or mustn't be the leader of his group.
- new: Status Requirements: 'Group Size' status check available. The combatant's group size will be compared with a defined value.
- change: GUI System: New UI: The GUI box instance used for a box object in the new UI can now be accessed through the 'GUIBox' property in the 'GUIBoxComponent' attached to it.
- change: GUI Boxes: The 'Inactive Alpha' settings for choices and tabs are no longer available when using the new UI. This is handled by the prefabs used for buttons/tabs, the 'Inactive Alpha' setting wasn't used in the new UI.
- change: Combatant Component Inspector: The inspector display of the combatant component now also displays the defence attributes of the selected combatant game object.
- fix: Combatants: A battle action without targets (e.g. an AoE ability) could cause errors when setting the last target's of a combatant.
- fix: Event System: Camera Steps: Changing the 'Field of View' in a 'Change Camera Position' step is working again.
- fix: Event System: Rotation Steps: The 'Rotate To' step will now correctly rotate into the shorter direction when using fading.
- fix: GUI System: New UI: Opening/selecting the ORK Framework editor while playing wont throw errors any longer.
- fix: HUDs: Combatant: Using the 'Change Combatant' click type and clicking on the current player's HUD removed the player controls but didn't add them again. Changing player now only works if the combatant isn't the current player.
- fix: Changing Player: Changing the player could result in still using the old interaction controller in some cases.


Version 2.2.2:
- new: Combatants: 'Shortcut List Count' setting available. A combatant can now have more than one shortcut list, each list contains of a various amount of slots. Lists can be switched using the event system.
- new: Combatants: 'Use Class Shortcuts' setting available. A combatant can optionally use class based shortcut lists.
- new: Classes: 'Shortcut List Count' and 'Default Shortcut' settings available. Shortcut lists can now optionally be based on classes, changing a class will also change the shortcut lists.
- new: Event System: Shortcut Steps: 'Change Shortcut List' step available. Changes a combatant's active shortcut list.
- new: HUDs: Combatant: 'No Inner Assign' setting available in 'Shortcut' HUD elements. Prevents assigning a shortcut slot from another slot of the same HUD element.
- change: Event System: The shortcut steps can now be found in the new 'Shortcut Steps' list.
- fix: Event System: Dialogue Steps: Restarting an event while an 'Autoclose' dialogue (without using 'Wait) is displayed wont result in errors.
- fix: HUDs: A HUD without any HUD elements (e.g. only using a background image) caused errors.
- fix: GUI System: New UI: Using text typing displayed the whole text for a frame when first displaying a GUI box.
- fix: Status Effects: Using 'End On Abilities' caused a status effect to be removed by the same ability that applied it.
- fix: Status Effects: Using an 'End Action' in combination with 'End On Abilities' could in some cases lead to an error.


Version 2.2.1:
- new: GUI System: New UI: The new UI now also supports text typing.
- new: GUI System: New UI: 'Layer' setting available. Select the layer the UI canvas will be placed at.
- new: Save Games: Support for saving/loading custom save data with ORK Framework save games. Use the function 'ORK.SaveGame.RegisterCustomData' to register a class (implementing 'ISaveData') that saves/loads your custom data.
- new: Event System: Base Steps: 'Add Combatant' step available. Adds a combatant to a game object (only if the game object doesn't already have a combatant).
- new: Event System: Base Steps: 'Use Mouse Position' setting available in the 'Raycast Object' step. Optionally uses the mouse position as target for raycasts when not using input.
- new: Event System: Variable Steps: 'Use Mouse Position' setting available in the 'Raycast to Variable' step. Optionally uses the mouse position as target for raycasts when not using input.
- new: Abilities: 'Hidden' setting available. Optionally hides the ability in 'Ability' and 'Ability Tree' menu screen parts and in battle menus.
- new: Items: 'Hidden' setting available. Optionally hides the item in 'Inventory' menu screen parts and in battle menus.
- new: Combatants: Battle Settings: 'Base Experience Factor' settings available. Defines the base experience factor of a combatant. The experience factor influences how much experience a combatant gains from battle. E.g. factor 1 gains 100 %, factor 2 gains 200 %.
- new: Combatants, Classes, Equipment, Abilities, Status Effects: Bonus Settings: 'Experience Factor Bonus' setting available. Defines a bonus that will be added to a combatant's experience factor.
- new: Status Effects: 'Stackable' setting available. Optionally allows applying a status effect multiple times, either generally (i.e. a user can apply the same effect multiple times) or once per combatant (i.e. a user can apply the effect only once, but a different user can apply it as well).
- new: Status Requirements: The 'Status Effect' check can now optionally check the quantity a status effect is stacked on a combatant. This is available throughout the framework (e.g. in the 'Check Status' event step).
- change: Event System: Base Steps: The 'Block Input Key' and 'Block Control Map' steps will now be executed in events that are stopped (e.g. when a combatant died during using an action). This makes sure the input keys or control maps wont stay blocked when an event is stopped before unblocking them.
- change: Event System: Dialogue Steps: The 'Block HUD' step will now be executed in events that are stopped. This makes sure the HUDs wont stay blocked when an event is stopped before unblocking them.
- change: Event System: Camera Steps: The 'Block Camera Control' step will now be executed in events that are stopped. This makes sure the camera control wont stay blocked when an event is stopped before unblocking it.
- change: Event System: Movement Steps: The 'Block Player Control' and 'Block Move AI' step will now be executed in events that are stopped. This makes sure the player control or move AI wont stay blocked when an event is stopped before unblocking them.
- fix: GUI System: New UI: Using the 'GUI Editor' to change a GUI box after playing the project no longer creates instances of UI parts.
- fix: Battle System: The correct player group leader will be used when the leader was changed using the player change keys.
- fix: Move AI: 'Auto Stop' issue fixed, leading to enemies circling around the player.


Version 2.2.0:
- new: Unity 4.6: ORK Framework now supports/requires Unity 4.6 and the new UI.
- new: Menu Settings: 'GUI System Type' setting available. Select if you want to use the 'Legacy GUI' (old GUI system) or the 'New UI' of Unity 4.6.
- new: Menu Settings: Settings for the 'New UI' GUI system type available.
- new: Menu Settings, GUI Boxes: GUI Skins: New settings available when using the 'New UI' gui system type. The settings replace the GUI skins used in the 'Legacy GUI' system and are used to select prefabs to create the GUI boxes, buttons, etc.
- new: Combatants: 'Auto Start Battles' setting available. Defines if a combatant will automatically start a battle when coming within a defined range to the player. By default enabled.
- new: Event System: Base/Function Steps: The 'Start Battle' step can now also start battles with objects who have a combatant. Previously, only objects with a 'Battle' component attached could be used.
- new: Battle Events: Battle Steps: 'Set Attacked By' step available. Marks that a combatant has been attacked by another combatant. This can influence various other things, e.g. victory gains or faction sympathy changes.
- fix: Status Effects: End Action: The end action marked by a status effect to be called by a combatant will no longer check if it can be used due to turn/time. The check resulted in the action not being marked if the combatant currently couldn't perform an action due to turn/time.


Version 2.1.11:
- new: Main Menu: 'Override Question' settings available for the auto save slot selection menu. Optionally display a question dialogue if an already used auto save slot should be overridden by a new game.
- change: Components: Getting and adding components now uses type functions instead of string functions. This allows Unity 5 compatibility.
- change: Components: The Unity 4 component getters (e.g. rigidbody, collider, etc.) have been replaced with GetComponent calls. This allows Unity 5 compatibility.
- change: Combatants, Classes: The experience of class level up status values will be stored when changing class. The experience of a class will be restored when changing back to it.
- change: Event System: Spawning prefabs now sets the position and rotation upon instantiating. This solves issues with shurikan particles producing a trail when spawned.
- change: GUI Boxes: Clicking on 'Ok' or 'Cancel' button positioned outside of the GUI box will now be recognized as click on the box.
- fix: Event System: Inventory Steps: 'Add To Item Box' and 'Remove From Item Box' steps wont throw errors in the editor.
- fix: Main Menu, Save Points, Menu Screens: The 'Load' buttons are now also available if only auto save games exist.
- fix: Abilities, Items, Event System: Target raycasts and raycast steps are now work correclty on different resolutions.
- fix: Combatants, Classes: Changing classes will now reset the class level up status value to the correct value.
- fix: Battle Gains: Collecting an item while an auto close battle gain dialogue is displayed wont lock the item collection dialogue any longer.
- fix: Item Collectors: Preventing an error when no item is added to the collectors list.


Version 2.1.10:
- new: Status Values: 'Real Value Count' setting available when using 'Count to Value'. Optionally uses the counted display value as real value of the status value.
- new: Battle System: 'Leave Arena Settings' available in all battle system types. The battle can optionally end when the player moves outside a defined range of the battle arena (i.e. the game object with the 'Battle' component).
- new: Battle System, Battle Components: 'Leave Arena Event' available. The battle end event used when the player leaves the battle arena.
- new: Battle Start Events, Battle End Events: 'Block Move AI' and 'Block Actor Move AI' settings available. Optionally blocks the move AI for all game objects or only for actors of the event. Blocking the move AI will only be active while the event is running.
- new: Event System: Base Steps: 'Auto Load Game' step available. Loads the AUTO save game or a temporary retry save game. The event ends after this step.
- new: Event System: Status Steps: 'Check Shortcut' step available. Checks a combatant's shortcut and executes 'Success' or 'Failed' based on the check.
- new: Event System: Battle Steps: 'Check Turn' step available. Checks a combatant's turn number and executes 'Success' or 'Failed' based on the check.
- new: Event System: Dialogue Steps: 'Button Info' and 'Button Title' settings available for 'Choice' type dialogues. Optionally add an info text and title to a choice.
- new: Event System: Dialogue Steps: 'Wait' setting available for 'Message' type 'Show Dialogue' steps. If disabled, the event will continue with the next step while the dialogue is displayed. By default enabled.
- new: Event System: Dialogue Steps: 'Close All Dialogues' step available. Closes all dialogues opened by this event (only from 'Show Dialogue' steps).
- new: Event System: Scene Steps: 'Check Item Box' step available. Checks the number of items in an item box and executes 'Success' or 'Failed' based on the check.
- new: Formulas: Combatant Steps: 'Turn' step available. Uses a combatant's turn number or the combatant's group average turn number to change the formula value.
- new: Formulas: Combatant Steps: 'Check Turn' step available. Checks a combatant's turn number or the combatant's group average turn number and executes 'Success' or 'Failed' based on the check.
- new: Menu Screens: Sub Menus: 'Assign Shortcut' sub menu item available. Shows a menu to assign items, abilities or equipment to a shortcut slot of the menu user.
- new: Menu Screens: '%lvl' text code available for content layouts (for choice buttons). Displays the level of an ability or equipment.
- new: Save Game Menu: 'Auto Save Slots' setting available. Defines the numbers of available auto save slots.
- new: Main Menu: 'Auto Save Slot Menu' settings available. Optionally select the auto save slot when starting a new game. Auto saving will use the selected slot in the running game.
- new: Abilities, Items: Target Raycast: 'Use Mouse Position' settings available for raycast auto targeting. Use this option if you're directly firing your actions from control maps without target selection.
- new: Abilities: 'Quantity' and 'Chance (%)' settings of an active ability's item consume now support formulas, game variables and other value origins.
- new: Ability Trees, Status Development: 'Quantity' and 'Chance (%)' settings of item learn costs now support formulas, game variables and other value origins.
- new: Control Maps: 'Show Tooltip' settings available for 'Action' and 'Shortcut' control keys. Optionally displays a 'Tooltip' type HUD instead of using the action/shortcut.
- new: Editor: 'Help Text Color' setting available in the editor settings. Changes the color of the help text.
- change: Combatants: Using 'Local Variables' in the combatant's object variable settings will now keep the local variables on the combatants and not the objects. This allows to keep the local object variables when the game object is destroyed, e.g. when changing prefab.
- change: Animations: Mecanim animations can now use play and set parameters at the same time.
- change: Event System: Inventory Steps: The item box steps are now also available in the 'Inventory Steps'.
- change: Battle Start Events: The 'Join Battle' step is now also available in battle start events.
- fix: Colors: Fading or blinking colors (e.g. in the 'Fade Object' event step) with time set to 0 resulted in a black color.
- fix: Event System: Battle Steps: The 'Look At Enemies' step works correctly again.
- fix: Event System: Function Steps: The 'Mount Object' step now correctly unmounts objects.
- fix: Item Collectors: 'Box' type item collectors now set the variables after closing the item box.
- fix: GUI Boxes: Buttons now can't be clicked while the GUI box is fading out.
- fix: Damage Dealers: Stopping particle emitting on prefabs is now working correctly.
- fix: Menu Screens: Changing/removing the player using a 'Group' menu part will now correctly change the player if needed.
- fix: Abilities, Items: Target Raycast: The auto targeting from screen position was inversed.


Version 2.1.9a:
- new: GUI Boxes: 'Title Text Alignment' setting available when using 'Set Title Width' in the choice settings. Manages the horizontal alignment of the title of a choice within its bounds.
- new: GUI Boxes: 'Title Line Alignment' setting available in the choice settings. Manages the vertical alignment of labels in a line of the title of a choice.
- new: Combatant Selections: 'Back Button' settings available. Optionally adds a back button to combatant selections.
- fix: Equipment: Changing equipment will now correctly update displayed values.
- fix: Shops: Tooltips are now working correctly in shops.
- fix: Variable Conditions: Checking 'Conditions' type had a display bug in the editor.


Version 2.1.9:
- new: HUDs: Combatant, Turn Order: 'Click Action' settings available for 'Combatant' and 'Turn Order' HUD elements. Clicking on a HUD element can optionally call a menu screen, change the current menu/shop user, change the player or select a target. Also works in menu screens and shops.
- new: HUDs: Combatant, Turn Order: '%c' text code available for 'Status Value', 'Attack Attribute' and 'Defence Attribute' elements. Displays the change between the current and preview value of a status value or attack/defence attribute.
- new: HUDs: 'Expand Bounds' setting available for HUD element background images. The element's display bounds will be increased when the image bounds exceed them.
- new: HUDs: 'Start Toggle State' setting available when using a 'Toggle Key'. Defines if the HUD is toggled on or off at the start of the game. When using 'Only While Key', the display state is inversed, i.e. the HUD will be hidden when the input key is valid. By default enabled (i.e. toggled on).
- new: Menu Screens: Ability, Inventory, Ability Tree, Status Value Upgrade: 'Don't Return' setting available when using 'Close After Use'. The menu screen wont return to a previously opened menu screen when closing after use.
- new: Menu Screens: Ability, Inventory: 'Animate Use' setting available. Defines if using an item/ability in a menu screen will be animated, i.e. using it's battle events. By default enabled.
- new: Menu Screens: Combatant: 'Show Ok Button' and 'Show Cancel Button' settings available. Optionally show the 'Ok'/'Cancel' buttons of the GUI box. The 'Ok' button can change to the next page when using 'Accept Next Page', the 'Cancel' button can close the menu screen.
- new: Battle System: 'Defend First' setting available in all battle system types. The defend command will optionally perform before other actions. Doesn't take already performing actions into account.
- new: Battle System: 'Auto Close' settings available when showing battle gains immediately. Optionally automatically closes the battle gains dialogue after a defined amount of time. Available in all battle systems.
- new: Battle End Events: Battle Steps: 'Auto Close' settings available in the 'Collect Battle Gains' step. Optionally automatically closes the battle gains dialogue after a defined amount of time.
- new: Input Keys: 'Mouse' and 'Touch' input origin settings available. Use mouse button clicks or touch input as input keys (can't be used as axis).
- new: Game Variables: 'Approximately' check type available for float game variable checks. The check is valid if the current value of the game variable is similar to a defined value. Uses the Mathf.Approximately function for the check.
- new: Game Variables: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available for Vector3 distance checks.
- new: Event System: Check Steps: 'Check Value' step available. Checks a value with another defined value, e.g. check if the result of a formula is within a defined range.
- new: Event System: Movement Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Distance' and 'Check Transform' steps.
- new: Event System: Rotation Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Angle' steps.
- new: Event System: Faction Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Faction Sympathy' steps.
- new: Formulas: Check Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Formula Value' steps.
- new: Formulas: Position Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Distance' and 'Check Angle' steps.
- new: Game Settings: Bestiary: 'Use in Battle AI' setting available. Uses bestiary knowledge when a player combatant does status checks on enemy combatants in a battle AI. A status check fails if the informatin is not known to the player.
- new: Battle AI: Status Steps: 'Force Knowledge' setting available for 'Check Status', 'Get Status Value', 'Get Attack Attribute' and 'Get Defence Attribute' steps. Optionally forces player combatants to have full knowledge about an enemy's status.
- new: Battle AI: Position Steps: 'Range Inclusive', 'Range Exclusive' and 'Approximately' check types available in 'Check Distance' and 'Check Angle' steps.
- new: Status Requirements: 'Combatant' requirement available. Status requirements can now check if a combatant is a selected combatant or not.
- new: Editor: 'Copy to Clipboard' button available for help texts. Copies the current help text to the system clipboard.
- change: Text Formats: The minimum value the 'Font Size' can be set to is now 0 instead of 1.
- fix: Menu Screens: Equipment: Changing between equipment with status value bonuses and status requirements will now correctly refresh the equipment list.
- fix: Menu Screens: Ability, Equipment, Inventory: Sub menus can now also be used on inactive choices (e.g. unequipable equipment, not useable items).
- fix: Menu Screens: Ability, Inventory: 'Close After Use' now correctly closes the menu screen when using 'Use Screen Combatant' in the menu screen or item.
- fix: Menu Screens: Selecting a choice via click will now correctly update the description when displaying a combatant choice.
- fix: Menu Screens: 'Description' menu part updates could cause menu screens to not fully close, blocking the game.
- fix: Status Values: Using a combined status value as another value's maximum value could lead to limiting it before the real maximum value has been calculated.
- fix: Status Effects: 'Auto Attack' and 'Attack Allies' will now correctly perform actions.
- fix: Battle System: Using 'Leave on Death' on player combatants could lead to errors upon losing a battle (when no combatant was left in the player group, i.e. no player).


Version 2.1.8:
- new: Abilities: 'Delay Time' settings available for active abilities. Abilities can set a delay time on the user. A combatant can't perform actions (e.g. attack, use an ability or item) during the delay time.
- new: Inventory Settings: 'Default Delay Time' settings available. Items can set a delay time on the user. A combatant can't perform actions (e.g. attack, use an ability or item) during the delay time.
- new: Items: 'Delay Time' settings available. Items can override the default delay time defined in the inventory settings.
- new: HUDs: Combatant, Turn Order: 'Delay Time' element type available. Displays a combatant's delay time as a text or bar. Only displayed while the time is running.
- new: HUDs: Combatant, Turn Order: 'Time Format' setting available for 'Cast Time' and 'Timebar' text time displays.
- new: HUDs: Combatant, Turn Order: 'Reverse Value' setting available for 'Cast Time'. The cast time will be displayed reversed, i.e. the time will count down instead of up.
- new: Status Requirement Templates: The status requirement templates allow you to set up status requirements that can be reused in other status requirements. Status requirement templates can be created in 'Base/Control > Status Requiremenet Templates'.
- new: Status Requirements: 'Requirement Type' setting available. Select if a requirement either checks a single 'Status', other 'Requirements' or a status requirement 'Template'. When checking other requirements, you can create multiple status requirements in a single condition, allowing you to set up checks like '(requirement1 && requirement2) || requirement3'.
- new: Event System: Dialogue Steps: You can now use actor text codes in choices added to a 'Dialogue Step'.
- new: Event System: Dialogue Steps: Choices can now use global, local and object variables in variable conditions.
- new: Event System: Active Group Steps: 'Check Group Size' step available. Checks the size of the active player group.
- new: Event System: Variable Steps: 'Variable to Variable' step available. Stores the value of a game variable into another game variable. You can use this step to transfer variables between variable origins (local, global and object).
- new: Combatants: Battle Animations: 'Join Look At' setting available. Optionally looks at enemy combatants when joining a running battle. By default disabled.
- new: Game Settings, Interactions: Setting 'Max. Click Distance' to -1 will allow starting 'Interact' type interactions without distance limitations.
- new: Status Development, Ability Trees: 'Experience' type learn costs can now use a defined value, formula, game variable, etc. for the required/consumed experience.
- fix: Status Values: 'Experience' type status values that level ub the base/class level will now correctly receive experience exceeding the current maximum value.
- fix: Status Requirements: Passive abilities can now also be checked without enabling 'Learned'.
- fix: Abilities: Passive abilities wont be added to the list multiple times.
- fix: Abilities: Passive abilities will now correctly add their status effects outside of battles.
- fix: Event System: The 'Found Objects' list was updated when using a child object, resulting in the child object being in the list instead of the original object.
- fix: GUI Boxes: Cut off text issues are solved.
- fix: Global Events: Wait times are now working correctly in 'Scene' type global events.
- fix: Equipment Viewers: Using the 'Add Combatant' component with 'Equipment Viewers' could still lead to not displaying equipment.
- fix: Music: If no music is played when storing music, now also no music will play when playing the stored music (also applies to shop/menu music).


Version 2.1.7:
- new: Main Menu: 'Continue Button' settings available. Loads the last saved game. Requires the save games to be saved with this version to find the latest save game.
- new: Main Menu: 'Hide Inactive' setting available for the load button. The load button wont be displayed if no save games are available.
- new: Status Requirements: 'Weapon' and 'Armor' requirements available. Status requirements can now check if a selected weapon or armor is equipped or not equipped on a combatant. Available throughout the framework.
- new: Text Format: 'Font' setting available. You can now optionally set the font in the text format settings throughout the framework.
- new: Status Values: 'Init to Level' setting available for 'Experience' type status values. The experience status value will be initialized to the value according to the combatant's level and status development. By default enabled.
- change: Status Values: 'Experience Type' setting replaces 'Level Up' and 'Class Level Up' settings for 'Experience' type status values.
- change: Status Values: 'Experience' type status values that don't level up (i.e. 'Experience Type' set to 'None') will now use the status value's minimum value as minimum value. Level up type values will still use the previous level's value as minimum value.
- fix: Battle Settings: Auto Join: Joining a running battle was possible when the battle already ended, leading to the joining combatants being removed.
- fix: Equipment Viewer: Using the 'Add Combatant' component with 'Equipment Viewers' could lead to not displaying equipment if the combatant was initialized after the equipment viewer.
- fix: Status Values: Having a 'Consumable' type status value above it's maximum status value (i.e. with a lower index) could lead to initialization to a wrong value.
- fix: Active Time Battles: Using 'Pause on Menu' with AI controlled player group members wont stop the battle any longer after an AI action.
- fix: Battle System: 'Death' actions and loot collection now works again when not using 'Death Immediately'.
- fix: Editor: The 'Console Settings' sub-section is working again.


Version 2.1.6:
- new: Variable Condition Templates: The variable condition templates allow you to set up variable conditions that can be reused in other variable conditions. Variable condition templates can be created in 'Base/Control > Variable Condition Templates'.
- new: Variable Conditions: 'Condition Type' setting available. Select if a condition either checks a single 'Variable', other 'Conditions' or a variable condition 'Template'. When checking other conditions, you can create multiple variable conditions in a single condition, allowing you to set up checks like '(condition1 && condition 2) || condition3'.
- new: Variable Conditions: New float checks available. 'Range Inclusive' checks if the current value of a float game variable is between two defined values, including the values. 'Range Exclusive' checks if the value is between two defined values, excluding the values.
- new: HUDs: Display Conditions: 'Only While Key' setting available when using a toggle key. The HUD will only be displayed while the selected toggle key input is valid, i.e. use a 'Hold' input key and the HUD will only be displayed while the key is pressed.
- new: HUDs: Combatant, Turn Order: 'Equipment' HUD element type available for 'Combatant' and 'Turn Order' type HUDs. Displays a combatant's equipment parts and equipped weapons/armors - either listing all parts or displaying a selected part.
- new: HUDs: Combatant, Turn Order: 'Display Requirements' settings available for 'Combatant' and 'Turn Order' type HUD elements. Optionally limit displaying a HUD element to status requirements and variable conditions.
- new: Game Settings: Bestiary: 'Equipment' settings available. The equipment of an enemy combatant can now also be learned for a bestiary entry.
- new: Status Values: 'Normal' type status values can now optionally use other 'Normal' type status values to define their minimum and maximum values. The min/max status value's current value will be used - this allows creating flexible min/max values, e.g. for upgrading the MaxHP with special equipment.
- new: Menu Screens: Status Value Upgrade: 'Show No Upgrade Req.' and 'No Upgrade Req. Content Layout' settings available. Used to display status values with upgrades that aren't available due to requirements (e.g. for maxed out ugprades).
- new: Event System: Function Steps: 'Close Menu Screen' step available. Closes a selected or all opened menu screens.
- new: Event System: Function Steps: 'Start Item Collector' step available. Starts an item collector attached to an event object (e.g. actor). The event continues after the item collection has been finished. You can use this to e.g. do additional animations when collecting items or opening item boxes.
- new: Event System: Spawn Steps: 'Spawn Player' and 'Destroy Player' steps can now also spawn/destroy a different member of the player group.
- new: Event System: Variable Steps: 'Function to Variable' step available. Stores the return value of a function into a game variable. Supports string, bool, int/float and Vector3 return values.
- new: Combatants: Movement Settings: 'Use Position Change' setting available. If enabled, the change of the combatant's position every update will be used to determine the real speed (used e.g. in auto move animations). Otherwise components will be check in that order: CharacterController > Rigidbody > Rigidbody2D > NavMeshAgent > Position Change.
- new: Combatants: 'Set Object Name' setting available. Optionally sets the name of the game object spawned for the combatant to the combatant's name.
- new: Battle Notifications: The notifications (e.g. status value changes) can now also set other properties of renderer materials like the 'Fade Object' event step.
- new: Combatant Spawners: 'Set Scale' settings available. You can now optionally set the scale of spawned combatants.
- new: Weapons, Armors: 'Viewer Name' setting available. Optionally sets the name of the game object spawned by the equipment viewer. You can use this to unify the name of displayed equipment and access it easier through events (e.g. child objects).
- new: Game States: The 'Menu Screen' game state can now optionally be limited to defined menu screens. The 'Yes' option will be valid if one of the added menu screens is opened - if no screen is added, any opened screen is valid.
- new: Equipment Viewers: 'Combatant in Battle' setting available when setting the 'In Battle' game state to 'Yes' or 'Ignore'. If enabled, the equipment will only be displayed when the combatant itself is in battle, not the game.
- new: Combatants: Battle Animations: 'Join Battle Animation' available. Uses battle events to animate a combatant joining the battle through 'Auto Join' in a running battle.
- new: Battle Settings, Classes, Combatants: New battle menu settings available. You can now optionally define a battle menu for each battle system type.
- new: Battle Settings: Auto Join: 'Join Running Battle' setting available. Combatants can optionally also join running battles when coming into auto join range.
- new: Battle System: Move AI: 'Block In Battle' setting available in all battle system type settings. Optionally blocks the move AI of combatants that are participating in battle when allowing move AI during battle. This allows not fighting combatants to still move while those who are fighting don't move.
- new: Text Codes: The new 'Float with Format' text code allows defining a text format when displaying float variables. E.g. 00.0 will display at least two digits before the decimal point and one after the decimal point (1.5 would be come 01.5).
- new: Equipment Viewers: 'Preview' inspector settings available. You can now preview a selected weapon or armor on an equipment viewer. You need to disable the preview again when you're done to get rid of the created preview object.
- change: Event System: Steps using combatants can now also used unspawned members of the combatant group as long as no game object is needed in the step.
- change: Event System: Fade Steps: The 'Blink Object' and 'Fade Object' steps now set the color property of 'Sprite Renderers' instead of the materials color property if a 'Sprite Renderer' is used (fading Sprite objects).
- change: Editor: The ORK Framework editor no longer closes automatically when entering 'Play' mode in Unity.
- fix: Save Games: Loading a save game without having 'Spawn Group' enabled doesn't spawn other group members any longer.
- fix: Status Effects: The turns of combatants with 'Stop Move' effects will now increase (and reduce turn bound effects).


Version 2.1.5:
- new: Bestiary: The bestiary is a collection of status information on enemy combatants. You can define when to learn which status information (e.g. status values on encountering an enemy, attack attributes on attacking with the individual attributes). The 'Bestiary Settings' are defined in 'Game > Game Settings'.
- new: Menu Screens: 'Bestiary (Area)' menu part available. Displays information on bestiary entries using HUD elements. The bestiary entries are separated by areas and area types in which they've been encountered.
- new: Event System: Bestiary Steps: 'Add To Bestiary' step available. Adds an entry to the bestiary - uses either an event object's combatant or a defined combatant.
- new: Event System: Bestiary Steps: 'Remove From Bestiary' step available. Removes an entry from the bestiary - uses either an event object's combatant or a defined combatant.
- new: Event System: Bestiary Steps: 'Check Bestiary' step available. Checks if a combatant's entry is in the bestiary (complete or partial entry) - uses either an event object's combatant or a defined combatant.
- new: Event System: Bestiary Steps: 'Bestiary Dialogue' step available. Displays a dialogue with information on a combatant's bestiary entry using HUD elements. Uses either an event object's combatant or a defined combatant, if no combatant or bestiary entry was found, the dialogue is skipped.
- new: Combatants: 'Not Scanable' setting available. The combatant wont add information to the bestiary, only an empty entry without status information will be made.
- new: Combatants: 'No Bestiary Entry' setting available. The combatant wont add an entry to the bestiary at all.
- new: Abilities, Items: 'Scan Target' setting available. The target will be added with a complete entry to the bestiary. Only possible if the user is part of the player group and target is an enemy.
- new: Save Game Menu: 'Save Bestiary' setting available. If enabled, the learned enemy combatant information will be saved. By default enabled.
- new: Requirements: 'Has Bestiary Entry' setting available. At least one bestiary entry must be available for this requirement to be valid.
- new: Status Development, Ability Trees: 'Cost Type' setting available for learn costs. You can now also use items, weapons, armors and currency as costs for learning abilities or increasing status values.
- new: Menu Settings: Use Cost Display: 'Item Cost', 'Weapon Cost', 'Armor Cost' and 'Currency Cost' settings available. Also, all use cost settings can now use %i to display icons.
- new: Images: All image settings can now also use alpha masks when using colors instead of images.
- new: Value Bars: 'Crop Image' setting available for all Value bars (e.g. for status values) with scale mode 'Stretch to Fill' or using alpha masks. If enabled, the image will use the whole bar's bounds for scaling, but crop the parts of the image that exceed the filling (e.g. 50 % filling will only display half of the image).
- new: Battle AIs: 'Check Target Count' step available. Checks the number of found targets and executes 'Success' or 'Failed' next step.
- new: Add Combatant Component: 'Battle Type' setting available for the 'Add Combatant' component. Defines the battle type used when a battle is started when entering the combatant's battle type.
- new: Inspectors: The 'Combatant' component inspector now also displays a combatant's name, level, class and class level.
- new: Menu Screens: 'Accept Next Page' setting available for 'Combatant' and 'Information' menu parts. The 'Accept' input key (and 'Ok' button) can optionally be used to change to the next page.
- new: Editor: 'Create HUD' button available for combatant page, information page and combatant choice layouts. Creates a new HUD from the defined HUD elements of the page/layout and uses the HUD instead.
- change: Item Collectors: 'Destroy Collected' setting is now 'Destroy Collected Object' and also available for item collectors not using scene ID. Warning: This will reset the setting on all item collectors to enabled.
- fix: GUI Editor: The WYSIWYG GUI editor is again working correctly with all GUI settings.
- fix: Event System: Status Steps: Using 'Level Up' to level up the base or class level now also works when no experience status value is set to level up base/class levels.
- fix: Player Group: Unspawned members of the player group didn't get updated properly, leading to equipment changes not adding bonuses, etc.


Version 2.1.4:
- new: Plugins: The new plugin system allows adding your own settings and functions to ORK Framework without changin ORK's code. The data will be saved with the rest of ORK's settings. Plugins can be added in 'Editor > Plugins'. The full version includes a plugin template project.
- new: Event System: Function Steps: 'Call Plugin' step available. Calls a plugin's 'Call' function with an information string.
- new: Main Menu: 'Call Plugin' settings available for 'Custom Choice' menu items. Custom choices can now call a plugin instead of a game object's component.
- new: GUI Layers: 'Use Full Screen' setting available. The layer ignores the GUI settings in the 'Game Settings' and uses 'Stretch to Fill' for all GUI boxes on this layer, using the full screen for placement.
- new: Game Settings: 'GUI Padding' setting available. Adds a padding at the borders of the screen when placing the GUI.
- new: Game Settings: 'GUI Anchor' setting available for all GUI scale modes except 'Stretch to Fill'. Select the anchor for the GUI when placing/scaling the GUI (e.g. Upper Left, Middle Center, ...).
- new: Game Settings: 'Raycast Type' setting available. Select the type of raycasts that are used throughout the framework, you can either use 'Only 3D', 'Only 2D' or mixed 'First 3D' and 'First 2D'. 3D raycasts will interact with 3D colliders, 2D raycasts with 2D objects. By default 'Only 3D'.
- new: Abilities, Items: 'Auto Target' setting available in 'Raycast Settings'. Used for AI/auto target raycasts - if enabled, a nearby combatant will automatically be targeted by the raycast, otherwise the screen center will be used. By default enabled.
- new: Battle Spots: 'Set Rotation' and 'Set Scale' settings available for the individual battle spots. You can now set the rotation and scale of the default battle spots.
- new: GUI Boxes: 'Select Unfocused' setting available for choices. Optionally allows selecting a choice on an unfocused GUI box.
- new: Animations: Mecanim: 'Trigger' parameter type available for Mecanim animations.
- new: Animations: Mecanim: 'Duration' setting available for Mecanim animations. Used in game events to set the wait time for animation steps.
- new: Event System: All advanced int, float and Vector3 selection fields now support local, global and object game variable selections.
- new: Event System: Base Steps: 'Raycast Object' step available. Adds/removes a game object that was hit by a raycast to the 'Found Objects' list.
- new: Event System: Variable Steps: 'Raycast to Variable' step available. Changes a Vector3 game variable using the hit point of a raycast.
- new: Event System: Spawn Steps: The 'Spawn Prefab' step can now also spawn prefabs at defind positions (e.g. from game variables) instead of using an event object.
- new: Shops: 'Block Move AI' and 'Block Owner Move AI' settings available. Blocks either the move AI of all combatants or only the move AI of the shop's game object while the shop is opened.
- new: Shop Interactions: 'Turn Player to Event' and 'Turn Event to Player' settings available. Turns the event object and the player to one another upon opening the shop.
- new: Move AIs: 'Hunting Range' settings available. A combatant can optionally hunt only within a defined range of it's start position (i.e. spawn position). When hunting outside of the defined range, the combatant will stop hunting and return to the start position.
- new: Logs: 'Portrait Settings' available. Logs can display portraits in menu screens.
- new: Log Texts: 'Portrait Settings' available. Log texts can override their log's portrait.
- new: Menu Screens: 'Show Portrait' settings available for 'Log' menu parts. The log choice and info display can show a log's portrait.
- new: Input Keys: New 'Input Handling' type 'Any' available. Receives input at down, hold and up.
- new: Save Game Menu: The 'Save Slots' setting can now also be set to 0. Having 0 save slots only allows using AUTO save games and retry.
- new: Item Collectors: 'Destroy Collected' setting available for 'Single' and 'Random' item collectors. If enabled, the game object will be destroyed when an item has been collected, otherwise only the item collector component will be removed. By default enabled.
- new: Item Collectors: 'Show Dialogue' setting available for 'Single' and 'Random' item collectors. If enabled, the item collection dialogue will be displayed, otherwise the item will be collected immediately. By default enabled.
- new: Item Collectors: 'Show Console' setting available. If enabled, the console output for adding items to the inventory will be dispalyed. By default enabled.
- change: Item Collectors: The 'Show Notification' setting will now handle showing the item collection notification (inventory notifications) instead of showing the item collection dialogue.
- change: Event System: Spawn Steps: The 'Destroy Player' step is now also available in 'Battle Start' and 'Battle End' events.
- change: Animations: 'Auto Move Speed Parameters' for Mecanim animations can now also be used without using the combatant's 'Automatic Move Animation'.
- fix: Damage Dealers, Damage Zones: The damage dealer/zone components no longer require a 'Rigidbody' component, i.e. you can now also use a 'Rigidbody2D' component instead.
- fix: Interactions: 'In Trigger' and 'While Colliding' now work correctly without the other one enabled.
- fix: Game Time: The game time is now set correctly when starting a game without going through the main menu.
- fix: Animations: 'Mecanim State Checks' are now used correctly.
- fix: Screen Fader: Fading the screen will now fit the screen size in each GUI scale mode.
- fix: Menu Screens: Quantity selections called by menu screens with 'Pause Game' enabled will now work properly.


Version 2.1.3:
- new: Interactions: 'Trigger Stay' start types available. Starts an interaction (e.g. event, item collector) while the player (or another object) is within the object's trigger.
- new: Interactions: 'Collision Enter' start types available. Starts an interaction (e.g. event, item collector) when the player (or another object) starts colliding with the object. Requires both objects to have a collider and at least one object to have a rigidbody.
- new: Interactions: 'Collision Exit' start types available. Starts an interaction (e.g. event, item collector) when the player (or another object) stops colliding with the object. Requires both objects to have a collider and at least one object to have a rigidbody.
- new: Interactions: 'Collision Stay' start types available. Starts an interaction (e.g. event, item collector) while the player (or another object) is colliding with the object. Requires both objects to have a collider and at least one object to have a rigidbody.
- new: Battle Menus: 'Change Member' menu item type available. Allows changing a combatant against a member of the non-battle group.
- new: Combatants: Battle Animations: 'Retreat Animation' available. Uses battle events to animate a combatant's retreat from battle when using the 'Change Member' command. Needs a 'Calculate' step to exchange members.
- new: Combatants: Battle Animations: 'Enter Battle Animation' available. Uses battle events to animate a combatant joining the battle when using the 'Change Member' command.
- new: Control Maps: 'Change Member' action available. Exchanges the combatant with a defined non-battle member (defined by index).
- new: Status Effects: 'Change Member' end action type available. Exchanges the combatant with a defined non-battle member (defined by index) after the status effect ends.
- new: Battle AI: Action Steps: 'Change Member' step available. Exchanges the combatant with a defind non-battle member (defind by index).
- new: Battle AI: Status Steps: 'Get Status Value' step available. The combatant with the highest or lowest value of a selected status value will be added to the target list.
- new: Battle AI: Status Steps: 'Get Attack Attribute' step available. The combatant with the highest or lowest value of a selected attack attribute will be added to the target list.
- new: Battle AI: Status Steps: 'Get Defence Attribute' step available. The combatant with the highest or lowest value of a selected defence attribute will be added to the target list.
- new: Loot: 'Variable Condition' settings available in loot tables. If a loot table is available can depend on variable conditions (either global or object variables on the combatatant or spawner).
- new: Loot: 'Set After Drop' settings available in loot tables. Loot tables can change game variables (either global or object variables on the combatatant or spawner) after being used/dropped by a combatant.
- new: Combatant Spawners: 'Move AI' settings available. A combatant spawner can block or override the move AI of spawned combatants.
- new: Event System: Status Steps: 'Check Combatant' step available. Checks if an object (e.g. actor) is a selected combatant.
- new: Event System: Active Group Steps: The 'Check Player' step can now check objects (e.g. actors) if they are the player.
- new: Inspectors: The ORK Framework object (created when playing) now shows all global game variables in the inspector.
- new: Inspectors: The 'Object Variables' component now shows all game variables of the object in the inspector.
- new: Item Collectors: 'Show Notification' setting available for 'Single' and 'Random' item collectors. The item collection notification will be skipped when disabled.
- new: Shop Layouts: 'Sell Without Items' setting available. If disabled, 'Sell' button will be disabled when no items are available to be sold. By default disabled.
- new: Shop Layouts: 'Auto Close Sell' setting available. If enabled, the sell mode will automatically be closed when the last item has been sold. By default enabled.
- new: Inventory Settings: Drop Item Settings: 'Collector Star Type' setting available. Select the start type of the item collector used for dropped items. By default set to 'Interact'.
- new: HUDs: Combatant HUDs: 'Start Index Offset' setting available for 'Group' mode combatant HUDs. Starts displaying the combatant list from the defind offset, i.e. combatants before that index will be skipped.
- new: HUDs: Combatant HUDs: 'Limit List Length' settings available for 'Group' mode combatant HUDs. Limit the number of displayed combatants.
- new: Animations: Mecanim: 'Set Layer Weight' settings available for mecanim animations. Optionally sets the current weight of the animation's layer before playing it.
- new: Menu Screens: 'Close Screens (Opening)' settings available for menu screens not using 'Single Screen' mode. Automatically closes selected menu screens when opening the (non-single) menu screen.
- new: Menu Screens: 'Close Screens (Closing)' settings available for menu screens not using 'Single Screen' mode. Automatically closes selected menu screens when closing the (non-single) menu screen.
- change: Combatant Spawners: The spawner will now set its game variables each time a combatant spawned by the spawner is killed.
- fix: Menu Screens: The drag info will now be properly displayed in menu screens that pause the game.
- fix: Camera Events: Camera events wont throw errors and block control when changing scene while a camera event is active.
- fix: Event System: Movement Steps: The 'Transform to Variable' step is now correctly setting the Vector3 game variable.
- fix: Combatant Groups: The additional battle gains are now also collected when using loot tables.
- fix: Shops: 'Accept' input key doesn't throw errors when shop is open in sell mode without items to sell.
- fix: HUDs: Control HUDs: 'Control' type HUDs now correctly support inputs with hold time.


Version 2.1.2:
- new: Battle Settings: 'Auto Join' settings available. Combatants within range of a starting battle can automatically join the battle. This is only available in arena battles (i.e. using the 'Battle' component), not in real time area battles.
- new: Battles: Battle components can override the default 'Auto Join' settings from the 'Battle Settings'.
- new: Status Effects: 'Keep Overflow' setting available for status conditions. Changes exceeding the possible changes for status values will be remembered and added to the next change. E.g. 5.25 can only do a change of 5, 0.25 will be remembered and added to the next change.
- new: Status Values: 'Ignore 0 Damage' setting available for damage and critical damage notifications. Optionally ignores a damage of 0 (i.e. no damage) and doesn't perform the notification text and HUD flash.
- new: Abilities, Items: Status Changes: 'Ignore Barrier' setting available in user/target changes. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Status Effects: Status Conditions: 'Ignore Barrier' setting available. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Combatants: Status Value Time Changes: 'Ignore Barrier' setting available. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Battle Settings: Player/Enemy Advantage: 'Ignore Barrier' setting available. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Battle System: Bonus Settings: 'Ignore Barrier' setting available. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Event System: Status Steps: 'Ignore Barrier' setting available in the 'Change Status Value' step. Optionally ignores barrier values of 'Consumable' type status values and targets the status value directly.
- new: Event System: Movement Steps: 'Change Gravity' step available. Change Physics.gravity or Physics2D.gravity - influences all game objects with a 'Rigidbody' or 'Rigidbody2D' component.
- new: Battle Menus: 'Audio Settings' available. A battle menu can now play an audio clip when being opened and closed.
- new: Abilities, Items: 'Target Requirements' settings available. A target can optionally depend on status requirements and variable conditions. If the requirements aren't met, the combatant can't be targeted.
- change: Battles: Battles can't start while changing scenes.
- change: Save Games: Status effects of player combatants are now saved.
- change: Dialogues, Menus: Accepting a choice will now also reset all ORK input keys instead of only the Unity input axes. This fixes problems when using the accept key also to call the menus.
- fix: Menu Screens: Displaying the back or unequip button first can cause errors when not displaying unequippable equipment.
- fix: Combatants: Level up now allows to gain more than one level at once.
- fix: Battle Settings: The enemy counter type 'Letter' now correctly displays letters exceeding A-Z as AA-AZ, BA-BZ, etc.
- fix: Event System: Image Steps: Removing lower ID images before higher ID images resulted in errors.
- fix: HUDs: Using icons for status value bars without empty icons displayed the already consumed icons at the position of the last icon.
- fix: Battles, Combatants: Enabling 'Keep Prefab' in the combatant's settings could prevent a battle from ending when all enemies have been killed.
- fix: Real Time Battle Areas: Implemented a workaround for a Unity bug where the player quickly leaves and enters the area's trigger, although he is still inside it.


Version 2.1.1:
- new: Unity 4.5: ORK Framework now supports/requires Unity 4.5.
- new: Game Controls: Collision Camera: 'Collision Camera' settings available in the game control settings. The new 'Collision Camera' component uses racasts to find objects between player and camera and places the camera accordingly. Can be used with all built-in and custom camera controls, and is also active during events (i.e. while camera changes).
- new: Float Values: Advanced float settings throughout the framework (e.g. changing game variables) now allow using the current time of day (i.e. time since midnight in seconds) and date and time (i.e. time since 1-1-1970 in seconds). You can use this to use the real time or check for days since something was done.
- new: Status Values: 'Barrier' settings available for 'Consumable' type status values. You can use other 'Consumable' type status values as barriers, i.e. they will consume damage instead (as long as they haven't reached their minimum value). They can either fully consume a damage, or only a defined percent range (0-100 %).
- new: Status Values: 'Death On' setting replaces 'Death on Minimum' for 'Consumable' type status values. You can now select 'None' (i.e. doesn't kill the combatant), 'On Minimum' (combatant dies when value reaches its minimum) and 'On Maximum' (combatant dies when value reaches its maximum).
- new: Items: 'Equipment Part Changes' settings available. Items can add/remove equipment parts to/from a combatant. This can be used to either add additional equipment parts or to block/remove equipment parts from the combatant/class settings.
- new: Weapons, Armors: 'Equipment Part Changes' settings available. Weapons and armors can add additional equipment parts and block other equipment parts while being equipped. This can be done per equipment level.
- new: Abilities: 'Equipment Part Changes' settings available in passive abilities (i.e. useable in 'None'). Passive abilities can add additional equipment parts and block other equipment parts. This can be done per ability level.
- new: Status Effects: 'Equipment Part Changes' settings available. Status effects can add additional equipment parts and block other equipment parts.
- new: Classes, Combatants: The weapon/armor settings are now split into available and unavailable equipments (due to equipment parts). Unavailable equipment was previously not displayed and couldn't be enabled. Also, automatic unselection of weapons/armors due to equipment part changes is now disabled.
- new: Camera Positions: 'Rotation Is Offset' setting available. Uses the defined rotation of the camera as an offset to the target's rotation.
- new: Quests: Quests can now learn log texts to the player when being added to the player's quest list, the quest finishes or fails.
- new: Quest Tasks: Quest tasks can now learn log texts to the player when being activated or the task is finished or failed.
- new: Quests, Quest Tasks: Experience rewards can now optionally be given to the whole group (or only battle group) and split between group members.
- new: Event System: Spawn Steps: 'Destroy Object' step available. Destroys a game object.
- new: Event System: Equipment Steps: 'Check Part Available' step available. Checks if an equipment part is available (i.e. can be equipped, ignoring locked parts).
- new: Event System: Equipment Steps: 'Change Equipment Part' step available. Adds/removes equipment parts to/from a combatant. Removing only allows removing previously added parts. Can be used to add additional equipment parts to combatants.
- new: Event System: Equipment Steps: 'Change Blocked Part' step available. Adds/removes a blocked equipment part to/from a combatant. A blocked equipment part isn't available for equipping. Can be used to remove equipment parts from combatant/class settings.
- new: Event System: Crafting Steps: 'Learn Recipe' and 'Forget Recipe' steps can now optionally learn/forget all crafting recipes of a selected crafting type.
- new: Event System: Check Steps: 'Chance Fork' step available. Define multiple value ranges, the next step of the first range that contains the random chance (minimum <= chance <= maximum) will be executed.
- new: Event System: Camera Steps: 'Collision Camera' step available. Enable/disable the collision camera - requires a 'Collision Camera' component attached to the camera.
- new: Event System: Movement Steps: 'Stop Movement' step available. Stops movement from 'Change Position', 'Move Into Direction' and 'Curve Move' steps.
- new: Game Events: 'Starting Object' actor type available. Uses the game object that started the event as actor. In most cases this will be the player, but you can use this to access other objects that started an event.
- new: Battle AI: Check Steps: 'Chance Fork' step available. Define multiple value ranges, the next step of the first range that contains the random chance (minimum <= chance <= maximum) will be executed.
- new: Battle AI: Check Steps: 'Check Game Variable' step available. Checks for game variable conditions - if the conditions are valid, the 'Success' step will be extecuted, otherwise 'Failed'.
- new: Battle AI: Check Steps: 'Game Variable Fork' step available. Checks a single game variable for multiple conditions and executes the first valid condition's next step.
- new: Formulas: Check Steps: 'Check Chance' step available. Which step will be executed next is decided by chance.
- new: Formulas: Check Steps: 'Chance Fork' step available. Define multiple value ranges, the next step of the first range that contains the random chance (minimum <= chance <= maximum) will be executed.
- new: Menu Screens: 'Alive User' setting available. When opening the menu screen and the current user is dead, the first alive member of the group will be used as user. Since dead combatants can't use items, this can be used to automatically switch to a different user when using items in the inventory menu.
- change: Items, Abilities: Status value and status effect change settings can now be copied and moved.
- change: Editor: The drag bar positions are now saved each time when the editor is closed. Previously, they have only been saved when the data has been saved. The remembered sections will be reset the first time you open the editor after this update.
- change: Game Events: The blocking event state will be removed during battles started by the the 'Start Battle' step. The battle controls are now fully useable during those battles.
- change: Scene Changers: When using a scene changer during battles, the battle will end.
- fix: Input Keys: Releasing an input key using 'Hold Time' will now correctly reset the hold timer.
- fix: Combatants, Status Effects: Auto effects will now be checked after initializing the start values of consumable status values.
- fix: Menu Screens: Hiding not equipable equipment (i.e. disabling 'All Weapons/Armors') caused a equipping wrong equipment.
- fix: Combatants: Conditional prefabs now correctly check for the combatant's death.
- fix: Battle System: Active Time Battles: The 'Start Calculation' formula is now correctly used at the start of the battle.
- fix: Battle System: The death event of the last player combatant didn't play when not using 'End Immediately'.
- fix: Game Over: Dead combatants played the idle animation while fading to the game over scene.
- fix: Item Collectors: Not using quantity limits could lead to items not being collected.


Version 2.1.0:
- new: Quest System: The new quest system consists of 'Quest Types', 'Quests' and 'Quest Tasks'. They are created in the 'Game' section of the ORK Framework editor.
- new: Quest Types: Quest types are used to separate quests into different types. The quest types can be used in menus and HUDs to filter/limit displaying quests.
- new: Quests: Quests can give rewards (experience, items, equipment and money) upon successful completion. A quest consists of multiple quest tasks.
- new: Quest Tasks: Quest tasks are the actual things a player needs to do in a quest. You can define requirements for activating, finishing or failing a task. The task's progress can be handled automatically.
- new: Menu Screens: 'Quest' menu part available. Displays the quests of the player and can be separated by quest types. Quests can optionally be set active/inactive.
- new: Interactions: Quest/task status conditions available in all interactions (e.g. Event Interaction, Item Collector).
- new: Requirements: 'Knows Logs', 'Has Quests', 'Has Not Ended Quests' and 'Has Ended Quests' settings available. Requires the player to knows at least one log, quest, active/inactive quest or finished/failed quest.
- new: Game Variables: Advanced Vector3 operations available. Setting a Vector3 game variable can now use the following operators: Add, Sub, Set, Cross, Min, Max, Scale, Project and Reflect. This is available throughout the entire framework.
- new: Inventory, Currencies, Items, Weapons, Armors: 'Inventory Notifications' settings available. Adding/removing items, weapons, armors and currency to/from the player's inventory can optionally display notifications. Also, if something can't be added due to inventory limitations can display a notification. Currencies, items, weapons and armors can override the default notifications.
- new: Inventory, Crafting Recipes: 'Crafting Notifications' settings available. Learning/forgetting a crafting recipe and using it (successfully/failed) can optionally display notifications. Crafting recipes can override the default notifications.
- new: Combatants: Auto Attacks: 'Target Type' setting available. Select the possible targets of auto attacks, e.g. only group/individual targets or all combatants.
- new: Combatants: 'Keep Prefab' settings available in the 'Death Settings'. The combatant's prefab wont be destroyed when the combatant dies (only for non-members of the player group).
- new: Text Codes: New text codes available for quest, quest task and quest type information.
- new: Event System: 'Quest Steps' available. There are various new steps available to manage/check the status of a quest and quest tasks.
- new: Event System: Dialogue Steps: 'Quest Choice' step available. Displays a dialogue or choice dialogue with quest information of a selected quest.
- new: Event System: Dialogue Steps: The message of 'Show Dialogue', 'Teleport Choice' and 'Value Input Dialogue' steps can optionally also be printed to the console.
- new: Event System: Dialogue Steps: The cancel choice in 'Teleport Choice' steps can optionally be the first choice in the list.
- new: Event System: Status Steps: 'Initialize to Level' step available. Initialize a combatant/group to a defind level and class level. All previous progress (e.g. learned abilities, status values) will be lost, all equipment will be unequipped.
- new: Event System: Base Steps: 'Wait For Input Fork' step available. Waits for an input key (out of multiple keys) to be pressed, either for a set amount of time, or until the key has been pressed. The next step of the input key that's pressed first will be executed.
- new: Event System: Statistic Steps: 'Clear Statistic' can now optionally reset a selected statistic value instead of all values.
- new: Event System: Statistic Steps: 'Check Statistic' step available. Checks a selected statistic value against a defined value.
- new: Event System: Statistic Steps: 'Statistic To Variable' step available. Stores a selected statistic value into a float game variable.
- new: Event System: Movement Steps: 'Transform To Variable' step available. Stores a transform's position, rotation or scale into a Vector3 game variable.
- new: Event System: Movement Steps: 'Block Move AI' step can now optionally block the move AI of a selected object instead of blocking it completely (i.e. for all objects).
- new: Battle Events: Battle Steps: 'End Phase' step available. The phase will end after the action finishes - combatants who didn't chose an action yet will not be able to do so. Only used in 'Phase' battles.
- new: Status Values: 'Start Value' settings available for 'Consumable' type status values. Define the start value of 'Consumable' status values either in percent of their maximum status value or an absolute value. By default 100 % of their maximum status value.
- new: Status Values: 'No Regeneration' setting available for 'Consumable' type status values. Optionally excludes a status value from being fully recovered upon regeneration (e.g. on level up or by the 'Regenerate' event step).
- new: Menu Settings, GUI Boxes: 'Show Unfocused' setting available for choice icons. The choice selection icon can optionally be displayed on a not focused GUI box.
- new: Battle AI: 'End Phase' setting available in all action steps. The phase will end after the action finishes - combatants who didn't chose an action yet will not be able to do so. Only used in 'Phase' battles.
- new: Game Settings: Area Notifications: 'Queue Area Notifications' setting available. Area notifications can optionally be displayed in sequence instead of replacing the current notification with a new one.
- new: Areas, Game Settings: Area Notification: 'Play Sound' settings available. An area notification can play an audio clip (even when not displaying the notification box).
- new: Areas, Game Settings: Area Notification: 'Show Portrait' setting available. Showing an area's portrait in the area notification is now optional. By default enabled.
- new: Battle Texts: 'Queue Infos' setting available. Battle infos can optionally be displayed in sequence instead of replacing the current info with a new one.
- new: HUDs: 'Quest' type HUD available. Displays a list of quests and their tasks. The displayed quests can be filtered by quest type and status.
- new: HUDs: 'Hide Empty HUD' setting available. A HUD will be hidden if it doesn't display any elements. Not available for 'Control', 'Navigation' and 'Console' type HUDs.
- new: HUDs: 'Quest' and 'Quest Task' settings available in 'Tooltip' type HUDs. A tooltip can be dispalyed when hovering the mouse above a quest or quest task in a 'Quest' type HUD.
- new: Main Menu: 'Stop Music' setting available. The current music is stopped when starting a new game. By default enabled.
- new: Status Effects, Battle Texts: 'Remove Status Effect' notification text settings available. You can display a notification text when a status effect is removed from a combatant.
- change: Object Variables: Accessing an object variable's component in the start function of a script now also initializes the variables.
- change: Event System: Moving, rotating and scaling objects over time will now start immediately. Previously, the changes started in the next frame, leading to sometimes not being finished completely after the wait time.
- change: Event System: PlayerPref Steps: The PlayerPrefs are saved each time after setting a PlayerPrefs.
- change: Inventory: Inventory limits prevent getting items from item collectors/boxes and buying items.
- fix: GUI Boxes: 'Select First' is now working correctly.
- fix: Menu Screens: The description part in equipment screens now displays the correct part information.
- fix: Menu Screens: Crafting menus could throw an error when using a choice for creating recipe outcomes.
- fix: Menu Screens: Group menus could throw an error (and block the menu from exiting) when using complex combatant layouts.
- fix: Event System: Base Steps: The 'Wait For Input' step now receives the input from input keys with 'Hold Time' correctly.
- fix: Event System: Game objects that are destroyed before being used in steps wont throw errors.
- fix: Console: Learning and forgetting console texts used the action range settings instead of learn/forget range.
- fix: Weapons, Armors: Enabling/disabling equipment parts wont throw errors when not using combatant equipment override.
- fix: Shops: Selling the last item of the inventory (without displaying 'Back' buttons) wont get you stuck in the shop any longer.
- fix: Save Games: Saving scene data (e.g. finished battles, collected items) is now working correctly.
- fix: Status Effects, Abilities, Items: Status effects overriding an ability/item attack attribute could result in an error.


Version 2.0.9a:
- new: Battle Events: Battle Steps: 'Use Ability Calculation' step available. Uses an ability (without animation) - the user/target changes will be calculated. The user doesn't need to know the ability.
- new: Battle Events: Battle Steps: 'Use Item Calculation' step available: Uses an item (without animation) - the user/target changes will be calculated.
- new: Shop Layouts: 'Show Portrait' setting available in the 'List Box' settings. The portrait of a selected item, weapon or armor in can be displayed.
- change: Controls: Blocking events will now prevent the use of battle related controls (e.g. control maps, group/individual target keys, ...).
- change: Editor: Combatants: The combatant's settings have been rearranged into 'Base Settings', 'Status Settings', 'Attacks & Abilities', 'Inventory & Equipment', 'Battle Settings' and 'Animations & Movement'.
- fix: Custom Controls: Custom camera controls aren't blocked by player control anymore.
- fix: Menu Screens: The description part now displays the correct content information of an equipped weapon/armor when selecting an equipment part.
- fix: Phase Battles: The next phase now starts automatically if no combatant of the current phase can perform an action.


Version 2.0.9:
- new: Event System: 'Found Objects' are available in all actor/waypoint/prefab-selections. Found objects are game objects in the scene that have been searched (and found) by the new 'Search Object' step.
- new: Event System: Base Steps: 'Search Objects' step available. Searches for game objects in the scene and adds or removes them to the 'Found Objects' list, or removes all found objects from the list.
- new: Battle Events: New actors available. Use 'User Group', 'Target Groups', 'All Allies', 'All Enemies' and 'All Combatants' actors for advanced battle events.
- new: Battle Events: Battle Steps: 'Change Action Targets' step available. A combatant is added or removed as a target of the action, or all targets can be removed.
- new: Game Events: Actors and waypoints have advanced 'Find Object' settings. You can now search for objects within a defined range.
- new: Combatants: 'Equipment Settings' available. Combatants can optionally override the equipment settings of their class, making the available equipment parts, weapons and armors independent from the class.
- new: Combatants: 'Experience Rewards' now have advanced reward value settings. You can use a value, game variables, formulas and other sources for the experience reward value.
- new: Abilities, Items: 'Animation Settings' available in the 'Damage Dealer Settings'. Damage dealers can optionally use battle events to create more complex actions when hitting a damage zone.
- new: Damage Zones: 'Audio Settings' available. Damage zones can play audio clips or a sound type when receiving damage from a damage dealer.
- new: Equipment Viewers: Advanced material settings available. You can optionally use the renderer of a child object and use an indexed material (if the renderer uses multiple materials).
- new: Menu Settings: 'Mouse Over Selection' setting available. Optionally selects (not accepts) a choice when the mouse cursor is above it (only on the currently focused GUI box).
- new: Game Controls: Custom Controls: The custom control behaviours are now separated from player/camera controls. You can select on which object (player or camera) a control is located and with which control they'll be blocked (player or camera).
- new: Placement: 'Scale' settings available for placing/mounting objects (e.g. spawn prefab step, cursor placement, etc.) throughout the entire framework.
- new: Quantity Selections: 'Hide Buttons' setting available for quantity selection buttons. Optionally hide the buttons, but still allows changing the quantity with the input keys.
- new: Quantity Selections: Advanced text codes available to display inventory money/item changes, details about the currency and the icon of the item.
- new: Combatant Component Inspector: The combatant component's inspector now displays advanced information on a combatant's battle data and actions.
- new: Menu Screens, Item Boxes: Description Part: Advanced text codes available and optional custom description text.
- change: Value Input: The value input field name is now multi-lingual.
- fix: Combatants: The start equipment's requirements will now also use bonuses from classes.
- fix: Shop Layouts: Buy/sell quantity selections got mixed up when using something other than 'Default'.
- fix: Battle Menus: The target cursor wasn't removed when clicking on a target to select it.
- fix: Phase Battles: Selecting 'End Phase' after canceling a combatant's battle menu didn't progress to the next phase.
- fix: Phase Battles: The combatant selection with 'Only Available' enabled and combatants not able to perform an action didn't progress to the next phase.
- fix: Active Time Battles: Doing nothing (i.e. 'End' battle menu item) resultet in the battle menu not reappearing when the timbar filled again.
- fix: GUI Boxes: Disabling the 'Use Cancel Button' setting was ignored.


Version 2.0.8:
- new: Formulas: 'Initial Value' settings available for formula selections throughout the entire framework. The formula will use the initial value as it's base and start the calculation with that value. The start value of the formula will be calculated to the initial value based on the selected operator in the formula's settings.
- new: Abilities, Items, Currencies, Weapons, Armors, Crafting Recipes: 'Portrait Settings' available. The portrait can be displayed by menus when the ability, item, currency, weapon, armor or crafting recipe has been selected.
- new: Menu Screens: 'Show Portrait' setting available in 'Ability', 'Ability Tree', 'Crafting', 'Equipment' and 'Inventory' menu parts. The portrait of a selected item, currency, weapon or armor in the inventory screen can be displayed.
- new: GUI Boxes: 'Show Button' setting available. Displaying a button around the content of a choice, tab or ok/cancel button is now optional (by default enabled).
- new: Abilities: Advanced 'Cast Time' settings available. The cast time of an ability can now also use formulas, game variables and other sources.
- new: Abilities: Advanced 'Reuse After' settings available. The reuse turns/time of an ability can now also use formulas, game variables and other sources.
- new: Shop Layouts: The 'List Box' settings can now optionally use a different layout for the back button. Use it when using custom info in the content layout that would otherwise also be displayed on the back button.
- new: Game Controls: Advanced 'Member Change Keys' settings available. Switching the player is optional for the field, turn based, active time, real time and phase battles. Switching the current menu user is available for active time and real time battles only.
- new: Interactions: 'In Blocked Control' setting available for 'Trigger Enter', 'Trigger Exit', 'Key Press' and 'Drop' interactions. The interaction can be started even while the player control is blocked (e.g. during a control blocking battle or event).
- new: Main Menu: The main menu can display a portrait. Optionally, every main menu option can display a different portrait.
- new: Battle Menus: Battle menus can display portraits of selected items, abilities, equipment, targets and command targets.
- new: Battle Menus: 'Use Sub-Menu Boxes' setting available. Battle menus can optionally use different GUI Boxes for different sub menus (e.g. ability type menu, item menu, target menu).
- new: Battle Events: Battle Steps: 'Activate Damage Dealer' step can now use the ability's or item's audio clip and prefab defined in their damage dealer settings.
- new: Damage Dealers: Environmental damage dealers now use the audio/prefab settings defined in the ability's damage dealer settings.
- fix: Shop Layouts: The content layout of the 'List Box' settings now displays custom info.
- fix: Event System: Movement Steps: 'Change Position' step using movement by speed now only faces the move direction if 'Face Direction' is enabled.
- fix: Real Time Battle Areas: Battle now ends correctly when leaving real time battle areas.
- fix: Input Keys: Getting the axis value from input keys set via HUD or code is now correct.
- fix: Menu Screens: Spamming the 'Cancel' key when having multiple non-single menu screens opened caused problems.
- fix: Turn Based Battles: Killing an enemy that had the last action could lead to the battle not continuing.
- fix: Real Time Battles: Death of combatants could lead to wait times between actions.


Version 2.0.7:
- new: GUI Boxes: You can use different text format settings for the text, info and title of choices.
- new: Control Maps: 'Need Targets' setting available. 
- new: Camera Controls: 'Mouse' camera control zoom by keys received an option to use a single key as axis instead of two separate buttons. Use this option for mouse wheels.
- new: Finding Objects: Finding objects in game event actors, navigation markers and custom main menu choices can now search for attached components. The found object is the one the component is attached to.
- new: Weapons, Armors: 'Viewer Material' setting available. Weapons and armors can change the material used by a renderer attached to the same game object as an 'Equipment Viewer'.
- new: Group Targets: You can now select different group targets for different abilities, ability types, items and item types. Settings are made in 'Battle System > Battle Settings'.
- new: Individual Targets: Set individual targets for a combatant to use abilities and items on. Work like group targets. Settings are made in 'Battle System > Battle Settings'.
- new: Combatants: 'Attack Individual Target' setting available. Uses an individual target for AI attacks.
- new: Combatants: 'Run Speed Threshold' and 'Sprint Speed Threshold' settings available in the combatant's 'Animation Settings'. Use thresholds for a smoother transition between walk/run and run/sprint animations.
- new: Battle Menus: 'Auto Target Settings' available. Optionally use abilities (also attacks) and items automatically on a group target or individual target.
- new: HUDs: 'Combatant Origin' setting available in 'Combatant' type HUD elements (except for 'Shortcut' elements). Select if the displayed information comes from the HUD's user, a group/individual target or the last target (of an attack, ability or item) of the user.
- new: HUDs: Shortcuts ('Combatant' type HUDs') can optionally target a group/individual target automatically when double clicked.
- new: Damage Types: The new damage types define the animation types used for damage, critical damage and evasion. Damage types are assigned to ability/item types and can optionally be assigned to abilities and items as well. This allows having different damage/evasion animations for each ability or item.
- new: Ability Types, Item Types: Set the default damage type for all abilities/items of the ability/item type.
- new: Abilities, Items: Abilities and items can override the default damage type of their ability/item type.
- new: Move AI: Advanced status requirements available for hunting and flee conditions.
- new: Interactions: The 'Trigger Enter' and 'Trigger Exit' start types of interactions can now be started by other game objects than the player. If an object can start the event can be checked by name/tag or by checking of added components, or both.
- new: Crafting Recipes: 'Audio Settings' available. Crafting recipes can play an audio clip when the creation has been successful or failed.
- new: Custom Controls: 'From Root' setting available. Searching/adding behaviour components will use the root of the game object - use this setting if the object isn't the real root.
- new: Custom Controls: You can optionally change fields and properties of custom control behaviours.
- new: Value Checks: 'Not Equal' check available. You can now use the not equal check in all value checks (previously only is equal, less or greater) - e.g. used in status requirements, distance checks, etc.
- new: Animations: 'Auto Move Speed Parameter' settings available for Mecanim. Optionally set the horizontal and vertical move speed of a combatant to float parameters of the game object's Mecanim animator.
- new: Scene Wizard: You can now create interaction controllers for 2D and 3D interactions.
- change: Status Values: 'Consumable' type status values can now only select 'Normal' type status values as maximum status value.
- change: Event System: 'Show Notification' step is now available in battle events, battle start events, battle end events and phase battle events.
- change: Battle Events: The 'Death' event now uses the combatants who attacked the dying combatant as targets.
- change: Animation Types: The animation types for damage, critical damage and evasion are now defined in 'Base/Control > Damage Types'.
- change: Difficulties: A combatant's 'Experience Rewards' are now influenced by the difficulty's faction status multipliers.
- change: Status Values: The percent bonus to combined 'Normal' type status values is now added after the final value calculation.
- change: Status Effects: When using formulas for status conditions, the calculation now happens every time, not only once.
- change: Status Effects: The caster of a status effect will now be used as the user for calculations of all changes, not only on cast.
- fix: Main Menu: The difficulty menu couldn't be displayed due to a bug.
- fix: Input Keys: Input keys of type 'Unity Input Manager' used as axis didn't receive input when the time scale was set to 0 (e.g. when using 'Freeze Game' in menu screens).
- fix: Menu Screens: The combatant's status values didn't update when the menu screen used 'Freeze Game'.
- fix: Menu Screens: Sub menus of menu screens that paused the game wheren't displayed and the game locked.
- fix: Abilities, Items: Using raycasts for 'None' target abilities/items is working now.
- fix: Event Interactions: When playing in the editor with an event interaction selected in the inspector, the event could be reloaded, stopping a running event from continuing.
- fix: Battle Start Events: The 'Spawn Combatants' step will now add player controls when spawning the player (e.g. when the battle takes place in a different scene).
- fix: Move AI: Stopping due to external influences (e.g. 'Stop Movement' status effect) wont cause loss of the hunted target any longer.
- fix: Combatant Spawners: Using combatant spawners with teleport battles (i.e. fighting in a different scene) wont result in the already spawned combatants missing in the battle.
- fix: Save Games: Error when loading inventory with money solved. Status values will now display the correct value. Equipment is now loaded correctly.
- fix: Compatibility: The 'EaseType' enumeration is now in the ORKFramework namespace and can be used with HOTween.
- fix: Status Effects: Having wrong auto apply/remove settings could lead to a stack overflow because a status effect was added and removed at the same time.
- fix: GUI Editor: Displaying 'Combatant' or 'Turn Order' type HUDs in the GUI Editor could crash Unity when having deadlocked auto apply/remove status effects.
- fix: Shops: Clicking on the 'Exit' button without selecting it first didn't return the control back to the player.


Version 2.0.6:
- new: Input Keys: 'Key Combo' input type available. Use a sequence of other input keys as input (e.g. 'A+A+B') as input. Define the used input keys and time the player has to press the next button. Each combo key can ignore selected other input keys (i.e. they wont cancel a combo).
- new: Value Inputs: Value inputs can now be selected and changed using input keys (i.e. vertical keys for selection, horizontal keys for slider changes, toggle bools and start text editing with accept).
- new: Event System: Equipment Steps: The 'Check Equipment' step can now check if an equipment part is generally equipped with a weapon or armor without specifying a specific equipment.
- new: Images: Use alpha mask textures to hide parts of displayed images. Used in image event steps, background images, portraits and HUDs.
- new: Event System: Rigidbody Steps: 'Add Force Rigidbody' step available. Add a force to 2D and 3D rigidbodies - optionally relative force (3D only).
- new: Event System: Rigidbody Steps: 'Add Torque Rigidbody' step available. Add torque to 2D or 3D rigidbodies.
- new: Event System: Rigidbody Steps: 'Position Force Rigidbody' step available. Add a force to a position, applying force/torque to 2D and 3D rigidbodies.
- new: Event System: Rigidbody Steps: 'Explosion Rigidbody' step available. Adds an explosion effect force to 3D rigidbodies.
- new: Event System: Rigidbody Steps: 'Stop Rigidbody' step available. Stops adding force/torque from other event steps to rigidbodies.
- new: Menu Screens: 'Remember Selection' setting available. Remembers the selected menu item when returning to the menu screen.
- new: GUI Boxes: 'Scale Settings' available in the 'Move In' and 'Move Out' settings. You can use this to create zoom effects when moving a GUI box in or out.
- new: Combatants: 'Experience Reward' settings available. You can now define experience rewards the player receives for defeating a combatant, without using the status development settings of the combatant. The real status values of the combatant and the exp reward can now be separated.
- new: Game Options: 'Random Battle Chance' option available in option menus (main menu and menu screens). Changes the chance for random battles happening. Used as percent of the chance defind in 'Random Battle Areas' (plus bonuses). E.g. 100 % is the default chance, 0 % is no random battles, 200 % is double chance.
- new: Abilities, Items: 'Random Battle Factor' settings available. Abilities and items can change the random battle factor for a defined amount of time. While the factor is changed by an ability/item, the factor bonuses of player group members are ignored. The factor is defined in percent.
- new: Control Maps: You can optionally select the equipment part used for an attack. The attack will only be used if a weapon with 'Override Attack' is equipped on the selected equipment part. Uses the attack of the equipped weapon.
- new: Battle Menus: 'Equipment' menu item type available. Lists the combatant's equipment parts and allows changing the equipment (similar to the equipment menu).
- new: Battle menus: 'Command' menu item type available. Give commands to other members of the group. Optionally only for 'AI Controlled' combatants. The given command will be performed the next time they're able to choose an action, giving a different command will override the previous one.
- new: Status Effects: 'Block Equipment Change' and 'Block Command' settings available. Status effects can now prevent a combatant from changing equipment and giving commands to other combatants.
- change: Battle Menus: Abilities and items can only be selected if targets are available.
- change: Control Maps: Abilities and items can only be used (and display a target menu) if targets are available.
- fix: Scene Wizard: Creating camera positions with the scene wizard will again add them to the data when the ORK Framework editor isn't already opened.
- fix: Combatants, Classes: Class development now uses the correct maximum values for class experience. The class experience is based on the status development of the class.
- fix: Battle System: Using items/abilities on combatants without doing damage will now also mark them as attacked by the user and allows the player to get battle gains from them.
- fix: Battle System: An enemy can't start a battle (when the player enters the combatant's battle start range) while a blocking menu is opened.
- fix: Battle Settings: Not using the target menu will now prevent the target menu from being displayed.


Version 2.0.5:
- new: Game Controls: Camera Control: 'Top Down Border' camera control available. Top down camera following the player until he crosses a border. The border is defind in the scene using a 'Camera Border' component with a 'Box Collider' (the collider defines the border).
- new: Scene Wizard: 'Camera Border' can be added to the scene through 'Create Object'. Adds a new game object with a 'Box Collider' and a 'Camera Border' attached.
- new: Event System: Camera Steps' 'Camera Control Target' step available. Changes the target of the camera control (i.e. the object the camera will follow). Requires the control to be a descendant of 'BaseCameraControl' (e.g. all built-in camera controls).
- new: Status Effects: 'End On Death' setting available. The effect will end when the combatant dies. By default enabled.
- new: Status Effects: 'Absorb Damage' settings available in 'Status Conditions'. Optionally absorbs damage dealt to a selected status value by abilities/items (with 'Use Absorb Effect' enabled).
- new: Status Effect Changes: 'Force' setting available. The status effect change will be forced, ignoring the target's status effect immunities.
- new: Abilities, Items: 'Use Effect Absorb' setting available. The user of the ability/item will absorb damage dealt according to applied absorb status effects.
- new: Abilities, Items: 'Volume' settings available for playing audio clips on status changes.
- new: Game Settings: 'Initial Game Variables' settings available. Define game variables that will be automatically set up when starting a game (i.e. before the main menu).
- new: Main Menu: 'Options' settings available. Add an options button to the main menu to display an options menu. You can change the music and sound volume, text speed and custom options (using global game variables).
- new: Menu Screens: 'Volume' settings available for the open and close audio clips.
- new: Menu Screens: 'Pause Settings' available. The game can optionally be paused while a menu screen is open. Pausing the game can also optionally pause the game time and freeze the game completely.
- new: Menu Screens: 'Options' menu part available. You can change the music and sound volume, text speed and custom options (using global game variables).
- new: Menu Audio: 'Value Input' audio settings available. A sound can be played when changing an input value (e.g. options menu, value input dialogues). Setting can be found in 'Menu Settings' and in GUI boxes which override the default audio settings.
- new: Inventory Settings: Item Collection: A sound can be played when collecting an item. The used sound can be either a selected sound type assigned to the player's combatant, or a selected audio clip.
- new: Inventory Settings: Item Box: Like the item collection, item boxes can now also play an animation and sound when the player interacts with them.
- change: Event System: Dialogue Steps: Choices in 'Show Dialogue' steps can be copied and moved.
- change: Event System: Inventory Steps: 'Add To Inventory', 'Remove From Inventory', 'Has In Inventory' and 'Drop Items' steps can now use formulas, game variables and other values to set the quantity and chance of items.
- change: Game Variables: The 'Is Valid' setting when checking game variables is now by default enabled.
- change: Stealing: Stealing items/money will now remove the stolen item/money the target's inventory, even if it's not the player.
- fix: Shops: Clicking on a 'Cancel' button when not using the buy/sell box and type box caused an error.
- fix: Node Editor: Event System: 'Show Dialogue' could throw an error when loading an event with a 'Choice' type dialogue without any choices.
- fix: Status Effects: Spawning prefabs for auto applied effects could sometime be displayed when spawning a combatant and immediately removing the effect.
- fix: Battle System: Enemies killed by other NPCs (not part of the player faction) wont give the player experience and loot - only if the player also attached the combatant.


Version 2.0.4:
- new: Shops: Selling individual items, weapons and armors can now depend on variable conditions.
- new: Shops: 'Sell to Shop' settings available. You can optionally limit which item types the player can sell to a shop.
- new: Text Code: 'Log Text' text code available. Displays the text of a log text, e.g. #logtext5# displays the text of log text with ID (index) 5.
- new: Game Controls: Custom player/camera control scripts can now be added to child objects.
- new: Console Settings: 'Unity Console Output' setting available. Optionally print new console lines in the Unity console when playing in the Editor.
- new: Event System: Equipment Steps: 'Lock Equipment Part' step available. Lock/unlock an equipment part of a combatant. Locked equipment parts can't change equipment.
- new: Event System: Equipment Steps: 'Check Part Locked' step available. Checks if a selected equipment part of a combatant is locked.
- new: Event System: Variable/Inventory Steps: 'Inventory To Variable' step available. Stores the quantity of a selected item, currency, weapon or armor found in an inventory into a float game variable.
- new: Status Effects: End after turn/time now also allows using formulas, game variables, PlayerPrefs and game time to determine the turns/time.
- new: Mouse/Touch Controls: New mode 'Hold' available for mouse/touch controls. Recognizes the input while holding it down (i.e. everything between 'Start' and 'End'). E.g. used in the 'Mouse' player controls.
- new: GUI Boxes: 'Selected Choice Offset' setting available. Optionally add an offset to the x-position of a selected choice. Setting also editable in the WYSIWYG editor.
- new: Node Editor: You can remove a focused node by pressing 'Delete'. You can remove the focused nodes and all following nodes (remove chain) by pressing 'ALT + Delete'. A focused node is displayed with an additional highlight around the node.
- new: Main Menu: 'Custom Choice Settings' available. You can add custom choices to the main menu (before the 'Exit' button). A custom choice will search for a game object in the scene and try to call a defined function on it. The call happens after the main menu is closed.
- new: Input Keys: 'Hold Time' setting available. When using input handling 'Hold' or 'Down', you can define the time the key has to be held to recognize the input.
- new: Inventory Settings: Item Collection: 'Auto Close' settings available. The item collection dialogue can automatically close after time.
- new: Combatants: The combatant's object variables can be initialized with default variables.
- new: Scene Objects: 'Object Variables' settings available. You can automatically add an 'Object Variable' component to a scene object and initialize them with default values.
- change: Editor: Events: The 'Close' button will now display a question dialogue if you really want to close the event.
- change: Status Effects: Reapplying a status effect (i.e. applying it again when it's already added) now also checks the hit chance.
- change: Inventory Settings: Item Collection: Playing an animation now uses Animation Types.
- fix: HUDs: 'Console' type HUDs don't throw an error when using 'All Console Types'.
- fix: Random Battle Area: Using a 'Battle Object' for the random battles blocked starting battles after the first battle.
- fix: Music: Playing the same music that is currently stored could sometimes result in playing from the stored time.


Version 2.0.3
- new: Editor: GUI Editor: The WYSIWYG editor allows editing HUDs.
- new: Editor: Updating events when saving or scanning for game variables in events can optionally only scan within a defind folder in the 'Assets' path.
- new: Editor: Status Development Curves: Creating a status development curve can now optionally use a curve instead of interpolation points.
- new: Abilities: 'Remove Turn' setting available. In 'Turn Based' battles, the target of the ability will be forced to skip a turn (if not yet performed).
- new: Items: 'Turn Based Order Changes' settings available. Like abilities, items can now change the turn order or remove the turn of a target in 'Turn Based' battles.
- new: Menu Screens: Equipment Part: Highlighting the 'Unequip' button will now also display preview values (for unequipping the equipment part).
- new: Status Effects: 'End Action' settings available. A status effect can optionally let the combatant perform an action when it ends. The action will be performed the next time the combatant can choose an action.
- new: Status Effects: 'No Turn Order Change' and 'No Turn Remove' settings available. Optionally grants immunity to turn order changes and removing a turn using abilities or items.
- new: HUDs: The new 'Turn Order' type HUD displays the current turn order of 'Turn Based' battles.
- new: HUDs: Navigation: 'Navigation' type HUD elements can display a background image.
- new: HUDs: Combatant: 'Combatant' type HUD status effect elements now allow adding multiple lables (similar to shortcut elements) to create more complex status effect information.
- new: HUDs: Combatant: 'Combatant' type HUD status effect elements can display the remaining time/turns of a status effect using % (without decimals, %1 (with 1 decimal) and %2 (with 2 decimals). Remaining turns are always displayed without decimals.
- new: HUDs: Tooltip: 'Status Effect' setting available in 'Tooltip' type HUDs. A tooltip can now be displayed when hovering the mouse above a status effect in a HUD.
- new: Combatants: 'Not Controllable' setting available. An 'AI Controlled' combatant can optionally be set to not controllable by the player. The combatant can't be selected as player using the player change keys.
- new: Languages: 'Initial Language' setting available. Set a language to be the initially selected language when starting the game.
- new: Damage Dealers: 'Environmental Damage' settings available. Set a damage dealer to be 'Always On' - damage will be dealt without firing an action first. You can use this for things like traps, hazardous areas or damage on contact with enemies.
- new: Damage Dealers: 'Reset Targets' settings available. When using 'One Time Damage' or 'One Target' you can use this to remove blocked targets after a defined amount of time, enabling additional damage by the damage dealer.
- new: GUI Boxes: 'Input Field Settings' available. Set spacing and alignment of input fields in dialogues.
- new: Event System: Dialogue Steps: 'Value Input Dialogue' step available. Displays a dialogue to input string, bool and float values and store them in game variables.
- new: Event System: Inventory Steps: 'Clear Inventory' step available. Removes everything (money, items, weapons and armors) from an inventory.
- new: Event System: Variable Steps: 'Clear Game Variables' step available. Removes all game variables (either local, global or object game variables).
- change: Abilities: 'Turn Based Order Changes' now also remove already fired actions that haven't yet been started. When using multi-turns, the turn value of the target will be changed instead of the turn order.
- change: Reflection: Call/check functions and check/change field/property exceptions now display the stack trace.
- fix: Move AI: 'Target Position Check' intervals of 0 now correctly update the target's position.
- fix: GUI Boxes: Selecting the last choice in a menu screen (e.g. equipment) which removes the choice wont cause an error any longer.
- fix: Event System: Animation Steps: 'Legacy Animation' now set's the layer and speed of animations correctly.
- fix: Node Editor: Adding unconnected nodes with the context menu will now place them correctly when scrolled down.
- fix: Player Group: Joining a combatant to the active player group after the player has already been spawned didn't spawn the new battle group member (requires 'Spawn Group' enabled in 'Game > Game Settings').


Version 2.0.2
- new: Editor: GUI Editor: The new GUI Editor allows editing GUI boxes in a WYSIWYG editor.
- new: Editor: You can open the ORK Framework editor using the hotkey 'CTRL + ALT + O'.
- new: Scene Wizard: You can open the ORK Scene Wizard using the hotkey 'CTRL + ALT + W'.
- new: Game Controls: Custom player/camera control scripts can now also be attached to child objects.
- new: Game Events: New event actor type 'Camera' available. Uses the event's camera as an actor.
- new: Event System: Movement Steps: 'Curve Move' step available. Move a game object using curves.
- new: Event System: Rotation Steps: 'Curve Rotation' step available. Rotate a game object using curves.
- new: Event System: Active Group Steps: 'Join Active Group' step allows adding a combatant group to the active player group.
- new: Abilities, Items: 'Use Screen Combatant' setting available. When using it's own combatant selection in menus, items and abilities can automatically be used on the current menu user without showing a combatant selection.
- new: Main Menu Settings: 'Set Start Group' setting available. You can use a Combatant Group as the player group at the start of a new game.
- change: GUI Boxes: The default settings for new GUI boxes have changed. The content/name box bounds have changed and the name box is now relative to the content box.
- fix: Event System: 'Use Center' setting in various steps wont cause objects to disappear when only a single target was used.
- fix: Battle System: Combatants dying when initialized (e.g. due to wrong setup, like 0 HP) wont cause an error.
- fix: Menu Screens: Hidden group members wont be displayed in 'Group Menu Parts' any longer.
- fix: Damage Dealers: Using an ability with the last available needed status value (e.g. MP) will no longer fail to activate the damage dealer.
- fix: Editor: Formulas: Testing formulas in the editor caused errors in some cases.
- fix: Status Effects: 'Auto Apply' caused an error in some cases.
- fix: GUI Boxes: The name box will is now displayed at the correct position when not relative to the content box with all anchor types.


Version 2.0.1
- new: Node Editor: Major update to the node editor. Button toolbar available at the top of the node display. Optional background grid display available. Searching the node list available.
- new: Editor: The variable list is automatically updated when saving the settings or an event. When saving the settings, only the settings will be scanned. When saving an event, only the event will be scanned.
- new: Items: 'Requirements' settings available. Using an item can depend on status requirements and variable conditions.
- new: Abilities: 'Requirements' settings now contain variable conditions. Using an ability can depend on variable conditions.
- new: Abilities, Items: 'Not On Self' setting available. When targetting allies or all combatants, the user can be excluded from being a target.
- new: Status Values: 'Critical Refresh Notification' and 'Critical Damage Notification' settings available. Optionally display different change notifications for critical hits.
- new: Event System: The new 'Image Steps' allow showing, fading and moving images on the screen. 'Show Image', 'Change Image Position', 'Change Image Color' and 'Remove Image' steps available.
- new: Event System: Variable Steps: 'Game Variable Fork' step available. Similar to 'Check Game Variable' step, but checks a single game variable for multiple values. The next step depends on which condition is valid.
- new: Event System: Status Steps: 'Status Fork' step available. The next step depends on which status requirement is valid.
- new: Event System: Status Steps: 'Change Status Value' step can optionally display change notifications as critical changes.
- new: Event System: Equipment Steps: 'Equipment Fork' step available. The next step depends on which weapon or armor is equipped on an equipment part.
- new: Event System: Fade Steps: 'Blink Object' step available. Starts/stops blinking a game object.
- new: Event System: Base Steps: 'Block Control Map' step available. Blocks/unblocks a selected control map or all control maps. A blocked control map can't be used.
- new: Event System: Dialogue Steps: 'Block HUD' step available. Blocks/unblocks a selected HUD or all HUDs. A blocked HUD wont be displayed.
- new: Event System: Function Steps: 'Change Time Factor' step available. Changes the time factor of Unity (everything in the game) or ORK Framework (things like battles and events only). You can use this to create slow motion effects.
- new: Event System: Function Steps: 'Check Component Enabled' step available. Checks if a component is enabled.
- new: Event System: Function Steps: 'Change Fields' step can now also change properties. Use the new 'Is Property' setting.
- new: Event System: Function Steps: 'Check Fields' step available. Checks the value of fields or properties of a component.
- new: Event System: Function Steps: 'Check Function' step available. Checks the return value of a function of a component.
- new: Event System: Movement Steps: 'Change Nav Mesh Target' step available. Sets the destination and speed of a Nav Mesh agent, or stops the agent.
- new: Formulas: Variable Steps: 'Game Variable Fork' step available. Similar to 'Check Game Variable' step, but checks a single game variable for multiple values. The next step depends on which condition is valid.
- new: Formulas: Combatant Steps: 'Status Fork' step available. The next step depends on which status requirement is valid.
- new: Logs: 'Invert Text Order' setting available. Optionally display log texts in inverted order (i.e. from high index to low index).
- new: Move AIs: 'Detect Only Leader' setting available. Detecting enemies can optionaly be limited to the group leader of an enemy group.
- new: Save Game Menu: Save Point: The 'Save' and 'Cancel' button are now optional (by default enabled). The 'Cancel' button can optionally override the default 'Cancel' button's content.
- new: Control Maps: 'Requirements' settings available for the whole control map and single control map keys. Using the control map or individual keys can optionally depend on status requirements and variable conditions.
- new: Battle AI: 'Check Distance' and 'Check Angle' steps available. Check possible targets upon distance and angle conditions. New 'Position Steps' group in step selection.
- new: Battle System: 'Stack Loot' setting available in all battle system types. Loot of the same kind will optionally be stacked. By default enabled.
- new: Turn Based Battles: 'Invert Turn Order' setting available. The turn order can optionally be inverted, i.e. sorted ascending, not descending (the combatant with the lowest value will have the first action).
- new: Turn Based Battles: 'Use Multi-Turns' setting available. A combatant can optionally perform multiple turns before another combatant had his turn. After a combatant performed his turn, his turn value will be reset to 0 and the turn value of all combatants will be increased. Available when 'Active Command' is enabled.
- new: Save Game Menu: 'Save Block States' setting available. The stated of blocked Input Keys, Control Maps and HUDs can be saved.
- new: Menu Screens: 'Menu Part Change Keys' settings available. Optionally use input keys to change the active menu part. You can only change to controlable parts (e.g. Inventory).
- change: Editor: Hotkeys: The navigation history hot keys now require the 'ALT' key to be pressed. Use 'ALT + Home' and 'ALT + End' to browse through the navigation history.
- change: Menu Screens: Items and abilities can't be used in a menu screen while the combatant is performing an action.
- fix: Menu Screens: Abilities and equipment displaying level up information will now display the correct inactive alpha value when inactive.
- fix: Event System: Function Steps: The 'Enable Component' step will now also enable/disable colliders, renderers, particle emitters and LOD groups.


Version 2.0.0
Initial release.

For changes to the beta versions, please visit http://orkframework.com.

