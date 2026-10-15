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
    RU,
    [Display(Name = "Árabe")]
    AR,
    [Display(Name = "Neerlandés")]
    NL,
    [Display(Name = "Polaco")]
    PL,
    [Display(Name = "Portugués de Portugal")]
    ptPT,
    [Display(Name = "Turco")]
    TR,
    [Display(Name = "Sueco")]
    SV,
    [Display(Name = "Noruego")]
    NO,
    [Display(Name = "Danés")]
    DA,
    [Display(Name = "Finlandés")]
    FI,
    [Display(Name = "Checo")]
    CS,
    [Display(Name = "Húngaro")]
    HU,
    [Display(Name = "Griego")]
    EL,
    [Display(Name = "Rumano")]
    RO,
    [Display(Name = "Ucraniano")]
    UK,
    [Display(Name = "Tailandés")]
    TH,
    [Display(Name = "Vietnamita")]
    VI,
    [Display(Name = "Indonesio")]
    ID,
    [Display(Name = "Malayo")]
    MS,
    [Display(Name = "Hindi")]
    HI,
    [Display(Name = "Hebreo")]
    HE,
    [Display(Name = "Catalán")]
    CA
}
