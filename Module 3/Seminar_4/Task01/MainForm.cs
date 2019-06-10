using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalBuilder
{
    public partial class MainForm : Form
    {
        static int counter;
        static Random rnd = new Random();
        
        public MainForm()
        {
            InitializeComponent();

            this.MouseEnter += (object sender, EventArgs e) => { this.Text = ("My Form " + counter++); this.BackColor = Form.DefaultBackColor; };
            this.MouseClick += (object sender, MouseEventArgs e) => { this.BackColor = Color.Red; };
            this.MouseDoubleClick += (object sender, MouseEventArgs e) => { this.Size = new Size(rnd.Next(100, 1000), rnd.Next(100, 1000)); };
        }

        private void FormActivated(object sender, EventArgs e)
        {

        }
    }
}
