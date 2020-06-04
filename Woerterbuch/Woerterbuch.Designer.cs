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
            this.tbGermanWord = new System.Windows.Forms.TextBox();
            this.tbEnglishWord = new System.Windows.Forms.TextBox();
            this.lBoxGermanWords = new System.Windows.Forms.ListBox();
            this.tbTranslation = new System.Windows.Forms.TextBox();
            this.tbSpanishWord = new System.Windows.Forms.TextBox();
            this.tbSpanishTranslation = new System.Windows.Forms.TextBox();
            this.lbEnglish = new System.Windows.Forms.Label();
            this.lbSpanish = new System.Windows.Forms.Label();
            this.lbGerman = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddEnglish
            // 
            this.btnAddEnglish.Location = new System.Drawing.Point(301, 164);
            this.btnAddEnglish.Name = "btnAddEnglish";
            this.btnAddEnglish.Size = new System.Drawing.Size(166, 31);
            this.btnAddEnglish.TabIndex = 0;
            this.btnAddEnglish.Text = "Hinzufügen";
            this.btnAddEnglish.UseVisualStyleBackColor = true;
            this.btnAddEnglish.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbGermanWord
            // 
            this.tbGermanWord.Location = new System.Drawing.Point(94, 93);
            this.tbGermanWord.Name = "tbGermanWord";
            this.tbGermanWord.Size = new System.Drawing.Size(189, 22);
            this.tbGermanWord.TabIndex = 1;
            // 
            // tbEnglishWord
            // 
            this.tbEnglishWord.Location = new System.Drawing.Point(484, 68);
            this.tbEnglishWord.Name = "tbEnglishWord";
            this.tbEnglishWord.Size = new System.Drawing.Size(175, 22);
            this.tbEnglishWord.TabIndex = 2;
            // 
            // lBoxGermanWords
            // 
            this.lBoxGermanWords.FormattingEnabled = true;
            this.lBoxGermanWords.ItemHeight = 16;
            this.lBoxGermanWords.Location = new System.Drawing.Point(94, 237);
            this.lBoxGermanWords.Name = "lBoxGermanWords";
            this.lBoxGermanWords.Size = new System.Drawing.Size(319, 180);
            this.lBoxGermanWords.TabIndex = 4;
            this.lBoxGermanWords.SelectedIndexChanged += new System.EventHandler(this.lBoxGermanWords_SelectedIndexChanged);
            // 
            // tbTranslation
            // 
            this.tbTranslation.Location = new System.Drawing.Point(484, 237);
            this.tbTranslation.Name = "tbTranslation";
            this.tbTranslation.Size = new System.Drawing.Size(175, 22);
            this.tbTranslation.TabIndex = 5;
            // 
            // tbSpanishWord
            // 
            this.tbSpanishWord.Location = new System.Drawing.Point(484, 115);
            this.tbSpanishWord.Name = "tbSpanishWord";
            this.tbSpanishWord.Size = new System.Drawing.Size(175, 22);
            this.tbSpanishWord.TabIndex = 6;
            // 
            // tbSpanishTranslation
            // 
            this.tbSpanishTranslation.Location = new System.Drawing.Point(484, 285);
            this.tbSpanishTranslation.Name = "tbSpanishTranslation";
            this.tbSpanishTranslation.Size = new System.Drawing.Size(175, 22);
            this.tbSpanishTranslation.TabIndex = 8;
            // 
            // lbEnglish
            // 
            this.lbEnglish.AutoSize = true;
            this.lbEnglish.Location = new System.Drawing.Point(481, 217);
            this.lbEnglish.Name = "lbEnglish";
            this.lbEnglish.Size = new System.Drawing.Size(54, 17);
            this.lbEnglish.TabIndex = 9;
            this.lbEnglish.Text = "English";
            // 
            // lbSpanish
            // 
            this.lbSpanish.AutoSize = true;
            this.lbSpanish.Location = new System.Drawing.Point(481, 265);
            this.lbSpanish.Name = "lbSpanish";
            this.lbSpanish.Size = new System.Drawing.Size(59, 17);
            this.lbSpanish.TabIndex = 10;
            this.lbSpanish.Text = "Spanish";
            // 
            // lbGerman
            // 
            this.lbGerman.AutoSize = true;
            this.lbGerman.Location = new System.Drawing.Point(91, 217);
            this.lbGerman.Name = "lbGerman";
            this.lbGerman.Size = new System.Drawing.Size(60, 17);
            this.lbGerman.TabIndex = 11;
            this.lbGerman.Text = "Deutsch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Deutsch <> Englisch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Deutsch <> Spanisch";
            // 
            // Woerterbuch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbGerman);
            this.Controls.Add(this.lbSpanish);
            this.Controls.Add(this.lbEnglish);
            this.Controls.Add(this.tbSpanishTranslation);
            this.Controls.Add(this.tbSpanishWord);
            this.Controls.Add(this.tbTranslation);
            this.Controls.Add(this.lBoxGermanWords);
            this.Controls.Add(this.tbEnglishWord);
            this.Controls.Add(this.tbGermanWord);
            this.Controls.Add(this.btnAddEnglish);
            this.Name = "Woerterbuch";
            this.Text = "Wörterbuch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEnglish;
        private System.Windows.Forms.TextBox tbGermanWord;
        private System.Windows.Forms.TextBox tbEnglishWord;
        private System.Windows.Forms.ListBox lBoxGermanWords;
        private System.Windows.Forms.TextBox tbTranslation;
        private System.Windows.Forms.TextBox tbSpanishWord;
        private System.Windows.Forms.TextBox tbSpanishTranslation;
        private System.Windows.Forms.Label lbEnglish;
        private System.Windows.Forms.Label lbSpanish;
        private System.Windows.Forms.Label lbGerman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

