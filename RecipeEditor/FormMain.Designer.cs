namespace RecipeEditor
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxItem = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxSelectedOnly = new System.Windows.Forms.CheckBox();
            this.listBoxRecipe = new System.Windows.Forms.ListBox();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.buttonItemAdd = new System.Windows.Forms.Button();
            this.buttonItemDel = new System.Windows.Forms.Button();
            this.buttonRecipeDel = new System.Windows.Forms.Button();
            this.buttonRecipeAdd = new System.Windows.Forms.Button();
            this.upDownRecipe1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe1 = new System.Windows.Forms.ComboBox();
            this.comboBoxRecipe2 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe2 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe3 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe3 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe6 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe6 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe5 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe5 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe4 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe4 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe9 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe9 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe8 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe8 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRecipe7 = new System.Windows.Forms.ComboBox();
            this.upDownRecipe7 = new System.Windows.Forms.NumericUpDown();
            this.upDownRecipeCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipeCount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(13, 13);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "新規";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(95, 13);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "開く";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(177, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "アイテム一覧";
            // 
            // listBoxItem
            // 
            this.listBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxItem.FormattingEnabled = true;
            this.listBoxItem.ItemHeight = 12;
            this.listBoxItem.Location = new System.Drawing.Point(12, 115);
            this.listBoxItem.Name = "listBoxItem";
            this.listBoxItem.Size = new System.Drawing.Size(120, 304);
            this.listBoxItem.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "レシピ一覧";
            // 
            // checkBoxSelectedOnly
            // 
            this.checkBoxSelectedOnly.AutoSize = true;
            this.checkBoxSelectedOnly.Location = new System.Drawing.Point(204, 43);
            this.checkBoxSelectedOnly.Name = "checkBoxSelectedOnly";
            this.checkBoxSelectedOnly.Size = new System.Drawing.Size(128, 16);
            this.checkBoxSelectedOnly.TabIndex = 6;
            this.checkBoxSelectedOnly.Text = "選択中のアイテムのみ";
            this.checkBoxSelectedOnly.UseVisualStyleBackColor = true;
            this.checkBoxSelectedOnly.CheckedChanged += new System.EventHandler(this.checkBoxSelectedOnly_CheckedChanged);
            // 
            // listBoxRecipe
            // 
            this.listBoxRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecipe.FormattingEnabled = true;
            this.listBoxRecipe.ItemHeight = 12;
            this.listBoxRecipe.Location = new System.Drawing.Point(142, 140);
            this.listBoxRecipe.Name = "listBoxRecipe";
            this.listBoxRecipe.Size = new System.Drawing.Size(470, 280);
            this.listBoxRecipe.TabIndex = 7;
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(15, 61);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(117, 19);
            this.textBoxItemName.TabIndex = 8;
            this.textBoxItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemName_KeyDown);
            // 
            // buttonItemAdd
            // 
            this.buttonItemAdd.Location = new System.Drawing.Point(15, 86);
            this.buttonItemAdd.Name = "buttonItemAdd";
            this.buttonItemAdd.Size = new System.Drawing.Size(64, 23);
            this.buttonItemAdd.TabIndex = 9;
            this.buttonItemAdd.Text = "追加";
            this.buttonItemAdd.UseVisualStyleBackColor = true;
            this.buttonItemAdd.Click += new System.EventHandler(this.buttonItemAdd_Click);
            // 
            // buttonItemDel
            // 
            this.buttonItemDel.Location = new System.Drawing.Point(85, 86);
            this.buttonItemDel.Name = "buttonItemDel";
            this.buttonItemDel.Size = new System.Drawing.Size(47, 23);
            this.buttonItemDel.TabIndex = 10;
            this.buttonItemDel.Text = "削除";
            this.buttonItemDel.UseVisualStyleBackColor = true;
            this.buttonItemDel.Click += new System.EventHandler(this.buttonItemDel_Click);
            // 
            // buttonRecipeDel
            // 
            this.buttonRecipeDel.Location = new System.Drawing.Point(142, 110);
            this.buttonRecipeDel.Name = "buttonRecipeDel";
            this.buttonRecipeDel.Size = new System.Drawing.Size(41, 23);
            this.buttonRecipeDel.TabIndex = 11;
            this.buttonRecipeDel.Text = "削除";
            this.buttonRecipeDel.UseVisualStyleBackColor = true;
            this.buttonRecipeDel.Click += new System.EventHandler(this.buttonRecipeDel_Click);
            // 
            // buttonRecipeAdd
            // 
            this.buttonRecipeAdd.Location = new System.Drawing.Point(142, 84);
            this.buttonRecipeAdd.Name = "buttonRecipeAdd";
            this.buttonRecipeAdd.Size = new System.Drawing.Size(41, 23);
            this.buttonRecipeAdd.TabIndex = 12;
            this.buttonRecipeAdd.Text = "追加";
            this.buttonRecipeAdd.UseVisualStyleBackColor = true;
            this.buttonRecipeAdd.Click += new System.EventHandler(this.buttonRecipeAdd_Click);
            // 
            // upDownRecipe1
            // 
            this.upDownRecipe1.Location = new System.Drawing.Point(286, 62);
            this.upDownRecipe1.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe1.Name = "upDownRecipe1";
            this.upDownRecipe1.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe1.TabIndex = 17;
            // 
            // comboBoxRecipe1
            // 
            this.comboBoxRecipe1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe1.FormattingEnabled = true;
            this.comboBoxRecipe1.Location = new System.Drawing.Point(189, 61);
            this.comboBoxRecipe1.Name = "comboBoxRecipe1";
            this.comboBoxRecipe1.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe1.TabIndex = 18;
            // 
            // comboBoxRecipe2
            // 
            this.comboBoxRecipe2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe2.FormattingEnabled = true;
            this.comboBoxRecipe2.Location = new System.Drawing.Point(325, 62);
            this.comboBoxRecipe2.Name = "comboBoxRecipe2";
            this.comboBoxRecipe2.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe2.TabIndex = 20;
            // 
            // upDownRecipe2
            // 
            this.upDownRecipe2.Location = new System.Drawing.Point(422, 63);
            this.upDownRecipe2.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe2.Name = "upDownRecipe2";
            this.upDownRecipe2.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe2.TabIndex = 19;
            // 
            // comboBoxRecipe3
            // 
            this.comboBoxRecipe3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe3.FormattingEnabled = true;
            this.comboBoxRecipe3.Location = new System.Drawing.Point(461, 62);
            this.comboBoxRecipe3.Name = "comboBoxRecipe3";
            this.comboBoxRecipe3.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe3.TabIndex = 22;
            // 
            // upDownRecipe3
            // 
            this.upDownRecipe3.Location = new System.Drawing.Point(558, 63);
            this.upDownRecipe3.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe3.Name = "upDownRecipe3";
            this.upDownRecipe3.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe3.TabIndex = 21;
            // 
            // comboBoxRecipe6
            // 
            this.comboBoxRecipe6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe6.FormattingEnabled = true;
            this.comboBoxRecipe6.Location = new System.Drawing.Point(461, 88);
            this.comboBoxRecipe6.Name = "comboBoxRecipe6";
            this.comboBoxRecipe6.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe6.TabIndex = 28;
            // 
            // upDownRecipe6
            // 
            this.upDownRecipe6.Location = new System.Drawing.Point(558, 89);
            this.upDownRecipe6.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe6.Name = "upDownRecipe6";
            this.upDownRecipe6.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe6.TabIndex = 27;
            // 
            // comboBoxRecipe5
            // 
            this.comboBoxRecipe5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe5.FormattingEnabled = true;
            this.comboBoxRecipe5.Location = new System.Drawing.Point(325, 88);
            this.comboBoxRecipe5.Name = "comboBoxRecipe5";
            this.comboBoxRecipe5.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe5.TabIndex = 26;
            // 
            // upDownRecipe5
            // 
            this.upDownRecipe5.Location = new System.Drawing.Point(422, 89);
            this.upDownRecipe5.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe5.Name = "upDownRecipe5";
            this.upDownRecipe5.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe5.TabIndex = 25;
            // 
            // comboBoxRecipe4
            // 
            this.comboBoxRecipe4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe4.FormattingEnabled = true;
            this.comboBoxRecipe4.Location = new System.Drawing.Point(189, 87);
            this.comboBoxRecipe4.Name = "comboBoxRecipe4";
            this.comboBoxRecipe4.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe4.TabIndex = 24;
            // 
            // upDownRecipe4
            // 
            this.upDownRecipe4.Location = new System.Drawing.Point(286, 88);
            this.upDownRecipe4.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe4.Name = "upDownRecipe4";
            this.upDownRecipe4.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe4.TabIndex = 23;
            // 
            // comboBoxRecipe9
            // 
            this.comboBoxRecipe9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe9.FormattingEnabled = true;
            this.comboBoxRecipe9.Location = new System.Drawing.Point(461, 114);
            this.comboBoxRecipe9.Name = "comboBoxRecipe9";
            this.comboBoxRecipe9.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe9.TabIndex = 34;
            // 
            // upDownRecipe9
            // 
            this.upDownRecipe9.Location = new System.Drawing.Point(558, 115);
            this.upDownRecipe9.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe9.Name = "upDownRecipe9";
            this.upDownRecipe9.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe9.TabIndex = 33;
            // 
            // comboBoxRecipe8
            // 
            this.comboBoxRecipe8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe8.FormattingEnabled = true;
            this.comboBoxRecipe8.Location = new System.Drawing.Point(325, 114);
            this.comboBoxRecipe8.Name = "comboBoxRecipe8";
            this.comboBoxRecipe8.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe8.TabIndex = 32;
            // 
            // upDownRecipe8
            // 
            this.upDownRecipe8.Location = new System.Drawing.Point(422, 115);
            this.upDownRecipe8.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe8.Name = "upDownRecipe8";
            this.upDownRecipe8.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe8.TabIndex = 31;
            // 
            // comboBoxRecipe7
            // 
            this.comboBoxRecipe7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecipe7.FormattingEnabled = true;
            this.comboBoxRecipe7.Location = new System.Drawing.Point(189, 113);
            this.comboBoxRecipe7.Name = "comboBoxRecipe7";
            this.comboBoxRecipe7.Size = new System.Drawing.Size(91, 20);
            this.comboBoxRecipe7.TabIndex = 30;
            // 
            // upDownRecipe7
            // 
            this.upDownRecipe7.Location = new System.Drawing.Point(286, 114);
            this.upDownRecipe7.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipe7.Name = "upDownRecipe7";
            this.upDownRecipe7.Size = new System.Drawing.Size(33, 19);
            this.upDownRecipe7.TabIndex = 29;
            // 
            // upDownRecipeCount
            // 
            this.upDownRecipeCount.Location = new System.Drawing.Point(142, 62);
            this.upDownRecipeCount.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.upDownRecipeCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownRecipeCount.Name = "upDownRecipeCount";
            this.upDownRecipeCount.Size = new System.Drawing.Size(41, 19);
            this.upDownRecipeCount.TabIndex = 35;
            this.upDownRecipeCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.upDownRecipeCount);
            this.Controls.Add(this.comboBoxRecipe9);
            this.Controls.Add(this.upDownRecipe9);
            this.Controls.Add(this.comboBoxRecipe8);
            this.Controls.Add(this.upDownRecipe8);
            this.Controls.Add(this.comboBoxRecipe7);
            this.Controls.Add(this.upDownRecipe7);
            this.Controls.Add(this.comboBoxRecipe6);
            this.Controls.Add(this.upDownRecipe6);
            this.Controls.Add(this.comboBoxRecipe5);
            this.Controls.Add(this.upDownRecipe5);
            this.Controls.Add(this.comboBoxRecipe4);
            this.Controls.Add(this.upDownRecipe4);
            this.Controls.Add(this.comboBoxRecipe3);
            this.Controls.Add(this.upDownRecipe3);
            this.Controls.Add(this.comboBoxRecipe2);
            this.Controls.Add(this.upDownRecipe2);
            this.Controls.Add(this.comboBoxRecipe1);
            this.Controls.Add(this.upDownRecipe1);
            this.Controls.Add(this.buttonRecipeAdd);
            this.Controls.Add(this.buttonRecipeDel);
            this.Controls.Add(this.buttonItemDel);
            this.Controls.Add(this.buttonItemAdd);
            this.Controls.Add(this.textBoxItemName);
            this.Controls.Add(this.listBoxRecipe);
            this.Controls.Add(this.checkBoxSelectedOnly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonNew);
            this.Name = "FormMain";
            this.Text = "Recipe Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipe7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRecipeCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxSelectedOnly;
        private System.Windows.Forms.ListBox listBoxRecipe;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Button buttonItemAdd;
        private System.Windows.Forms.Button buttonItemDel;
        private System.Windows.Forms.Button buttonRecipeDel;
        private System.Windows.Forms.Button buttonRecipeAdd;
        private System.Windows.Forms.NumericUpDown upDownRecipe1;
        private System.Windows.Forms.ComboBox comboBoxRecipe1;
        private System.Windows.Forms.ComboBox comboBoxRecipe2;
        private System.Windows.Forms.NumericUpDown upDownRecipe2;
        private System.Windows.Forms.ComboBox comboBoxRecipe3;
        private System.Windows.Forms.NumericUpDown upDownRecipe3;
        private System.Windows.Forms.ComboBox comboBoxRecipe6;
        private System.Windows.Forms.NumericUpDown upDownRecipe6;
        private System.Windows.Forms.ComboBox comboBoxRecipe5;
        private System.Windows.Forms.NumericUpDown upDownRecipe5;
        private System.Windows.Forms.ComboBox comboBoxRecipe4;
        private System.Windows.Forms.NumericUpDown upDownRecipe4;
        private System.Windows.Forms.ComboBox comboBoxRecipe9;
        private System.Windows.Forms.NumericUpDown upDownRecipe9;
        private System.Windows.Forms.ComboBox comboBoxRecipe8;
        private System.Windows.Forms.NumericUpDown upDownRecipe8;
        private System.Windows.Forms.ComboBox comboBoxRecipe7;
        private System.Windows.Forms.NumericUpDown upDownRecipe7;
        private System.Windows.Forms.NumericUpDown upDownRecipeCount;
    }
}

