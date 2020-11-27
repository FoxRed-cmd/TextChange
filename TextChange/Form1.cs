using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextChange
{
	public partial class Form1 : Form
	{
		int size;
		string font;
		string style;
		string color;
		long count;
		long num_file;
		string save_path;

		public Form1()
		{
			InitializeComponent();
			count = 0;
			Text = "Блокнотик";
			groupBox1.Text = "Параметры";
			radioButton1.Text = "Размер";
			radioButton2.Text = "Стиль";
			radioButton3.Text = "Цвет";
			radioButton4.Text = "Шрифт";
			button1.Text = "Выполнить";
		}

		async void Form1_Load(object sender, EventArgs e)
		{
			for (double i = 0; i <= 1; i += 0.01)
			{
				Opacity = i;
				await Task.Delay(10);
			}
			size = 8;
			font = "Microsoft Sans Serif";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
			color = comboBox3.SelectedItem == null ? "Black" : comboBox3.SelectedItem.ToString();

			if (radioButton1.Checked)
			{
				size = Convert.ToInt32(comboBox1.Text);
				textBox1.Font = new Font(font, size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));

			}

			else if (radioButton2.Checked)
			{
				Check_style();
			}

			else if (radioButton3.Checked)
			{
				Check_color();
			}

			else
			{
				font = comboBox4.SelectedItem == null ? "Microsoft Sans Serif" : comboBox4.SelectedItem.ToString();
				textBox1.Font = new Font(font, size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
			}

			void Check_color()
			{
				if (color == "Красный")
				{
					textBox1.ForeColor = Color.Red;
				}
				else if (color == "Зелёный")
				{
					textBox1.ForeColor = Color.Green;
				}
				else if (color == "Синий")
				{
					textBox1.ForeColor = Color.Blue;
				}
			}
			void Check_style()
			{
				if (style == "Обычный")
				{

					textBox1.Font = new Font(font, size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
				}
				else if (style == "Полужирный")
				{
					textBox1.Font = new Font(font, size, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
				}
				else if (style == "Курсив")
				{
					textBox1.Font = new Font(font, size, FontStyle.Italic, GraphicsUnit.Point, ((byte)(204)));
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			count++;

			if (count % 2 == 0)
			{
				BackColor = SystemColors.Control;
				ForeColor = SystemColors.ControlText;
				groupBox1.BackColor = SystemColors.Control;
				groupBox1.ForeColor = SystemColors.ControlText;
				textBox1.BackColor = SystemColors.Window;
				textBox1.ForeColor = SystemColors.WindowText;
				comboBox1.BackColor = SystemColors.Window;
				comboBox2.BackColor = SystemColors.Window;
				comboBox3.BackColor = SystemColors.Window;
				comboBox4.BackColor = SystemColors.Window;
				comboBox1.ForeColor = SystemColors.WindowText;
				comboBox2.ForeColor = SystemColors.WindowText;
				comboBox3.ForeColor = SystemColors.WindowText;
				comboBox4.ForeColor = SystemColors.WindowText;
				button1.BackColor = SystemColors.ControlLight;
				button1.ForeColor = SystemColors.ControlText;
				button2.BackColor = SystemColors.ControlLight;
				button2.ForeColor = SystemColors.ControlText;
				button3.BackColor = SystemColors.ControlLight;
				button3.ForeColor = SystemColors.ControlText;
				button2.Text = "Dark Mode";
			}
			else
			{
				BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
				ForeColor = SystemColors.ButtonHighlight;
				groupBox1.BackColor = SystemColors.ControlText;
				groupBox1.ForeColor = Color.LawnGreen;
				textBox1.BackColor = SystemColors.ControlText;
				textBox1.ForeColor = Color.LawnGreen;
				comboBox1.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
				comboBox2.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
				comboBox3.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
				comboBox4.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
				comboBox1.ForeColor = Color.LawnGreen;
				comboBox2.ForeColor = Color.LawnGreen;
				comboBox3.ForeColor = Color.LawnGreen;
				comboBox4.ForeColor = Color.LawnGreen;
				button1.BackColor = SystemColors.ControlText;
				button1.ForeColor = Color.LawnGreen;
				button2.BackColor = SystemColors.ControlText;
				button2.ForeColor = Color.LawnGreen;
				button3.BackColor = SystemColors.ControlText;
				button3.ForeColor = Color.LawnGreen;
				button2.Text = "White Mode";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				num_file++;
				save_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				using (FileStream fstream = new FileStream($"{save_path + "\\"}File_{num_file}.txt", FileMode.OpenOrCreate))
				{
					byte[] array = System.Text.Encoding.Default.GetBytes(textBox1.Text);
					fstream.Write(array, 0, array.Length);
				}
				MessageBox.Show("Сохранено", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				MessageBox.Show("Упс, что-то пошло не так и теперь твоя motherboard сгорела... Ха-ха, шутка)",
					"Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				comboBox1.Visible = true;
			}
			else
			{
				comboBox1.Visible = false;
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				comboBox2.Visible = true;
			}
			else
			{
				comboBox2.Visible = false;
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				comboBox3.Visible = true;
			}
			else
			{
				comboBox3.Visible = false;
			}
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton4.Checked)
			{
				comboBox4.Visible = true;
			}
			else
			{
				comboBox4.Visible = false;
			}
		}
	}
}
