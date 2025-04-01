# Interjections

This is a library mod which makes it possible for conversations in *Caves of Qud* to feature interjections from other characters.
This is achieved through the addition of a few conversation parts and delegates which can be used in any conversation XML file.
For general information on conversation parts and delegates, see the [Qud wiki](https://wiki.cavesofqud.com/wiki/Modding:Conversations).

The purpose of this library is so that mod authors can write multi-character dialogue for Qud without having to write code.
**Please use it to make something cool!**

# Documentation

## Parts

### `Interjection`

This part changes the title and sprite displayed in the conversation window to match the supplied `Speaker` object blueprint:

```xml
<part Name="Interjection" Speaker="Q Girl" />
```

This is achieved by creating a sample object.
The blueprint specified does not have to be present in the current zone.

The change in speaker applies only to the conversation node with this part on it, and applies only to the UI. Multi-node interjections will need this part on each node. Other conversation parts like `StartFight` will still target the original speaker. 

### `ScreenShake`

This part applies camera shake at the beginning and/or end of a conversation node:

```xml
<part Name="ScreenShake" ShakeStart="0.3" ShakeEnd="0.3" />
```

Either `ShakeStart` or `ShakeEnd` can be left out. The value of these fields determines the length of the camera shake effect applied at the start or end of a node, respectively.

This can be useful for applying a bit of visual juice when the speaker changes mid-conversation, such as if one character interrupts another.

### `PlaySound`

This part allows a sound to be played when a conversation node is entered:

```xml
<part Name="PlaySound" Sound="Sounds/Abilities/sfx_ability_mutation_flamingRay_attack" Volume="1" PitchVariance="0.3" Delay="0.5" Pitch="0.8" />
```

The `Volume`, `PitchVariance`, `Delay`, and `Pitch` fields are optional and self-explanatory.

This can be useful for applying a bit of auditory juice when the speaker changes mid-conversation.

## Delegates

### `IfPresent`

This predicate can be used on choices to check if an object with a blueprint ID matching its value can be found in the current zone:

```xml
<choice GotoID="QGirlInterjects" IfPresent="Q Girl">...</choice>
```

Its counterpart `IfNotPresent` also exists. Combined with the `Interjection` part, it can be used for conditional interjections based on whether or not a given character (or other game object) is present.

### `IfHaveFollower`

This predicate can be used on choices to check if the player has a follower in the current zone with a blueprint ID matching its value:

```xml
<choice GotoID="IndrixInterjects" IfHaveFollower="Warden Indrix">What do you think, Indrix?</choice>
```

Its counterpart `IfNotHaveFollower` also exists. Combined with the `Interjection` part, it can be used for conditional interjections based on whether or not the player has a given follower with them.

## Usage

An example using all of the parts and delegates added by this mod can be found in `blueprints/Conversations.xml`.
It can be tested in-game by wishing for `InterjectionTest` and conversing with the spawned creature.
If Q Girl is present in the zone, one `Interjection` using `IfPresent` will occur in the conversation that uses the `ScreenShake` and `PlaySound` parts.
If Warden Indrix is a follower of the player, another `Interjection` using `IfHaveFollower` will occur in the conversation.

**New in Qud build 210**: To use this library in a mod, add the ID `visceralfield_interjections` to the `Dependencies` field in your `manifest.json` file. See [here](https://wiki.cavesofqud.com/wiki/Modding:Mod_Configuration#manifest.json) for an example.

# Compatibility

There is no Harmony patching in this library, and as such it should be broadly compatible with other mods.
Other mods that change the conversation UI may behave unexpectedly when combined with this mod.
Send me a message if there are mods that should be listed here with known (in)compatibility.

This mod should be compatible with [*Script - Chat Portraits!*](https://steamcommunity.com/sharedfiles/filedetails/?id=3453864549) although characters who interject into a conversation will always use their original blueprint sprite.
