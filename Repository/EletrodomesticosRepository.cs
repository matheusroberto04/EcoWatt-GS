using EcoWatt.Data;
using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcoWatt.Repository
{
    public class EletrodomesticosRepository : IEletrodomesticosRepository
    {
        private readonly dbContext dbContext;
        public EletrodomesticosRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Eletrodomesticos> AddEletrodomesticos(Eletrodomesticos eletrodomesticos) 
        {
            var result = await dbContext.Eletrodomesticos.AddAsync(eletrodomesticos);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Eletrodomesticos>GetEletrodomesticos(int eletrodomesticosId) 
        {
            return await dbContext.Eletrodomesticos.FirstOrDefaultAsync(
                x => x.EletrodomesticosId == eletrodomesticosId);
        }
        public async Task<IEnumerable<Eletrodomesticos>> GetEletrodomesticos() 
        {
            return await dbContext.Eletrodomesticos.ToListAsync();
        }
        public async Task<Eletrodomesticos> UpdateEletrodomesticos(Eletrodomesticos eletrodomesticos)
        {
            
            var result = await dbContext.Eletrodomesticos.FirstOrDefaultAsync(
                x => x.EletrodomesticosId == eletrodomesticos.EletrodomesticosId);

            if (result == null)
            {
                return null;
            }      
            result.Nome_Aparelho = eletrodomesticos.Nome_Aparelho;
            result.Valor_Consumo_Watts = eletrodomesticos.Valor_Consumo_Watts;
            result.Categoria = eletrodomesticos.Categoria;
            result.Modelo = eletrodomesticos.Modelo;

            await dbContext.SaveChangesAsync();

            return result; 
        }

        public async void DeleteEletrodomesticos(int eletrodomesticosId)
        {
            
            var result = await dbContext.Eletrodomesticos.FirstOrDefaultAsync(x => x.EletrodomesticosId == eletrodomesticosId);

          
            if (result == null)
            {
                return; 
            }

      
            dbContext.Eletrodomesticos.Remove(result);

            
            await dbContext.SaveChangesAsync();
        }
    }
}
