using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntityBasicoDAL.DAL;

namespace eva2DWSJRCP.Pages
{
    public class Nuevo_RegistroModel : PageModel
    {
        private readonly EntityBasicoDAL.DAL.BdEvaluacionContext context;

        public Nuevo_RegistroModel(EntityBasicoDAL.DAL.BdEvaluacionContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CodEvaluacion"] = new SelectList(this.context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion");
            return Page();
        }

        //Con la etiqueta la unimos con la vista
        [BindProperty]
        public EvaTchNotasEvaluacion EvaTchNotasEvaluacion { get; set; }
        
        //Con este metodo guardamos los datos a la BBDD y guardamos los cambios.
        //Si todo es correcto nos llevara al Index con un mensaje de OK
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.EvaTchNotasEvaluacions.Add(EvaTchNotasEvaluacion);
            await this.context.SaveChangesAsync();
            Console.WriteLine("Datos guardados en la BBDD correctamente.");

            return RedirectToPage("./Index");
        }
    }
}
