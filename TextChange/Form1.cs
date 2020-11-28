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
		string color/*, welcome = "Привет, чёрт)\r\nЧё как?\r\nНаше знакомство как-то не заладилось, но теперь ты можешь изменять меня полностью)\r\n\r\nИЗМЕНЯЙ МЕНЯ ПОЛНОСТЬЮ!!!" +
			"\r\n\r\nКнопка сохранить позволяет сохранить файл.txt на рабочий стол!!!\r\nЯ теперь почти блокнот)\r\n\r\n\r\n©\"LOLisCorporation\""*/;
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

			radioButton1.CheckedChanged += (a, e) =>
			{
				if (radioButton1.Checked) comboBox1.Visible = true;
				else
				{
					comboBox1.Visible = false;
					try
					{
						style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
						size = comboBox1.Text == "" ? 8 : Convert.ToInt32(comboBox1.Text);
						Check_style();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + "\n Ай-яй-яй!!! Пиши сюда только цифры) а про 0 забудь вообще...", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
						size = 8;
					}
				}					
			};
			radioButton2.CheckedChanged += (a, e) =>
			{
				if (radioButton2.Checked) comboBox2.Visible = true;
				else
				{
					comboBox2.Visible = false;
					style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
					Check_style();
				} 
			};
			radioButton3.CheckedChanged += (a, e) =>
			{
				if (radioButton3.Checked) comboBox3.Visible = true;
				else
				{
					comboBox3.Visible = false;
					color = comboBox3.SelectedItem == null ? "Black" : comboBox3.SelectedItem.ToString();
					Check_color();
				}
			};
			radioButton4.CheckedChanged += (a, e) =>
			{
				if (radioButton4.Checked) comboBox4.Visible = true;
				else
				{
					comboBox4.Visible = false;
					style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
					font = comboBox4.SelectedItem == null ? "Microsoft Sans Serif" : comboBox4.SelectedItem.ToString();
					Check_style();
				}
			};
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

		async void Form1_Load(object sender, EventArgs e)
		{
			for (double i = 0; i <= 1; i += 0.01)
			{
				Opacity = i;
				await Task.Delay(10);
			}
			size = 8;
			font = "Microsoft Sans Serif";

			/*char[] arr = welcome.ToCharArray();
			for (int i = 0; i < arr.Length; i++)
			{
				textBox1.Text += arr[i].ToString();
				await Task.Delay(50);
			}*/
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
				bool flag = true;
				do
				{
					num_file++;
					save_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
					if (!File.Exists($"{save_path + "\\"}File_{num_file}.txt"))
					{
						using (FileStream fstream = new FileStream($"{save_path + "\\"}File_{num_file}.txt", FileMode.OpenOrCreate))
						{
							byte[] array = System.Text.Encoding.UTF8.GetBytes(textBox1.Text);
							fstream.Write(array, 0, array.Length);
						}
						flag = false;
						MessageBox.Show("Сохранено", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

				} while (flag);
			}
			catch (Exception)
			{
				MessageBox.Show("Упс, что-то пошло не так и теперь твоя motherboard сгорела... Ха-ха, шутка)",
					"Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		private void textBox1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}

		}

		private void textBox1_DragDrop(object sender, DragEventArgs e)
		{
			string[] read = (string[])e.Data.GetData(DataFormats.FileDrop);
			string files = read[0].ToString();
			using (FileStream file = File.OpenRead(files))
			{
				using (StreamReader streamReader = new StreamReader(file, System.Text.Encoding.UTF8))
				{
					textBox1.Text = streamReader.ReadToEnd();
				}
			}
		}

		private void textBox1_Click(object sender, EventArgs e)
		{
			try
			{
				style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
				size = comboBox1.Text == "" ? 8 : Convert.ToInt32(comboBox1.Text);
				Check_style();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n Ай-яй-яй!!! Пиши сюда только цифры) а про 0 забудь вообще...", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
				size = 8;
			}
			style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
			color = comboBox3.SelectedItem == null ? "Black" : comboBox3.SelectedItem.ToString();
			font = comboBox4.SelectedItem == null ? "Microsoft Sans Serif" : comboBox4.SelectedItem.ToString();
			Check_style();
			Check_color();
		}
	}
}
