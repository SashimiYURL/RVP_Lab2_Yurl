using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RVP_Lab2_Yurl
{
    public partial class DialogBackground : Form
    {
        int style = 0;
        Color colorChange;
        public int StyleType { get { return style; } }
        public Color ColorType { 
            get { return colorChange; }
            set { colorChange=value; }
        }
        public string fileName { get; set; }

        public DialogBackground()
        {
            InitializeComponent();
            buttonOK.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void comboBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBoxBackground.SelectedIndex)
            {
                case 0: 
                {
                        style = 1;
                        ColorDialog colorDialog = new ColorDialog();
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            ColorType = colorDialog.Color;
                        }
                        break;
                };
                case 1: 
                { 
                        style = 2;

                        break;
                };
                case 2:
                {
                        style = 3;
                        break;
                }
                case 3:
                {
                        style = 4;
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            fileName = fileDialog.FileName;
                        }
                        break;
                }
                case 4:
                { 
                        style = 5;
                        break;
                }
                case 5:
                {
                        style = 6;
                        break;
                }




            }
        }
    }
}
