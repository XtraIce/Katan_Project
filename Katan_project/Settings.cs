using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Katan_project
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            TransparentControl TileA = new TransparentControl();
            TileA.Image = System.Drawing.Image.FromFile(@"C:\Users\Riker\OneDrive\CatanMaterials\BrickTileSmall.png");
            TileA.Location = new Point(500, 500);
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RandomCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
