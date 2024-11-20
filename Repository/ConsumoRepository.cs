using EcoWatt.Data;
using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcoWatt.Repository
{
    public class ConsumoRepository : IConsumoRepository
    {
        private readonly dbContext dbContext;
        public ConsumoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Consumo> AddConsumo(Consumo consumo) 
        {
            var result = await dbContext.Consumos.AddAsync(consumo);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Consumo> GetConsumo(int consumoId) 
        {
            return await dbContext.Consumos.FirstOrDefaultAsync(
                x => x.ConsumoId == consumoId);
        }
        public async Task<IEnumerable<Consumo>> GetConsumos() 
        {
            return await dbContext.Consumos.ToListAsync();
        }
        public async Task<Consumo> UpdateConsumo(Consumo consumo)
        {
            var result = await dbContext.Consumos.FirstOrDefaultAsync(
                x => x.ConsumoId == consumo.ConsumoId);
            if (result != null) // Corrigido
            {
                result.Data_Consumo = consumo.Data_Consumo;
                result.Hora_Consumo = consumo.Hora_Consumo;
                result.Quantidade_Watts = consumo.Quantidade_Watts;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async void DeleteConsumo(int consumoId)
        {
            var result = await dbContext.Consumos.FirstOrDefaultAsync(
                x => x.ConsumoId == consumoId);

            if (result != null) // Certifique-se de que o registro existe
            {
                dbContext.Consumos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
