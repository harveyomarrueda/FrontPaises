using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PaisesMVC.Services;
using PaisesMVC.Models;

namespace PaisesMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IServiceAPI _servicioAPI;  //BPM. INYECCION DE DEPENDENCIA PARA EL SERVICIO API (DESACOPLADO)

        public HomeController(IServiceAPI servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        //serviceAPI _servicioAPI = new serviceAPI();


        public async Task<ActionResult> Index(string txtFilter = "")
        {

            string txtErrors;
            modelPaises datosPais = new modelPaises();

            txtErrors = string.Empty;
            if (txtFilter != null)
            {
                try
                {

                    datosPais = await _servicioAPI.GetDatosPais(txtFilter);

		    //Código entrante
		    ViewBag.NuevoDato = "CA002-01-98";


                    if (datosPais == null)
                    {
                        txtErrors = "Error del Servicio externo. Respuesta nula consultando pais (" + txtFilter + ")";
                    }
                }
                catch (Exception ex)
                {
                    txtErrors = "Falla del Servicio externo. Excepción: " + ex.ToString();
                }
            }
            else
            {
                txtErrors = "Error Bad request. Se Intento consultar al servicio con pais nulo";
            }

            //ViewBag.FormatoHora = customHourFormat;
            ViewBag.txtErrors = txtErrors;
            return View(datosPais);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}