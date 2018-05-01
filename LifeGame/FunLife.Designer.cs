namespace LifeGame
{
  partial class FunLifeForm
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
      this.startCyclesButton = new System.Windows.Forms.Button();
      this.nextCycleButton = new System.Windows.Forms.Button();
      this.restartButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.gridSizeBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panelSizeBox = new System.Windows.Forms.TextBox();
      this.gliderButton = new System.Windows.Forms.Button();
      this.pentButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // startCyclesButton
      // 
      this.startCyclesButton.Location = new System.Drawing.Point(1253, 290);
      this.startCyclesButton.Name = "startCyclesButton";
      this.startCyclesButton.Size = new System.Drawing.Size(100, 23);
      this.startCyclesButton.TabIndex = 0;
      this.startCyclesButton.Text = "Start Life Cycles";
      this.startCyclesButton.UseVisualStyleBackColor = true;
      this.startCyclesButton.Click += new System.EventHandler(this.startCyclesButton_Click);
      // 
      // nextCycleButton
      // 
      this.nextCycleButton.Location = new System.Drawing.Point(1253, 334);
      this.nextCycleButton.Name = "nextCycleButton";
      this.nextCycleButton.Size = new System.Drawing.Size(100, 23);
      this.nextCycleButton.TabIndex = 1;
      this.nextCycleButton.Text = "Next Life Cycle";
      this.nextCycleButton.UseVisualStyleBackColor = true;
      this.nextCycleButton.Click += new System.EventHandler(this.nextCycleButton_Click);
      // 
      // restartButton
      // 
      this.restartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.restartButton.Location = new System.Drawing.Point(1253, 204);
      this.restartButton.Name = "restartButton";
      this.restartButton.Size = new System.Drawing.Size(100, 23);
      this.restartButton.TabIndex = 2;
      this.restartButton.Text = "Reset Planet";
      this.restartButton.UseVisualStyleBackColor = true;
      this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(1253, 96);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(79, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Grid Size (2-80)";
      // 
      // gridSizeBox
      // 
      this.gridSizeBox.Location = new System.Drawing.Point(1253, 114);
      this.gridSizeBox.MaxLength = 2;
      this.gridSizeBox.Name = "gridSizeBox";
      this.gridSizeBox.Size = new System.Drawing.Size(100, 20);
      this.gridSizeBox.TabIndex = 5;
      this.gridSizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridSizeBox_KeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(1253, 149);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Creature Size (5-15)";
      // 
      // panelSizeBox
      // 
      this.panelSizeBox.Location = new System.Drawing.Point(1253, 167);
      this.panelSizeBox.MaxLength = 2;
      this.panelSizeBox.Name = "panelSizeBox";
      this.panelSizeBox.Size = new System.Drawing.Size(100, 20);
      this.panelSizeBox.TabIndex = 7;
      this.panelSizeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.panelSizeBox_KeyPress);
      // 
      // gliderButton
      // 
      this.gliderButton.Location = new System.Drawing.Point(1253, 399);
      this.gliderButton.Name = "gliderButton";
      this.gliderButton.Size = new System.Drawing.Size(100, 23);
      this.gliderButton.TabIndex = 9;
      this.gliderButton.Text = "Glider";
      this.gliderButton.UseVisualStyleBackColor = true;
      this.gliderButton.Click += new System.EventHandler(this.gliderButton_Click);
      // 
      // pentButton
      // 
      this.pentButton.Location = new System.Drawing.Point(1253, 428);
      this.pentButton.Name = "pentButton";
      this.pentButton.Size = new System.Drawing.Size(100, 23);
      this.pentButton.TabIndex = 10;
      this.pentButton.Text = "R-pentiomino";
      this.pentButton.UseVisualStyleBackColor = true;
      this.pentButton.Click += new System.EventHandler(this.pentButton_Click);
      // 
      // FunLifeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1361, 765);
      this.Controls.Add(this.pentButton);
      this.Controls.Add(this.gliderButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.panelSizeBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.gridSizeBox);
      this.Controls.Add(this.restartButton);
      this.Controls.Add(this.nextCycleButton);
      this.Controls.Add(this.startCyclesButton);
      this.Name = "FunLifeForm";
      this.Text = "Fun LIFE";
      this.Load += new System.EventHandler(this.FunLifeForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button startCyclesButton;
    private System.Windows.Forms.Button nextCycleButton;
    private System.Windows.Forms.Button restartButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox gridSizeBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox panelSizeBox;
    private System.Windows.Forms.Button gliderButton;
    private System.Windows.Forms.Button pentButton;
  }
}

