using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
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
						size = comboBox1.Text == "" ? 14 : Convert.ToInt32(comboBox1.Text);
						Check_style();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + "\n Ай-яй-яй!!! Пиши сюда только цифры) а про 0 забудь вообще...", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
						size = 14;
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
			button4.Click += (a, e) =>
			{
				try
				{
					Clipboard.SetText(textBox1.Text);
				}
				catch (Exception)
				{
					MessageBox.Show("Копировать нечего, не жмякай на кнопки просто так...", "Копировать", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			};
			button5.Click += (a, e) =>
			{
				textBox1.Clear();
				textBox1.Focus();
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
			size = 14;
			font = "Microsoft Sans Serif";

			/*char[] arr = welcome.ToCharArray();
			for (int i = 0; i < arr.Length; i++)
			{
				textBox1.Text += arr[i].ToString();
				await Task.Delay(50);
			}*/
		}

		async void button2_Click(object sender, EventArgs e)
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
				button4.BackColor = SystemColors.ControlLight;
				button4.ForeColor = SystemColors.ControlText;
				button5.BackColor = SystemColors.ControlLight;
				button5.ForeColor = SystemColors.ControlText;
				button6.BackColor = SystemColors.ControlLight;
				button6.ForeColor = SystemColors.ControlText;
				button2.Text = "Dark Mode";
				for (byte r = 0, g = 0, b = 0; r <= 240 && g <= 240 && b <= 240; r += 10, g += 10, b += 10)
				{
					button1.BackColor = Color.FromArgb(r, g, b);
					await Task.Delay(1);
				}
				button1.Text = "";
				button1.Enabled = false;
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
				button4.BackColor = SystemColors.ControlText;
				button4.ForeColor = Color.LawnGreen;
				button5.BackColor = SystemColors.ControlText;
				button5.ForeColor = Color.LawnGreen;
				button6.BackColor = SystemColors.ControlText;
				button6.ForeColor = Color.LawnGreen;
				button2.Text = "White Mode";
				for (byte r = 64, g = 64, b = 64; r > 0 && g > 0 && b > 0; r -= 2, g -= 2, b -= 2)
				{
					button1.BackColor = Color.FromArgb(r, g, b);
					await Task.Delay(1);
				}
				button1.Text = "Пробить IP";
				button1.Enabled = true;
				button1.ForeColor = Color.LawnGreen;
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
				size = comboBox1.Text == "" ? 14 : Convert.ToInt32(comboBox1.Text);
				Check_style();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n Ай-яй-яй!!! Пиши сюда только цифры) а про 0 забудь вообще...", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);
				size = 14;
			}
			style = comboBox2.SelectedItem == null ? "Обычный" : comboBox2.SelectedItem.ToString();
			color = comboBox3.SelectedItem == null ? "Black" : comboBox3.SelectedItem.ToString();
			font = comboBox4.SelectedItem == null ? "Microsoft Sans Serif" : comboBox4.SelectedItem.ToString();
			Check_style();
			Check_color();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (WebClient wc = new WebClient())
			{
				string ip_info = wc.DownloadString($"http://ip-api.com/xml/{textBox1.Text}");
				Match match = Regex.Match(ip_info, "<country>(.*?)</country>");
				Match match2 = Regex.Match(ip_info, "<regionName>(.*?)</regionName>");
				Match match3 = Regex.Match(ip_info, "<city>(.*?)</city>");
				Match match4 = Regex.Match(ip_info, "<lat>(.*?)</lat>");
				Match match5 = Regex.Match(ip_info, "<lon>(.*?)</lon>");
				Match match6 = Regex.Match(ip_info, "<query>(.*?)</query>");
				textBox1.Text = match.Groups[1].Value + "\r\n" + match2.Groups[1].Value + "\r\n" + match3.Groups[1].Value + "\r\n" + match4.Groups[1].Value + "\r\n" + match5.Groups[1].Value + "\r\n" + match6.Groups[1].Value;
				textBox1.Focus();
			}
		}
		ToolTip toolTip = new ToolTip();
		private void button1_MouseHover(object sender, EventArgs e)
		{
			toolTip.Show("Чтобы узнать инфорацию об IP введите его в текстовое поле и нажмите F1 (или кнопку)", button1);
		}
		private void button1_MouseLeave(object sender, EventArgs e)
		{
			toolTip.Hide(button1);
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
			{
				button1_Click(button1, null);
			}

		}

		private void button6_Click(object sender, EventArgs e)
		{
			using (WebClient wc = new WebClient())
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
							wc.DownloadFile("https://github.com/FoxRed-cmd/TextChange/raw/main/TextChange/bin/Release/TextChange.exe", $"{save_path + "\\"}TextChange{num_file}.exe");
							flag = false;
							MessageBox.Show("Обновление загружено", "Обновить", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					} while (flag);
				}
				catch (Exception)
				{
					MessageBox.Show("Упс, что-то пошло не так и теперь твоя motherboard сгорела... Ха-ха, шутка)",
						"Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				
			}
		}
	}
}
