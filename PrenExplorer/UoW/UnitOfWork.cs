using PrenExplorer.Data;
using PrenExplorer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.UoW
{
    public class UnitOfWork
    {
        private NewGenContext _context;
        public ProjectRepository Projects { get; set; }
        public LevelRepository Levels { get; set; }

        public UnitOfWork(NewGenContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Levels = new LevelRepository(_context);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
