namespace Arkanoid_WF
{
    partial class Arkanoid
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.PaddlePictureBox = new System.Windows.Forms.PictureBox();
            this.BallPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PaddlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PaddlePictureBox
            // 
            this.PaddlePictureBox.BackColor = System.Drawing.Color.White;
            this.PaddlePictureBox.Location = new System.Drawing.Point(356, 394);
            this.PaddlePictureBox.Name = "PaddlePictureBox";
            this.PaddlePictureBox.Size = new System.Drawing.Size(125, 37);
            this.PaddlePictureBox.TabIndex = 0;
            this.PaddlePictureBox.TabStop = false;
            // 
            // BallPictureBox
            // 
            this.BallPictureBox.BackColor = System.Drawing.Color.White;
            this.BallPictureBox.Location = new System.Drawing.Point(393, 351);
            this.BallPictureBox.Name = "BallPictureBox";
            this.BallPictureBox.Size = new System.Drawing.Size(47, 37);
            this.BallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BallPictureBox.TabIndex = 1;
            this.BallPictureBox.TabStop = false;
            // 
            // Arkanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.BallPictureBox);
            this.Controls.Add(this.PaddlePictureBox);
            this.DoubleBuffered = true;
            this.Name = "Arkanoid";
            this.Text = "Arkanoid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Arkanoid_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PaddlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private PictureBox PaddlePictureBox;
        private PictureBox BallPictureBox;
    }
}