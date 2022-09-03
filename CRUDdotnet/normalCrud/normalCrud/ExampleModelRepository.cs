using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace normalCrud
{
    public class ExampleModelRepository
    {
        private readonly AppDbContext _appDbContext;
        public ExampleModelRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public void Save(ExampleModel model)
        {
            _appDbContext.Add(model);
            _appDbContext.SaveChanges();
        }
        public ExampleModel GetById(int id)
        {
            return _appDbContext.ExampleModels.Where(x => x.Id == id).SingleOrDefault();
        }
        public void Update(ExampleModel model)
        {
            _appDbContext.ExampleModels.Update(model);
            _appDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _appDbContext.ExampleModels.Remove(GetById(id));
            _appDbContext.SaveChanges();
        }
    }
}
