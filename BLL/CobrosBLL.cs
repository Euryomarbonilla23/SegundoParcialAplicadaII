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
    public class CobrosBLL
    {
        private Contexto _contexto { get; set; }
        public CobrosBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public async Task<bool> Existe(int id)
        {
            bool Cobro = false;
            try
            {
                Cobro = await _contexto.Cobros.AnyAsync(c => c.CobroId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return Cobro;
        }

        
        public async Task<bool> Insertar(Cobros Cobro)
        {
            bool paso = false;
            try
            {
                await _contexto.Cobros.AddAsync(Cobro);
                paso = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        
        private async Task<bool> Modificar(Cobros Cobro)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(Cobro).State = EntityState.Modified;
                paso = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

     
        public async Task<bool> Guardar(Cobros cobros)
        {
            if (!await Existe(cobros.CobroId))
                return await Insertar(cobros);
            else
                return await Modificar(cobros);
        }

        public async Task<bool> Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var cobros = await _contexto.Cobros.FindAsync(id);
                if (cobros != null)
                {
                    _contexto.Cobros.Remove(cobros);
                    paso = await _contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public async Task<Cobros> Buscar(int id)
        {
            Cobros cobros;
            try
            {
                cobros = await _contexto.Cobros
                   .Where(o => o.CobroId == id)
                   .Include(d => d.Cobrosdetalles)
                   .AsNoTracking()
                   .SingleOrDefaultAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return cobros;
        }


       
        public async Task<List<Cobros>> GetList()
        {
            List<Cobros> lista = new List<Cobros>();
            try
            {
                lista = await _contexto.Cobros.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public async Task<List<Cobros>> GetList(Expression<Func<Cobros, bool>> criterio)
        {
            List<Cobros> lista = new List<Cobros>();

            try
            {
                lista = await _contexto.Cobros.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

    }
}
