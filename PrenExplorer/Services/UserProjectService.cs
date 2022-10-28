using PrenExplorer.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenExplorer.Services
{
    public class UserProjectService
    {
        private UnitOfWork _unitOfWork;
        public UserProjectService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
