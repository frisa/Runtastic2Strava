namespace Runtastic2Strava
{
	partial class MainForm
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
			this.btnLoad = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.dgvImport = new System.Windows.Forms.DataGridView();
			this.btnImport = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLoad.Location = new System.Drawing.Point(1083, 3);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(114, 32);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.Controls.Add(this.btnLoad, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbPath, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.dgvImport, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnImport, 4, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 946);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Runtastic Export Path";
			// 
			// tbPath
			// 
			this.tbPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPath.Location = new System.Drawing.Point(182, 3);
			this.tbPath.Name = "tbPath";
			this.tbPath.Size = new System.Drawing.Size(775, 26);
			this.tbPath.TabIndex = 2;
			this.tbPath.Text = "d:\\Repositories\\export-20201030-000\\";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnBrowse.Location = new System.Drawing.Point(963, 3);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(114, 32);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// dgvImport
			// 
			this.dgvImport.AllowUserToAddRows = false;
			this.dgvImport.ColumnHeadersHeight = 34;
			this.tableLayoutPanel1.SetColumnSpan(this.dgvImport, 4);
			this.dgvImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvImport.Location = new System.Drawing.Point(3, 41);
			this.dgvImport.Name = "dgvImport";
			this.dgvImport.ReadOnly = true;
			this.dgvImport.RowHeadersVisible = false;
			this.dgvImport.RowHeadersWidth = 62;
			this.dgvImport.RowTemplate.Height = 28;
			this.dgvImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvImport.Size = new System.Drawing.Size(1194, 902);
			this.dgvImport.TabIndex = 4;
			// 
			// btnImport
			// 
			this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnImport.Location = new System.Drawing.Point(1203, 3);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(114, 32);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1320, 946);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.DataGridView dgvImport;
		private System.Windows.Forms.Button btnImport;
	}
}