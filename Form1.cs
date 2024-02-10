using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Text.Unicode;
using FastColoredTextBoxNS;
using TabStrip;
using static System.Net.Mime.MediaTypeNames;

namespace Notepad
{
    public partial class frmMain : Form
    {

        private Encoding encode = Encoding.Default;

        public frmMain()
        {
            InitializeComponent();
            txt_infoStripStatusLabel1.Text = @$"    Масштаб:{txtMain.Zoom}   |   Синтаксис:{txtMain.Language}";
        }
        /// <summary>
        /// Сохраненные параметры страницы
        /// </summary>
        private PageSettings? savedPageSettings;

        /// <summary>
        /// Открыть файл
        /// Функция вызывает окно, в котором выбирается текстовый файл для открытия в блокноте
        /// и автоматически определяет синтаксис файла по его расширению
        /// </summary>
        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                string? str;
                try
                {
                    StreamReader fr = new(ofdMain.FileName);
                    str = fr.ReadLine();
                    txtMain.Text = str + "\r\n";
                    encode = fr.CurrentEncoding;
                    SetAutoEncode();
                    while (str != null)
                    {
                        str = fr.ReadLine();
                        txtMain.Text = txtMain.Text + str + "\r\n"; ;
                    }
                    string ext = Path.GetExtension(ofdMain.FileName);
                    SetAutoSintax(ext);
                    fr.Close();
                }
                catch (Exception b)
                {
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
                Save(sfdMain.FileName, encode);
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
                Save(ofdMain.FileName, encode);
            }
        }
        private void Save(string FileName, Encoding encoding)
        {
            try
            {
                if (encoding == null) encoding = Encoding.UTF8;
                string read_str = txtMain.Text;
                StreamWriter writer = new(FileName, false, encoding);
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
            System.Windows.Forms.Application.Exit();
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
                    Save(sfdMain.FileName, encode);
                }
            }
            else if (result == DialogResult.No)
            {
                txtMain.Text = "";
            }
        }


        /// <summary>
        /// Новое окно
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
        /// Строка состояния в разработке...
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
            txt_infoStripStatusLabel1.Text = @$"    Масштаб:{txtMain.Zoom}   |   Синтаксис:{txtMain.Language}   |   Кодировка:{encode.HeaderName}";
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
            //RichTextBoxFinds richTextBoxFinds = new RichTextBoxFinds();
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

        private void WrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMain.WordWrap == true)
            {
                txtMain.WordWrap = false;
                WrapToolStripMenuItem.Checked = false;
            }
            else
            {
                txtMain.WordWrap = true;
                WrapToolStripMenuItem.Checked = true;
            }

        }

        private void Scale_defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom = 100;
        }

        private void reduce_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom -= 10;
        }

        private void increase_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom += 10;

        }

        private void Status_BarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stsMain.Visible == true)
            {
                Status_BarToolStripMenuItem.Checked = false;
                stsMain.Visible = false;
            }
            else
            {
                Status_BarToolStripMenuItem.Checked = true;
                stsMain.Visible = true;
            }
        }

        private void Defaul_textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.Custom;
            txtMain.Text = text;
            txtMain.OnTextChanged();
        }

        private void C_SharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.CSharp;
            txtMain.Text = text;
            txtMain.OnTextChanged();
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.HTML;
            txtMain.Text = text;
            txtMain.OnTextChanged();
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.PHP;
            txtMain.Text = text;
            txtMain.OnTextChanged();
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.VB;
            txtMain.Text = text;
            txtMain.OnTextChanged();
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = txtMain.Text;
            txtMain.Language = Language.SQL;
            txtMain.Text = text;
            txtMain.OnTextChanged();
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
        }

        private void SetAutoSintax(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".txt":
                    txtMain.Language = Language.Custom;
                    break;
                case ".cs":
                    txtMain.Language = Language.CSharp;
                    txtMain.WordWrap = false;
                    WrapToolStripMenuItem.Checked = false;
                    break;
                case ".html":
                    txtMain.Language = Language.HTML;
                    txtMain.WordWrap = false;
                    WrapToolStripMenuItem.Checked = false;
                    break;
                case ".php":
                    txtMain.Language = Language.PHP;
                    txtMain.WordWrap = false;
                    WrapToolStripMenuItem.Checked = false;
                    break;
                case ".vb":
                    txtMain.Language = Language.VB;
                    txtMain.WordWrap = false;
                    WrapToolStripMenuItem.Checked = false;
                    break;
                case ".sql":
                    txtMain.Language = Language.SQL;
                    txtMain.WordWrap = false;
                    WrapToolStripMenuItem.Checked = false;
                    break;
                default:
                    txtMain.Language = Language.Custom;
                    break;
            }

            txtMain.OnTextChanged();
        }

        private void SetEncoding(Encoding encoding)
        {
            encode = encoding;
            UpdateStatusStrip();
        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF8);
        }

        private void uTF16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.Unicode);
        }

        private void ASCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.ASCII);
        }

        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF32);
        }

        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF7);
        }

        private void UpdateStatusStrip()
        {
            uTF8ToolStripMenuItem.Checked = (encode == Encoding.UTF8);
            uTF16ToolStripMenuItem.Checked = (encode == Encoding.Unicode);
            ASCIIToolStripMenuItem.Checked = (encode == Encoding.ASCII);
            uTF32ToolStripMenuItem.Checked = (encode == Encoding.UTF32);
            uTF7ToolStripMenuItem.Checked = (encode == Encoding.UTF7);
            txt_infoStripStatusLabel1.Text = @$"    Масштаб:{txtMain.Zoom}   |   Синтаксис:{txtMain.Language}   |   Кодировка:{encode.HeaderName}";
        }

        private void SetAutoEncode()
        {
            switch (encode.HeaderName.ToLower())
            {
                case nameof(Encoding.UTF8):
                    SetEncoding(Encoding.UTF8);
                    break;
                case nameof(Encoding.Unicode):
                    SetEncoding(Encoding.Unicode);
                    break;
                case nameof(Encoding.ASCII):
                    SetEncoding(Encoding.ASCII);
                    break;
                case nameof(Encoding.UTF32):
                    SetEncoding(Encoding.UTF32);
                    break;
                case nameof(Encoding.UTF7):
                    SetEncoding(Encoding.UTF7);
                    break;
                default:
                    SetEncoding(Encoding.UTF8);
                    break;
            }
        }

        
    }
}