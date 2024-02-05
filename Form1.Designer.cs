namespace Notepad
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mnuMain = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            tsmCreate = new ToolStripMenuItem();
            tsmNewWindow = new ToolStripMenuItem();
            tsmOpen = new ToolStripMenuItem();
            tsmSave = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            PagerSettingsToolStripMenuItem = new ToolStripMenuItem();
            print = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmExit = new ToolStripMenuItem();
            правкаToolStripMenuItem = new ToolStripMenuItem();
            UndoToolStripMenuItem = new ToolStripMenuItem();
            форматToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            txtMain = new TextBox();
            stsMain = new StatusStrip();
            sfdMain = new SaveFileDialog();
            ofdMain = new OpenFileDialog();
            prdMain = new PrintDialog();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, форматToolStripMenuItem, видToolStripMenuItem, справкаToolStripMenuItem });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(807, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmCreate, tsmNewWindow, tsmOpen, tsmSave, SaveAsToolStripMenuItem, toolStripSeparator2, PagerSettingsToolStripMenuItem, print, toolStripSeparator1, tsmExit });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // tsmCreate
            // 
            tsmCreate.Name = "tsmCreate";
            tsmCreate.ShortcutKeyDisplayString = "CTRL+N";
            tsmCreate.ShortcutKeys = Keys.Control | Keys.N;
            tsmCreate.Size = new Size(241, 22);
            tsmCreate.Text = "Создать";
            tsmCreate.Click += tsmCreate_Click;
            // 
            // tsmNewWindow
            // 
            tsmNewWindow.Name = "tsmNewWindow";
            tsmNewWindow.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            tsmNewWindow.Size = new Size(241, 22);
            tsmNewWindow.Text = "Новое окно";
            tsmNewWindow.Click += tsmNewWindow_Click;
            // 
            // tsmOpen
            // 
            tsmOpen.Name = "tsmOpen";
            tsmOpen.ShortcutKeys = Keys.Control | Keys.O;
            tsmOpen.Size = new Size(241, 22);
            tsmOpen.Text = "Открыть...";
            tsmOpen.Click += tsmOpen_Click;
            // 
            // tsmSave
            // 
            tsmSave.Name = "tsmSave";
            tsmSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmSave.Size = new Size(241, 22);
            tsmSave.Text = "Сохранить";
            tsmSave.Click += tsmSave_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveAsToolStripMenuItem.Size = new Size(241, 22);
            SaveAsToolStripMenuItem.Text = "Сохранить как...";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(238, 6);
            // 
            // PagerSettingsToolStripMenuItem
            // 
            PagerSettingsToolStripMenuItem.Name = "PagerSettingsToolStripMenuItem";
            PagerSettingsToolStripMenuItem.Size = new Size(241, 22);
            PagerSettingsToolStripMenuItem.Text = "Параметры страницы...";
            PagerSettingsToolStripMenuItem.Click += PagerSettingsToolStripMenuItem_Click;
            // 
            // print
            // 
            print.Name = "print";
            print.ShortcutKeys = Keys.Control | Keys.P;
            print.Size = new Size(241, 22);
            print.Text = "Печать...";
            print.Click += print_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(238, 6);
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(241, 22);
            tsmExit.Text = "Выход";
            tsmExit.Click += tsmExit_Click;
            // 
            // правкаToolStripMenuItem
            // 
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UndoToolStripMenuItem });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(59, 20);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // UndoToolStripMenuItem
            // 
            UndoToolStripMenuItem.Enabled = false;
            UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            UndoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            UndoToolStripMenuItem.Size = new Size(180, 22);
            UndoToolStripMenuItem.Text = "Отменить";
            UndoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // форматToolStripMenuItem
            // 
            форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            форматToolStripMenuItem.Size = new Size(62, 20);
            форматToolStripMenuItem.Text = "Формат";
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(39, 20);
            видToolStripMenuItem.Text = "Вид";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // txtMain
            // 
            txtMain.BorderStyle = BorderStyle.None;
            txtMain.Dock = DockStyle.Fill;
            txtMain.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtMain.Location = new Point(0, 24);
            txtMain.Multiline = true;
            txtMain.Name = "txtMain";
            txtMain.ScrollBars = ScrollBars.Both;
            txtMain.Size = new Size(807, 424);
            txtMain.TabIndex = 1;
            txtMain.TextChanged += txtMain_TextChanged;
            // 
            // stsMain
            // 
            stsMain.Location = new Point(0, 426);
            stsMain.Name = "stsMain";
            stsMain.Size = new Size(807, 22);
            stsMain.TabIndex = 2;
            stsMain.Text = "statusStrip1";
            // 
            // sfdMain
            // 
            sfdMain.Filter = "Текстовый файл (.txt)|*.txt";
            // 
            // ofdMain
            // 
            ofdMain.FileName = "openFileDialog1";
            // 
            // prdMain
            // 
            prdMain.UseEXDialog = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 448);
            Controls.Add(stsMain);
            Controls.Add(txtMain);
            Controls.Add(mnuMain);
            MainMenuStrip = mnuMain;
            Name = "frmMain";
            Text = "Блокнот";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private TextBox txtMain;
        private StatusStrip stsMain;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem tsmCreate;
        private ToolStripMenuItem правкаToolStripMenuItem;
        private ToolStripMenuItem форматToolStripMenuItem;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem tsmNewWindow;
        private ToolStripMenuItem tsmOpen;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmExit;
        private SaveFileDialog sfdMain;
        private OpenFileDialog ofdMain;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem tsmSave;
        private PrintDialog prdMain;
        private ToolStripMenuItem print;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem PagerSettingsToolStripMenuItem;
        private ToolStripMenuItem UndoToolStripMenuItem;
    }
}