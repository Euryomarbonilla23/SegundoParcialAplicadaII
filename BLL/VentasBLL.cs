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
    public class VentasBLL
    {
        public Contexto _contexto { get; set; }

        public VentasBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public async Task<List<Ventas>> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> lista = new List<Ventas>();

            try
            {
                lista = await _contexto.Ventas.Where(criterio).Include(c => c.Cliente).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }


        
        public async Task<Ventas> Buscar(int id)
        {
            Ventas ventas;
            try
            {
                ventas = await _contexto.Ventas.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return ventas;
        }

        public async Task<List<Ventas>> GetList()
        {
            List<Ventas> lista = new List<Ventas>();
            try
            {
                lista = await _contexto.Ventas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public static async Task<List<CobrosDetalles>> GetVentasCobradas(int clienteId)
        {
            var pendientes = new List<CobrosDetalles>();
            Contexto contexto = new Contexto();

            var ventas = await contexto.Ventas
                .Where(v => v.Cliente.ClienteId == clienteId && v.Balance == 0)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in ventas)
            {
                pendientes.Add(new CobrosDetalles
                {
                    VentaId = item.VentaId,
                    Cobrado = 0
                });
            }

            return pendientes;
        }

    }
}
