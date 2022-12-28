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
            this.btPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PaddlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PaddlePictureBox
            // 
            this.PaddlePictureBox.BackColor = System.Drawing.Color.White;
            this.PaddlePictureBox.Location = new System.Drawing.Point(445, 492);
            this.PaddlePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PaddlePictureBox.Name = "PaddlePictureBox";
            this.PaddlePictureBox.Size = new System.Drawing.Size(156, 46);
            this.PaddlePictureBox.TabIndex = 0;
            this.PaddlePictureBox.TabStop = false;
            // 
            // BallPictureBox
            // 
            this.BallPictureBox.BackColor = System.Drawing.Color.White;
            this.BallPictureBox.Location = new System.Drawing.Point(491, 439);
            this.BallPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.BallPictureBox.Name = "BallPictureBox";
            this.BallPictureBox.Size = new System.Drawing.Size(59, 46);
            this.BallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BallPictureBox.TabIndex = 1;
            this.BallPictureBox.TabStop = false;
            // 
            // btPause
            // 
            this.btPause.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btPause.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btPause.ForeColor = System.Drawing.Color.LightCyan;
            this.btPause.Location = new System.Drawing.Point(874, 1);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(102, 52);
            this.btPause.TabIndex = 2;
            this.btPause.Text = "Пауза";
            this.btPause.UseVisualStyleBackColor = false;
            // 
            // Arkanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.BallPictureBox);
            this.Controls.Add(this.PaddlePictureBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Arkanoid";
            this.Text = "Arkanoid";
            ((System.ComponentModel.ISupportInitialize)(this.PaddlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private PictureBox PaddlePictureBox;
        private PictureBox BallPictureBox;
        private Button btPause;
    }
}