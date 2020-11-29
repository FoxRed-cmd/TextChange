using System.Drawing;
using System.Windows.Forms;

namespace TextChange
{
	public static class Tem
	{
		public static void DarkButton(this Button button)
		{
			button.BackColor = SystemColors.ControlText;
			button.ForeColor = Color.LawnGreen;
		}
		public static void DarkComboBox(this ComboBox comboBox)
		{
			comboBox.BackColor = Color.FromArgb(64, 64, 64);
			comboBox.ForeColor = Color.LawnGreen;
		}
		public static void WhiteButton(this Button button)
		{
			button.BackColor = SystemColors.ControlLight;
			button.ForeColor = SystemColors.ControlText;
		}
		public static void WhiteComboBox(this ComboBox comboBox)
		{
			comboBox.BackColor = SystemColors.Window;
			comboBox.ForeColor = SystemColors.WindowText;
		}
	}
}
