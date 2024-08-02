using Microsoft.AspNetCore.Mvc;
using ReservationAPP.Models;
using ReservationAPP.Controllers;
using ReservationAPP.DTOs;


namespace ReservationAPP.Controllers
{

	public class MenuController : Controller
	{
		Context _menu = new Context();




		public IActionResult Index()
		{
			var degerler = _menu.Menu.ToList();
			return View(degerler);
		}
		public IActionResult DeleteRecord(int id)
		{
			var rec = _menu.Menu.Find(id);
			_menu.Menu.Remove(rec);
			_menu.SaveChanges();
			return RedirectToAction("Index");

		}




		public IActionResult AddNewRecord()
		{
			MenuAddDto _menu = new();
			return PartialView("_AddNewRecord", _menu);
		}

		[HttpPost]
		public IActionResult AddNewRecord(MenuAddDto d)
		{
			_menu.Menu.Add(new()
			{
				Name = d.Name,
				Description = d.Description,
				Price = d.Price
			});
			_menu.SaveChanges();
			return RedirectToAction("Index");
		}

		/*
				public IActionResult Edit(int id)
				{

					//MenuEditDto menus = _menu.MenuEditDto.Where(x => x.Id == id).FirstOrDefault();
					Menu selam = _menu.Menu.Where(p => p.id == id).FirstOrDefault();
					return PartialView("_EditMenuPratialView", selam);

				}*/


		public IActionResult _EditMenuPratialView(int Id)
		{

			var EditMenuI = _menu.Menu.Where(x => x.Id == Id).FirstOrDefault();
			Menu menuEdit = new Menu();
			return PartialView("_EditMenuPratialView", menuEdit);

		}
		[HttpPost]
		public IActionResult _EditMenuPratialView(Menu menuEdit)
		{

			_menu.Menu.Update(menuEdit);
			_menu.SaveChanges();
			return RedirectToAction("Index");

		}
		/*

				[HttpPost] public IActionResult _EditMenuPratialView(Menu menuEdit) {

					var MenuE = _menu.Menu.Find(menuEdit.Id);
					MenuE.Name= menuEdit.Name;
					MenuE.Description= menuEdit.Description;
					MenuE.Price= menuEdit.Price;
					_menu.SaveChanges();
					return RedirectToAction("Index");
				}*/

	}
}