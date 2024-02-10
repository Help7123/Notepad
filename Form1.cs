using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using FastColoredTextBoxNS;
using TabStrip;
using static System.Net.Mime.MediaTypeNames;

namespace Notepad
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            txt_infoStripStatusLabel1.Text = @$"    ������:{txtMain.Zoom}   |   ���������:{txtMain.Language}";
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
                    while (str != null)
                    {
                        str = fr.ReadLine();
                        txtMain.Text = txtMain.Text + str + "\r\n"; ;
                    }
                    string ext =Path.GetExtension(ofdMain.FileName);
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
        /// ��������� ���...
        /// ������� �������� ����, ���������� ����� ���, ��� ����� ������� ����, ��� ����� �������� ���� � ��� ��������
        /// </summary>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                Save(sfdMain.FileName);
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
                    Save(sfdMain.FileName);
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
        /// ������ ��������� � ����������...
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
            txt_infoStripStatusLabel1.Text = @$"    ������:{txtMain.Zoom}   |   ���������:{txtMain.Language}";
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
    }
}