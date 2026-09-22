using System.Drawing;
using System.Windows.Forms;

namespace ElBrezal.Desktop.UI.Styles
{
    public static class VentaStyles
    {
        public static void AplicarTextBox(TextBox textBox)
        {
            textBox.Font =
                new Font("Courier New", 9F, FontStyle.Regular);

            textBox.Height = 24;
        }

        public static void AplicarComboBox(ComboBox comboBox)
        {
            comboBox.Font =
                new Font("Courier New", 9F, FontStyle.Regular);

            comboBox.Height = 24;
            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        public static void AplicarLabel(Label label)
        {
            label.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);
        }
    }
}