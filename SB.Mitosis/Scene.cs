using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SB.Mitosis
{
  internal class Scene
  {
    public const decimal FRAMES_PER_SEC = 60m;
    public const int WIDTH = 1280;
    public const int HEIGHT = 800;

    public List<Cell> Cells;

    public Scene()
    {
      this.Cells = new List<Cell>();
    }

    public void HandleKeyPress(KeyEventArgs kea)
    {
    }

    public void Draw(System.Drawing.Graphics gfx)
    {
      this.Cells.ForEach(c => c.Draw(gfx));
    }

    public void Update()
    {
      this.Cells.ForEach(c => c.UpdateLocation());
    }

  }
}
