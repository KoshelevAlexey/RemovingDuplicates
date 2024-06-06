namespace RemovingDublicates
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenJsonFile = new System.Windows.Forms.Button();
            this.btnSaveJsonFile = new System.Windows.Forms.Button();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenJsonFile
            // 
            this.btnOpenJsonFile.Location = new System.Drawing.Point(39, 21);
            this.btnOpenJsonFile.Name = "btnOpenJsonFile";
            this.btnOpenJsonFile.Size = new System.Drawing.Size(108, 47);
            this.btnOpenJsonFile.TabIndex = 0;
            this.btnOpenJsonFile.Text = "Открыть файл и удалить дубликаты";
            this.btnOpenJsonFile.UseVisualStyleBackColor = true;
            this.btnOpenJsonFile.Click += new System.EventHandler(this.btnOpenJsonFile_Click);
            // 
            // btnSaveJsonFile
            // 
            this.btnSaveJsonFile.Enabled = false;
            this.btnSaveJsonFile.Location = new System.Drawing.Point(163, 21);
            this.btnSaveJsonFile.Name = "btnSaveJsonFile";
            this.btnSaveJsonFile.Size = new System.Drawing.Size(108, 47);
            this.btnSaveJsonFile.TabIndex = 1;
            this.btnSaveJsonFile.Text = "Сохранить файл";
            this.btnSaveJsonFile.UseVisualStyleBackColor = true;
            this.btnSaveJsonFile.Click += new System.EventHandler(this.btnSaveJsonFile_Click);
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 88);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(956, 451);
            this.dgvLogs.TabIndex = 2;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnOpenJsonFile);
            this.panelMenu.Controls.Add(this.btnSaveJsonFile);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(956, 88);
            this.panelMenu.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 539);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление дубликатов из файла Json";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenJsonFile;
        private System.Windows.Forms.Button btnSaveJsonFile;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Panel panelMenu;
    }
}

