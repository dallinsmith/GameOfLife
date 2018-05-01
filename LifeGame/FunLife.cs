using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
  public partial class FunLifeForm : Form
  {
    private Panel[,] _thisGeneration;
    private Panel[,] _nextGeneration;
    public Action<Panel[,]> NextGenerationCompleted;

    private int _gridSize;
    private int _panelSize;
    private Task _processTask;

    private int Generation { get; set; }

    public FunLifeForm()
    {
      InitializeComponent();
    }

    private void FunLifeForm_Load(object sender, EventArgs e)
    {
      _gridSize = 15;
      _panelSize = 15;
      gridSizeBox.Text = @"15";
      panelSizeBox.Text = @"15";

      _thisGeneration = new Panel[_gridSize, _gridSize];
      _nextGeneration = new Panel[_gridSize, _gridSize];

      SetUpBoard(_thisGeneration);
    }

    private void SetUpBoard(Panel[,] generation)
    {
      var smoke = Color.WhiteSmoke;
      var white = Color.White;

      for (var n = 0; n < _gridSize; n++)
      {
        for (var m = 0; m < _gridSize; m++)
        {
          var newPanel = new Panel
          {
            Size = new Size(_panelSize, _panelSize),
            Location = new Point(_panelSize * n, _panelSize * m),
          };

          newPanel.Click += panel_Click;

          Controls.Add(newPanel);

          generation[n, m] = newPanel;

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

    public void BeginGeneration()
    {
      if (_processTask == null || (_processTask != null && _processTask.IsCompleted))
      {
        _processTask = NextLifeCycle();
      }
    }

    private void ResetBoard()
    {
      ClearBoard();
      CopyNewBoard();
    }

    private void ClearBoard()
    {
      Controls.Clear();
      InitializeComponent();
      gridSizeBox.Text = _gridSize.ToString();
      panelSizeBox.Text = _panelSize.ToString();
    }

    private void CopyNewBoard()
    {
      for (var n = 0; n < _gridSize; n++)
      {
        for (var m = 0; m < _gridSize; m++)
        {
          var panel = _thisGeneration[n, m];
          panel.Click += panel_Click;
          Controls.Add(panel);
        }
      }
    }

    private void panel_Click(object sender, EventArgs e)
    {
      Panel panel = (Panel) sender;
      panel.BackColor = panel.BackColor == Color.Black ? panel.ForeColor : Color.Black;
    }

    private void nextCycleButton_Click(object sender, EventArgs e)
    {
      BeginGeneration();
      Wait();
      CopyPanels(_thisGeneration, _nextGeneration);
      ResetBoard();
    }

    public void Wait()
    {
      _processTask?.Wait();
    }

    private void CopyPanels(Panel[,] panelTo, Panel[,] panelFrom)
    {
      for (var n = 0; n < _gridSize; n++)
      {
        for (var m = 0; m < _gridSize; m++)
        {
          var panel = panelFrom[n, m];
          panelTo[n, m] = new Panel {Size = panel.Size, Location = panel.Location, BackColor = panel.BackColor, ForeColor = panel.ForeColor};
        }
      }
    }

    private Task NextLifeCycle()
    {
      CopyPanels(_nextGeneration, _thisGeneration);

      return Task.Factory.StartNew(() =>
      {
        for (var x = 0; x < _gridSize; x++)
        {
          for (var y = 0; y < _gridSize; y++)
          {
            var isAlive = _thisGeneration[x, y].BackColor == Color.Black;

            int numberOfNeighbors = NeighborAlive(x, y, -1, 0)
                                    + NeighborAlive(x, y, -1, 1)
                                    + NeighborAlive(x, y, 0, 1)
                                    + NeighborAlive(x, y, 1, 1)
                                    + NeighborAlive(x, y, 1, 0)
                                    + NeighborAlive(x, y, 1, -1)
                                    + NeighborAlive(x, y, 0, -1)
                                    + NeighborAlive(x, y, -1, -1);

            var shouldLive = false;
            if (isAlive && (numberOfNeighbors == 2 || numberOfNeighbors == 3))
            {
              shouldLive = true;
            }
            else if (!isAlive && numberOfNeighbors == 3)
            {
              shouldLive = true;
            }

            _nextGeneration[x, y].BackColor = shouldLive ? Color.Black : _thisGeneration[x, y].ForeColor;
          }
        }
      });
    }

    private int NeighborAlive(int x, int y, int offsetx, int offsety)
    {
      int result = 0;

      int proposedOffsetX = x + offsetx;
      int proposedOffsetY = y + offsety;
      bool outOfBounds = proposedOffsetX < 0 || proposedOffsetX >= _gridSize | proposedOffsetY < 0 || proposedOffsetY >= _gridSize;
      if (!outOfBounds)
      {
        result = _thisGeneration[proposedOffsetX, proposedOffsetY].BackColor == Color.Black ? 1 : 0;
      }
      return result;
    }

    private void restartButton_Click(object sender, EventArgs e)
    {
      RestartBoard();
    }

    private void RestartBoard()
    {
      var gridSize = Convert.ToInt32(gridSizeBox.Text);
      var panelSize = Convert.ToInt32(panelSizeBox.Text);
      if (CorrectGridSizes(gridSize, panelSize))
      {
        _gridSize = gridSize;
        _panelSize = panelSize;
        ClearBoard();
        _thisGeneration = new Panel[_gridSize, _gridSize];
        _nextGeneration = new Panel[_gridSize, _gridSize];
        SetUpBoard(_thisGeneration);
      }
    }

    private void startCyclesButton_Click(object sender, EventArgs e)
    {
      while (Generation < 10)
      { 
        BeginGeneration();
        Wait();
        Update();
      }
      Generation = 0;
    }

    private new void Update()
    {
      if (_processTask == null || !_processTask.IsCompleted) return;
      CopyPanels(_thisGeneration, _nextGeneration);
      ResetBoard();
      Generation++;
      _processTask = NextLifeCycle();
      NextGenerationCompleted?.Invoke(_thisGeneration);
    }

    private void gridSizeBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
    }

    private void panelSizeBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
    }

    private static bool CorrectGridSizes(int gridSize, int panelSize)
    {
      if (gridSize > 80 || gridSize < 2)
      {
        MessageBox.Show(@"Sorry. You must have the correct value for Grid Size. (2-80)");
        return false;
      }
      if (panelSize > 15 || panelSize < 5)
      {
        MessageBox.Show(@"Sorry. You must have the correct value for Creature Size. (5-15)");
        return false;
      }

      return true;
    }

    private void gliderButton_Click(object sender, EventArgs e)
    {
      if (_gridSize < 3)
      {
        MessageBox.Show(@"Sorry. You must have a grid large enouph for the glider. (> 2)");
      }
      RestartBoard();
      _thisGeneration[1,0].BackColor = Color.Black;
      _thisGeneration[2,1].BackColor = Color.Black;
      _thisGeneration[0,2].BackColor = Color.Black;
      _thisGeneration[1,2].BackColor = Color.Black;
      _thisGeneration[2,2].BackColor = Color.Black;
    }

    private void pentButton_Click(object sender, EventArgs e)
    {
      if (_gridSize < 10)
      {
        MessageBox.Show(@"Sorry. You must have a grid large enouph for the R-pentimino. (> 9)");
      }
      RestartBoard();
      _thisGeneration[6, 5].BackColor = Color.Black;
      _thisGeneration[7, 5].BackColor = Color.Black;
      _thisGeneration[5, 6].BackColor = Color.Black;
      _thisGeneration[6, 6].BackColor = Color.Black;
      _thisGeneration[6, 7].BackColor = Color.Black;
    }
  }

}
