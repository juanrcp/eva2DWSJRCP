using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.DAL;

//En esta clase declaramos la tabla "eva_tch_notas_evaluacion" con sus campos como atributos y metodos para poder acceder a ellos.
public partial class EvaTchNotasEvaluacion
{
    public string? MdUuid { get; set; }

    public DateTime? MdFch { get; set; }

    public long IdNotaEvaluacion { get; set; }

    public string? CodAlumno { get; set; }

    public long? NotaEvaluacion { get; set; }

    public string? CodEvaluacion { get; set; }

    public virtual EvaCatEvaluacion? CodEvaluacionNavigation { get; set; }
}
