namespace PathFinding
{
    using System;

    partial class PathfindingForm
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
            this.grid = new System.Windows.Forms.Panel();
            this.start = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.BackColor = System.Drawing.Color.White;
            this.grid.Location = new System.Drawing.Point(12, 43);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(300, 300);
            this.grid.TabIndex = 0;
            this.grid.Paint += new System.Windows.Forms.PaintEventHandler(this.GridPaint);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(82, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.StartClick);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(163, 12);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.ResetClick);
            // 
            // PathfindingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 351);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.start);
            this.Controls.Add(this.grid);
            this.Name = "PathfindingForm";
            this.Text = "A* Pathfinding";
            this.Load += new System.EventHandler(this.PathfindingFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel grid;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button reset;
    }
}

