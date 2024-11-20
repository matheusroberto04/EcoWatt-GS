using EcoWatt.Models;

namespace EcoWatt.Repository.Interface
{
    public interface IConsumoRepository
    {
        Task<IEnumerable<Consumo>> GetConsumos();
        Task<Consumo> GetConsumo(int consumoId);
        Task<Consumo> AddConsumo(Consumo consumo);
        Task<Consumo> UpdateConsumo (Consumo consumo);
        void DeleteConsumo(int consumoId);
    }
}
