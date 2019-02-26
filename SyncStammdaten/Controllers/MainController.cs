using Microsoft.EntityFrameworkCore;
using SyncStammdaten.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Controllers
{
    class MainController
    {
        private MainView mainView;
        private ApplicationDbContext _efContext;
        private AdoContext _adoContext;

        public MainController(MainView mainView)
        {
            this.mainView = mainView;
            _efContext = new ApplicationDbContext();
            _adoContext = new AdoContext();

            Initialize();
        }

        private void Initialize()
        {
            _efContext.Database.Migrate();
            _adoContext.Migrate();
        }
    }
}
