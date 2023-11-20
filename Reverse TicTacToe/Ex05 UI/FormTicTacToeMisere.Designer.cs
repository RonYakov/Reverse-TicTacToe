namespace Ex05_UI
{
    partial class FormTicTacToeMisere
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
            this.tableLayoutPanelTicTacToeBoard = new System.Windows.Forms.TableLayoutPanel();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTicTacToeBoard
            // 
            this.tableLayoutPanelTicTacToeBoard.ColumnCount = 2;
            this.tableLayoutPanelTicTacToeBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.65197F));
            this.tableLayoutPanelTicTacToeBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.34803F));
            this.tableLayoutPanelTicTacToeBoard.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelTicTacToeBoard.Name = "tableLayoutPanelTicTacToeBoard";
            this.tableLayoutPanelTicTacToeBoard.RowCount = 2;
            this.tableLayoutPanelTicTacToeBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.5702F));
            this.tableLayoutPanelTicTacToeBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.4298F));
            this.tableLayoutPanelTicTacToeBoard.Size = new System.Drawing.Size(70, 60);
            this.tableLayoutPanelTicTacToeBoard.TabIndex = 0;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelPlayer1.Location = new System.Drawing.Point(251, 515);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(35, 13);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "label1";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(457, 515);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(35, 13);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "label2";
            // 
            // FormTicTacToeMisere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 537);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.tableLayoutPanelTicTacToeBoard);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "FormTicTacToeMisere";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicTacToeMisere";
            this.Load += new System.EventHandler(this.FormTicTacToeMisere_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTicTacToeBoard;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
    }
}