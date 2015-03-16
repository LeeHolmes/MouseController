using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Runtime.InteropServices;

namespace MouseController
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MouseController : System.Windows.Forms.Form
	{
		//declare consts for mouse messages
		public const int MOUSEEVENTF_LEFTDOWN = 0x02;
		public const int MOUSEEVENTF_LEFTUP = 0x04;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		public const int MOUSEEVENTF_RIGHTUP = 0x10;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int top, bottom, left, right;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;

		public MouseController()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			top = 0;
			bottom = Screen.GetWorkingArea(this).Height;
			left = 0;
			right = Screen.GetWorkingArea(this).Width;
		}

		private void UpdateCursor()
		{
			Cursor.Position = new Point((left + right) / 2, (bottom + top) / 2);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MouseController));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ctrl+(Right/Left/Up/Down): Binary Search";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(216, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Right/Left/Up/Down: 10 pixel change";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(224, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Shift+(Right/Left/Up/Down): 1 pixel change";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(216, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Enter: Left-click";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(216, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Shift-enter: Right-click";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(216, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Esc: Quit";
			// 
			// MouseController
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 133);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MouseController";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Mouse Controller";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MouseController_KeyUp);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MouseController());
		}

		private void MouseController_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Key operations, for cursor movement
			if((e.KeyCode == Keys.Left) || 
				(e.KeyCode == Keys.Right) || 
				(e.KeyCode == Keys.Up) || 
				(e.KeyCode == Keys.Down))
			{
				// Control-operations: binary search
				if(e.Control)
				{
					// Control-Left: Move the cursor left
					if(e.KeyCode == Keys.Left)
						right = (left + right) / 2;
					// Control-Right: Move the cursor right
					if(e.KeyCode == Keys.Right)
						left = (left + right) / 2;
					// Control-Up: Move the cursor up
					if(e.KeyCode == Keys.Up)
						bottom = (bottom + top) / 2;
					// Control-Down: Move the cursor down
					if(e.KeyCode == Keys.Down)
						top = (bottom + top) / 2;

					UpdateCursor();
				}
				else
				{
					int adjustmentIncrement = 5;
					if(e.Shift)
						adjustmentIncrement = 1;

					// Normal operations: fine control
					if(e.KeyCode == Keys.Left)
						Cursor.Position = new Point(Cursor.Position.X - adjustmentIncrement, Cursor.Position.Y);
					if(e.KeyCode == Keys.Right)
						Cursor.Position = new Point(Cursor.Position.X + adjustmentIncrement, Cursor.Position.Y);
					if(e.KeyCode == Keys.Up)
						Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - adjustmentIncrement);
					if(e.KeyCode == Keys.Down)
						Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + adjustmentIncrement);
				}

				// Move the form to avoid the mouse
				if((Cursor.Position.Y < (this.Location.Y + this.Height)) &&
					(Cursor.Position.Y >= (this.Location.Y)) &&
					(Cursor.Position.X < (this.Location.X + this.Width)) &&
					(Cursor.Position.X >= (this.Location.X)))
				{
					if(this.Location.Y < this.Height)
						this.Location = new Point(this.Location.X, this.Location.Y + this.Height);
					else
						this.Location = new Point(this.Location.X, this.Location.Y - this.Height);
				}
			}
			
			// Enter = Mouse click, Shift+Enter = Right-Mouse click
			else if(e.KeyCode == Keys.Enter)
			{
				if(e.Shift)
				{
					mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
					System.Threading.Thread.Sleep(100);
					mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
				}
				else
				{
					mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
					System.Threading.Thread.Sleep(100);
					mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
				}

				this.Close();
			}

			// ESC = Quit
			else if(e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		[DllImport("user32.dll")]
		public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
	}
}
