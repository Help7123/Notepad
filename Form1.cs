using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using FastColoredTextBoxNS;


namespace Notepad
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Сохраненная кодировка
        /// </summary>
        private Encoding encode = Encoding.Default;
        
        /// <summary>
        /// Счетчик открытых вкладок
        /// </summary>
        private int i = 1;
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
        /// Функция вызывает окно, в котором выбирается текстовый файл для открытия в блокноте,
        /// автоматически определяет синтаксис и кодировку файла по его расширению
        /// Устанавливает путь к файлу в заголовок окна и открывает его в новой вкладке
        /// </summary>
        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                string? str;

                try
                {
                    StreamReader fr = new(ofdMain.FileName);
                    string filename = System.IO.Path.GetFileNameWithoutExtension(ofdMain.FileName);
                    TabPage newTabPage = new TabPage();
                    newTabPage.Text = $"{filename}";
                    tabControl.TabPages.Add(newTabPage);
                    FastColoredTextBoxNS.FastColoredTextBox txtMain = new FastColoredTextBoxNS.FastColoredTextBox();
                    txtMain.Dock = DockStyle.Fill;
                    newTabPage.Controls.Add(txtMain);
                    tabControl.SelectedTab = newTabPage;
                    txtMain.TextChanged += txtMain_TextChanged;
                    if (ofdMain.FileName != null && ofdMain.FileName != "openFileDialog1") { this.Text = $"{ofdMain.FileName}   Блокнот"; }
                    else { this.Text = $"Новый {i}   Блокнот"; }
                    str = fr.ReadLine();
                    txtMain.Text = str + "\r\n";
                    encode = fr.CurrentEncoding;
                    SetAutoEncode();
                    while (str != null)
                    {
                        str = fr.ReadLine();
                        txtMain.Text += str + "\r\n"; ;
                    }
                    string ext = Path.GetExtension(ofdMain.FileName);
                    SetAutoSyntax(ext);
                    fr.Close();

                }
                catch (Exception b)
                {
                    Console.WriteLine(b.Message);
                }
                i++;
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
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            e.Graphics.DrawString(txtMain.Text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }


        /// <summary>
        /// Создать
        /// Открывает новй файл в новой вкладке
        /// </summary>
        private void tsmCreate_Click(object sender, EventArgs e)
        {
            TabPage newTabPage = new TabPage();
            newTabPage.Text = $"Новый {i}";
            tabControl.TabPages.Add(newTabPage);
            FastColoredTextBoxNS.FastColoredTextBox txtMain = new FastColoredTextBoxNS.FastColoredTextBox();
            txtMain.Dock = DockStyle.Fill;
            newTabPage.Controls.Add(txtMain);
            tabControl.SelectedTab = newTabPage;
            txtMain.TextChanged += txtMain_TextChanged;
            this.Text = $"Новый {i}    Блокнот";
            i++;

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
        /// Строка состояния показывает информацию об окне
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            UndoToolStripMenuItem.Enabled = true;
            if (txtMain.Language == null) { txtMain.Language = Language.Custom; }
            if (ofdMain.FileName != null && ofdMain.FileName != "openFileDialog1")
                this.Text = $"{ofdMain.FileName}   Блокнот";
            else this.Text = $"Новый  {i}   Блокнот";

            toolStripStatusLabel1.Text = @$"    Масштаб:{txtMain.Zoom}   |   Синтаксис:{txtMain.Language}";
            i++;
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
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
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
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            txtMain.Text += DateTime.Now;
        }


        /// <summary>
        /// шрифт
        /// При нажатие на кнопку, открывается меню шрифтов Textbox
        /// </summary>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            FontDialog myFontDialog = new FontDialog();
            if (myFontDialog.ShowDialog() == DialogResult.OK)
            {
                txtMain.Font = myFontDialog.Font;
            }
        }

        /// <summary>
        /// Перенос по словам
        /// Включает перенос слов, если они не влазят в окно программы
        /// </summary>
        private void WrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
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

        /// <summary>
        /// Восстановить масштаб по умолчанию
        /// Устанавливает масштаб на 100%
        /// </summary>
        private void Scale_defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? textBox = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            textBox.Zoom = 100;
        }

        /// <summary>
        /// Уменьшить
        /// Уменьшаем масштаб на 10%
        /// </summary>
        private void reduce_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? textBox = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            textBox.Zoom -= 10;
        }

        /// <summary>
        /// Увеличить
        /// Увеличивает масштаб на 10%
        /// </summary>
        private void increase_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? textBox = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            textBox.Zoom += 10;

        }

        /// <summary>
        /// Строка состояния
        /// Включает/Отключает отображение строки состояния
        /// </summary>
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

        /// <summary>
        /// Вспомогательная функция для установки синтаксиса TextBox и установление
        /// параметра Checked у нужного пункта в меню Синтаксис
        /// </summary>
        private void SetLanguage(Language language, TabPage tabPage)
        {
            FastColoredTextBoxNS.FastColoredTextBox? textBox = tabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            textBox.Language = language;
            textBox.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
            C_SharpToolStripMenuItem.Checked = (textBox.Language == Language.CSharp);
            hTMLToolStripMenuItem.Checked = (textBox.Language == Language.HTML);
            pHPToolStripMenuItem.Checked = (textBox.Language == Language.PHP);
            vBToolStripMenuItem.Checked = (textBox.Language == Language.VB);
            sQLToolStripMenuItem.Checked = (textBox.Language == Language.SQL);
            Defaul_textToolStripMenuItem.Checked = (textBox.Language == Language.Custom);
            textBox.OnTextChanged();
        }

        /// <summary>
        /// Обычный текст
        /// Устанавливает Синтаксис на Обычный текст
        /// </summary>
        private void Defaul_textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.Custom, openedTabPage);
        }

        /// <summary>
        /// C#
        /// Устанавливает Синтаксис на C#
        /// </summary>
        private void C_SharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.CSharp, openedTabPage);
        }

        /// <summary>
        /// HTML
        /// Устанавливает Синтаксис на HTML
        /// </summary>
        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.HTML, openedTabPage);
        }

        /// <summary>
        /// PHP
        /// Устанавливает Синтаксис на PHP
        /// </summary>
        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.PHP, openedTabPage);
        }

        /// <summary>
        /// VB
        /// Устанавливает Синтаксис на VB
        /// </summary>
        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.VB, openedTabPage);
        }

        /// <summary>
        /// SQL
        /// Устанавливает Синтаксис на SQL
        /// </summary>
        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetLanguage(Language.SQL, openedTabPage);
        }

        /// <summary>
        /// Функция для автоматической установки синтаксиса по расширению файла
        /// </summary>
        private void SetAutoSyntax(string fileExtension)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            switch (fileExtension.ToLower())
            {
                case ".cs":
                    SetLanguage(Language.CSharp, openedTabPage);
                    break;
                case ".html":
                    SetLanguage(Language.HTML, openedTabPage);
                    break;
                case ".php":
                    SetLanguage(Language.PHP, openedTabPage);
                    break;
                case ".vb":
                    SetLanguage(Language.VB, openedTabPage);
                    break;
                case ".sql":
                    SetLanguage(Language.SQL, openedTabPage);
                    break;
                default:
                    SetLanguage(Language.Custom, openedTabPage);
                    break;
            }
        }

        /// <summary>
        /// Вспомогательная функция для установки кодировки TextBox и установление
        /// параметра Checked у нужного пункта в меню Кодировка
        /// </summary>
        private void SetEncoding(Encoding encoding, TabPage tabPage)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            FastColoredTextBoxNS.FastColoredTextBox? txtMain = openedTabPage.Controls.OfType<FastColoredTextBoxNS.FastColoredTextBox>().FirstOrDefault();
            UndoToolStripMenuItem.Enabled = true;
            encode = encoding;
            uTF8ToolStripMenuItem.Checked = (encode == Encoding.UTF8);
            uTF16ToolStripMenuItem.Checked = (encode == Encoding.Unicode);
            ASCIIToolStripMenuItem.Checked = (encode == Encoding.ASCII);
            uTF32ToolStripMenuItem.Checked = (encode == Encoding.UTF32);
            uTF7ToolStripMenuItem.Checked = (encode == Encoding.UTF7);
            toolStripStatusLabel1.Text = @$"    Масштаб:{txtMain.Zoom}   |   Синтаксис:{txtMain.Language}";
        }

        /// <summary>
        /// UTF8
        /// Устанавливает кодировку на UTF8
        /// </summary>
        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetEncoding(Encoding.UTF8, openedTabPage);
        }

        /// <summary>
        /// UTF16
        /// Устанавливает кодировку на UTF-16
        /// </summary>
        private void uTF16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetEncoding(Encoding.Unicode, openedTabPage);
        }

        /// <summary>
        /// ASCII
        /// Устанавливает кодировку на ASCII
        /// </summary>
        private void ASCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetEncoding(Encoding.ASCII, openedTabPage);
        }

        /// <summary>
        /// UTF32
        /// Устанавливает кодировку на UTF32
        /// </summary>
        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetEncoding(Encoding.UTF32, openedTabPage);
        }

        /// <summary>
        /// UTF7
        /// Устанавливает кодировку на UTF7
        /// </summary>
        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            SetEncoding(Encoding.UTF7, openedTabPage);
        }

        /// <summary>
        /// Функция для автоматической установки кодировки открытого файла
        /// </summary>
        private void SetAutoEncode()
        {
            TabPage openedTabPage = tabControl.SelectedTab;
            switch (encode.HeaderName.ToLower())
            {
                case nameof(Encoding.UTF8):
                    SetEncoding(Encoding.UTF8, openedTabPage);
                    break;
                case nameof(Encoding.Unicode):
                    SetEncoding(Encoding.Unicode, openedTabPage);
                    break;
                case nameof(Encoding.ASCII):
                    SetEncoding(Encoding.ASCII, openedTabPage);
                    break;
                case nameof(Encoding.UTF32):
                    SetEncoding(Encoding.UTF32, openedTabPage);
                    break;
                case nameof(Encoding.UTF7):
                    SetEncoding(Encoding.UTF7, openedTabPage);
                    break;
                default:
                    SetEncoding(Encoding.UTF8, openedTabPage);
                    break;
            }
        }

        /// <summary>
        ///Закрыть файл
        ///Закрывает и сохраняет файл в открытой вкладке
        /// </summary>
        private void Close_fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdMain.FileName != null && ofdMain.FileName != "openFileDialog1")
            {
                Save(ofdMain.FileName, encode);
            }
            else if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                Save(sfdMain.FileName, encode);
            }
            TabPage openedTabPage = tabControl.SelectedTab;
            tabControl.TabPages.Remove(openedTabPage);
        }
    }
}