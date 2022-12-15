using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityBasicoDAL.DAL;

namespace eva2DWSJRCP.Pages
{
    public class Listado_CompletoModel : PageModel
    {
        //Establecemos contexto para consultas
        private readonly EntityBasicoDAL.DAL.BdEvaluacionContext context;

        //Prpiedad del contexto
        public Listado_CompletoModel(EntityBasicoDAL.DAL.BdEvaluacionContext context)
        {
            this.context = context;
        }

        //Declaramos lista donde guardar los elementos de la BBDD y le declaramos sus propiedades
        //en el mismo sitio
        public IList<EvaTchNotasEvaluacion> EvaTchNotasEvaluacion { get;set; } = default!;

        //Con este metodo llenaremos la lista anteriormente y se la pasaremos a la vista. 
        public async Task OnGetAsync()
        {
            if (this.context.EvaTchNotasEvaluacions != null)
            {
                EvaTchNotasEvaluacion = await this.context.EvaTchNotasEvaluacions
                .Include(e => e.CodEvaluacionNavigation).ToListAsync();

                Console.WriteLine("Lista de Alumnos Cargada.");
            }
        }
    }
}
