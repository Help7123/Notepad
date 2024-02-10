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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
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
            toolStripSeparator3 = new ToolStripSeparator();
            CutToolStripMenuItem = new ToolStripMenuItem();
            CopyToolStripMenuItem = new ToolStripMenuItem();
            PasteToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            Find_on_InternetToolStripMenuItem = new ToolStripMenuItem();
            FindToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            SellectAllToolStripMenuItem = new ToolStripMenuItem();
            DateandTimeToolStripMenuItem = new ToolStripMenuItem();
            форматToolStripMenuItem = new ToolStripMenuItem();
            FontToolStripMenuItem = new ToolStripMenuItem();
            WrapToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            маштабToolStripMenuItem = new ToolStripMenuItem();
            increase_the_ScaleToolStripMenuItem = new ToolStripMenuItem();
            reduce_the_ScaleToolStripMenuItem = new ToolStripMenuItem();
            Scale_defaultToolStripMenuItem = new ToolStripMenuItem();
            Status_BarToolStripMenuItem = new ToolStripMenuItem();
            синтаксисыToolStripMenuItem = new ToolStripMenuItem();
            Defaul_textToolStripMenuItem = new ToolStripMenuItem();
            C_SharpToolStripMenuItem = new ToolStripMenuItem();
            hTMLToolStripMenuItem = new ToolStripMenuItem();
            pHPToolStripMenuItem = new ToolStripMenuItem();
            vBToolStripMenuItem = new ToolStripMenuItem();
            sQLToolStripMenuItem = new ToolStripMenuItem();
            кодировкаToolStripMenuItem = new ToolStripMenuItem();
            uTF8ToolStripMenuItem = new ToolStripMenuItem();
            uTF16ToolStripMenuItem = new ToolStripMenuItem();
            ASCIIToolStripMenuItem = new ToolStripMenuItem();
            uTF7ToolStripMenuItem = new ToolStripMenuItem();
            uTF32ToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            ViewTheHelpToolStripMenuItem = new ToolStripMenuItem();
            feedbackToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            About_a_ProgramToolStripMenuItem = new ToolStripMenuItem();
            stsMain = new StatusStrip();
            txt_infoStripStatusLabel1 = new ToolStripStatusLabel();
            sfdMain = new SaveFileDialog();
            ofdMain = new OpenFileDialog();
            prdMain = new PrintDialog();
            txtMain = new FastColoredTextBoxNS.FastColoredTextBox();
            mnuMain.SuspendLayout();
            stsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMain).BeginInit();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, форматToolStripMenuItem, видToolStripMenuItem, синтаксисыToolStripMenuItem, кодировкаToolStripMenuItem, справкаToolStripMenuItem });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new Size(752, 24);
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
            правкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UndoToolStripMenuItem, toolStripSeparator3, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem, DeleteToolStripMenuItem, toolStripSeparator4, Find_on_InternetToolStripMenuItem, FindToolStripMenuItem, toolStripSeparator5, SellectAllToolStripMenuItem, DateandTimeToolStripMenuItem });
            правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            правкаToolStripMenuItem.Size = new Size(59, 20);
            правкаToolStripMenuItem.Text = "Правка";
            // 
            // UndoToolStripMenuItem
            // 
            UndoToolStripMenuItem.Enabled = false;
            UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            UndoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            UndoToolStripMenuItem.Size = new Size(226, 22);
            UndoToolStripMenuItem.Text = "Отменить";
            UndoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(223, 6);
            // 
            // CutToolStripMenuItem
            // 
            CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            CutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            CutToolStripMenuItem.Size = new Size(226, 22);
            CutToolStripMenuItem.Text = "Вырезать";
            CutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            CopyToolStripMenuItem.Size = new Size(226, 22);
            CopyToolStripMenuItem.Text = "Копировать";
            CopyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            // 
            // PasteToolStripMenuItem
            // 
            PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            PasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            PasteToolStripMenuItem.Size = new Size(226, 22);
            PasteToolStripMenuItem.Text = "Вставить";
            PasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            DeleteToolStripMenuItem.Size = new Size(226, 22);
            DeleteToolStripMenuItem.Text = "Удалить";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(223, 6);
            // 
            // Find_on_InternetToolStripMenuItem
            // 
            Find_on_InternetToolStripMenuItem.Name = "Find_on_InternetToolStripMenuItem";
            Find_on_InternetToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            Find_on_InternetToolStripMenuItem.Size = new Size(226, 22);
            Find_on_InternetToolStripMenuItem.Text = "Поиск в интернете...";
            Find_on_InternetToolStripMenuItem.Click += Find_on_InternetToolStripMenuItem_Click;
            // 
            // FindToolStripMenuItem
            // 
            FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            FindToolStripMenuItem.Size = new Size(226, 22);
            FindToolStripMenuItem.Text = "Найти...";
            FindToolStripMenuItem.Click += FindToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(223, 6);
            // 
            // SellectAllToolStripMenuItem
            // 
            SellectAllToolStripMenuItem.Name = "SellectAllToolStripMenuItem";
            SellectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            SellectAllToolStripMenuItem.Size = new Size(226, 22);
            SellectAllToolStripMenuItem.Text = "Выделить всё";
            SellectAllToolStripMenuItem.Click += SellectAllToolStripMenuItem_Click;
            // 
            // DateandTimeToolStripMenuItem
            // 
            DateandTimeToolStripMenuItem.Name = "DateandTimeToolStripMenuItem";
            DateandTimeToolStripMenuItem.ShortcutKeys = Keys.F5;
            DateandTimeToolStripMenuItem.Size = new Size(226, 22);
            DateandTimeToolStripMenuItem.Text = "Дата и время";
            DateandTimeToolStripMenuItem.Click += DateandTimeToolStripMenuItem_Click;
            // 
            // форматToolStripMenuItem
            // 
            форматToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { FontToolStripMenuItem, WrapToolStripMenuItem });
            форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            форматToolStripMenuItem.Size = new Size(62, 20);
            форматToolStripMenuItem.Text = "Формат";
            // 
            // FontToolStripMenuItem
            // 
            FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            FontToolStripMenuItem.Size = new Size(183, 22);
            FontToolStripMenuItem.Text = "Шрифт...";
            FontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
            // 
            // WrapToolStripMenuItem
            // 
            WrapToolStripMenuItem.Name = "WrapToolStripMenuItem";
            WrapToolStripMenuItem.Size = new Size(183, 22);
            WrapToolStripMenuItem.Text = "Перенос по словам";
            WrapToolStripMenuItem.Click += WrapToolStripMenuItem_Click;
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { маштабToolStripMenuItem, Status_BarToolStripMenuItem });
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(39, 20);
            видToolStripMenuItem.Text = "Вид";
            // 
            // маштабToolStripMenuItem
            // 
            маштабToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { increase_the_ScaleToolStripMenuItem, reduce_the_ScaleToolStripMenuItem, Scale_defaultToolStripMenuItem });
            маштабToolStripMenuItem.Name = "маштабToolStripMenuItem";
            маштабToolStripMenuItem.Size = new Size(180, 22);
            маштабToolStripMenuItem.Text = "масштаб";
            // 
            // increase_the_ScaleToolStripMenuItem
            // 
            increase_the_ScaleToolStripMenuItem.Name = "increase_the_ScaleToolStripMenuItem";
            increase_the_ScaleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            increase_the_ScaleToolStripMenuItem.Size = new Size(328, 22);
            increase_the_ScaleToolStripMenuItem.Text = "Увеличить";
            increase_the_ScaleToolStripMenuItem.Click += increase_the_ScaleToolStripMenuItem_Click;
            // 
            // reduce_the_ScaleToolStripMenuItem
            // 
            reduce_the_ScaleToolStripMenuItem.Name = "reduce_the_ScaleToolStripMenuItem";
            reduce_the_ScaleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            reduce_the_ScaleToolStripMenuItem.Size = new Size(328, 22);
            reduce_the_ScaleToolStripMenuItem.Text = "Уменьшить";
            reduce_the_ScaleToolStripMenuItem.Click += reduce_the_ScaleToolStripMenuItem_Click;
            // 
            // Scale_defaultToolStripMenuItem
            // 
            Scale_defaultToolStripMenuItem.Name = "Scale_defaultToolStripMenuItem";
            Scale_defaultToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            Scale_defaultToolStripMenuItem.Size = new Size(328, 22);
            Scale_defaultToolStripMenuItem.Text = "Восстановить масштаб по умолчанию";
            Scale_defaultToolStripMenuItem.Click += Scale_defaultToolStripMenuItem_Click;
            // 
            // Status_BarToolStripMenuItem
            // 
            Status_BarToolStripMenuItem.Checked = true;
            Status_BarToolStripMenuItem.CheckState = CheckState.Checked;
            Status_BarToolStripMenuItem.Name = "Status_BarToolStripMenuItem";
            Status_BarToolStripMenuItem.Size = new Size(180, 22);
            Status_BarToolStripMenuItem.Text = "Строка состояния";
            Status_BarToolStripMenuItem.Click += Status_BarToolStripMenuItem_Click;
            // 
            // синтаксисыToolStripMenuItem
            // 
            синтаксисыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Defaul_textToolStripMenuItem, C_SharpToolStripMenuItem, hTMLToolStripMenuItem, pHPToolStripMenuItem, vBToolStripMenuItem, sQLToolStripMenuItem });
            синтаксисыToolStripMenuItem.Name = "синтаксисыToolStripMenuItem";
            синтаксисыToolStripMenuItem.Size = new Size(86, 20);
            синтаксисыToolStripMenuItem.Text = "Синтаксисы";
            // 
            // Defaul_textToolStripMenuItem
            // 
            Defaul_textToolStripMenuItem.Name = "Defaul_textToolStripMenuItem";
            Defaul_textToolStripMenuItem.Size = new Size(160, 22);
            Defaul_textToolStripMenuItem.Text = "Обычный текст";
            Defaul_textToolStripMenuItem.Click += Defaul_textToolStripMenuItem_Click;
            // 
            // C_SharpToolStripMenuItem
            // 
            C_SharpToolStripMenuItem.Name = "C_SharpToolStripMenuItem";
            C_SharpToolStripMenuItem.Size = new Size(160, 22);
            C_SharpToolStripMenuItem.Text = "C#";
            C_SharpToolStripMenuItem.Click += C_SharpToolStripMenuItem_Click;
            // 
            // hTMLToolStripMenuItem
            // 
            hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            hTMLToolStripMenuItem.Size = new Size(160, 22);
            hTMLToolStripMenuItem.Text = "HTML";
            hTMLToolStripMenuItem.Click += hTMLToolStripMenuItem_Click;
            // 
            // pHPToolStripMenuItem
            // 
            pHPToolStripMenuItem.Name = "pHPToolStripMenuItem";
            pHPToolStripMenuItem.Size = new Size(160, 22);
            pHPToolStripMenuItem.Text = "PHP";
            pHPToolStripMenuItem.Click += pHPToolStripMenuItem_Click;
            // 
            // vBToolStripMenuItem
            // 
            vBToolStripMenuItem.Name = "vBToolStripMenuItem";
            vBToolStripMenuItem.Size = new Size(160, 22);
            vBToolStripMenuItem.Text = "VB";
            vBToolStripMenuItem.Click += vBToolStripMenuItem_Click;
            // 
            // sQLToolStripMenuItem
            // 
            sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            sQLToolStripMenuItem.Size = new Size(160, 22);
            sQLToolStripMenuItem.Text = "SQL";
            sQLToolStripMenuItem.Click += sQLToolStripMenuItem_Click;
            // 
            // кодировкаToolStripMenuItem
            // 
            кодировкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uTF8ToolStripMenuItem, uTF16ToolStripMenuItem, ASCIIToolStripMenuItem, uTF7ToolStripMenuItem, uTF32ToolStripMenuItem });
            кодировкаToolStripMenuItem.Name = "кодировкаToolStripMenuItem";
            кодировкаToolStripMenuItem.Size = new Size(78, 20);
            кодировкаToolStripMenuItem.Text = "Кодировка";
            // 
            // uTF8ToolStripMenuItem
            // 
            uTF8ToolStripMenuItem.Checked = true;
            uTF8ToolStripMenuItem.CheckState = CheckState.Checked;
            uTF8ToolStripMenuItem.Name = "uTF8ToolStripMenuItem";
            uTF8ToolStripMenuItem.Size = new Size(111, 22);
            uTF8ToolStripMenuItem.Text = "UTF-8";
            uTF8ToolStripMenuItem.Click += uTF8ToolStripMenuItem_Click;
            // 
            // uTF16ToolStripMenuItem
            // 
            uTF16ToolStripMenuItem.Name = "uTF16ToolStripMenuItem";
            uTF16ToolStripMenuItem.Size = new Size(111, 22);
            uTF16ToolStripMenuItem.Text = "UTF-16";
            uTF16ToolStripMenuItem.Click += uTF16ToolStripMenuItem_Click;
            // 
            // ASCIIToolStripMenuItem
            // 
            ASCIIToolStripMenuItem.Name = "ASCIIToolStripMenuItem";
            ASCIIToolStripMenuItem.Size = new Size(111, 22);
            ASCIIToolStripMenuItem.Text = "ASCII";
            ASCIIToolStripMenuItem.Click += ASCIIToolStripMenuItem_Click;
            // 
            // uTF7ToolStripMenuItem
            // 
            uTF7ToolStripMenuItem.Name = "uTF7ToolStripMenuItem";
            uTF7ToolStripMenuItem.Size = new Size(111, 22);
            uTF7ToolStripMenuItem.Text = "UTF-7";
            uTF7ToolStripMenuItem.Click += uTF7ToolStripMenuItem_Click;
            // 
            // uTF32ToolStripMenuItem
            // 
            uTF32ToolStripMenuItem.Name = "uTF32ToolStripMenuItem";
            uTF32ToolStripMenuItem.Size = new Size(111, 22);
            uTF32ToolStripMenuItem.Text = "UTF-32";
            uTF32ToolStripMenuItem.Click += uTF32ToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ViewTheHelpToolStripMenuItem, feedbackToolStripMenuItem, toolStripSeparator6, About_a_ProgramToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // ViewTheHelpToolStripMenuItem
            // 
            ViewTheHelpToolStripMenuItem.Name = "ViewTheHelpToolStripMenuItem";
            ViewTheHelpToolStripMenuItem.Size = new Size(195, 22);
            ViewTheHelpToolStripMenuItem.Text = "Просмотреть справку";
            // 
            // feedbackToolStripMenuItem
            // 
            feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            feedbackToolStripMenuItem.Size = new Size(195, 22);
            feedbackToolStripMenuItem.Text = "Оставить отзыв";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(192, 6);
            // 
            // About_a_ProgramToolStripMenuItem
            // 
            About_a_ProgramToolStripMenuItem.Name = "About_a_ProgramToolStripMenuItem";
            About_a_ProgramToolStripMenuItem.Size = new Size(195, 22);
            About_a_ProgramToolStripMenuItem.Text = "О программе";
            // 
            // stsMain
            // 
            stsMain.Items.AddRange(new ToolStripItem[] { txt_infoStripStatusLabel1 });
            stsMain.Location = new Point(0, 347);
            stsMain.Name = "stsMain";
            stsMain.Size = new Size(752, 22);
            stsMain.TabIndex = 2;
            stsMain.Text = "statusStrip1";
            // 
            // txt_infoStripStatusLabel1
            // 
            txt_infoStripStatusLabel1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_infoStripStatusLabel1.Name = "txt_infoStripStatusLabel1";
            txt_infoStripStatusLabel1.Size = new Size(0, 17);
            // 
            // sfdMain
            // 
            sfdMain.Filter = "Текстовый файл (.txt)|*.txt|Файлы C# (.cs)|*.cs|HTML-файлы (.html)|*.html|Файлы PHP (.php)|*.php|Файлы VB (.vb)|*.vb|Файлы SQL (.sql)|*.sql";
            // 
            // ofdMain
            // 
            ofdMain.FileName = "openFileDialog1";
            // 
            // prdMain
            // 
            prdMain.UseEXDialog = true;
            // 
            // txtMain
            // 
            txtMain.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            txtMain.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            txtMain.AutoScrollMinSize = new Size(27, 14);
            txtMain.BackBrush = null;
            txtMain.CharHeight = 14;
            txtMain.CharWidth = 8;
            txtMain.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            txtMain.Dock = DockStyle.Fill;
            txtMain.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMain.IsReplaceMode = false;
            txtMain.Location = new Point(0, 24);
            txtMain.Name = "txtMain";
            txtMain.Paddings = new Padding(0);
            txtMain.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            txtMain.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("txtMain.ServiceColors");
            txtMain.Size = new Size(752, 323);
            txtMain.TabIndex = 3;
            txtMain.Zoom = 100;
            txtMain.TextChanged += txtMain_TextChanged;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 369);
            Controls.Add(txtMain);
            Controls.Add(stsMain);
            Controls.Add(mnuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuMain;
            Name = "frmMain";
            Text = "Блокнот";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            stsMain.ResumeLayout(false);
            stsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
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
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem Find_on_InternetToolStripMenuItem;
        private ToolStripMenuItem FindToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem SellectAllToolStripMenuItem;
        private ToolStripMenuItem DateandTimeToolStripMenuItem;
        private ToolStripMenuItem FontToolStripMenuItem;
        private ToolStripMenuItem WrapToolStripMenuItem;
        private ToolStripMenuItem ViewTheHelpToolStripMenuItem;
        private ToolStripMenuItem feedbackToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem About_a_ProgramToolStripMenuItem;
        private ToolStripMenuItem маштабToolStripMenuItem;
        private ToolStripMenuItem increase_the_ScaleToolStripMenuItem;
        private ToolStripMenuItem reduce_the_ScaleToolStripMenuItem;
        private ToolStripMenuItem Scale_defaultToolStripMenuItem;
        private ToolStripMenuItem Status_BarToolStripMenuItem;
        private ToolStripStatusLabel txt_infoStripStatusLabel1;
        private FastColoredTextBoxNS.FastColoredTextBox txtMain;
        private ToolStripMenuItem синтаксисыToolStripMenuItem;
        private ToolStripMenuItem Defaul_textToolStripMenuItem;
        private ToolStripMenuItem C_SharpToolStripMenuItem;
        private ToolStripMenuItem hTMLToolStripMenuItem;
        private ToolStripMenuItem pHPToolStripMenuItem;
        private ToolStripMenuItem vBToolStripMenuItem;
        private ToolStripMenuItem sQLToolStripMenuItem;
        private ToolStripMenuItem кодировкаToolStripMenuItem;
        private ToolStripMenuItem uTF8ToolStripMenuItem;
        private ToolStripMenuItem uTF16ToolStripMenuItem;
        private ToolStripMenuItem ASCIIToolStripMenuItem;
        private ToolStripMenuItem uTF7ToolStripMenuItem;
        private ToolStripMenuItem uTF32ToolStripMenuItem;
    }
}