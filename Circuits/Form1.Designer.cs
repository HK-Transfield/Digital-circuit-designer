namespace Circuits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAnd = new System.Windows.Forms.ToolStripButton();
            this.buttonOr = new System.Windows.Forms.ToolStripButton();
            this.buttonNot = new System.Windows.Forms.ToolStripButton();
            this.buttonInputSource = new System.Windows.Forms.ToolStripButton();
            this.buttonOutputLamp = new System.Windows.Forms.ToolStripButton();
            this.buttonEvaluate = new System.Windows.Forms.ToolStripButton();
            this.buttonCopy = new System.Windows.Forms.ToolStripButton();
            this.buttonStartCompound = new System.Windows.Forms.ToolStripButton();
            this.buttonEndCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAnd,
            this.buttonOr,
            this.buttonNot,
            this.buttonInputSource,
            this.buttonOutputLamp,
            this.buttonEvaluate,
            this.buttonCopy,
            this.buttonStartCompound,
            this.buttonEndCompound});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAnd
            // 
            this.buttonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAnd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnd.Image")));
            this.buttonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(23, 22);
            this.buttonAnd.Text = "And";
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOr.Image = ((System.Drawing.Image)(resources.GetObject("buttonOr.Image")));
            this.buttonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(23, 22);
            this.buttonOr.Text = "Or";
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.BackColor = System.Drawing.SystemColors.Control;
            this.buttonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNot.Image = ((System.Drawing.Image)(resources.GetObject("buttonNot.Image")));
            this.buttonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(23, 22);
            this.buttonNot.Text = "Not";
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // buttonInputSource
            // 
            this.buttonInputSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonInputSource.Image = global::Circuits.Properties.Resources.InputIcon;
            this.buttonInputSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonInputSource.Name = "buttonInputSource";
            this.buttonInputSource.Size = new System.Drawing.Size(23, 22);
            this.buttonInputSource.Text = "Input Source";
            this.buttonInputSource.Click += new System.EventHandler(this.buttonInputSource_Click);
            // 
            // buttonOutputLamp
            // 
            this.buttonOutputLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOutputLamp.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.buttonOutputLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOutputLamp.Name = "buttonOutputLamp";
            this.buttonOutputLamp.Size = new System.Drawing.Size(23, 22);
            this.buttonOutputLamp.Text = "Output Lamp";
            this.buttonOutputLamp.Click += new System.EventHandler(this.buttonOutputLamp_Click);
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEvaluate.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.buttonEvaluate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(23, 22);
            this.buttonEvaluate.Text = "Evaluate";
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCopy.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.buttonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(23, 22);
            this.buttonCopy.Text = "Copy Gate";
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonStartCompound
            // 
            this.buttonStartCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStartCompound.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.buttonStartCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStartCompound.Name = "buttonStartCompound";
            this.buttonStartCompound.Size = new System.Drawing.Size(23, 22);
            this.buttonStartCompound.Text = "Start Group";
            this.buttonStartCompound.Click += new System.EventHandler(this.buttonStartCompound_Click);
            // 
            // buttonEndCompound
            // 
            this.buttonEndCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEndCompound.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.buttonEndCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEndCompound.Name = "buttonEndCompound";
            this.buttonEndCompound.Size = new System.Drawing.Size(23, 22);
            this.buttonEndCompound.Text = "End Group";
            this.buttonEndCompound.Click += new System.EventHandler(this.buttonEndCompound_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(683, 510);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAnd;
        private System.Windows.Forms.ToolStripButton buttonOr;
        private System.Windows.Forms.ToolStripButton buttonNot;
        private System.Windows.Forms.ToolStripButton buttonInputSource;
        private System.Windows.Forms.ToolStripButton buttonOutputLamp;
        private System.Windows.Forms.ToolStripButton buttonEvaluate;
        private System.Windows.Forms.ToolStripButton buttonCopy;
        private System.Windows.Forms.ToolStripButton buttonStartCompound;
        private System.Windows.Forms.ToolStripButton buttonEndCompound;
    }
}

