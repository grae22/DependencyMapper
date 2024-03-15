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
      menuStrip = new System.Windows.Forms.MenuStrip();
      toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
      exportAllDiagramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      exportCategoryDependencyDiagramsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      mainLeftLayout = new System.Windows.Forms.TableLayoutPanel();
      nodeRelationshipsGroup = new System.Windows.Forms.GroupBox();
      nodeRelationshipsList = new System.Windows.Forms.ListBox();
      nodeRelationshipsEdit = new System.Windows.Forms.Button();
      nodeDependantsBtn = new System.Windows.Forms.RadioButton();
      nodeDependenciesBtn = new System.Windows.Forms.RadioButton();
      nodeBox = new System.Windows.Forms.GroupBox();
      isComplete = new System.Windows.Forms.CheckBox();
      copyNodeBtn = new System.Windows.Forms.Button();
      nodeDeleteBtn = new System.Windows.Forms.Button();
      newNodeBtn = new System.Windows.Forms.Button();
      nodeSaveBtn = new System.Windows.Forms.Button();
      nodeCategoryDropdown = new System.Windows.Forms.ComboBox();
      nodeCategoryLabel = new System.Windows.Forms.Label();
      nodeDescriptionTxtBox = new System.Windows.Forms.TextBox();
      nodeDescriptionLabel = new System.Windows.Forms.Label();
      nodeNameLabel = new System.Windows.Forms.Label();
      nodeNameTxtBox = new System.Windows.Forms.TextBox();
      nodesGroup = new System.Windows.Forms.GroupBox();
      showIndirectDependants = new System.Windows.Forms.CheckBox();
      showIndirectDependencies = new System.Windows.Forms.CheckBox();
      showAll = new System.Windows.Forms.RadioButton();
      showDependants = new System.Windows.Forms.RadioButton();
      showDependencies = new System.Windows.Forms.RadioButton();
      nodesListCategoryApplyAll = new System.Windows.Forms.Button();
      nodesListNameFilterClearBtn = new System.Windows.Forms.Button();
      nodesListNameFilter = new System.Windows.Forms.TextBox();
      nodesListCategoryFilter = new System.Windows.Forms.ComboBox();
      nodesList = new System.Windows.Forms.ListBox();
      panel1 = new System.Windows.Forms.Panel();
      diagramPicBox = new System.Windows.Forms.PictureBox();
      menuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      mainLeftLayout.SuspendLayout();
      nodeRelationshipsGroup.SuspendLayout();
      nodeBox.SuspendLayout();
      nodesGroup.SuspendLayout();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)diagramPicBox).BeginInit();
      SuspendLayout();
      // 
      // menuStrip
      // 
      menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem3 });
      menuStrip.Location = new System.Drawing.Point(0, 0);
      menuStrip.Name = "menuStrip";
      menuStrip.Size = new System.Drawing.Size(984, 24);
      menuStrip.TabIndex = 0;
      menuStrip.Text = "menuStrip";
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2 });
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
      toolStripMenuItem1.Text = "&File";
      // 
      // toolStripMenuItem2
      // 
      toolStripMenuItem2.Name = "toolStripMenuItem2";
      toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
      toolStripMenuItem2.Text = "&Load";
      toolStripMenuItem2.Click += OnFileLoad;
      // 
      // toolStripMenuItem3
      // 
      toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem4, exportAllDiagramMenuItem, exportCategoryDependencyDiagramsMenuItem });
      toolStripMenuItem3.Name = "toolStripMenuItem3";
      toolStripMenuItem3.Size = new System.Drawing.Size(64, 20);
      toolStripMenuItem3.Text = "&Diagram";
      // 
      // toolStripMenuItem4
      // 
      toolStripMenuItem4.Name = "toolStripMenuItem4";
      toolStripMenuItem4.Size = new System.Drawing.Size(357, 22);
      toolStripMenuItem4.Text = "&Generate";
      toolStripMenuItem4.Click += OnDiagramGenerate;
      // 
      // exportAllDiagramMenuItem
      // 
      exportAllDiagramMenuItem.Name = "exportAllDiagramMenuItem";
      exportAllDiagramMenuItem.Size = new System.Drawing.Size(357, 22);
      exportAllDiagramMenuItem.Text = "Export All";
      exportAllDiagramMenuItem.Click += exportAllDiagramMenuItem_Click;
      // 
      // exportCategoryDependencyDiagramsMenuItem
      // 
      exportCategoryDependencyDiagramsMenuItem.Name = "exportCategoryDependencyDiagramsMenuItem";
      exportCategoryDependencyDiagramsMenuItem.Size = new System.Drawing.Size(357, 22);
      exportCategoryDependencyDiagramsMenuItem.Text = "Export depedency diagram for all in selected category";
      exportCategoryDependencyDiagramsMenuItem.Click += exportCategoryDependencyDiagramsMenuItem_Click;
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      splitContainer1.Location = new System.Drawing.Point(0, 24);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(panel1);
      splitContainer1.Size = new System.Drawing.Size(984, 713);
      splitContainer1.SplitterDistance = 500;
      splitContainer1.TabIndex = 1;
      splitContainer1.Text = "splitContainer1";
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.5F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.5F));
      tableLayoutPanel1.Controls.Add(mainLeftLayout, 1, 0);
      tableLayoutPanel1.Controls.Add(nodesGroup, 0, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 1;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(500, 713);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // mainLeftLayout
      // 
      mainLeftLayout.ColumnCount = 1;
      mainLeftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      mainLeftLayout.Controls.Add(nodeRelationshipsGroup, 0, 1);
      mainLeftLayout.Controls.Add(nodeBox, 0, 0);
      mainLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      mainLeftLayout.Location = new System.Drawing.Point(200, 3);
      mainLeftLayout.Name = "mainLeftLayout";
      mainLeftLayout.RowCount = 2;
      mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      mainLeftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      mainLeftLayout.Size = new System.Drawing.Size(297, 707);
      mainLeftLayout.TabIndex = 0;
      // 
      // nodeRelationshipsGroup
      // 
      nodeRelationshipsGroup.Controls.Add(nodeRelationshipsList);
      nodeRelationshipsGroup.Controls.Add(nodeRelationshipsEdit);
      nodeRelationshipsGroup.Controls.Add(nodeDependantsBtn);
      nodeRelationshipsGroup.Controls.Add(nodeDependenciesBtn);
      nodeRelationshipsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      nodeRelationshipsGroup.Location = new System.Drawing.Point(3, 219);
      nodeRelationshipsGroup.Name = "nodeRelationshipsGroup";
      nodeRelationshipsGroup.Size = new System.Drawing.Size(291, 516);
      nodeRelationshipsGroup.TabIndex = 4;
      nodeRelationshipsGroup.TabStop = false;
      nodeRelationshipsGroup.Text = "Node Relationships";
      // 
      // nodeRelationshipsList
      // 
      nodeRelationshipsList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodeRelationshipsList.FormattingEnabled = true;
      nodeRelationshipsList.ItemHeight = 15;
      nodeRelationshipsList.Location = new System.Drawing.Point(19, 59);
      nodeRelationshipsList.Name = "nodeRelationshipsList";
      nodeRelationshipsList.Size = new System.Drawing.Size(256, 439);
      nodeRelationshipsList.Sorted = true;
      nodeRelationshipsList.TabIndex = 10;
      nodeRelationshipsList.DoubleClick += nodeRelationshipsList_DoubleClick;
      // 
      // nodeRelationshipsEdit
      // 
      nodeRelationshipsEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      nodeRelationshipsEdit.Location = new System.Drawing.Point(223, 32);
      nodeRelationshipsEdit.Name = "nodeRelationshipsEdit";
      nodeRelationshipsEdit.Size = new System.Drawing.Size(52, 23);
      nodeRelationshipsEdit.TabIndex = 9;
      nodeRelationshipsEdit.Text = "Edit";
      nodeRelationshipsEdit.UseVisualStyleBackColor = true;
      nodeRelationshipsEdit.Click += nodeRelationshipsEdit_Click;
      // 
      // nodeDependantsBtn
      // 
      nodeDependantsBtn.AutoSize = true;
      nodeDependantsBtn.Location = new System.Drawing.Point(124, 34);
      nodeDependantsBtn.Name = "nodeDependantsBtn";
      nodeDependantsBtn.Size = new System.Drawing.Size(88, 19);
      nodeDependantsBtn.TabIndex = 8;
      nodeDependantsBtn.Text = "Dependants";
      nodeDependantsBtn.UseVisualStyleBackColor = true;
      nodeDependantsBtn.CheckedChanged += nodeDependantsBtn_CheckedChanged;
      // 
      // nodeDependenciesBtn
      // 
      nodeDependenciesBtn.AutoSize = true;
      nodeDependenciesBtn.Checked = true;
      nodeDependenciesBtn.Location = new System.Drawing.Point(19, 34);
      nodeDependenciesBtn.Name = "nodeDependenciesBtn";
      nodeDependenciesBtn.Size = new System.Drawing.Size(99, 19);
      nodeDependenciesBtn.TabIndex = 7;
      nodeDependenciesBtn.TabStop = true;
      nodeDependenciesBtn.Text = "Dependencies";
      nodeDependenciesBtn.UseVisualStyleBackColor = true;
      nodeDependenciesBtn.CheckedChanged += nodeDependenciesBtn_CheckedChanged;
      // 
      // nodeBox
      // 
      nodeBox.Controls.Add(isComplete);
      nodeBox.Controls.Add(copyNodeBtn);
      nodeBox.Controls.Add(nodeDeleteBtn);
      nodeBox.Controls.Add(newNodeBtn);
      nodeBox.Controls.Add(nodeSaveBtn);
      nodeBox.Controls.Add(nodeCategoryDropdown);
      nodeBox.Controls.Add(nodeCategoryLabel);
      nodeBox.Controls.Add(nodeDescriptionTxtBox);
      nodeBox.Controls.Add(nodeDescriptionLabel);
      nodeBox.Controls.Add(nodeNameLabel);
      nodeBox.Controls.Add(nodeNameTxtBox);
      nodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
      nodeBox.Location = new System.Drawing.Point(3, 3);
      nodeBox.Name = "nodeBox";
      nodeBox.Size = new System.Drawing.Size(291, 210);
      nodeBox.TabIndex = 0;
      nodeBox.TabStop = false;
      nodeBox.Text = "Node";
      // 
      // isComplete
      // 
      isComplete.AutoSize = true;
      isComplete.Location = new System.Drawing.Point(98, 138);
      isComplete.Name = "isComplete";
      isComplete.Size = new System.Drawing.Size(87, 19);
      isComplete.TabIndex = 8;
      isComplete.Text = "Is complete";
      isComplete.UseVisualStyleBackColor = true;
      isComplete.CheckedChanged += isComplete_CheckedChanged;
      // 
      // copyNodeBtn
      // 
      copyNodeBtn.Location = new System.Drawing.Point(98, 22);
      copyNodeBtn.Name = "copyNodeBtn";
      copyNodeBtn.Size = new System.Drawing.Size(75, 23);
      copyNodeBtn.TabIndex = 7;
      copyNodeBtn.Text = "Copy";
      copyNodeBtn.UseVisualStyleBackColor = true;
      copyNodeBtn.Click += copyNodeBtn_Click;
      // 
      // nodeDeleteBtn
      // 
      nodeDeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      nodeDeleteBtn.Location = new System.Drawing.Point(98, 171);
      nodeDeleteBtn.Name = "nodeDeleteBtn";
      nodeDeleteBtn.Size = new System.Drawing.Size(75, 23);
      nodeDeleteBtn.TabIndex = 6;
      nodeDeleteBtn.Text = "Delete";
      nodeDeleteBtn.UseVisualStyleBackColor = true;
      nodeDeleteBtn.Click += nodeDeleteBtn_Click;
      // 
      // newNodeBtn
      // 
      newNodeBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      newNodeBtn.Location = new System.Drawing.Point(200, 22);
      newNodeBtn.Name = "newNodeBtn";
      newNodeBtn.Size = new System.Drawing.Size(75, 23);
      newNodeBtn.TabIndex = 1;
      newNodeBtn.Text = "New";
      newNodeBtn.UseVisualStyleBackColor = true;
      newNodeBtn.Click += newNodeBtn_Click;
      // 
      // nodeSaveBtn
      // 
      nodeSaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      nodeSaveBtn.Location = new System.Drawing.Point(200, 171);
      nodeSaveBtn.Name = "nodeSaveBtn";
      nodeSaveBtn.Size = new System.Drawing.Size(75, 23);
      nodeSaveBtn.TabIndex = 5;
      nodeSaveBtn.Text = "Save";
      nodeSaveBtn.UseVisualStyleBackColor = true;
      nodeSaveBtn.Click += nodeSaveBtn_Click;
      // 
      // nodeCategoryDropdown
      // 
      nodeCategoryDropdown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodeCategoryDropdown.FormattingEnabled = true;
      nodeCategoryDropdown.Location = new System.Drawing.Point(98, 109);
      nodeCategoryDropdown.Name = "nodeCategoryDropdown";
      nodeCategoryDropdown.Size = new System.Drawing.Size(177, 23);
      nodeCategoryDropdown.Sorted = true;
      nodeCategoryDropdown.TabIndex = 4;
      nodeCategoryDropdown.Enter += nodeCategoryDropdown_Enter;
      // 
      // nodeCategoryLabel
      // 
      nodeCategoryLabel.AutoSize = true;
      nodeCategoryLabel.Location = new System.Drawing.Point(19, 112);
      nodeCategoryLabel.Name = "nodeCategoryLabel";
      nodeCategoryLabel.Size = new System.Drawing.Size(55, 15);
      nodeCategoryLabel.TabIndex = 1;
      nodeCategoryLabel.Text = "Category";
      // 
      // nodeDescriptionTxtBox
      // 
      nodeDescriptionTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodeDescriptionTxtBox.Location = new System.Drawing.Point(98, 80);
      nodeDescriptionTxtBox.Name = "nodeDescriptionTxtBox";
      nodeDescriptionTxtBox.Size = new System.Drawing.Size(177, 23);
      nodeDescriptionTxtBox.TabIndex = 3;
      // 
      // nodeDescriptionLabel
      // 
      nodeDescriptionLabel.AutoSize = true;
      nodeDescriptionLabel.Location = new System.Drawing.Point(19, 83);
      nodeDescriptionLabel.Name = "nodeDescriptionLabel";
      nodeDescriptionLabel.Size = new System.Drawing.Size(67, 15);
      nodeDescriptionLabel.TabIndex = 1;
      nodeDescriptionLabel.Text = "Description";
      // 
      // nodeNameLabel
      // 
      nodeNameLabel.AutoSize = true;
      nodeNameLabel.Location = new System.Drawing.Point(19, 54);
      nodeNameLabel.Name = "nodeNameLabel";
      nodeNameLabel.Size = new System.Drawing.Size(39, 15);
      nodeNameLabel.TabIndex = 1;
      nodeNameLabel.Text = "Name";
      // 
      // nodeNameTxtBox
      // 
      nodeNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodeNameTxtBox.Location = new System.Drawing.Point(98, 51);
      nodeNameTxtBox.Name = "nodeNameTxtBox";
      nodeNameTxtBox.Size = new System.Drawing.Size(177, 23);
      nodeNameTxtBox.TabIndex = 2;
      nodeNameTxtBox.Enter += nodeNameTxtBox_Enter;
      // 
      // nodesGroup
      // 
      nodesGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      nodesGroup.Controls.Add(showIndirectDependants);
      nodesGroup.Controls.Add(showIndirectDependencies);
      nodesGroup.Controls.Add(showAll);
      nodesGroup.Controls.Add(showDependants);
      nodesGroup.Controls.Add(showDependencies);
      nodesGroup.Controls.Add(nodesListCategoryApplyAll);
      nodesGroup.Controls.Add(nodesListNameFilterClearBtn);
      nodesGroup.Controls.Add(nodesListNameFilter);
      nodesGroup.Controls.Add(nodesListCategoryFilter);
      nodesGroup.Controls.Add(nodesList);
      nodesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
      nodesGroup.Location = new System.Drawing.Point(3, 3);
      nodesGroup.Name = "nodesGroup";
      nodesGroup.Padding = new System.Windows.Forms.Padding(15, 15, 15, 20);
      nodesGroup.Size = new System.Drawing.Size(191, 707);
      nodesGroup.TabIndex = 1;
      nodesGroup.TabStop = false;
      nodesGroup.Text = "Nodes";
      // 
      // showIndirectDependants
      // 
      showIndirectDependants.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
      showIndirectDependants.AutoSize = true;
      showIndirectDependants.Location = new System.Drawing.Point(120, 679);
      showIndirectDependants.Name = "showIndirectDependants";
      showIndirectDependants.Size = new System.Drawing.Size(66, 19);
      showIndirectDependants.TabIndex = 11;
      showIndirectDependants.Text = "Indirect";
      showIndirectDependants.UseVisualStyleBackColor = true;
      showIndirectDependants.CheckedChanged += showOption_CheckedChanged;
      // 
      // showIndirectDependencies
      // 
      showIndirectDependencies.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
      showIndirectDependencies.AutoSize = true;
      showIndirectDependencies.Location = new System.Drawing.Point(120, 660);
      showIndirectDependencies.Name = "showIndirectDependencies";
      showIndirectDependencies.Size = new System.Drawing.Size(66, 19);
      showIndirectDependencies.TabIndex = 10;
      showIndirectDependencies.Text = "Indirect";
      showIndirectDependencies.UseVisualStyleBackColor = true;
      showIndirectDependencies.CheckedChanged += showOption_CheckedChanged;
      // 
      // showAll
      // 
      showAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
      showAll.AutoSize = true;
      showAll.Checked = true;
      showAll.Location = new System.Drawing.Point(15, 641);
      showAll.Name = "showAll";
      showAll.Size = new System.Drawing.Size(39, 19);
      showAll.TabIndex = 9;
      showAll.TabStop = true;
      showAll.Text = "All";
      showAll.UseVisualStyleBackColor = true;
      showAll.CheckedChanged += showOption_CheckedChanged;
      // 
      // showDependants
      // 
      showDependants.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
      showDependants.AutoSize = true;
      showDependants.Location = new System.Drawing.Point(15, 679);
      showDependants.Name = "showDependants";
      showDependants.Size = new System.Drawing.Size(88, 19);
      showDependants.TabIndex = 8;
      showDependants.Text = "Dependants";
      showDependants.UseVisualStyleBackColor = true;
      showDependants.CheckedChanged += showOption_CheckedChanged;
      // 
      // showDependencies
      // 
      showDependencies.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
      showDependencies.AutoSize = true;
      showDependencies.Location = new System.Drawing.Point(15, 660);
      showDependencies.Name = "showDependencies";
      showDependencies.Size = new System.Drawing.Size(99, 19);
      showDependencies.TabIndex = 7;
      showDependencies.Text = "Dependencies";
      showDependencies.UseVisualStyleBackColor = true;
      showDependencies.CheckedChanged += showOption_CheckedChanged;
      // 
      // nodesListCategoryApplyAll
      // 
      nodesListCategoryApplyAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      nodesListCategoryApplyAll.Location = new System.Drawing.Point(143, 25);
      nodesListCategoryApplyAll.Name = "nodesListCategoryApplyAll";
      nodesListCategoryApplyAll.Size = new System.Drawing.Size(33, 23);
      nodesListCategoryApplyAll.TabIndex = 1;
      nodesListCategoryApplyAll.Text = "All";
      nodesListCategoryApplyAll.UseVisualStyleBackColor = true;
      nodesListCategoryApplyAll.Click += nodeListCategoryFilterApplyAll_OnClick;
      // 
      // nodesListNameFilterClearBtn
      // 
      nodesListNameFilterClearBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      nodesListNameFilterClearBtn.Location = new System.Drawing.Point(150, 57);
      nodesListNameFilterClearBtn.Name = "nodesListNameFilterClearBtn";
      nodesListNameFilterClearBtn.Size = new System.Drawing.Size(26, 23);
      nodesListNameFilterClearBtn.TabIndex = 3;
      nodesListNameFilterClearBtn.Text = "X";
      nodesListNameFilterClearBtn.UseVisualStyleBackColor = true;
      nodesListNameFilterClearBtn.Click += nodesListNameFilterClearBtn_Click;
      // 
      // nodesListNameFilter
      // 
      nodesListNameFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodesListNameFilter.Location = new System.Drawing.Point(15, 57);
      nodesListNameFilter.Name = "nodesListNameFilter";
      nodesListNameFilter.Size = new System.Drawing.Size(129, 23);
      nodesListNameFilter.TabIndex = 2;
      nodesListNameFilter.Enter += nodesListNameFilter_Enter;
      nodesListNameFilter.KeyPress += nodesListNameFilter_KeyPress;
      // 
      // nodesListCategoryFilter
      // 
      nodesListCategoryFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodesListCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      nodesListCategoryFilter.FormattingEnabled = true;
      nodesListCategoryFilter.Location = new System.Drawing.Point(15, 26);
      nodesListCategoryFilter.Name = "nodesListCategoryFilter";
      nodesListCategoryFilter.Size = new System.Drawing.Size(122, 23);
      nodesListCategoryFilter.Sorted = true;
      nodesListCategoryFilter.TabIndex = 1;
      nodesListCategoryFilter.SelectedIndexChanged += nodesListCategoryFilter_SelectedIndexChanged;
      // 
      // nodesList
      // 
      nodesList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
      nodesList.FormattingEnabled = true;
      nodesList.HorizontalScrollbar = true;
      nodesList.ItemHeight = 15;
      nodesList.Location = new System.Drawing.Point(15, 91);
      nodesList.Name = "nodesList";
      nodesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
      nodesList.Size = new System.Drawing.Size(161, 544);
      nodesList.Sorted = true;
      nodesList.TabIndex = 4;
      nodesList.SelectedIndexChanged += nodesList_SelectedIndexChanged;
      // 
      // panel1
      // 
      panel1.AutoScroll = true;
      panel1.AutoSize = true;
      panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      panel1.Controls.Add(diagramPicBox);
      panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      panel1.Location = new System.Drawing.Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new System.Drawing.Size(480, 713);
      panel1.TabIndex = 0;
      // 
      // diagramPicBox
      // 
      diagramPicBox.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
      diagramPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      diagramPicBox.ImageLocation = "";
      diagramPicBox.Location = new System.Drawing.Point(0, 0);
      diagramPicBox.Name = "diagramPicBox";
      diagramPicBox.Size = new System.Drawing.Size(400, 400);
      diagramPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      diagramPicBox.TabIndex = 0;
      diagramPicBox.TabStop = false;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      BackColor = System.Drawing.SystemColors.Control;
      ClientSize = new System.Drawing.Size(984, 737);
      Controls.Add(splitContainer1);
      Controls.Add(menuStrip);
      Name = "MainForm";
      StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      Text = "Dependency Mapper";
      menuStrip.ResumeLayout(false);
      menuStrip.PerformLayout();
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      mainLeftLayout.ResumeLayout(false);
      nodeRelationshipsGroup.ResumeLayout(false);
      nodeRelationshipsGroup.PerformLayout();
      nodeBox.ResumeLayout(false);
      nodeBox.PerformLayout();
      nodesGroup.ResumeLayout(false);
      nodesGroup.PerformLayout();
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)diagramPicBox).EndInit();
      ResumeLayout(false);
      PerformLayout();
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
    private System.Windows.Forms.Button nodesListCategoryApplyAll;
    private System.Windows.Forms.Button copyNodeBtn;
    private System.Windows.Forms.ToolStripMenuItem exportCategoryDependencyDiagramsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportAllDiagramMenuItem;
    private System.Windows.Forms.CheckBox isComplete;
    private System.Windows.Forms.RadioButton showDependants;
    private System.Windows.Forms.RadioButton showDependencies;
    private System.Windows.Forms.RadioButton showAll;
    private System.Windows.Forms.CheckBox showIndirectDependants;
    private System.Windows.Forms.CheckBox showIndirectDependencies;
  }
}

