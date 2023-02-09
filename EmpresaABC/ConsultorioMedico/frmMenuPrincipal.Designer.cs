
namespace ConsultorioMedico
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.btnConsultas = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnExames = new System.Windows.Forms.Button();
            this.btnConvenios = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConsultas
            // 
            this.btnConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultas.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultas.Image")));
            this.btnConsultas.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultas.Location = new System.Drawing.Point(53, 49);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(196, 201);
            this.btnConsultas.TabIndex = 0;
            this.btnConsultas.Text = "&Consultas";
            this.btnConsultas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConsultas.UseVisualStyleBackColor = true;
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicos.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicos.Image")));
            this.btnMedicos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMedicos.Location = new System.Drawing.Point(273, 49);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(196, 201);
            this.btnMedicos.TabIndex = 1;
            this.btnMedicos.Text = "&Médicos";
            this.btnMedicos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.Image = ((System.Drawing.Image)(resources.GetObject("btnPacientes.Image")));
            this.btnPacientes.Location = new System.Drawing.Point(491, 49);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(196, 201);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "&Pacientes";
            this.btnPacientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPacientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnExames
            // 
            this.btnExames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExames.Image = ((System.Drawing.Image)(resources.GetObject("btnExames.Image")));
            this.btnExames.Location = new System.Drawing.Point(53, 285);
            this.btnExames.Name = "btnExames";
            this.btnExames.Size = new System.Drawing.Size(196, 201);
            this.btnExames.TabIndex = 3;
            this.btnExames.Text = "&Exames";
            this.btnExames.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExames.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExames.UseVisualStyleBackColor = true;
            this.btnExames.Click += new System.EventHandler(this.btnExames_Click);
            // 
            // btnConvenios
            // 
            this.btnConvenios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvenios.Image = ((System.Drawing.Image)(resources.GetObject("btnConvenios.Image")));
            this.btnConvenios.Location = new System.Drawing.Point(273, 285);
            this.btnConvenios.Name = "btnConvenios";
            this.btnConvenios.Size = new System.Drawing.Size(196, 201);
            this.btnConvenios.TabIndex = 4;
            this.btnConvenios.Text = "&Convênios";
            this.btnConvenios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConvenios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConvenios.UseVisualStyleBackColor = true;
            this.btnConvenios.Click += new System.EventHandler(this.btnConvenios_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.Image = ((System.Drawing.Image)(resources.GetObject("btnAgenda.Image")));
            this.btnAgenda.Location = new System.Drawing.Point(491, 285);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(196, 201);
            this.btnAgenda.TabIndex = 5;
            this.btnAgenda.Text = "&Agenda";
            this.btnAgenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(669, 503);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(103, 46);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAgenda);
            this.Controls.Add(this.btnConvenios);
            this.Controls.Add(this.btnExames);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnMedicos);
            this.Controls.Add(this.btnConsultas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultório médico";
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnExames;
        private System.Windows.Forms.Button btnConvenios;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnVoltar;
    }
}