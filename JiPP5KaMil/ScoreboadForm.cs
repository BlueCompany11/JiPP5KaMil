using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiPP5KaMil
{
    public partial class ScoreboadForm : Form
    {
        public ScoreboadForm()
        {
            InitializeComponent();
            Model2 model2 = new Model2();
            var wyniki = model2.TablicaWynikowWidoks.ToList();
            var bindingList = new BindingList<TablicaWynikowWidok>(wyniki);
            var source = new BindingSource(bindingList, null);
            dataGridViewWyniki.DataSource = source;
        }
    }
}
