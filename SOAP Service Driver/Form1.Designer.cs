namespace SOAP_Service_Driver
{
    partial class Form1
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
            this.BasicHttpBindingButton = new System.Windows.Forms.Button();
            this.WSHTTPBindingButton = new System.Windows.Forms.Button();
            this.Value = new System.Windows.Forms.TextBox();
            this.Valuelbl = new System.Windows.Forms.Label();
            this.ReturnValue = new System.Windows.Forms.TextBox();
            this.ReturnValuelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BasicHttpBindingButton
            // 
            this.BasicHttpBindingButton.Location = new System.Drawing.Point(29, 92);
            this.BasicHttpBindingButton.Name = "BasicHttpBindingButton";
            this.BasicHttpBindingButton.Size = new System.Drawing.Size(223, 23);
            this.BasicHttpBindingButton.TabIndex = 0;
            this.BasicHttpBindingButton.Text = "Basic Http Binding";
            this.BasicHttpBindingButton.UseVisualStyleBackColor = true;
            this.BasicHttpBindingButton.Click += new System.EventHandler(this.BasicHttpBindingButtonHTTPBinding_Click);
            // 
            // WSHTTPBindingButton
            // 
            this.WSHTTPBindingButton.Location = new System.Drawing.Point(29, 139);
            this.WSHTTPBindingButton.Name = "WSHTTPBindingButton";
            this.WSHTTPBindingButton.Size = new System.Drawing.Size(223, 23);
            this.WSHTTPBindingButton.TabIndex = 1;
            this.WSHTTPBindingButton.Text = "WS-Http Binding";
            this.WSHTTPBindingButton.UseVisualStyleBackColor = true;
            this.WSHTTPBindingButton.Click += new System.EventHandler(this.WSHTTPBindingButton_Click);
            // 
            // Value
            // 
            this.Value.Location = new System.Drawing.Point(29, 54);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(223, 20);
            this.Value.TabIndex = 2;
            // 
            // Valuelbl
            // 
            this.Valuelbl.AutoSize = true;
            this.Valuelbl.Location = new System.Drawing.Point(122, 38);
            this.Valuelbl.Name = "Valuelbl";
            this.Valuelbl.Size = new System.Drawing.Size(34, 13);
            this.Valuelbl.TabIndex = 3;
            this.Valuelbl.Text = "Value";
            // 
            // ReturnValue
            // 
            this.ReturnValue.Location = new System.Drawing.Point(29, 190);
            this.ReturnValue.Name = "ReturnValue";
            this.ReturnValue.Size = new System.Drawing.Size(223, 20);
            this.ReturnValue.TabIndex = 4;
            // 
            // ReturnValuelbl
            // 
            this.ReturnValuelbl.AutoSize = true;
            this.ReturnValuelbl.Location = new System.Drawing.Point(103, 174);
            this.ReturnValuelbl.Name = "ReturnValuelbl";
            this.ReturnValuelbl.Size = new System.Drawing.Size(69, 13);
            this.ReturnValuelbl.TabIndex = 5;
            this.ReturnValuelbl.Text = "Return Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ReturnValuelbl);
            this.Controls.Add(this.ReturnValue);
            this.Controls.Add(this.Valuelbl);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.WSHTTPBindingButton);
            this.Controls.Add(this.BasicHttpBindingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BasicHttpBindingButton;
        private System.Windows.Forms.Button WSHTTPBindingButton;
        private System.Windows.Forms.TextBox Value;
        private System.Windows.Forms.Label Valuelbl;
        private System.Windows.Forms.TextBox ReturnValue;
        private System.Windows.Forms.Label ReturnValuelbl;
    }
}

