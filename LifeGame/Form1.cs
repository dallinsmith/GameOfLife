using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
  public partial class FunLifeForm : Form
  {

    public FunLifeForm()
    {
      InitializeComponent();
    }

    private Panel[,] _chessBoardPanels;
    private int _gridSize;
    private int tileSize;

    private void FunLifeForm_Load(object sender, EventArgs e)
    {
      tileSize = 20;
      _gridSize = 10;

      SetUpBoard();

    }

    private void SetUpBoard()
    {
      var smoke = Color.WhiteSmoke;
      var white = Color.White;

      _chessBoardPanels = new Panel[_gridSize, _gridSize];

      for (var n = 0; n < _gridSize; n++)
      {
        for (var m = 0; m < _gridSize; m++)
        {
          var newPanel = new Panel
          {
            Size = new Size(tileSize, tileSize),
            Location = new Point(tileSize * n, tileSize * m),
          };

          newPanel.Click += panel_Click;

          Controls.Add(newPanel);

          _chessBoardPanels[n, m] = newPanel;

          if (n % 2 == 0)
          {
            newPanel.BackColor = m % 2 != 0 ? smoke : white;
            newPanel.ForeColor = newPanel.BackColor;
          }
          else
          {
            newPanel.BackColor = m % 2 != 0 ? white : smoke;
            newPanel.ForeColor = newPanel.BackColor;
          }
        }
      }
    }

    void panel_Click(object sender, EventArgs e)
    {
      Panel panel = (Panel) sender;
      panel.BackColor = panel.BackColor == Color.Black ? panel.ForeColor : Color.Black;
    }

    private void nextCycleButton_Click(object sender, EventArgs e)
    {
      NextLifeCycle();
    }

    private void NextLifeCycle()
    {
      for (var x = 0; x < _gridSize; x++)
      {
        for (var y = 0; y < _gridSize; y++)
        {
          var isAlive = _chessBoardPanels[x, y].BackColor != Color.Black;

          int numberOfNeighbors = IsNeighborAlive(_gridSize, x, y, -1, 0)
                                  + IsNeighborAlive(_gridSize, x, y, -1, 1)
                                  + IsNeighborAlive(_gridSize, x, y, 0, 1)
                                  + IsNeighborAlive(_gridSize, x, y, 1, 1)
                                  + IsNeighborAlive(_gridSize, x, y, 1, 0)
                                  + IsNeighborAlive(_gridSize, x, y, 1, -1)
                                  + IsNeighborAlive(_gridSize, x, y, 0, -1)
                                  + IsNeighborAlive(_gridSize, x, y, -1, -1);

          var shouldLive = false;
          if (isAlive && (numberOfNeighbors == 2 || numberOfNeighbors == 3))
          {
            shouldLive = true;
          }
          else if (!isAlive && numberOfNeighbors == 3)
          {
            shouldLive = true;
          }

          _chessBoardPanels[x, y].BackColor = shouldLive ? Color.Black : _chessBoardPanels[x, y].ForeColor;

        }
      }
    }

    private int IsNeighborAlive(int size, int x, int y, int offsetx, int offsety)
    {
      int result = 0;

      int proposedOffsetX = x + offsetx;
      int proposedOffsetY = y + offsety;
      bool outOfBounds = proposedOffsetX < 0 || proposedOffsetX >= size | proposedOffsetY < 0 || proposedOffsetY >= size;
      if (!outOfBounds)
      {
        result = _chessBoardPanels[x + offsetx, y + offsety].BackColor == Color.Black ? 1 : 0;
      }
      return result;
    }

    private void restartButton_Click(object sender, EventArgs e)
    {
      SetUpBoard();
    }

    private void startCyclesButton_Click(object sender, EventArgs e)
    {
      for (var i = 10; i > 0; i--)
      {
        NextLifeCycle();
      }
    }

    private void gridSizeBox_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
