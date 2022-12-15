using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.DAL;

//En esta clase declaramos la tabla "eva_cat_evaluacion" con sus campos como atributos y metodos para poder acceder a ellos. 
public partial class EvaCatEvaluacion
{
    public string CodEvaluacion { get; set; } = null!;

    public string? DescEvaluacion { get; set; }

    public virtual ICollection<EvaTchNotasEvaluacion> EvaTchNotasEvaluacions { get; } = new List<EvaTchNotasEvaluacion>();
}
