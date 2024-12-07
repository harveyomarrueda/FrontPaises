using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaisesMVC.Models;


namespace PaisesMVC.Services
{
    public interface IServiceAPI
    {

        Task<modelPaises> GetDatosPais(string nombrePais);


    }

}
