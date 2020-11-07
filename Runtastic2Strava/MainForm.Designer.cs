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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnLoad = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.dgvImport = new System.Windows.Forms.DataGridView();
			this.btnImport = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnGpxImport = new System.Windows.Forms.Button();
			this.dgvGpx = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGpx)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLoad.Location = new System.Drawing.Point(865, 2);
			this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(76, 22);
			this.btnLoad.TabIndex = 0;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 2);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.btnLoad, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbPath, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(943, 26);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Runtastic Export Path";
			// 
			// tbPath
			// 
			this.tbPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPath.Location = new System.Drawing.Point(121, 2);
			this.tbPath.Margin = new System.Windows.Forms.Padding(2);
			this.tbPath.Name = "tbPath";
			this.tbPath.Size = new System.Drawing.Size(660, 20);
			this.tbPath.TabIndex = 2;
			this.tbPath.Text = "d:\\Repositories\\export-20201030-000\\";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnBrowse.Location = new System.Drawing.Point(785, 2);
			this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(76, 22);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// dgvImport
			// 
			this.dgvImport.AllowUserToAddRows = false;
			this.dgvImport.AllowUserToDeleteRows = false;
			this.dgvImport.ColumnHeadersHeight = 34;
			this.dgvImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvImport.Location = new System.Drawing.Point(2, 32);
			this.dgvImport.Margin = new System.Windows.Forms.Padding(2);
			this.dgvImport.Name = "dgvImport";
			this.dgvImport.ReadOnly = true;
			this.dgvImport.RowHeadersVisible = false;
			this.dgvImport.RowHeadersWidth = 62;
			this.dgvImport.RowTemplate.Height = 28;
			this.dgvImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvImport.Size = new System.Drawing.Size(469, 528);
			this.dgvImport.TabIndex = 4;
			// 
			// btnImport
			// 
			this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnImport.Location = new System.Drawing.Point(2, 564);
			this.btnImport.Margin = new System.Windows.Forms.Padding(2);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(469, 26);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "Import Activities";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.btnImport, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnGpxImport, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.dgvImport, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.dgvGpx, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(947, 592);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// btnGpxImport
			// 
			this.btnGpxImport.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnGpxImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGpxImport.Location = new System.Drawing.Point(476, 565);
			this.btnGpxImport.Name = "btnGpxImport";
			this.btnGpxImport.Size = new System.Drawing.Size(468, 24);
			this.btnGpxImport.TabIndex = 6;
			this.btnGpxImport.Text = "Import GPX";
			this.btnGpxImport.UseVisualStyleBackColor = true;
			// 
			// dgvGpx
			// 
			this.dgvGpx.AllowUserToAddRows = false;
			this.dgvGpx.AllowUserToDeleteRows = false;
			this.dgvGpx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGpx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGpx.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGpx.Location = new System.Drawing.Point(476, 33);
			this.dgvGpx.Name = "dgvGpx";
			this.dgvGpx.ReadOnly = true;
			this.dgvGpx.RowHeadersVisible = false;
			this.dgvGpx.Size = new System.Drawing.Size(468, 526);
			this.dgvGpx.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 592);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImport)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGpx)).EndInit();
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnGpxImport;
		private System.Windows.Forms.DataGridView dgvGpx;
	}
}