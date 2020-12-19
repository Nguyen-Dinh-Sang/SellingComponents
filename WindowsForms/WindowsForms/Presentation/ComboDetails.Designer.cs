
namespace WindowsForms.Presentation
{
    partial class ComboDetails
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
            this.PanelKhung = new System.Windows.Forms.Panel();
            this.dataGridViewListProductIn = new System.Windows.Forms.DataGridView();
            this.dataGridViewListProductNotIn = new System.Windows.Forms.DataGridView();
            this.buttonbackall = new System.Windows.Forms.Button();
            this.buttonbackone = new System.Windows.Forms.Button();
            this.buttonsendall = new System.Windows.Forms.Button();
            this.buttonsendone = new System.Windows.Forms.Button();
            this.PanelKhung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProductIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProductNotIn)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelKhung
            // 
            this.PanelKhung.Controls.Add(this.dataGridViewListProductIn);
            this.PanelKhung.Controls.Add(this.dataGridViewListProductNotIn);
            this.PanelKhung.Controls.Add(this.buttonbackall);
            this.PanelKhung.Controls.Add(this.buttonbackone);
            this.PanelKhung.Controls.Add(this.buttonsendall);
            this.PanelKhung.Controls.Add(this.buttonsendone);
            this.PanelKhung.Location = new System.Drawing.Point(0, 0);
            this.PanelKhung.Name = "PanelKhung";
            this.PanelKhung.Size = new System.Drawing.Size(893, 438);
            this.PanelKhung.TabIndex = 0;
            // 
            // dataGridViewListProductIn
            // 
            this.dataGridViewListProductIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListProductIn.Location = new System.Drawing.Point(479, 0);
            this.dataGridViewListProductIn.Name = "dataGridViewListProductIn";
            this.dataGridViewListProductIn.Size = new System.Drawing.Size(414, 419);
            this.dataGridViewListProductIn.TabIndex = 7;
            this.dataGridViewListProductIn.Text = "dataGridView2";
            // 
            // dataGridViewListProductNotIn
            // 
            this.dataGridViewListProductNotIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListProductNotIn.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewListProductNotIn.Name = "dataGridViewListProductNotIn";
            this.dataGridViewListProductNotIn.Size = new System.Drawing.Size(412, 419);
            this.dataGridViewListProductNotIn.TabIndex = 6;
            this.dataGridViewListProductNotIn.Text = "dataGridView1";
            this.dataGridViewListProductNotIn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListProductNotIn_CellContentClick);
            // 
            // buttonbackall
            // 
            this.buttonbackall.Location = new System.Drawing.Point(418, 219);
            this.buttonbackall.Name = "buttonbackall";
            this.buttonbackall.Size = new System.Drawing.Size(55, 23);
            this.buttonbackall.TabIndex = 5;
            this.buttonbackall.Text = "<<<";
            this.buttonbackall.UseVisualStyleBackColor = true;
            // 
            // buttonbackone
            // 
            this.buttonbackone.Location = new System.Drawing.Point(418, 171);
            this.buttonbackone.Name = "buttonbackone";
            this.buttonbackone.Size = new System.Drawing.Size(55, 23);
            this.buttonbackone.TabIndex = 4;
            this.buttonbackone.Text = "<";
            this.buttonbackone.UseVisualStyleBackColor = true;
            // 
            // buttonsendall
            // 
            this.buttonsendall.Location = new System.Drawing.Point(418, 123);
            this.buttonsendall.Name = "buttonsendall";
            this.buttonsendall.Size = new System.Drawing.Size(55, 23);
            this.buttonsendall.TabIndex = 3;
            this.buttonsendall.Text = ">>>";
            this.buttonsendall.UseVisualStyleBackColor = true;
            // 
            // buttonsendone
            // 
            this.buttonsendone.Location = new System.Drawing.Point(418, 75);
            this.buttonsendone.Name = "buttonsendone";
            this.buttonsendone.Size = new System.Drawing.Size(55, 25);
            this.buttonsendone.TabIndex = 2;
            this.buttonsendone.Text = ">";
            this.buttonsendone.UseVisualStyleBackColor = true;
            this.buttonsendone.Click += new System.EventHandler(this.buttonsendone_Click);
            // 
            // ComboDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.PanelKhung);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "ComboDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComboDetail";
            this.PanelKhung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProductIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListProductNotIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelKhung;
        private System.Windows.Forms.Button buttonbackall;
        private System.Windows.Forms.Button buttonbackone;
        private System.Windows.Forms.Button buttonsendall;
        private System.Windows.Forms.Button buttonsendone;
        private System.Windows.Forms.DataGridView dataGridViewListProductIn;
        private System.Windows.Forms.DataGridView dataGridViewListProductNotIn;
    }
}