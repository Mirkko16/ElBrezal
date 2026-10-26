using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Configs.Arca
{
    public partial class CertificadoPasswordForm : Form
    {
        public string Password => textBoxPassword.Text;

        public CertificadoPasswordForm()
        {
            InitializeComponent();

            textBoxPassword.UseSystemPasswordChar = true;

            AcceptButton = btnAceptar;
            CancelButton = btnCancelar;

            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }
    }
}
