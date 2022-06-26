namespace Staff_database
{
    partial class SettingsForm
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
            this.connectionStringText = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.roleBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.loginBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.deleteUser = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.roleText = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.passwordText = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.passwordLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.loginText = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.loginLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.addNewUser = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.AccoutingLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.connectionStringText)).BeginInit();
            this.connectionStringText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleText)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionStringText
            // 
            this.connectionStringText.Controls.Add(this.kryptonGroupBox2);
            this.connectionStringText.Controls.Add(this.kryptonGroupBox1);
            this.connectionStringText.Controls.Add(this.AccoutingLabel);
            this.connectionStringText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionStringText.Location = new System.Drawing.Point(0, 0);
            this.connectionStringText.Name = "connectionStringText";
            this.connectionStringText.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderCustom1;
            this.connectionStringText.Size = new System.Drawing.Size(824, 430);
            this.connectionStringText.TabIndex = 0;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.CaptionOverlap = 0.2D;
            this.kryptonGroupBox2.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(434, 68);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Panel.Controls.Add(this.roleBox);
            this.kryptonGroupBox2.Panel.Controls.Add(this.loginBox);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Panel.Controls.Add(this.deleteUser);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(354, 255);
            this.kryptonGroupBox2.TabIndex = 9;
            this.kryptonGroupBox2.Values.Heading = "Удаление пользователя";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 21);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(50, 23);
            this.kryptonLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Роль";
            // 
            // roleBox
            // 
            this.roleBox.DropDownWidth = 208;
            this.roleBox.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.roleBox.Items.AddRange(new object[] {
            "Администратор",
            "Бухгалтер",
            "Кадровик"});
            this.roleBox.Location = new System.Drawing.Point(113, 20);
            this.roleBox.Name = "roleBox";
            this.roleBox.Size = new System.Drawing.Size(208, 24);
            this.roleBox.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleBox.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleBox.TabIndex = 10;
            this.roleBox.Text = "Выберите роль";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(113, 62);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(208, 27);
            this.loginBox.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginBox.TabIndex = 7;
            this.loginBox.Text = "Введите логин";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(22, 62);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(57, 23);
            this.kryptonLabel4.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Логин";
            // 
            // deleteUser
            // 
            this.deleteUser.AutoSize = true;
            this.deleteUser.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.deleteUser.Location = new System.Drawing.Point(128, 161);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.deleteUser.Size = new System.Drawing.Size(103, 35);
            this.deleteUser.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteUser.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUser.TabIndex = 4;
            this.deleteUser.Values.Text = "  Удалить";
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionOverlap = 0.2D;
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(42, 68);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.roleText);
            this.kryptonGroupBox1.Panel.Controls.Add(this.passwordText);
            this.kryptonGroupBox1.Panel.Controls.Add(this.passwordLabel);
            this.kryptonGroupBox1.Panel.Controls.Add(this.loginText);
            this.kryptonGroupBox1.Panel.Controls.Add(this.loginLabel);
            this.kryptonGroupBox1.Panel.Controls.Add(this.addNewUser);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(354, 255);
            this.kryptonGroupBox1.TabIndex = 8;
            this.kryptonGroupBox1.Values.Heading = "Задание нового пользователя";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(22, 21);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(50, 23);
            this.kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel1.TabIndex = 11;
            this.kryptonLabel1.Values.Text = "Роль";
            // 
            // roleText
            // 
            this.roleText.DropDownWidth = 208;
            this.roleText.Items.AddRange(new object[] {
            "Администратор",
            "Бухгалтер",
            "Кадровик"});
            this.roleText.Location = new System.Drawing.Point(113, 20);
            this.roleText.Name = "roleText";
            this.roleText.Size = new System.Drawing.Size(208, 24);
            this.roleText.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleText.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roleText.TabIndex = 10;
            this.roleText.Text = "Выберите роль";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(113, 106);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(208, 27);
            this.passwordText.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordText.TabIndex = 9;
            this.passwordText.Text = "Введите пароль";
            // 
            // passwordLabel
            // 
            this.passwordLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.passwordLabel.Location = new System.Drawing.Point(22, 106);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 23);
            this.passwordLabel.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Values.Text = "Пароль";
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(113, 62);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(208, 27);
            this.loginText.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginText.TabIndex = 7;
            this.loginText.Text = "Введите логин";
            // 
            // loginLabel
            // 
            this.loginLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.loginLabel.Location = new System.Drawing.Point(22, 62);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(57, 23);
            this.loginLabel.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Values.Text = "Логин";
            // 
            // addNewUser
            // 
            this.addNewUser.AutoSize = true;
            this.addNewUser.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.addNewUser.Location = new System.Drawing.Point(128, 161);
            this.addNewUser.Name = "addNewUser";
            this.addNewUser.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.addNewUser.Size = new System.Drawing.Size(103, 35);
            this.addNewUser.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNewUser.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewUser.TabIndex = 4;
            this.addNewUser.Values.Text = "  Задать";
            this.addNewUser.Click += new System.EventHandler(this.personalCardsButton_Click);
            // 
            // AccoutingLabel
            // 
            this.AccoutingLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AccoutingLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.AccoutingLabel.Location = new System.Drawing.Point(356, 12);
            this.AccoutingLabel.Name = "AccoutingLabel";
            this.AccoutingLabel.Size = new System.Drawing.Size(110, 29);
            this.AccoutingLabel.StateNormal.LongText.Font = new System.Drawing.Font("MS Outlook", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.AccoutingLabel.TabIndex = 2;
            this.AccoutingLabel.Values.Text = "Настройки";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 430);
            this.Controls.Add(this.connectionStringText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.connectionStringText)).EndInit();
            this.connectionStringText.ResumeLayout(false);
            this.connectionStringText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel connectionStringText;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel AccoutingLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton addNewUser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel loginLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox loginText;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel passwordLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox roleText;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox roleBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox loginBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton deleteUser;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox passwordText;
    }
}