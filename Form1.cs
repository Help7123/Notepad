using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Notepad
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Сохраненные параметры страницы
        /// </summary>
        private PageSettings? savedPageSettings;

        /// <summary>
        /// Открыть файл
        /// Функция вызывает окно, в котором выбирается текстовый файл для открытия в блокноте
        /// </summary>
        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                string? str;
                try
                {
                    StreamReader fr = new(ofdMain.FileName);
                    Console.WriteLine("Содержание файла:");
                    str = fr.ReadLine();
                    txtMain.Text = str + "\r\n";
                    while (str != null)
                    {
                        Console.WriteLine(str);
                        str = fr.ReadLine();
                        txtMain.Text = txtMain.Text + str + "\r\n"; ;
                    }
                    fr.Close();
                }
                catch (Exception b)
                {
                    Console.WriteLine("Произошла ошибка!");
                    Console.WriteLine(b.Message);
                }



            }
        }


        /// <summary>
        /// Сохранить как...
        /// Функция вызывает окно, сохранения файла как, где можно выбрать путь, где будет сохранен файл и его название
        /// </summary>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                Save(sfdMain.FileName);
            }
        }

        /// <summary>
        /// Сохранить
        /// Функция проверяет, есть ли название у файла, если оно есть, то файл сохраняется там же, где и лежал, в противном случае вызовется функция "Сохранить как..."
        /// </summary>
        private void tsmSave_Click(object sender, EventArgs e)
        {
            if (ofdMain.FileName != null)
            {
                Save(ofdMain.FileName);
            }
        }
        private void Save(string FileName)
        {
            try
            {
                string read_str = txtMain.Text;
                StreamWriter writer = new(FileName);
                writer.WriteLine(read_str);
                writer.Close();
            }
            catch (Exception b)
            {
                Console.WriteLine("Произошла ошибка!");
                Console.WriteLine(b.Message);
            }
        }


        /// <summary>
        /// Выход
        /// При нажатие на кнопку, закрывает окно
        /// </summary>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Печать
        /// При нажатие на кнопку, вызывается окно печати
        /// </summary>
        private void print_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            if (savedPageSettings != null)
            {
                printDocument.DefaultPageSettings = savedPageSettings;
            }
            printDocument.PrintPage += PrintPageHandler;
            prdMain.Document = printDocument;
            if (prdMain.ShowDialog() == DialogResult.OK)
            {
                prdMain.Document.Print();
            }
        }


        /// <summary>
        /// Обработчик события печали, который выставляет странице шрифт, размер и цвет текста
        /// </summary>
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtMain.Text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }


        /// <summary>
        /// Сохранить
        /// При нажатие на кнопку вызывается окно, где спрашивается, "Вы хотите сохранить изменения?", в случае положительного ответа, вызывается функция "Сохранить"
        /// Если сохранять не надо, то текст в txtMain затирается
        /// </summary>
        private void tsmCreate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                if (sfdMain.ShowDialog() == DialogResult.OK)
                {
                    Save(sfdMain.FileName);
                }
            }
            else if (result == DialogResult.No)
            {
                txtMain.Text = "";
            }
        }


        /// <summary>
        /// Сохранить
        /// При нажатие на кнопку вызывается новое окно блокнота
        /// </summary>
        private void tsmNewWindow_Click(object sender, EventArgs e)
        {
            frmMain newForm = new frmMain();
            newForm.Show();
        }


        /// <summary>
        /// Параметры страницы
        /// При нажатие на кнопку вызывается окно параметров страницы, которые сохраняются в savedPageSettings
        /// </summary>
        private void PagerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            PrintDocument printDocument = new PrintDocument();
            pageSetupDialog.Document = printDocument;
            DialogResult result = pageSetupDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                savedPageSettings = pageSetupDialog.PageSettings;
            }
        }

        /// <summary>
        /// Отменить
        /// При нажатие на кнопку вызывается операция отмена, аналогичная Ctrl+Z
        /// </summary>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        /// <summary>
        /// При изменение txtMain включает кнопку Отменить
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
        }


        /// <summary>
        /// Вырезать
        /// При нажатие на кнопку, функция вырезает выделенный текст
        /// </summary>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Cut();
        }


        /// <summary>
        /// Копировать
        /// При нажатие на кнопку, функция копирует выделенный текст
        /// </summary>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMain.SelectedText);
        }


        /// <summary>
        /// Вставить
        /// При нажатие на кнопку, функция вставляет текст и буфера обмена
        /// </summary>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Paste();
        }


        /// <summary>
        /// Удалить
        /// При нажатие на кнопку, функция удаляет выделенный текст
        /// </summary>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectedText = "";
        }


        /// <summary>
        /// Поиск в интернете
        /// При нажатие на кнопку, функция открывает браузер с поиском выделенного текста
        /// </summary>
        private void Find_on_InternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMain.SelectionLength > 0)
                Process.Start(new ProcessStartInfo($@"https://www.google.ru/search?source=hp&q={txtMain.SelectedText}&num=100") { UseShellExecute = true });
        }


        /// <summary>
        /// Найти
        /// В разработке...
        /// </summary>
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds richTextBoxFinds = new RichTextBoxFinds();
        }


        /// <summary>
        /// Выбрать всё
        /// При нажатие на кнопку, выделяет весь текст в TextBox
        /// </summary>
        private void SellectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }


        /// <summary>
        /// Дата и время
        /// При нажатие на кнопку, вставляет дату и время в Textbox
        /// </summary>
        private void DateandTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Text += DateTime.Now;
        }


        /// <summary>
        /// шрифт
        /// При нажатие на кнопку, открывается меню шрифтов Textbox
        /// </summary>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFontDialog = new FontDialog();
            if (myFontDialog.ShowDialog() == DialogResult.OK)
            {
                txtMain.Font = myFontDialog.Font;
            }
        }
    }
}