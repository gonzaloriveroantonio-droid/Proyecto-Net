using System.ComponentModel.DataAnnotations;

namespace proyecto_aspnet.Models;

public enum GameEngine
{
[Display(Name = "Unreal Engine")]
UnrealEngine,
[Display(Name = "Unity")]
Unity,
[Display(Name = "Godot Engine")]
GodotEngine,
[Display(Name = "GameMaker")]
GameMaker,
[Display(Name = "Phaser")]
Phaser,
[Display(Name = "RAGE")]
RAGE,
[Display(Name = "Frostbite")]
Frosbite,
[Display(Name = "Creation Engine")]
CreationEngine,
[Display(Name = "RE Engine")]
REEngine
}
