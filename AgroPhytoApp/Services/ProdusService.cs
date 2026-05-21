using AgroPhytoApp.Models;
using AgroPhytoApp.Repositories;

namespace AgroPhytoApp.Services
{
    public class ProdusService
    {
        private readonly ProdusRepository _repository;

        public ProdusService(ProdusRepository repository)
        {
            _repository = repository;
        }

        // GET ALL
        public List<Produs> GetAllProduse()
        {
            return _repository.GetAll();
        }

        // GET BY ID
        public Produs GetProdusById(int id)
        {
            return _repository.GetById(id);
        }

        // ADD
        public void AddProdus(Produs produs)
        {
            _repository.Add(produs);
        }

        // UPDATE
        public void UpdateProdus(Produs produs)
        {
            _repository.Update(produs);
        }

        // DELETE
        public void DeleteProdus(int id)
        {
            _repository.Delete(id);
        }
    }
}