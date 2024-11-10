namespace BatteryChargeControlUI
{
    partial class PowerLimit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrentPolicy = new System.Windows.Forms.Label();
            this.lblCurrentThreshold = new System.Windows.Forms.Label();
            this.txtChargeThreshold = new System.Windows.Forms.TextBox();
            this.btnStandardPolicy = new System.Windows.Forms.Button();
            this.btnCustomPolicy = new System.Windows.Forms.Button();
            this.btnSetThreshold = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrentPolicy
            // 
            this.lblCurrentPolicy.AutoSize = true;
            this.lblCurrentPolicy.Location = new System.Drawing.Point(77, 48);
            this.lblCurrentPolicy.Name = "lblCurrentPolicy";
            this.lblCurrentPolicy.Size = new System.Drawing.Size(41, 12);
            this.lblCurrentPolicy.TabIndex = 0;
            this.lblCurrentPolicy.Text = "label1";
            // 
            // lblCurrentThreshold
            // 
            this.lblCurrentThreshold.AutoSize = true;
            this.lblCurrentThreshold.Location = new System.Drawing.Point(230, 48);
            this.lblCurrentThreshold.Name = "lblCurrentThreshold";
            this.lblCurrentThreshold.Size = new System.Drawing.Size(41, 12);
            this.lblCurrentThreshold.TabIndex = 1;
            this.lblCurrentThreshold.Text = "label2";
            // 
            // txtChargeThreshold
            // 
            this.txtChargeThreshold.Location = new System.Drawing.Point(232, 122);
            this.txtChargeThreshold.Name = "txtChargeThreshold";
            this.txtChargeThreshold.Size = new System.Drawing.Size(71, 21);
            this.txtChargeThreshold.TabIndex = 3;
            this.txtChargeThreshold.Visible = false;
            // 
            // btnStandardPolicy
            // 
            this.btnStandardPolicy.Location = new System.Drawing.Point(79, 120);
            this.btnStandardPolicy.Name = "btnStandardPolicy";
            this.btnStandardPolicy.Size = new System.Drawing.Size(71, 23);
            this.btnStandardPolicy.TabIndex = 4;
            this.btnStandardPolicy.Text = "标准";
            this.btnStandardPolicy.UseVisualStyleBackColor = true;
            this.btnStandardPolicy.Click += new System.EventHandler(this.btnStandardPolicy_Click);
            // 
            // btnCustomPolicy
            // 
            this.btnCustomPolicy.Location = new System.Drawing.Point(79, 200);
            this.btnCustomPolicy.Name = "btnCustomPolicy";
            this.btnCustomPolicy.Size = new System.Drawing.Size(71, 23);
            this.btnCustomPolicy.TabIndex = 5;
            this.btnCustomPolicy.Text = "自定义";
            this.btnCustomPolicy.UseVisualStyleBackColor = true;
            this.btnCustomPolicy.Click += new System.EventHandler(this.btnCustomPolicy_Click);
            // 
            // btnSetThreshold
            // 
            this.btnSetThreshold.Location = new System.Drawing.Point(232, 200);
            this.btnSetThreshold.Name = "btnSetThreshold";
            this.btnSetThreshold.Size = new System.Drawing.Size(71, 23);
            this.btnSetThreshold.TabIndex = 6;
            this.btnSetThreshold.Text = "保存";
            this.btnSetThreshold.UseVisualStyleBackColor = true;
            this.btnSetThreshold.Click += new System.EventHandler(this.btnSetThreshold_Click);
            // 
            // PowerLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 273);
            this.Controls.Add(this.btnSetThreshold);
            this.Controls.Add(this.btnCustomPolicy);
            this.Controls.Add(this.btnStandardPolicy);
            this.Controls.Add(this.txtChargeThreshold);
            this.Controls.Add(this.lblCurrentThreshold);
            this.Controls.Add(this.lblCurrentPolicy);
            this.Name = "PowerLimit";
            this.Text = "PowerLimit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentPolicy;
        private System.Windows.Forms.Label lblCurrentThreshold;
        private System.Windows.Forms.TextBox txtChargeThreshold;
        private System.Windows.Forms.Button btnStandardPolicy;
        private System.Windows.Forms.Button btnCustomPolicy;
        private System.Windows.Forms.Button btnSetThreshold;
    }
}

