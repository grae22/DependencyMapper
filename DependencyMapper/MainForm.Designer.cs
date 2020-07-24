namespace DependencyMapper
{
  partial class MainForm
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
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
      this.mainLeftLayout = new System.Windows.Forms.TableLayoutPanel();
      this.nodeRelationshipsGroup = new System.Windows.Forms.GroupBox();
      this.nodeRelationshipsList = new System.Windows.Forms.ListBox();
      this.nodeRelationshipsEdit = new System.Windows.Forms.Button();
      this.nodeDependantsBtn = new System.Windows.Forms.RadioButton();
      this.nodeDependenciesBtn = new System.Windows.Forms.RadioButton();
      this.nodeBox = new System.Windows.Forms.GroupBox();
      this.nodeDeleteBtn = new System.Windows.Forms.Button();
      this.newNodeBtn = new System.Windows.Forms.Button();
      this.nodeSaveBtn = new System.Windows.Forms.Button();
      this.nodeCategoryDropdown = new System.Windows.Forms.ComboBox();
      this.nodeCategoryLabel = new System.Windows.Forms.Label();
      this.nodeDescriptionTxtBox = new System.Windows.Forms.TextBox();
      this.nodeDescriptionLabel = new System.Windows.Forms.Label();
      this.nodeNameLabel = new System.Windows.Forms.Label();
      this.nodeNameTxtBox = new System.Windows.Forms.TextBox();
      this.nodesGroup = new System.Windows.Forms.GroupBox();
      this.nodesList = new System.Windows.Forms.ListBox();
      this.menuStrip.SuspendLayout();
      this.mainLayout.SuspendLayout();
      this.mainLeftLayout.SuspendLayout();
      this.nodeRelationshipsGroup.SuspendLayout();
      this.nodeBox.SuspendLayout();
      this.nodesGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(1157, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
      this.toolStripMenuItem1.Text = "&File";
      // 
      // mainLayout
      // 
      this.mainLayout.ColumnCount = 3;
      this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.61971F));
      this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.75627F));
      this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.71046F));
      this.mainLayout.Controls.Add(this.mainLeftLayout, 1, 0);
      this.mainLayout.Controls.Add(this.nodesGroup, 0, 0);
      this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainLayout.Location = new System.Drawing.Point(0, 24);
      this.mainLayout.Name = "mainLayout";
      this.mainLayout.RowCount = 1;
      this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainLayout.Size = new System.Drawing.Size(1157, 713);
      this.mainLayout.TabIndex = 1;
      // 
      // mainLeftLayout
      // 
      this.mainLeftLayout.ColumnCount = 1;
      this.mainLeftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainLeftLayout.Controls.Add(this.nodeRelationshipsGroup, 0, 1);
      this.mainLeftLayout.Controls.Add(this.nodeBox, 0, 0);
      this.mainLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainLeftLayout.Location = new System.Drawing.Point(229, 3);
      this.mainLeftLayout.Name = "mainLeftLayout";
      this.mainLeftLayout.RowCount = 2;
      this.mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.mainLeftLayout.Size = new System.Drawing.Size(291, 707);
      this.mainLeftLayout.TabIndex = 0;
      // 
      // nodeRelationshipsGroup
      // 
      this.nodeRelationshipsGroup.Controls.Add(this.nodeRelationshipsList);
      this.nodeRelationshipsGroup.Controls.Add(this.nodeRelationshipsEdit);
      this.nodeRelationshipsGroup.Controls.Add(this.nodeDependantsBtn);
      this.nodeRelationshipsGroup.Controls.Add(this.nodeDependenciesBtn);
      this.nodeRelationshipsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nodeRelationshipsGroup.Location = new System.Drawing.Point(3, 188);
      this.nodeRelationshipsGroup.Name = "nodeRelationshipsGroup";
      this.nodeRelationshipsGroup.Size = new System.Drawing.Size(285, 516);
      this.nodeRelationshipsGroup.TabIndex = 4;
      this.nodeRelationshipsGroup.TabStop = false;
      this.nodeRelationshipsGroup.Text = "Node Relationships";
      // 
      // nodeRelationshipsList
      // 
      this.nodeRelationshipsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeRelationshipsList.FormattingEnabled = true;
      this.nodeRelationshipsList.ItemHeight = 15;
      this.nodeRelationshipsList.Location = new System.Drawing.Point(19, 59);
      this.nodeRelationshipsList.Name = "nodeRelationshipsList";
      this.nodeRelationshipsList.Size = new System.Drawing.Size(250, 439);
      this.nodeRelationshipsList.TabIndex = 2;
      // 
      // nodeRelationshipsEdit
      // 
      this.nodeRelationshipsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeRelationshipsEdit.Location = new System.Drawing.Point(217, 32);
      this.nodeRelationshipsEdit.Name = "nodeRelationshipsEdit";
      this.nodeRelationshipsEdit.Size = new System.Drawing.Size(52, 23);
      this.nodeRelationshipsEdit.TabIndex = 1;
      this.nodeRelationshipsEdit.Text = "Edit";
      this.nodeRelationshipsEdit.UseVisualStyleBackColor = true;
      // 
      // nodeDependantsBtn
      // 
      this.nodeDependantsBtn.AutoSize = true;
      this.nodeDependantsBtn.Location = new System.Drawing.Point(124, 34);
      this.nodeDependantsBtn.Name = "nodeDependantsBtn";
      this.nodeDependantsBtn.Size = new System.Drawing.Size(88, 19);
      this.nodeDependantsBtn.TabIndex = 0;
      this.nodeDependantsBtn.Text = "Dependants";
      this.nodeDependantsBtn.UseVisualStyleBackColor = true;
      // 
      // nodeDependenciesBtn
      // 
      this.nodeDependenciesBtn.AutoSize = true;
      this.nodeDependenciesBtn.Checked = true;
      this.nodeDependenciesBtn.Location = new System.Drawing.Point(19, 34);
      this.nodeDependenciesBtn.Name = "nodeDependenciesBtn";
      this.nodeDependenciesBtn.Size = new System.Drawing.Size(99, 19);
      this.nodeDependenciesBtn.TabIndex = 0;
      this.nodeDependenciesBtn.TabStop = true;
      this.nodeDependenciesBtn.Text = "Dependencies";
      this.nodeDependenciesBtn.UseVisualStyleBackColor = true;
      // 
      // nodeBox
      // 
      this.nodeBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.nodeBox.Controls.Add(this.nodeDeleteBtn);
      this.nodeBox.Controls.Add(this.newNodeBtn);
      this.nodeBox.Controls.Add(this.nodeSaveBtn);
      this.nodeBox.Controls.Add(this.nodeCategoryDropdown);
      this.nodeBox.Controls.Add(this.nodeCategoryLabel);
      this.nodeBox.Controls.Add(this.nodeDescriptionTxtBox);
      this.nodeBox.Controls.Add(this.nodeDescriptionLabel);
      this.nodeBox.Controls.Add(this.nodeNameLabel);
      this.nodeBox.Controls.Add(this.nodeNameTxtBox);
      this.nodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nodeBox.Location = new System.Drawing.Point(3, 3);
      this.nodeBox.Name = "nodeBox";
      this.nodeBox.Size = new System.Drawing.Size(285, 179);
      this.nodeBox.TabIndex = 0;
      this.nodeBox.TabStop = false;
      this.nodeBox.Text = "Node";
      // 
      // nodeDeleteBtn
      // 
      this.nodeDeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeDeleteBtn.Location = new System.Drawing.Point(113, 138);
      this.nodeDeleteBtn.Name = "nodeDeleteBtn";
      this.nodeDeleteBtn.Size = new System.Drawing.Size(75, 23);
      this.nodeDeleteBtn.TabIndex = 3;
      this.nodeDeleteBtn.Text = "Delete";
      this.nodeDeleteBtn.UseVisualStyleBackColor = true;
      // 
      // newNodeBtn
      // 
      this.newNodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.newNodeBtn.Location = new System.Drawing.Point(194, 22);
      this.newNodeBtn.Name = "newNodeBtn";
      this.newNodeBtn.Size = new System.Drawing.Size(75, 23);
      this.newNodeBtn.TabIndex = 3;
      this.newNodeBtn.Text = "New";
      this.newNodeBtn.UseVisualStyleBackColor = true;
      this.newNodeBtn.Click += new System.EventHandler(this.newNodeBtn_Click);
      // 
      // nodeSaveBtn
      // 
      this.nodeSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeSaveBtn.Location = new System.Drawing.Point(194, 138);
      this.nodeSaveBtn.Name = "nodeSaveBtn";
      this.nodeSaveBtn.Size = new System.Drawing.Size(75, 23);
      this.nodeSaveBtn.TabIndex = 3;
      this.nodeSaveBtn.Text = "Save";
      this.nodeSaveBtn.UseVisualStyleBackColor = true;
      this.nodeSaveBtn.Click += new System.EventHandler(this.nodeSaveBtn_Click);
      // 
      // nodeCategoryDropdown
      // 
      this.nodeCategoryDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeCategoryDropdown.FormattingEnabled = true;
      this.nodeCategoryDropdown.Location = new System.Drawing.Point(98, 109);
      this.nodeCategoryDropdown.Name = "nodeCategoryDropdown";
      this.nodeCategoryDropdown.Size = new System.Drawing.Size(171, 23);
      this.nodeCategoryDropdown.TabIndex = 2;
      // 
      // nodeCategoryLabel
      // 
      this.nodeCategoryLabel.AutoSize = true;
      this.nodeCategoryLabel.Location = new System.Drawing.Point(19, 112);
      this.nodeCategoryLabel.Name = "nodeCategoryLabel";
      this.nodeCategoryLabel.Size = new System.Drawing.Size(55, 15);
      this.nodeCategoryLabel.TabIndex = 1;
      this.nodeCategoryLabel.Text = "Category";
      // 
      // nodeDescriptionTxtBox
      // 
      this.nodeDescriptionTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeDescriptionTxtBox.Location = new System.Drawing.Point(98, 80);
      this.nodeDescriptionTxtBox.Name = "nodeDescriptionTxtBox";
      this.nodeDescriptionTxtBox.Size = new System.Drawing.Size(171, 23);
      this.nodeDescriptionTxtBox.TabIndex = 0;
      // 
      // nodeDescriptionLabel
      // 
      this.nodeDescriptionLabel.AutoSize = true;
      this.nodeDescriptionLabel.Location = new System.Drawing.Point(19, 83);
      this.nodeDescriptionLabel.Name = "nodeDescriptionLabel";
      this.nodeDescriptionLabel.Size = new System.Drawing.Size(67, 15);
      this.nodeDescriptionLabel.TabIndex = 1;
      this.nodeDescriptionLabel.Text = "Description";
      // 
      // nodeNameLabel
      // 
      this.nodeNameLabel.AutoSize = true;
      this.nodeNameLabel.Location = new System.Drawing.Point(19, 54);
      this.nodeNameLabel.Name = "nodeNameLabel";
      this.nodeNameLabel.Size = new System.Drawing.Size(39, 15);
      this.nodeNameLabel.TabIndex = 1;
      this.nodeNameLabel.Text = "Name";
      // 
      // nodeNameTxtBox
      // 
      this.nodeNameTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeNameTxtBox.Location = new System.Drawing.Point(98, 51);
      this.nodeNameTxtBox.Name = "nodeNameTxtBox";
      this.nodeNameTxtBox.Size = new System.Drawing.Size(171, 23);
      this.nodeNameTxtBox.TabIndex = 0;
      // 
      // nodesGroup
      // 
      this.nodesGroup.Controls.Add(this.nodesList);
      this.nodesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nodesGroup.Location = new System.Drawing.Point(3, 3);
      this.nodesGroup.Name = "nodesGroup";
      this.nodesGroup.Padding = new System.Windows.Forms.Padding(15, 15, 15, 20);
      this.nodesGroup.Size = new System.Drawing.Size(220, 707);
      this.nodesGroup.TabIndex = 1;
      this.nodesGroup.TabStop = false;
      this.nodesGroup.Text = "Nodes";
      // 
      // nodesList
      // 
      this.nodesList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nodesList.FormattingEnabled = true;
      this.nodesList.ItemHeight = 15;
      this.nodesList.Location = new System.Drawing.Point(15, 31);
      this.nodesList.Name = "nodesList";
      this.nodesList.Size = new System.Drawing.Size(190, 656);
      this.nodesList.TabIndex = 0;
      this.nodesList.SelectedIndexChanged += new System.EventHandler(this.nodesList_SelectedIndexChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1157, 737);
      this.Controls.Add(this.mainLayout);
      this.Controls.Add(this.menuStrip);
      this.Name = "MainForm";
      this.Text = "Dependency Mapper";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.mainLayout.ResumeLayout(false);
      this.mainLeftLayout.ResumeLayout(false);
      this.nodeRelationshipsGroup.ResumeLayout(false);
      this.nodeRelationshipsGroup.PerformLayout();
      this.nodeBox.ResumeLayout(false);
      this.nodeBox.PerformLayout();
      this.nodesGroup.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.TableLayoutPanel mainLayout;
    private System.Windows.Forms.TableLayoutPanel mainLeftLayout;
    private System.Windows.Forms.GroupBox nodeBox;
    private System.Windows.Forms.Label nodeNameLabel;
    private System.Windows.Forms.TextBox nodeNameTxtBox;
    private System.Windows.Forms.TextBox nodeDescriptionTxtBox;
    private System.Windows.Forms.Label nodeDescriptionLabel;
    private System.Windows.Forms.ComboBox nodeCategoryDropdown;
    private System.Windows.Forms.Label nodeCategoryLabel;
    private System.Windows.Forms.Button nodeSaveBtn;
    private System.Windows.Forms.Button nodeDeleteBtn;
    private System.Windows.Forms.Button newNodeBtn;
    private System.Windows.Forms.GroupBox nodeRelationshipsGroup;
    private System.Windows.Forms.RadioButton nodeDependantsBtn;
    private System.Windows.Forms.RadioButton nodeDependenciesBtn;
    private System.Windows.Forms.Button nodeRelationshipsEdit;
    private System.Windows.Forms.ListBox nodeRelationshipsList;
    private System.Windows.Forms.GroupBox nodesGroup;
    private System.Windows.Forms.ListBox nodesList;
  }
}

