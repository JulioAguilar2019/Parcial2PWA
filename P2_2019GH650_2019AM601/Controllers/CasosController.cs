using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P2_2019GH650_2019AM601.Models;
using System.Collections.Generic;
using System.Linq;

namespace P2_2019GH650_2019AM601.Controllers
{
    public class CasosController : Controller
    {
        private readonly dbContext _context;
        public CasosController(dbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<departamentos> datosDepartamentos = from d in _context.departamentos select d;
            List<SelectListItem> comboDepartamentos = new List<SelectListItem>();
            foreach (departamentos departamentos in datosDepartamentos)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = departamentos.departamento,
                    Value = departamentos.departamentosId.ToString()
                };
                comboDepartamentos.Add(miOpcion);
            }

            ViewBag.comboDepartamentos = comboDepartamentos;

            IEnumerable<genero> datosGenero = from g in _context.genero select g;
            List<SelectListItem> comboGenero = new List<SelectListItem>();
            
            foreach (genero genero in datosGenero)
            {
                SelectListItem miOpcion = new SelectListItem
                {
                    Text = genero.generos,
                    Value = genero.generoId.ToString()
                };
                comboGenero.Add(miOpcion);
            }

            ViewBag.comboGenero = comboGenero;
            IEnumerable<casosReportados> casos = (from c in _context.casosReportados
                                                  join d in _context.departamentos on c.departamentosId equals d.departamentosId
                                                  join g in _context.genero on c.generoId equals g.generoId
                                        select new casosReportados
                                        {
                                            departamento = d.departamento,
                                            genero = g.generos,
                                            confirmados = c.confirmados,
                                            recuperados = c.recuperados,
                                            fallecidos = c.fallecidos,
                                        });

            return View(casos);
        }

        public IActionResult postNew(casosReportados datosForm)
        {
            int idmax = (from i in _context.casosReportados select i.casosId).Max();
            var nuevo = new casosReportados()
            {
                casosId = datosForm.casosId,
                departamentosId = datosForm.departamentosId,
                generoId = datosForm.generoId,            
                confirmados = datosForm.confirmados,
                recuperados = datosForm.recuperados,
                fallecidos = datosForm.fallecidos
            };

            _context.casosReportados.Add(nuevo);
            _context.SaveChanges();
            return RedirectToAction("Index", "casos");
        }
    }
}
