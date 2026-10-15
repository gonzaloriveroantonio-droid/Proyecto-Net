using System.ComponentModel.DataAnnotations;

namespace proyecto_aspnet.Models;

public enum Language
{
[Display(Name = "Español")]
ES,
[Display(Name = "Ingles")]
EN,
[Display(Name = "Frances")]
FR,
[Display(Name = "Aleman")]
DE,
[Display(Name = "Italiano")]
IT,
[Display(Name = "Japones")]
JA,
[Display(Name = "Chino Simplificado")]
zhCN,
[Display(Name = "Chino Tradicional")]
zhTW,
[Display(Name = "Coreano")]
KO,
[Display(Name = "Portugues de Brasil")]
ptBR,
[Display(Name = "Ruso")]
RU
}
