namespace CraftRecipeTool
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxToMake = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxMaterial = new System.Windows.Forms.ListBox();
            this.listBoxRecipe = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "作りたいもの";
            // 
            // comboBoxToMake
            // 
            this.comboBoxToMake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxToMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxToMake.FormattingEnabled = true;
            this.comboBoxToMake.Location = new System.Drawing.Point(81, 12);
            this.comboBoxToMake.Name = "comboBoxToMake";
            this.comboBoxToMake.Size = new System.Drawing.Size(531, 20);
            this.comboBoxToMake.TabIndex = 2;
            this.comboBoxToMake.SelectedIndexChanged += new System.EventHandler(this.comboBoxToMake_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "素材";
            // 
            // listBoxMaterial
            // 
            this.listBoxMaterial.FormattingEnabled = true;
            this.listBoxMaterial.ItemHeight = 12;
            this.listBoxMaterial.Location = new System.Drawing.Point(81, 39);
            this.listBoxMaterial.Name = "listBoxMaterial";
            this.listBoxMaterial.Size = new System.Drawing.Size(531, 196);
            this.listBoxMaterial.TabIndex = 4;
            this.listBoxMaterial.SelectedIndexChanged += new System.EventHandler(this.listBoxMaterial_SelectedIndexChanged);
            // 
            // listBoxRecipe
            // 
            this.listBoxRecipe.FormattingEnabled = true;
            this.listBoxRecipe.ItemHeight = 12;
            this.listBoxRecipe.Location = new System.Drawing.Point(81, 241);
            this.listBoxRecipe.Name = "listBoxRecipe";
            this.listBoxRecipe.Size = new System.Drawing.Size(531, 100);
            this.listBoxRecipe.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "レシピ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxRecipe);
            this.Controls.Add(this.listBoxMaterial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxToMake);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Craft Recipe Tool";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxToMake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxMaterial;
        private System.Windows.Forms.ListBox listBoxRecipe;
        private System.Windows.Forms.Label label3;
    }
}

