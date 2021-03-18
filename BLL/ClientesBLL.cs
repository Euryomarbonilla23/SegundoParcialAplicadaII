using Microsoft.EntityFrameworkCore;
using SegundoParcialAplicadaII.Data;
using SegundoParcialAplicadaII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SegundoParcialAplicadaII.BLL
{
    public class ClientesBLL
    {
        private Contexto _contexto { get; set; } 

        public ClientesBLL(Contexto contexto)
        {
            //profe me da error esto
            this._contexto = contexto;
        }
        
       
        public async Task<Clientes> Buscar(int Id)
        {
            Clientes Cliente = new Clientes();

            try
            {

                Cliente = await _contexto.Clientes.FindAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
            return Cliente;

            
        }

        public async Task<List<Clientes>> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                lista = await _contexto.Clientes.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        public async Task<List<Clientes>> GetClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            try
            {
                lista = await _contexto.Cliente.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
