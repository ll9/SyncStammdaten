using Microsoft.EntityFrameworkCore;
using SyncStammdaten.Data;
using SyncStammdaten.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Controllers
{
    class MainController
    {
        private MainView _view;
        private ApplicationDbContext _efContext;
        private AdoContext _adoContext;
        private BaseEntityRepository _baseEntityRepo;

        public MainController(MainView mainView)
        {
            this._view = mainView;
            _efContext = new ApplicationDbContext();
            _adoContext = new AdoContext();
            _baseEntityRepo = new BaseEntityRepository(_adoContext);

            Initialize();
        }

        private void Initialize()
        {
            _efContext.Database.Migrate();
            _adoContext.Migrate();

            _view.DataSource = _baseEntityRepo.List();
        }

        internal void SaveChanges(System.Data.DataTable dataSource)
        {
            _baseEntityRepo.SaveChanges(dataSource);
        }
    }
}
