
namespace AnimalsApplication
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.classesComboBox = new System.Windows.Forms.ComboBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.animalsListBox = new System.Windows.Forms.ListBox();
            this.filteredAnimalsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.classesComboBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.typeTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.acceptButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.animalsListBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.filteredAnimalsListBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(410, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Животные выбранного класса";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classesComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.classesComboBox, 2);
            this.classesComboBox.DisplayMember = "AnimalClassName";
            this.classesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.classesComboBox.FormattingEnabled = true;
            this.classesComboBox.Location = new System.Drawing.Point(10, 10);
            this.classesComboBox.Margin = new System.Windows.Forms.Padding(10);
            this.classesComboBox.Name = "classesComboBox";
            this.classesComboBox.Size = new System.Drawing.Size(380, 21);
            this.classesComboBox.TabIndex = 0;
            this.classesComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClassesComboBox_SelectionChangeCommitted);
            // 
            // typeTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.typeTextBox, 2);
            this.typeTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.typeTextBox.Location = new System.Drawing.Point(410, 10);
            this.typeTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(380, 20);
            this.typeTextBox.TabIndex = 1;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Location = new System.Drawing.Point(715, 433);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(10);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 2;
            this.acceptButton.Text = "Добавить";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // animalsListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.animalsListBox, 2);
            this.animalsListBox.DisplayMember = "AnimalType";
            this.animalsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animalsListBox.FormattingEnabled = true;
            this.animalsListBox.Location = new System.Drawing.Point(10, 71);
            this.animalsListBox.Margin = new System.Windows.Forms.Padding(10);
            this.animalsListBox.Name = "animalsListBox";
            this.animalsListBox.Size = new System.Drawing.Size(380, 342);
            this.animalsListBox.TabIndex = 3;
            // 
            // filteredAnimalsListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.filteredAnimalsListBox, 2);
            this.filteredAnimalsListBox.DisplayMember = "AnimalType";
            this.filteredAnimalsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filteredAnimalsListBox.FormattingEnabled = true;
            this.filteredAnimalsListBox.Location = new System.Drawing.Point(410, 71);
            this.filteredAnimalsListBox.Margin = new System.Windows.Forms.Padding(10);
            this.filteredAnimalsListBox.Name = "filteredAnimalsListBox";
            this.filteredAnimalsListBox.Size = new System.Drawing.Size(380, 342);
            this.filteredAnimalsListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Все животные";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(10, 433);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 433);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сохранить репозиторий как...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Животные";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox classesComboBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ListBox animalsListBox;
        private System.Windows.Forms.ListBox filteredAnimalsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;
    }
}

