namespace Woerterbuch
{
    partial class Woerterbuch
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddEnglish = new System.Windows.Forms.Button();
            this.tbFirstWord = new System.Windows.Forms.TextBox();
            this.lBoxGermanWords = new System.Windows.Forms.ListBox();
            this.tbSecondWord = new System.Windows.Forms.TextBox();
            this.lbGerman = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lBoxAlphabet = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.coBoLang1 = new System.Windows.Forms.ComboBox();
            this.coBoLang2 = new System.Windows.Forms.ComboBox();
            this.lBoxTranslation = new System.Windows.Forms.ListBox();
            this.tbSearchCountry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddEnglish
            // 
            this.btnAddEnglish.Location = new System.Drawing.Point(246, 152);
            this.btnAddEnglish.Name = "btnAddEnglish";
            this.btnAddEnglish.Size = new System.Drawing.Size(166, 31);
            this.btnAddEnglish.TabIndex = 0;
            this.btnAddEnglish.Text = "Hinzufügen";
            this.btnAddEnglish.UseVisualStyleBackColor = true;
            this.btnAddEnglish.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbFirstWord
            // 
            this.tbFirstWord.Location = new System.Drawing.Point(105, 93);
            this.tbFirstWord.Name = "tbFirstWord";
            this.tbFirstWord.Size = new System.Drawing.Size(175, 22);
            this.tbFirstWord.TabIndex = 1;
            // 
            // lBoxGermanWords
            // 
            this.lBoxGermanWords.FormattingEnabled = true;
            this.lBoxGermanWords.ItemHeight = 16;
            this.lBoxGermanWords.Location = new System.Drawing.Point(93, 258);
            this.lBoxGermanWords.Name = "lBoxGermanWords";
            this.lBoxGermanWords.Size = new System.Drawing.Size(319, 180);
            this.lBoxGermanWords.TabIndex = 4;
            this.lBoxGermanWords.SelectedIndexChanged += new System.EventHandler(this.lBoxGermanWords_SelectedIndexChanged);
            // 
            // tbSecondWord
            // 
            this.tbSecondWord.Location = new System.Drawing.Point(484, 93);
            this.tbSecondWord.Name = "tbSecondWord";
            this.tbSecondWord.Size = new System.Drawing.Size(175, 22);
            this.tbSecondWord.TabIndex = 6;
            // 
            // lbGerman
            // 
            this.lbGerman.AutoSize = true;
            this.lbGerman.Location = new System.Drawing.Point(90, 240);
            this.lbGerman.Name = "lbGerman";
            this.lbGerman.Size = new System.Drawing.Size(60, 17);
            this.lbGerman.TabIndex = 11;
            this.lbGerman.Text = "Deutsch";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(626, 277);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 47);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(93, 217);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(318, 22);
            this.tbSearch.TabIndex = 15;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Suche";
            // 
            // lBoxAlphabet
            // 
            this.lBoxAlphabet.FormattingEnabled = true;
            this.lBoxAlphabet.ItemHeight = 16;
            this.lBoxAlphabet.Location = new System.Drawing.Point(41, 258);
            this.lBoxAlphabet.Name = "lBoxAlphabet";
            this.lBoxAlphabet.Size = new System.Drawing.Size(46, 180);
            this.lBoxAlphabet.TabIndex = 17;
            this.lBoxAlphabet.Click += new System.EventHandler(this.lBoxAlphabet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(626, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 47);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // coBoLang1
            // 
            this.coBoLang1.FormattingEnabled = true;
            this.coBoLang1.Location = new System.Drawing.Point(41, 93);
            this.coBoLang1.Name = "coBoLang1";
            this.coBoLang1.Size = new System.Drawing.Size(49, 24);
            this.coBoLang1.TabIndex = 19;
            this.coBoLang1.SelectedIndexChanged += new System.EventHandler(this.coBoLang1_SelectedIndexChanged);
            // 
            // coBoLang2
            // 
            this.coBoLang2.FormattingEnabled = true;
            this.coBoLang2.Location = new System.Drawing.Point(418, 93);
            this.coBoLang2.Name = "coBoLang2";
            this.coBoLang2.Size = new System.Drawing.Size(50, 24);
            this.coBoLang2.TabIndex = 20;
            // 
            // lBoxTranslation
            // 
            this.lBoxTranslation.FormattingEnabled = true;
            this.lBoxTranslation.ItemHeight = 16;
            this.lBoxTranslation.Location = new System.Drawing.Point(428, 258);
            this.lBoxTranslation.Name = "lBoxTranslation";
            this.lBoxTranslation.Size = new System.Drawing.Size(182, 164);
            this.lBoxTranslation.TabIndex = 21;
            // 
            // tbSearchCountry
            // 
            this.tbSearchCountry.Location = new System.Drawing.Point(513, 216);
            this.tbSearchCountry.Name = "tbSearchCountry";
            this.tbSearchCountry.Size = new System.Drawing.Size(96, 22);
            this.tbSearchCountry.TabIndex = 22;
            this.tbSearchCountry.TextChanged += new System.EventHandler(this.tbSearchCountry_TextChanged);
            this.tbSearchCountry.Leave += new System.EventHandler(this.tbSearchCountry_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(510, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Suche (Laendercode)";
            // 
            // Woerterbuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearchCountry);
            this.Controls.Add(this.lBoxTranslation);
            this.Controls.Add(this.coBoLang2);
            this.Controls.Add(this.coBoLang1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lBoxAlphabet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lbGerman);
            this.Controls.Add(this.tbSecondWord);
            this.Controls.Add(this.lBoxGermanWords);
            this.Controls.Add(this.tbFirstWord);
            this.Controls.Add(this.btnAddEnglish);
            this.Name = "Woerterbuch";
            this.Text = "Wörterbuch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEnglish;
        private System.Windows.Forms.TextBox tbFirstWord;
        private System.Windows.Forms.ListBox lBoxGermanWords;
        private System.Windows.Forms.TextBox tbSecondWord;
        private System.Windows.Forms.Label lbGerman;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lBoxAlphabet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox coBoLang1;
        private System.Windows.Forms.ComboBox coBoLang2;
        private System.Windows.Forms.ListBox lBoxTranslation;
        private System.Windows.Forms.TextBox tbSearchCountry;
        private System.Windows.Forms.Label label1;
    }
}

