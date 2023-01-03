using Microsoft.EntityFrameworkCore;
using PrenExplorer.Data;
using PrenExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(NewGenContext context) : base(context) { }

        public async Task<int> GetFirstProjectIdAsync(int LevelId)
        {
            return (await _dbSet.FirstOrDefaultAsync(p => p.LevelId == LevelId)).Id;
        }
    }
}
