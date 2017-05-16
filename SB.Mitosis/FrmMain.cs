using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SB.Mitosis
{
  public partial class FrmMain : Form
  {
    private Scene Scene;
    private Timer RedrawTimer;

    public FrmMain()
    {
      InitializeComponent();

      this.Scene = new Scene();

      this.ClientSize = new Size(Scene.WIDTH, Scene.HEIGHT);

      this.RedrawTimer = new Timer();
      this.RedrawTimer.Interval = (int)((1 / Scene.FRAMES_PER_SEC) * 1000m);
      this.RedrawTimer.Tick += (s, ea) => this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      var gfx = e.Graphics;

      this.Scene.Draw(gfx);
      this.Scene.Update();

      if (!this.DoubleBuffered) { gfx.Dispose(); }  
    }

    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
      this.Scene.HandleKeyPress(e);
    }

    private void FrmMain_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
    }

    private void FrmMain_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;

      Console.WriteLine("right click");
    }

  }
}
