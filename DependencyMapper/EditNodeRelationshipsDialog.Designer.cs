namespace DependencyMapper
{
  partial class EditNodeRelationshipsDialog
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
      this.nodesList = new System.Windows.Forms.CheckedListBox();
      this.closeBtn = new System.Windows.Forms.Button();
      this.filterTxtBox = new System.Windows.Forms.TextBox();
      this.clearFilterBtn = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.changesLbl = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.showIndirectRelationsChkBox = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // nodesList
      // 
      this.nodesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesList.CheckOnClick = true;
      this.nodesList.FormattingEnabled = true;
      this.nodesList.Location = new System.Drawing.Point(12, 12);
      this.nodesList.Name = "nodesList";
      this.nodesList.Size = new System.Drawing.Size(302, 490);
      this.nodesList.Sorted = true;
      this.nodesList.TabIndex = 0;
      this.nodesList.SelectedValueChanged += new System.EventHandler(this.nodesList_SelectedValueChanged);
      // 
      // closeBtn
      // 
      this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeBtn.Location = new System.Drawing.Point(431, 479);
      this.closeBtn.Name = "closeBtn";
      this.closeBtn.Size = new System.Drawing.Size(75, 23);
      this.closeBtn.TabIndex = 3;
      this.closeBtn.Text = "Close";
      this.closeBtn.UseVisualStyleBackColor = true;
      this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
      // 
      // filterTxtBox
      // 
      this.filterTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.filterTxtBox.Location = new System.Drawing.Point(365, 50);
      this.filterTxtBox.Name = "filterTxtBox";
      this.filterTxtBox.Size = new System.Drawing.Size(109, 23);
      this.filterTxtBox.TabIndex = 1;
      this.filterTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filterTxtBox_KeyPress);
      // 
      // clearFilterBtn
      // 
      this.clearFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clearFilterBtn.Location = new System.Drawing.Point(480, 50);
      this.clearFilterBtn.Name = "clearFilterBtn";
      this.clearFilterBtn.Size = new System.Drawing.Size(26, 23);
      this.clearFilterBtn.TabIndex = 2;
      this.clearFilterBtn.Text = "X";
      this.clearFilterBtn.UseVisualStyleBackColor = true;
      this.clearFilterBtn.Click += new System.EventHandler(this.clearFilterBtn_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.changesLbl);
      this.groupBox1.Location = new System.Drawing.Point(326, 92);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(180, 371);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Changes";
      // 
      // changesLbl
      // 
      this.changesLbl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.changesLbl.Location = new System.Drawing.Point(3, 19);
      this.changesLbl.Name = "changesLbl";
      this.changesLbl.Size = new System.Drawing.Size(174, 349);
      this.changesLbl.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(326, 54);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 15);
      this.label1.TabIndex = 6;
      this.label1.Text = "Filter";
      // 
      // showIndirectRelationsChkBox
      // 
      this.showIndirectRelationsChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.showIndirectRelationsChkBox.AutoSize = true;
      this.showIndirectRelationsChkBox.Location = new System.Drawing.Point(365, 25);
      this.showIndirectRelationsChkBox.Name = "showIndirectRelationsChkBox";
      this.showIndirectRelationsChkBox.Size = new System.Drawing.Size(146, 19);
      this.showIndirectRelationsChkBox.TabIndex = 7;
      this.showIndirectRelationsChkBox.Text = "Show indirect relations";
      this.showIndirectRelationsChkBox.UseVisualStyleBackColor = true;
      this.showIndirectRelationsChkBox.CheckedChanged += new System.EventHandler(this.showIndirectRelationsChkBox_CheckedChanged);
      // 
      // EditNodeRelationshipsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(518, 515);
      this.ControlBox = false;
      this.Controls.Add(this.showIndirectRelationsChkBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.clearFilterBtn);
      this.Controls.Add(this.filterTxtBox);
      this.Controls.Add(this.closeBtn);
      this.Controls.Add(this.nodesList);
      this.Name = "EditNodeRelationshipsDialog";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "<<set by code>>";
      this.Load += new System.EventHandler(this.EditNodeRelationshipsDialog_Load);
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckedListBox nodesList;
    private System.Windows.Forms.Button closeBtn;
    private System.Windows.Forms.TextBox filterTxtBox;
    private System.Windows.Forms.Button clearFilterBtn;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label changesLbl;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox showIndirectRelationsChkBox;
  }
}