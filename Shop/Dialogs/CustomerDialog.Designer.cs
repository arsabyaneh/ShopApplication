namespace Shop.Dialogs
{
    partial class CustomerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CodeLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.BirthDateLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.TelephoneLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Telephone = new System.Windows.Forms.MaskedTextBox();
            this.Country = new Shop.Controls.CountryBox();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.Panel = new System.Windows.Forms.Panel();
            this.Female = new System.Windows.Forms.RadioButton();
            this.Male = new System.Windows.Forms.RadioButton();
            this.LastName = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.MaskedTextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.CustomerGroupBox.SuspendLayout();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeLabel.Location = new System.Drawing.Point(19, 35);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(39, 14);
            this.CodeLabel.TabIndex = 0;
            this.CodeLabel.Text = "Code:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(19, 62);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(68, 14);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(19, 89);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(68, 14);
            this.LastNameLabel.TabIndex = 2;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.Location = new System.Drawing.Point(19, 116);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(51, 14);
            this.GenderLabel.TabIndex = 3;
            this.GenderLabel.Text = "Gender:";
            // 
            // BirthDateLabel
            // 
            this.BirthDateLabel.AutoSize = true;
            this.BirthDateLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthDateLabel.Location = new System.Drawing.Point(19, 143);
            this.BirthDateLabel.Name = "BirthDateLabel";
            this.BirthDateLabel.Size = new System.Drawing.Size(66, 14);
            this.BirthDateLabel.TabIndex = 4;
            this.BirthDateLabel.Text = "Birth Date:";
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountryLabel.Location = new System.Drawing.Point(19, 170);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(54, 14);
            this.CountryLabel.TabIndex = 5;
            this.CountryLabel.Text = "Country:";
            // 
            // TelephoneLabel
            // 
            this.TelephoneLabel.AutoSize = true;
            this.TelephoneLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelephoneLabel.Location = new System.Drawing.Point(19, 197);
            this.TelephoneLabel.Name = "TelephoneLabel";
            this.TelephoneLabel.Size = new System.Drawing.Size(70, 14);
            this.TelephoneLabel.TabIndex = 6;
            this.TelephoneLabel.Text = "Telephone:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(19, 251);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(54, 14);
            this.AddressLabel.TabIndex = 7;
            this.AddressLabel.Text = "Address:";
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.Email);
            this.CustomerGroupBox.Controls.Add(this.EmailLabel);
            this.CustomerGroupBox.Controls.Add(this.Address);
            this.CustomerGroupBox.Controls.Add(this.Telephone);
            this.CustomerGroupBox.Controls.Add(this.Country);
            this.CustomerGroupBox.Controls.Add(this.BirthDate);
            this.CustomerGroupBox.Controls.Add(this.Panel);
            this.CustomerGroupBox.Controls.Add(this.LastName);
            this.CustomerGroupBox.Controls.Add(this.FirstName);
            this.CustomerGroupBox.Controls.Add(this.AddressLabel);
            this.CustomerGroupBox.Controls.Add(this.Code);
            this.CustomerGroupBox.Controls.Add(this.TelephoneLabel);
            this.CustomerGroupBox.Controls.Add(this.CodeLabel);
            this.CustomerGroupBox.Controls.Add(this.CountryLabel);
            this.CustomerGroupBox.Controls.Add(this.FirstNameLabel);
            this.CustomerGroupBox.Controls.Add(this.BirthDateLabel);
            this.CustomerGroupBox.Controls.Add(this.LastNameLabel);
            this.CustomerGroupBox.Controls.Add(this.GenderLabel);
            this.CustomerGroupBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerGroupBox.Location = new System.Drawing.Point(12, 12);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(420, 367);
            this.CustomerGroupBox.TabIndex = 8;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Customer Profile Info.";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(95, 248);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Address.Size = new System.Drawing.Size(317, 110);
            this.Address.TabIndex = 14;
            // 
            // Telephone
            // 
            this.Telephone.Location = new System.Drawing.Point(95, 194);
            this.Telephone.Mask = "(999) 000-0000";
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(317, 22);
            this.Telephone.TabIndex = 13;
            // 
            // Country
            // 
            this.Country.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Country.FormattingEnabled = true;
            this.Country.Items.AddRange(new object[] {
            "Austria",
            "Canada",
            "France"});
            this.Country.Location = new System.Drawing.Point(95, 167);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(317, 23);
            this.Country.TabIndex = 12;
            // 
            // BirthDate
            // 
            this.BirthDate.Location = new System.Drawing.Point(95, 140);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(317, 22);
            this.BirthDate.TabIndex = 11;
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.Female);
            this.Panel.Controls.Add(this.Male);
            this.Panel.Location = new System.Drawing.Point(95, 113);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(317, 22);
            this.Panel.TabIndex = 10;
            // 
            // Female
            // 
            this.Female.AutoSize = true;
            this.Female.Location = new System.Drawing.Point(61, 2);
            this.Female.Name = "Female";
            this.Female.Size = new System.Drawing.Size(63, 18);
            this.Female.TabIndex = 11;
            this.Female.Text = "Female";
            this.Female.UseVisualStyleBackColor = true;
            // 
            // Male
            // 
            this.Male.AutoSize = true;
            this.Male.Checked = true;
            this.Male.Location = new System.Drawing.Point(6, 2);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(49, 18);
            this.Male.TabIndex = 0;
            this.Male.TabStop = true;
            this.Male.Text = "Male";
            this.Male.UseVisualStyleBackColor = true;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(95, 86);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(317, 22);
            this.LastName.TabIndex = 9;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(95, 59);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(317, 22);
            this.FirstName.TabIndex = 8;
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(95, 32);
            this.Code.Mask = "00000";
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(100, 22);
            this.Code.TabIndex = 0;
            this.Code.ValidatingType = typeof(int);
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(276, 391);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 9;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(357, 391);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(19, 224);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(38, 14);
            this.EmailLabel.TabIndex = 15;
            this.EmailLabel.Text = "Email:";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(95, 221);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(317, 22);
            this.Email.TabIndex = 16;
            // 
            // CustomerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 425);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.CustomerGroupBox);
            this.Name = "CustomerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
            this.CustomerGroupBox.ResumeLayout(false);
            this.CustomerGroupBox.PerformLayout();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label BirthDateLabel;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.Label TelephoneLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.MaskedTextBox Code;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.RadioButton Female;
        private System.Windows.Forms.RadioButton Male;
        private Controls.CountryBox Country;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.MaskedTextBox Telephone;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label EmailLabel;
    }
}