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
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
      this.exportCategoryDependencyDiagramsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.mainLeftLayout = new System.Windows.Forms.TableLayoutPanel();
      this.nodeRelationshipsGroup = new System.Windows.Forms.GroupBox();
      this.nodeRelationshipsList = new System.Windows.Forms.ListBox();
      this.nodeRelationshipsEdit = new System.Windows.Forms.Button();
      this.nodeDependantsBtn = new System.Windows.Forms.RadioButton();
      this.nodeDependenciesBtn = new System.Windows.Forms.RadioButton();
      this.nodeBox = new System.Windows.Forms.GroupBox();
      this.copyNodeBtn = new System.Windows.Forms.Button();
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
      this.nodesListCategoryApplyAll = new System.Windows.Forms.Button();
      this.nodesListShowSelectedNodeDependants = new System.Windows.Forms.Button();
      this.nodesListShowSelectedNodeDependencies = new System.Windows.Forms.Button();
      this.nodesListNameFilterClearBtn = new System.Windows.Forms.Button();
      this.nodesListNameFilter = new System.Windows.Forms.TextBox();
      this.nodesListCategoryFilter = new System.Windows.Forms.ComboBox();
      this.nodesList = new System.Windows.Forms.ListBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.diagramPicBox = new System.Windows.Forms.PictureBox();
      this.exportAllDiagramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.mainLeftLayout.SuspendLayout();
      this.nodeRelationshipsGroup.SuspendLayout();
      this.nodeBox.SuspendLayout();
      this.nodesGroup.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.diagramPicBox)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(984, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
      this.toolStripMenuItem1.Text = "&File";
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItem2.Text = "&Load";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.OnFileLoad);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.exportAllDiagramMenuItem,
            this.exportCategoryDependencyDiagramsMenuItem});
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(64, 20);
      this.toolStripMenuItem3.Text = "&Diagram";
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(357, 22);
      this.toolStripMenuItem4.Text = "&Generate";
      this.toolStripMenuItem4.Click += new System.EventHandler(this.OnDiagramGenerate);
      // 
      // exportCategoryDependencyDiagramsMenuItem
      // 
      this.exportCategoryDependencyDiagramsMenuItem.Name = "exportCategoryDependencyDiagramsMenuItem";
      this.exportCategoryDependencyDiagramsMenuItem.Size = new System.Drawing.Size(357, 22);
      this.exportCategoryDependencyDiagramsMenuItem.Text = "Export depedency diagram for all in selected category";
      this.exportCategoryDependencyDiagramsMenuItem.Click += new System.EventHandler(this.exportCategoryDependencyDiagramsMenuItem_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 24);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.panel1);
      this.splitContainer1.Size = new System.Drawing.Size(984, 713);
      this.splitContainer1.SplitterDistance = 500;
      this.splitContainer1.TabIndex = 1;
      this.splitContainer1.Text = "splitContainer1";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.5F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.5F));
      this.tableLayoutPanel1.Controls.Add(this.mainLeftLayout, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.nodesGroup, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 713);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // mainLeftLayout
      // 
      this.mainLeftLayout.ColumnCount = 1;
      this.mainLeftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainLeftLayout.Controls.Add(this.nodeRelationshipsGroup, 0, 1);
      this.mainLeftLayout.Controls.Add(this.nodeBox, 0, 0);
      this.mainLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainLeftLayout.Location = new System.Drawing.Point(200, 3);
      this.mainLeftLayout.Name = "mainLeftLayout";
      this.mainLeftLayout.RowCount = 2;
      this.mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.mainLeftLayout.Size = new System.Drawing.Size(297, 707);
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
      this.nodeRelationshipsGroup.Size = new System.Drawing.Size(291, 516);
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
      this.nodeRelationshipsList.Size = new System.Drawing.Size(256, 439);
      this.nodeRelationshipsList.Sorted = true;
      this.nodeRelationshipsList.TabIndex = 10;
      this.nodeRelationshipsList.DoubleClick += new System.EventHandler(this.nodeRelationshipsList_DoubleClick);
      // 
      // nodeRelationshipsEdit
      // 
      this.nodeRelationshipsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeRelationshipsEdit.Location = new System.Drawing.Point(223, 32);
      this.nodeRelationshipsEdit.Name = "nodeRelationshipsEdit";
      this.nodeRelationshipsEdit.Size = new System.Drawing.Size(52, 23);
      this.nodeRelationshipsEdit.TabIndex = 9;
      this.nodeRelationshipsEdit.Text = "Edit";
      this.nodeRelationshipsEdit.UseVisualStyleBackColor = true;
      this.nodeRelationshipsEdit.Click += new System.EventHandler(this.nodeRelationshipsEdit_Click);
      // 
      // nodeDependantsBtn
      // 
      this.nodeDependantsBtn.AutoSize = true;
      this.nodeDependantsBtn.Location = new System.Drawing.Point(124, 34);
      this.nodeDependantsBtn.Name = "nodeDependantsBtn";
      this.nodeDependantsBtn.Size = new System.Drawing.Size(88, 19);
      this.nodeDependantsBtn.TabIndex = 8;
      this.nodeDependantsBtn.Text = "Dependants";
      this.nodeDependantsBtn.UseVisualStyleBackColor = true;
      this.nodeDependantsBtn.CheckedChanged += new System.EventHandler(this.nodeDependantsBtn_CheckedChanged);
      // 
      // nodeDependenciesBtn
      // 
      this.nodeDependenciesBtn.AutoSize = true;
      this.nodeDependenciesBtn.Checked = true;
      this.nodeDependenciesBtn.Location = new System.Drawing.Point(19, 34);
      this.nodeDependenciesBtn.Name = "nodeDependenciesBtn";
      this.nodeDependenciesBtn.Size = new System.Drawing.Size(99, 19);
      this.nodeDependenciesBtn.TabIndex = 7;
      this.nodeDependenciesBtn.TabStop = true;
      this.nodeDependenciesBtn.Text = "Dependencies";
      this.nodeDependenciesBtn.UseVisualStyleBackColor = true;
      this.nodeDependenciesBtn.CheckedChanged += new System.EventHandler(this.nodeDependenciesBtn_CheckedChanged);
      // 
      // nodeBox
      // 
      this.nodeBox.Controls.Add(this.copyNodeBtn);
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
      this.nodeBox.Size = new System.Drawing.Size(291, 179);
      this.nodeBox.TabIndex = 0;
      this.nodeBox.TabStop = false;
      this.nodeBox.Text = "Node";
      // 
      // copyNodeBtn
      // 
      this.copyNodeBtn.Location = new System.Drawing.Point(98, 22);
      this.copyNodeBtn.Name = "copyNodeBtn";
      this.copyNodeBtn.Size = new System.Drawing.Size(75, 23);
      this.copyNodeBtn.TabIndex = 7;
      this.copyNodeBtn.Text = "Copy";
      this.copyNodeBtn.UseVisualStyleBackColor = true;
      this.copyNodeBtn.Click += new System.EventHandler(this.copyNodeBtn_Click);
      // 
      // nodeDeleteBtn
      // 
      this.nodeDeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeDeleteBtn.Location = new System.Drawing.Point(98, 138);
      this.nodeDeleteBtn.Name = "nodeDeleteBtn";
      this.nodeDeleteBtn.Size = new System.Drawing.Size(75, 23);
      this.nodeDeleteBtn.TabIndex = 6;
      this.nodeDeleteBtn.Text = "Delete";
      this.nodeDeleteBtn.UseVisualStyleBackColor = true;
      this.nodeDeleteBtn.Click += new System.EventHandler(this.nodeDeleteBtn_Click);
      // 
      // newNodeBtn
      // 
      this.newNodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.newNodeBtn.Location = new System.Drawing.Point(200, 22);
      this.newNodeBtn.Name = "newNodeBtn";
      this.newNodeBtn.Size = new System.Drawing.Size(75, 23);
      this.newNodeBtn.TabIndex = 1;
      this.newNodeBtn.Text = "New";
      this.newNodeBtn.UseVisualStyleBackColor = true;
      this.newNodeBtn.Click += new System.EventHandler(this.newNodeBtn_Click);
      // 
      // nodeSaveBtn
      // 
      this.nodeSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodeSaveBtn.Location = new System.Drawing.Point(200, 138);
      this.nodeSaveBtn.Name = "nodeSaveBtn";
      this.nodeSaveBtn.Size = new System.Drawing.Size(75, 23);
      this.nodeSaveBtn.TabIndex = 5;
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
      this.nodeCategoryDropdown.Size = new System.Drawing.Size(177, 23);
      this.nodeCategoryDropdown.Sorted = true;
      this.nodeCategoryDropdown.TabIndex = 4;
      this.nodeCategoryDropdown.Enter += new System.EventHandler(this.nodeCategoryDropdown_Enter);
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
      this.nodeDescriptionTxtBox.Size = new System.Drawing.Size(177, 23);
      this.nodeDescriptionTxtBox.TabIndex = 3;
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
      this.nodeNameTxtBox.Size = new System.Drawing.Size(177, 23);
      this.nodeNameTxtBox.TabIndex = 2;
      this.nodeNameTxtBox.Enter += new System.EventHandler(this.nodeNameTxtBox_Enter);
      // 
      // nodesGroup
      // 
      this.nodesGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.nodesGroup.Controls.Add(this.nodesListCategoryApplyAll);
      this.nodesGroup.Controls.Add(this.nodesListShowSelectedNodeDependants);
      this.nodesGroup.Controls.Add(this.nodesListShowSelectedNodeDependencies);
      this.nodesGroup.Controls.Add(this.nodesListNameFilterClearBtn);
      this.nodesGroup.Controls.Add(this.nodesListNameFilter);
      this.nodesGroup.Controls.Add(this.nodesListCategoryFilter);
      this.nodesGroup.Controls.Add(this.nodesList);
      this.nodesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nodesGroup.Location = new System.Drawing.Point(3, 3);
      this.nodesGroup.Name = "nodesGroup";
      this.nodesGroup.Padding = new System.Windows.Forms.Padding(15, 15, 15, 20);
      this.nodesGroup.Size = new System.Drawing.Size(191, 707);
      this.nodesGroup.TabIndex = 1;
      this.nodesGroup.TabStop = false;
      this.nodesGroup.Text = "Nodes";
      // 
      // nodesListCategoryApplyAll
      // 
      this.nodesListCategoryApplyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListCategoryApplyAll.Location = new System.Drawing.Point(143, 25);
      this.nodesListCategoryApplyAll.Name = "nodesListCategoryApplyAll";
      this.nodesListCategoryApplyAll.Size = new System.Drawing.Size(33, 23);
      this.nodesListCategoryApplyAll.TabIndex = 1;
      this.nodesListCategoryApplyAll.Text = "All";
      this.nodesListCategoryApplyAll.UseVisualStyleBackColor = true;
      this.nodesListCategoryApplyAll.Click += new System.EventHandler(this.nodeListCategoryFilterApplyAll_OnClick);
      // 
      // nodesListShowSelectedNodeDependants
      // 
      this.nodesListShowSelectedNodeDependants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListShowSelectedNodeDependants.Location = new System.Drawing.Point(15, 670);
      this.nodesListShowSelectedNodeDependants.Name = "nodesListShowSelectedNodeDependants";
      this.nodesListShowSelectedNodeDependants.Size = new System.Drawing.Size(161, 23);
      this.nodesListShowSelectedNodeDependants.TabIndex = 6;
      this.nodesListShowSelectedNodeDependants.Text = "Dependants";
      this.nodesListShowSelectedNodeDependants.UseVisualStyleBackColor = true;
      this.nodesListShowSelectedNodeDependants.Click += new System.EventHandler(this.nodesListShowSelectedNodeDependants_Click);
      // 
      // nodesListShowSelectedNodeDependencies
      // 
      this.nodesListShowSelectedNodeDependencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListShowSelectedNodeDependencies.Location = new System.Drawing.Point(15, 641);
      this.nodesListShowSelectedNodeDependencies.Name = "nodesListShowSelectedNodeDependencies";
      this.nodesListShowSelectedNodeDependencies.Size = new System.Drawing.Size(161, 23);
      this.nodesListShowSelectedNodeDependencies.TabIndex = 5;
      this.nodesListShowSelectedNodeDependencies.Text = "Dependencies";
      this.nodesListShowSelectedNodeDependencies.UseVisualStyleBackColor = true;
      this.nodesListShowSelectedNodeDependencies.Click += new System.EventHandler(this.nodesListShowSelectedNodeDependencies_Click);
      // 
      // nodesListNameFilterClearBtn
      // 
      this.nodesListNameFilterClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListNameFilterClearBtn.Location = new System.Drawing.Point(150, 57);
      this.nodesListNameFilterClearBtn.Name = "nodesListNameFilterClearBtn";
      this.nodesListNameFilterClearBtn.Size = new System.Drawing.Size(26, 23);
      this.nodesListNameFilterClearBtn.TabIndex = 3;
      this.nodesListNameFilterClearBtn.Text = "X";
      this.nodesListNameFilterClearBtn.UseVisualStyleBackColor = true;
      this.nodesListNameFilterClearBtn.Click += new System.EventHandler(this.nodesListNameFilterClearBtn_Click);
      // 
      // nodesListNameFilter
      // 
      this.nodesListNameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListNameFilter.Location = new System.Drawing.Point(15, 57);
      this.nodesListNameFilter.Name = "nodesListNameFilter";
      this.nodesListNameFilter.Size = new System.Drawing.Size(129, 23);
      this.nodesListNameFilter.TabIndex = 2;
      this.nodesListNameFilter.Enter += new System.EventHandler(this.nodesListNameFilter_Enter);
      this.nodesListNameFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nodesListNameFilter_KeyPress);
      // 
      // nodesListCategoryFilter
      // 
      this.nodesListCategoryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesListCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.nodesListCategoryFilter.FormattingEnabled = true;
      this.nodesListCategoryFilter.Location = new System.Drawing.Point(15, 26);
      this.nodesListCategoryFilter.Name = "nodesListCategoryFilter";
      this.nodesListCategoryFilter.Size = new System.Drawing.Size(122, 23);
      this.nodesListCategoryFilter.Sorted = true;
      this.nodesListCategoryFilter.TabIndex = 1;
      this.nodesListCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.nodesListCategoryFilter_SelectedIndexChanged);
      // 
      // nodesList
      // 
      this.nodesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nodesList.FormattingEnabled = true;
      this.nodesList.ItemHeight = 15;
      this.nodesList.Location = new System.Drawing.Point(15, 91);
      this.nodesList.Name = "nodesList";
      this.nodesList.Size = new System.Drawing.Size(161, 544);
      this.nodesList.Sorted = true;
      this.nodesList.TabIndex = 4;
      this.nodesList.SelectedIndexChanged += new System.EventHandler(this.nodesList_SelectedIndexChanged);
      // 
      // panel1
      // 
      this.panel1.AutoScroll = true;
      this.panel1.AutoSize = true;
      this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.panel1.Controls.Add(this.diagramPicBox);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(480, 713);
      this.panel1.TabIndex = 0;
      // 
      // diagramPicBox
      // 
      this.diagramPicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.diagramPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.diagramPicBox.ImageLocation = "";
      this.diagramPicBox.Location = new System.Drawing.Point(0, 0);
      this.diagramPicBox.Name = "diagramPicBox";
      this.diagramPicBox.Size = new System.Drawing.Size(400, 400);
      this.diagramPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.diagramPicBox.TabIndex = 0;
      this.diagramPicBox.TabStop = false;
      // 
      // exportAllDiagramMenuItem
      // 
      this.exportAllDiagramMenuItem.Name = "exportAllDiagramMenuItem";
      this.exportAllDiagramMenuItem.Size = new System.Drawing.Size(357, 22);
      this.exportAllDiagramMenuItem.Text = "Export All";
      this.exportAllDiagramMenuItem.Click += new System.EventHandler(this.exportAllDiagramMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(984, 737);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Dependency Mapper";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.mainLeftLayout.ResumeLayout(false);
      this.nodeRelationshipsGroup.ResumeLayout(false);
      this.nodeRelationshipsGroup.PerformLayout();
      this.nodeBox.ResumeLayout(false);
      this.nodeBox.PerformLayout();
      this.nodesGroup.ResumeLayout(false);
      this.nodesGroup.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.diagramPicBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel mainLeftLayout;
    private System.Windows.Forms.GroupBox nodeRelationshipsGroup;
    private System.Windows.Forms.ListBox nodeRelationshipsList;
    private System.Windows.Forms.Button nodeRelationshipsEdit;
    private System.Windows.Forms.RadioButton nodeDependantsBtn;
    private System.Windows.Forms.RadioButton nodeDependenciesBtn;
    private System.Windows.Forms.GroupBox nodeBox;
    private System.Windows.Forms.Button nodeDeleteBtn;
    private System.Windows.Forms.Button newNodeBtn;
    private System.Windows.Forms.Button nodeSaveBtn;
    private System.Windows.Forms.ComboBox nodeCategoryDropdown;
    private System.Windows.Forms.Label nodeCategoryLabel;
    private System.Windows.Forms.TextBox nodeDescriptionTxtBox;
    private System.Windows.Forms.Label nodeDescriptionLabel;
    private System.Windows.Forms.Label nodeNameLabel;
    private System.Windows.Forms.TextBox nodeNameTxtBox;
    private System.Windows.Forms.GroupBox nodesGroup;
    private System.Windows.Forms.ListBox nodesList;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.PictureBox diagramPicBox;
    private System.Windows.Forms.ComboBox nodesListCategoryFilter;
    private System.Windows.Forms.TextBox nodesListNameFilter;
    private System.Windows.Forms.Button nodesListNameFilterClearBtn;
    private System.Windows.Forms.Button nodesListShowSelectedNodeDependencies;
    private System.Windows.Forms.Button nodesListShowSelectedNodeDependants;
    private System.Windows.Forms.Button nodesListCategoryApplyAll;
    private System.Windows.Forms.Button copyNodeBtn;
    private System.Windows.Forms.ToolStripMenuItem exportCategoryDependencyDiagramsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportAllDiagramMenuItem;
  }
}

