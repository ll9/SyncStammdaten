using SyncStammdaten.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncStammdaten
{
    public partial class MainView : Form
    {
        private MainController _controller;

        public MainView()
        {
            InitializeComponent();
            _controller = new MainController(this);
        }
    }
}
