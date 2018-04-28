using Sdl.Desktop.IntegrationApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExSegmentLocker
{
    public class MyCustomBatchTaskSettingsControl : UserControl, ISettingsAware<MyCustomBatchTaskSettings>
    {
        private TextBox txtRegEx;
        private CheckBox chkbxIncludeTagContent;
        private Label label1;
        private Button btnRegexEmail;
        private Label label3;
        private Button btnRegexUrl;
        private Button btnRegexCopyTitle;
        private Button btnRegexNumber;
        private Button btnRegexString;
        private DataGridView dgvRegEx;
        private Button btnAddEmptyRow;
        private Button btnDeleteRow;
        private DataGridViewTextBoxColumn RegEx;
        private DataGridViewTextBoxColumn Description;
        private Label lbRegEx;

        public MyCustomBatchTaskSettings Settings { get; set; }

        public MyCustomBatchTaskSettingsControl()
        {
            InitializeComponent();
        }


        public void SetSettings(MyCustomBatchTaskSettings taskSettings)
        {
            // sets the UI element, i.e. the status dropdown list to the corresponding segment status value
            Settings = taskSettings;

            if (Settings.RegexPatterns == null) Settings.RegexPatterns = new BindingList<RegExPattern>();

            SettingsBinder.DataBindSetting<BindingList<RegExPattern>>(dgvRegEx, "DataSource", Settings, nameof(Settings.RegexPatterns));
            SettingsBinder.DataBindSetting<bool>(chkbxIncludeTagContent, "Checked", Settings, nameof(Settings.IncludeTagContent));

            dgvRegEx.DataSource = Settings.RegexPatterns;

            UpdateUI(taskSettings);
        }

        public void UpdateSettings(MyCustomBatchTaskSettings mySettings)
        {
            Settings = mySettings;
        }

        // Updates the UI elements to the corresponding settings
        public void UpdateUI(MyCustomBatchTaskSettings mySettings)
        {
            Settings = mySettings;
            this.UpdateSettings(Settings);
        }


        // The control elements on the UI are configured with the corresponding values
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetSettings(Settings);
        }


        private void InitializeComponent()
        {
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.lbRegEx = new System.Windows.Forms.Label();
            this.chkbxIncludeTagContent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegexEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegexUrl = new System.Windows.Forms.Button();
            this.btnRegexCopyTitle = new System.Windows.Forms.Button();
            this.btnRegexNumber = new System.Windows.Forms.Button();
            this.btnRegexString = new System.Windows.Forms.Button();
            this.dgvRegEx = new System.Windows.Forms.DataGridView();
            this.btnAddEmptyRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.RegEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegEx)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRegEx
            // 
            this.txtRegEx.Location = new System.Drawing.Point(17, 38);
            this.txtRegEx.Multiline = true;
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegEx.Size = new System.Drawing.Size(355, 155);
            this.txtRegEx.TabIndex = 0;
            this.txtRegEx.Text = "[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\r\n(https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6" +
    "})([\\/\\w \\.-]*)*\\/?";
            // 
            // lbRegEx
            // 
            this.lbRegEx.AutoSize = true;
            this.lbRegEx.Location = new System.Drawing.Point(17, 19);
            this.lbRegEx.Name = "lbRegEx";
            this.lbRegEx.Size = new System.Drawing.Size(170, 13);
            this.lbRegEx.TabIndex = 1;
            this.lbRegEx.Text = "Regular Expressions: (one per line)";
            // 
            // chkbxIncludeTagContent
            // 
            this.chkbxIncludeTagContent.AutoSize = true;
            this.chkbxIncludeTagContent.Location = new System.Drawing.Point(20, 206);
            this.chkbxIncludeTagContent.Name = "chkbxIncludeTagContent";
            this.chkbxIncludeTagContent.Size = new System.Drawing.Size(118, 17);
            this.chkbxIncludeTagContent.TabIndex = 2;
            this.chkbxIncludeTagContent.Text = "Include tag content";
            this.chkbxIncludeTagContent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "Example: Text inside html tags, like this:\r\n<a href=\"http://www.thislink.com\">exa" +
    "mple</a>\r\nIf checked, the href content will be scanned too. \r\nText inbetween tag" +
    "s will always be scanned.\r\n";
            // 
            // btnRegexEmail
            // 
            this.btnRegexEmail.Location = new System.Drawing.Point(378, 54);
            this.btnRegexEmail.Name = "btnRegexEmail";
            this.btnRegexEmail.Size = new System.Drawing.Size(183, 23);
            this.btnRegexEmail.TabIndex = 5;
            this.btnRegexEmail.Text = "Email, e.g. me@url.com";
            this.btnRegexEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegexEmail.UseVisualStyleBackColor = true;
            this.btnRegexEmail.Click += new System.EventHandler(this.btnRegexEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Add a regex for:";
            // 
            // btnRegexUrl
            // 
            this.btnRegexUrl.Location = new System.Drawing.Point(378, 83);
            this.btnRegexUrl.Name = "btnRegexUrl";
            this.btnRegexUrl.Size = new System.Drawing.Size(183, 23);
            this.btnRegexUrl.TabIndex = 7;
            this.btnRegexUrl.Text = "URL, e.g. http:\\\\something.com";
            this.btnRegexUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegexUrl.UseVisualStyleBackColor = true;
            this.btnRegexUrl.Click += new System.EventHandler(this.btnRegexUrl_Click);
            // 
            // btnRegexCopyTitle
            // 
            this.btnRegexCopyTitle.Location = new System.Drawing.Point(378, 112);
            this.btnRegexCopyTitle.Name = "btnRegexCopyTitle";
            this.btnRegexCopyTitle.Size = new System.Drawing.Size(183, 23);
            this.btnRegexCopyTitle.TabIndex = 8;
            this.btnRegexCopyTitle.Text = "Copy title, e.g. ((Headline))";
            this.btnRegexCopyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegexCopyTitle.UseVisualStyleBackColor = true;
            this.btnRegexCopyTitle.Click += new System.EventHandler(this.btnRegexCopyTitle_Click);
            // 
            // btnRegexNumber
            // 
            this.btnRegexNumber.Location = new System.Drawing.Point(378, 141);
            this.btnRegexNumber.Name = "btnRegexNumber";
            this.btnRegexNumber.Size = new System.Drawing.Size(183, 23);
            this.btnRegexNumber.TabIndex = 9;
            this.btnRegexNumber.Text = "Number, e.g. 1234";
            this.btnRegexNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegexNumber.UseVisualStyleBackColor = true;
            this.btnRegexNumber.Click += new System.EventHandler(this.btnRegexNumber_Click);
            // 
            // btnRegexString
            // 
            this.btnRegexString.Location = new System.Drawing.Point(378, 170);
            this.btnRegexString.Name = "btnRegexString";
            this.btnRegexString.Size = new System.Drawing.Size(183, 23);
            this.btnRegexString.TabIndex = 10;
            this.btnRegexString.Text = "String, e.g. \"This Text\"";
            this.btnRegexString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegexString.UseVisualStyleBackColor = true;
            this.btnRegexString.Click += new System.EventHandler(this.btnRegexString_Click);
            // 
            // dgvRegEx
            // 
            this.dgvRegEx.AllowUserToOrderColumns = true;
            this.dgvRegEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegEx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegEx,
            this.Description});
            this.dgvRegEx.Location = new System.Drawing.Point(17, 333);
            this.dgvRegEx.Name = "dgvRegEx";
            this.dgvRegEx.Size = new System.Drawing.Size(355, 150);
            this.dgvRegEx.TabIndex = 11;
            // 
            // btnAddEmptyRow
            // 
            this.btnAddEmptyRow.Location = new System.Drawing.Point(378, 333);
            this.btnAddEmptyRow.Name = "btnAddEmptyRow";
            this.btnAddEmptyRow.Size = new System.Drawing.Size(183, 23);
            this.btnAddEmptyRow.TabIndex = 12;
            this.btnAddEmptyRow.Text = "Add empty row";
            this.btnAddEmptyRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEmptyRow.UseVisualStyleBackColor = true;
            this.btnAddEmptyRow.Click += new System.EventHandler(this.btnAddEmptyRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(378, 460);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(183, 23);
            this.btnDeleteRow.TabIndex = 13;
            this.btnDeleteRow.Text = "Delete row";
            this.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // RegEx
            // 
            this.RegEx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegEx.DataPropertyName = "Pattern";
            this.RegEx.HeaderText = "RegEx";
            this.RegEx.Name = "RegEx";
            this.RegEx.Width = 212;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // MyCustomBatchTaskSettingsControl
            // 
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnAddEmptyRow);
            this.Controls.Add(this.dgvRegEx);
            this.Controls.Add(this.btnRegexString);
            this.Controls.Add(this.btnRegexNumber);
            this.Controls.Add(this.btnRegexCopyTitle);
            this.Controls.Add(this.btnRegexUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRegexEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbxIncludeTagContent);
            this.Controls.Add(this.lbRegEx);
            this.Controls.Add(this.txtRegEx);
            this.Name = "MyCustomBatchTaskSettingsControl";
            this.Size = new System.Drawing.Size(564, 491);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnRegexEmail_Click(object sender, EventArgs e)
        {
            txtRegEx.Text += Environment.NewLine + @"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}";

        }

        private void btnRegexUrl_Click(object sender, EventArgs e)
        {
            txtRegEx.Text += Environment.NewLine + @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";
        }

        private void btnRegexCopyTitle_Click(object sender, EventArgs e)
        {
            txtRegEx.Text += Environment.NewLine + @"\(\(.*?\)\)";
        }

        private void btnRegexNumber_Click(object sender, EventArgs e)
        {
            txtRegEx.Text += Environment.NewLine + @"\d";
        }

        private void btnRegexString_Click(object sender, EventArgs e)
        {
            txtRegEx.Text += Environment.NewLine + @"This\sText";
        }

        private void btnAddEmptyRow_Click(object sender, EventArgs e)
        {
            Settings.RegexPatterns.Add(new RegExPattern { Description = "", Pattern = "" });
            dgvRegEx.DataSource = Settings.RegexPatterns;

            //dgvRegEx.Rows.Add("reg ex", "desc");
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRegEx.SelectedRows)
            {
                dgvRegEx.Rows.Remove(row);
            }
        }


    }
}
