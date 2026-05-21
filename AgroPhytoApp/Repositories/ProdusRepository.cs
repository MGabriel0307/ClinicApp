using AgroPhytoApp.Models;

namespace AgroPhytoApp.Repositories
{
    public class ProdusRepository
    {
        private readonly AppDbContext _context;

        public ProdusRepository(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public List<Produs> GetAll()
        {
            return _context.Produse.ToList();
        }

        // GET BY ID
        public Produs GetById(int id)
        {
            return _context.Produse.FirstOrDefault(x => x.Id == id);
        }

        // ADD
        public void Add(Produs produs)
        {
            _context.Produse.Add(produs);

            _context.SaveChanges();
        }

        // UPDATE
        public void Update(Produs produs)
        {
            _context.Produse.Update(produs);

            _context.SaveChanges();
        }

        // DELETE
        public void Delete(int id)
        {
            var produs = _context.Produse.FirstOrDefault(x => x.Id == id);

            if (produs != null)
            {
                _context.Produse.Remove(produs);

                _context.SaveChanges();
            }
        }
    }
}