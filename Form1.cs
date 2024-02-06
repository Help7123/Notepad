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
        /// ����������� ��������� ��������
        /// </summary>
        private PageSettings? savedPageSettings;

        /// <summary>
        /// ������� ����
        /// ������� �������� ����, � ������� ���������� ��������� ���� ��� �������� � ��������
        /// </summary>
        private void tsmOpen_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                string? str;
                try
                {
                    StreamReader fr = new(ofdMain.FileName);
                    Console.WriteLine("���������� �����:");
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
                    Console.WriteLine("��������� ������!");
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
            Application.Exit();
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
        /// ���������
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
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
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
            RichTextBoxFinds richTextBoxFinds = new RichTextBoxFinds();
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
    }
}