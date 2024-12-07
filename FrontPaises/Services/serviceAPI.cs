using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using PaisesMVC.Models;
using Newtonsoft.Json;

namespace PaisesMVC.Services
{
    public class serviceAPI : IServiceAPI
    {

        //CAPA DE SERVICIO QUE IMPLEMENTA DE SU INTERFAZ (PARA DESACOPLAR)
        //ACTUA COMO CLIENTE DENTRO DE CAPA FRONT, PARA USAR LA API EXTERNA DE PAISES.

        //paises
        private static string _url;
        private static string _urlExterna;

        public serviceAPI()
        {
            _urlExterna = ConfigurationManager.AppSettings["UrlServidorPaises"];
        }


        public async Task<modelPaises> GetDatosPais(string nombrePais)
        {
            List<modelPaises> DatosPaises = new List<modelPaises>();
            modelPaises DatosPais = new modelPaises();
            string jsonRta,txtRta;
            byte[] bytesRta;


            System.Net.ServicePointManager.Expect100Continue = true;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_urlExterna);

            var response = await cliente.GetAsync(nombrePais);
            if (response.IsSuccessStatusCode)
            {
                txtRta = await response.Content.ReadAsStringAsync();

                bytesRta = Encoding.Default.GetBytes(txtRta);
                jsonRta=Encoding.UTF8.GetString(bytesRta);  //Evitar errores newton json por acentos, etc.

                if (jsonRta != null)
                {
                    DatosPaises = JsonConvert.DeserializeObject<List<modelPaises>>(jsonRta);
                    if (DatosPaises.Count > 0)
                    {
                        DatosPais = DatosPaises[0];
                    }
                }
            }

            return DatosPais;
        }


    }

}