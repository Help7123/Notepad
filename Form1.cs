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
        /// <summary>
        /// ����������� ���������
        /// </summary>
        private Encoding encode = Encoding.Default;

        public frmMain()
        {
            InitializeComponent();
            txt_infoStripStatusLabel1.Text = @$"    �������:{txtMain.Zoom}   |   ���������:{txtMain.Language}";
        }
        /// <summary>
        /// ����������� ��������� ��������
        /// </summary>
        private PageSettings? savedPageSettings;

        /// <summary>
        /// ������� ����
        /// ������� �������� ����, � ������� ���������� ��������� ���� ��� �������� � ��������
        /// � ������������� ���������� ��������� ����� �� ��� ����������
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
                    SetAutoSyntax(ext);
                    fr.Close();
                }
                catch (Exception b)
                {
                    Console.WriteLine(b.Message);
                }
            }
        }




        /// <summary>
        /// ��������� ���...
        /// ������� �������� ����, ���������� ����� ���, ��� ����� ������� ����, ��� ����� �������� ���� � ��� ��������
        /// </summary>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                Save(sfdMain.FileName, encode);
            }
        }

        /// <summary>
        /// ���������
        /// ������� ���������, ���� �� �������� � �����, ���� ��� ����, �� ���� ����������� ��� ��, ��� � �����, � ��������� ������ ��������� ������� "��������� ���..."
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
                Console.WriteLine("��������� ������!");
                Console.WriteLine(b.Message);
            }
        }


        /// <summary>
        /// �����
        /// ��� ������� �� ������, ��������� ����
        /// </summary>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        /// <summary>
        /// ������
        /// ��� ������� �� ������, ���������� ���� ������
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
        /// ���������� ������� ������, ������� ���������� �������� �����, ������ � ���� ������
        /// </summary>
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtMain.Text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }


        /// <summary>
        /// ���������
        /// ��� ������� �� ������ ���������� ����, ��� ������������, "�� ������ ��������� ���������?", � ������ �������������� ������, ���������� ������� "���������"
        /// ���� ��������� �� ����, �� ����� � txtMain ����������
        /// </summary>
        private void tsmCreate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�� ������ ��������� ���������?", "����������", MessageBoxButtons.YesNoCancel);

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
        /// ����� ����
        /// ��� ������� �� ������ ���������� ����� ���� ��������
        /// </summary>
        private void tsmNewWindow_Click(object sender, EventArgs e)
        {
            frmMain newForm = new frmMain();
            newForm.Show();
        }


        /// <summary>
        /// ��������� ��������
        /// ��� ������� �� ������ ���������� ���� ���������� ��������, ������� ����������� � savedPageSettings
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
        /// ��������
        /// ��� ������� �� ������ ���������� �������� ������, ����������� Ctrl+Z
        /// </summary>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        /// <summary>
        /// ��� ��������� txtMain �������� ������ ��������
        /// ������ ��������� ���������� ���������� �� ����
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
            txt_infoStripStatusLabel1.Text = @$"    �������:{txtMain.Zoom}   |   ���������:{txtMain.Language}   |   ���������:{encode.HeaderName}";
        }


        /// <summary>
        /// ��������
        /// ��� ������� �� ������, ������� �������� ���������� �����
        /// </summary>
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Cut();
        }


        /// <summary>
        /// ����������
        /// ��� ������� �� ������, ������� �������� ���������� �����
        /// </summary>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMain.SelectedText);
        }


        /// <summary>
        /// ��������
        /// ��� ������� �� ������, ������� ��������� ����� � ������ ������
        /// </summary>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Paste();
        }


        /// <summary>
        /// �������
        /// ��� ������� �� ������, ������� ������� ���������� �����
        /// </summary>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectedText = "";
        }


        /// <summary>
        /// ����� � ���������
        /// ��� ������� �� ������, ������� ��������� ������� � ������� ����������� ������
        /// </summary>
        private void Find_on_InternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMain.SelectionLength > 0)
                Process.Start(new ProcessStartInfo($@"https://www.google.ru/search?source=hp&q={txtMain.SelectedText}&num=100") { UseShellExecute = true });
        }


        /// <summary>
        /// �����
        /// � ����������...
        /// </summary>
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RichTextBoxFinds richTextBoxFinds = new RichTextBoxFinds();
        }


        /// <summary>
        /// ������� ��
        /// ��� ������� �� ������, �������� ���� ����� � TextBox
        /// </summary>
        private void SellectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }


        /// <summary>
        /// ���� � �����
        /// ��� ������� �� ������, ��������� ���� � ����� � Textbox
        /// </summary>
        private void DateandTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Text += DateTime.Now;
        }


        /// <summary>
        /// �����
        /// ��� ������� �� ������, ����������� ���� ������� Textbox
        /// </summary>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFontDialog = new FontDialog();
            if (myFontDialog.ShowDialog() == DialogResult.OK)
            {
                txtMain.Font = myFontDialog.Font;
            }
        }

        /// <summary>
        /// ������� �� ������
        /// �������� ������� ����, ���� ��� �� ������ � ���� ���������
        /// </summary>
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

        /// <summary>
        /// ������������ ������� �� ���������
        /// ������������� ������� �� 100%
        /// </summary>
        private void Scale_defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom = 100;
        }

        /// <summary>
        /// ���������
        /// ��������� ������� �� 10%
        /// </summary>
        private void reduce_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom -= 10;
        }

        /// <summary>
        /// ���������
        /// ����������� ������� �� 10%
        /// </summary>
        private void increase_the_ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Zoom += 10;

        }

        /// <summary>
        /// ������ ���������
        /// ��������/��������� ����������� ������ ���������
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
        /// ��������������� ������� ��� ��������� ���������� TextBox � ������������
        /// ��������� Checked � ������� ������ � ���� ���������
        /// </summary>
        private void SetLanguage(Language language)
        {
            txtMain.Language = language;
            txtMain.WordWrap = false;
            WrapToolStripMenuItem.Checked = false;
            C_SharpToolStripMenuItem.Checked = (txtMain.Language == Language.CSharp);
            hTMLToolStripMenuItem.Checked = (txtMain.Language == Language.HTML);
            pHPToolStripMenuItem.Checked = (txtMain.Language == Language.PHP);
            vBToolStripMenuItem.Checked = (txtMain.Language == Language.VB);
            sQLToolStripMenuItem.Checked = (txtMain.Language == Language.SQL);
            Defaul_textToolStripMenuItem.Checked = (txtMain.Language == Language.Custom);
            txtMain.OnTextChanged();   
        }

        /// <summary>
        /// ������� �����
        /// ������������� ��������� �� ������� �����
        /// </summary>
        private void Defaul_textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.Custom);
        }

        /// <summary>
        /// C#
        /// ������������� ��������� �� C#
        /// </summary>
        private void C_SharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.CSharp);
        }

        /// <summary>
        /// HTML
        /// ������������� ��������� �� HTML
        /// </summary>
        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.HTML);
        }

        /// <summary>
        /// PHP
        /// ������������� ��������� �� PHP
        /// </summary>
        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.PHP);
        }

        /// <summary>
        /// VB
        /// ������������� ��������� �� VB
        /// </summary>
        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.VB);
        }

        /// <summary>
        /// SQL
        /// ������������� ��������� �� SQL
        /// </summary>
        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(Language.SQL);
        }

        /// <summary>
        /// ������� ��� �������������� ��������� ���������� �� ���������� �����
        /// </summary>
        private void SetAutoSyntax(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".cs":
                    SetLanguage(Language.CSharp);
                    break;
                case ".html":
                    SetLanguage(Language.HTML);
                    break;
                case ".php":
                    SetLanguage(Language.PHP);
                    break;
                case ".vb":
                    SetLanguage(Language.VB);
                    break;
                case ".sql":
                    SetLanguage(Language.SQL);
                    break;
                default:
                    SetLanguage(Language.Custom);
                    break;
            }
        }

        /// <summary>
        /// ��������������� ������� ��� ��������� ��������� TextBox � ������������
        /// ��������� Checked � ������� ������ � ���� ���������
        /// </summary>
        private void SetEncoding(Encoding encoding)
        {
            encode = encoding;
            uTF8ToolStripMenuItem.Checked = (encode == Encoding.UTF8);
            uTF16ToolStripMenuItem.Checked = (encode == Encoding.Unicode);
            ASCIIToolStripMenuItem.Checked = (encode == Encoding.ASCII);
            uTF32ToolStripMenuItem.Checked = (encode == Encoding.UTF32);
            uTF7ToolStripMenuItem.Checked = (encode == Encoding.UTF7);
            txt_infoStripStatusLabel1.Text = @$"    �������:{txtMain.Zoom}   |   ���������:{txtMain.Language}   |   ���������:{encode.HeaderName}";
        }

        /// <summary>
        /// UTF8
        /// ������������� ��������� �� UTF8
        /// </summary>
        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF8);
        }

        /// <summary>
        /// UTF16
        /// ������������� ��������� �� UTF-16
        /// </summary>
        private void uTF16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.Unicode);
        }

        /// <summary>
        /// ASCII
        /// ������������� ��������� �� ASCII
        /// </summary>
        private void ASCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.ASCII);
        }

        /// <summary>
        /// UTF32
        /// ������������� ��������� �� UTF32
        /// </summary>
        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF32);
        }

        /// <summary>
        /// UTF7
        /// ������������� ��������� �� UTF7
        /// </summary>
        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEncoding(Encoding.UTF7);
        }

        /// <summary>
        /// ������� ��� �������������� ��������� ��������� ��������� �����
        /// </summary>
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