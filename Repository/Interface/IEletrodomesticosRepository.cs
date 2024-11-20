using EcoWatt.Models;

namespace EcoWatt.Repository.Interface
{
    public interface IEletrodomesticosRepository
    {
        Task<IEnumerable<Eletrodomesticos>> GetEletrodomesticos();
        Task<Eletrodomesticos> GetEletrodomesticos(int eletrodomesticosId);
        Task<Eletrodomesticos> AddEletrodomesticos(Eletrodomesticos eletrodomesticos);
        Task<Eletrodomesticos> UpdateEletrodomesticos(Eletrodomesticos eletrodomesticos);
        void DeleteEletrodomesticos(int eletrodomesticosId);
    }
}
