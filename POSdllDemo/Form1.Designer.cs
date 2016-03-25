namespace POSdllDemo
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gb76BlackMark = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btPrintGoNextCut = new System.Windows.Forms.Button();
            this.btPrintGoNext = new System.Windows.Forms.Button();
            this.tbCutMarkBack = new System.Windows.Forms.TextBox();
            this.btCutMarkBack = new System.Windows.Forms.Button();
            this.tbCutMarkGo = new System.Windows.Forms.TextBox();
            this.btCutMarkGo = new System.Windows.Forms.Button();
            this.tbCheckMarkBack = new System.Windows.Forms.TextBox();
            this.btCheckMarkBack = new System.Windows.Forms.Button();
            this.tbCheckMarkGo = new System.Windows.Forms.TextBox();
            this.btCheckMarkGo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbGetState = new System.Windows.Forms.Label();
            this.btn_GetPrinterState = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb76BlackMark.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gb76BlackMark);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // gb76BlackMark
            // 
            resources.ApplyResources(this.gb76BlackMark, "gb76BlackMark");
            this.gb76BlackMark.Controls.Add(this.label5);
            this.gb76BlackMark.Controls.Add(this.label4);
            this.gb76BlackMark.Controls.Add(this.btPrintGoNextCut);
            this.gb76BlackMark.Controls.Add(this.btPrintGoNext);
            this.gb76BlackMark.Controls.Add(this.tbCutMarkBack);
            this.gb76BlackMark.Controls.Add(this.btCutMarkBack);
            this.gb76BlackMark.Controls.Add(this.tbCutMarkGo);
            this.gb76BlackMark.Controls.Add(this.btCutMarkGo);
            this.gb76BlackMark.Controls.Add(this.tbCheckMarkBack);
            this.gb76BlackMark.Controls.Add(this.btCheckMarkBack);
            this.gb76BlackMark.Controls.Add(this.tbCheckMarkGo);
            this.gb76BlackMark.Controls.Add(this.btCheckMarkGo);
            this.gb76BlackMark.Name = "gb76BlackMark";
            this.gb76BlackMark.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btPrintGoNextCut
            // 
            resources.ApplyResources(this.btPrintGoNextCut, "btPrintGoNextCut");
            this.btPrintGoNextCut.Name = "btPrintGoNextCut";
            this.btPrintGoNextCut.UseVisualStyleBackColor = true;
            this.btPrintGoNextCut.Click += new System.EventHandler(this.btPrintGoNextCut_Click);
            // 
            // btPrintGoNext
            // 
            resources.ApplyResources(this.btPrintGoNext, "btPrintGoNext");
            this.btPrintGoNext.Name = "btPrintGoNext";
            this.btPrintGoNext.UseVisualStyleBackColor = true;
            this.btPrintGoNext.Click += new System.EventHandler(this.btPrintGoNext_Click);
            // 
            // tbCutMarkBack
            // 
            resources.ApplyResources(this.tbCutMarkBack, "tbCutMarkBack");
            this.tbCutMarkBack.Name = "tbCutMarkBack";
            // 
            // btCutMarkBack
            // 
            resources.ApplyResources(this.btCutMarkBack, "btCutMarkBack");
            this.btCutMarkBack.Name = "btCutMarkBack";
            this.btCutMarkBack.UseVisualStyleBackColor = true;
            this.btCutMarkBack.Click += new System.EventHandler(this.btCutMarkBack_Click);
            // 
            // tbCutMarkGo
            // 
            resources.ApplyResources(this.tbCutMarkGo, "tbCutMarkGo");
            this.tbCutMarkGo.Name = "tbCutMarkGo";
            // 
            // btCutMarkGo
            // 
            resources.ApplyResources(this.btCutMarkGo, "btCutMarkGo");
            this.btCutMarkGo.Name = "btCutMarkGo";
            this.btCutMarkGo.UseVisualStyleBackColor = true;
            this.btCutMarkGo.Click += new System.EventHandler(this.btCutMarkGo_Click);
            // 
            // tbCheckMarkBack
            // 
            resources.ApplyResources(this.tbCheckMarkBack, "tbCheckMarkBack");
            this.tbCheckMarkBack.Name = "tbCheckMarkBack";
            // 
            // btCheckMarkBack
            // 
            resources.ApplyResources(this.btCheckMarkBack, "btCheckMarkBack");
            this.btCheckMarkBack.Name = "btCheckMarkBack";
            this.btCheckMarkBack.UseVisualStyleBackColor = true;
            this.btCheckMarkBack.Click += new System.EventHandler(this.btCheckMarkBack_Click);
            // 
            // tbCheckMarkGo
            // 
            resources.ApplyResources(this.tbCheckMarkGo, "tbCheckMarkGo");
            this.tbCheckMarkGo.Name = "tbCheckMarkGo";
            // 
            // btCheckMarkGo
            // 
            resources.ApplyResources(this.btCheckMarkGo, "btCheckMarkGo");
            this.btCheckMarkGo.Name = "btCheckMarkGo";
            this.btCheckMarkGo.UseVisualStyleBackColor = true;
            this.btCheckMarkGo.Click += new System.EventHandler(this.btCheckMarkGo_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.lbGetState);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.btn_GetPrinterState);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // lbGetState
            // 
            resources.ApplyResources(this.lbGetState, "lbGetState");
            this.lbGetState.Name = "lbGetState";
            // 
            // btn_GetPrinterState
            // 
            resources.ApplyResources(this.btn_GetPrinterState, "btn_GetPrinterState");
            this.btn_GetPrinterState.Name = "btn_GetPrinterState";
            this.btn_GetPrinterState.UseVisualStyleBackColor = true;
            this.btn_GetPrinterState.Click += new System.EventHandler(this.btn_GetPrinterState_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gb76BlackMark.ResumeLayout(false);
            this.gb76BlackMark.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox gb76BlackMark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPrintGoNextCut;
        private System.Windows.Forms.Button btPrintGoNext;
        private System.Windows.Forms.TextBox tbCutMarkBack;
        private System.Windows.Forms.Button btCutMarkBack;
        private System.Windows.Forms.TextBox tbCutMarkGo;
        private System.Windows.Forms.Button btCutMarkGo;
        private System.Windows.Forms.TextBox tbCheckMarkBack;
        private System.Windows.Forms.Button btCheckMarkBack;
        private System.Windows.Forms.TextBox tbCheckMarkGo;
        private System.Windows.Forms.Button btCheckMarkGo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_GetPrinterState;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbGetState;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

