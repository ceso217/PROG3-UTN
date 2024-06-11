namespace Simon
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerJuego = new System.Windows.Forms.Timer(this.components);
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelSecuencia = new System.Windows.Forms.Label();
            this.labelSecuenciaJugador = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGreen
            // 
            this.buttonGreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGreen.AutoSize = true;
            this.buttonGreen.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.buttonGreen.Location = new System.Drawing.Point(93, 202);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(256, 144);
            this.buttonGreen.TabIndex = 0;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRed.AutoSize = true;
            this.buttonRed.BackColor = System.Drawing.Color.Maroon;
            this.buttonRed.Location = new System.Drawing.Point(349, 52);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(260, 144);
            this.buttonRed.TabIndex = 1;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBlue.AutoSize = true;
            this.buttonBlue.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonBlue.Location = new System.Drawing.Point(609, 202);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(260, 144);
            this.buttonBlue.TabIndex = 2;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.buttonYellow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonYellow.AutoSize = true;
            this.buttonYellow.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonYellow.Location = new System.Drawing.Point(349, 352);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(260, 144);
            this.buttonYellow.TabIndex = 3;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "SIMON";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.sequencEvent);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "bool";
            // 
            // timerJuego
            // 
            this.timerJuego.Enabled = true;
            this.timerJuego.Interval = 1000;
            this.timerJuego.Tick += new System.EventHandler(this.timerJuego_Tick);
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(483, 294);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(13, 13);
            this.labelTimer.TabIndex = 7;
            this.labelTimer.Text = "0";
            // 
            // labelSecuencia
            // 
            this.labelSecuencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSecuencia.AutoSize = true;
            this.labelSecuencia.Location = new System.Drawing.Point(639, 23);
            this.labelSecuencia.Name = "labelSecuencia";
            this.labelSecuencia.Size = new System.Drawing.Size(95, 13);
            this.labelSecuencia.TabIndex = 8;
            this.labelSecuencia.Text = "Secuencia colores";
            // 
            // labelSecuenciaJugador
            // 
            this.labelSecuenciaJugador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSecuenciaJugador.AutoSize = true;
            this.labelSecuenciaJugador.Location = new System.Drawing.Point(799, 23);
            this.labelSecuenciaJugador.Name = "labelSecuenciaJugador";
            this.labelSecuenciaJugador.Size = new System.Drawing.Size(96, 13);
            this.labelSecuenciaJugador.TabIndex = 9;
            this.labelSecuenciaJugador.Text = "Secuencia jugador";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(760, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(963, 547);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelSecuenciaJugador);
            this.Controls.Add(this.labelSecuencia);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonGreen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerJuego;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelSecuencia;
        private System.Windows.Forms.Label labelSecuenciaJugador;
        private System.Windows.Forms.Label label4;
    }
}

