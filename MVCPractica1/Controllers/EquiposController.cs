using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPractica1.Models;

namespace MVCPractica1.Controllers
{
	public class EquiposController : Controller
	{

		private readonly equiposDbContext _equiposDbContext;

		public EquiposController(equiposDbContext equiposDbContext)
		{
			_equiposDbContext = equiposDbContext;
		}



		public IActionResult Index()
		{
			var listaTipoDeEquipos = (from t in _equiposDbContext.tipo_Equipo
									  select t).ToList();
			ViewData["listadoTipoDeEquipos"] = new SelectList(listaTipoDeEquipos, "id_tipo_equipo", "descripcion", "estado");


			var listaDeMarcas = (from m in _equiposDbContext.marcas
								 select m).ToList();
			ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

			var listaEstadoDeEquipos = (from e in _equiposDbContext.estados_equipo
										select e).ToList();
			ViewData["listadoEstadoDeEquipos"] = new SelectList(listaEstadoDeEquipos, "id_estados_equipo", "descripcion", "estado");

			var listadoDeEquipos = (from e in _equiposDbContext.equipos
									join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
									select new
									{
										nombre = e.nombre,
										descripcion = e.descripcion,
										marca_id = e.marca_id,
										marca_nombre = m.nombre_marca
									}).ToList();
			ViewData["ListadoEquipo"] = listadoDeEquipos;

			return View();
		}

		public IActionResult CrearEquipos(equipos nuevoEquipo)
		{
			_equiposDbContext.Add(nuevoEquipo);
			_equiposDbContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
