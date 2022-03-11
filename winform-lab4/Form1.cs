namespace winform_lab4
{
    public partial class Form1 : Form
    {
        public int polesize = 3;
        public int bordervert = 300;
        public int borderhoriz = 300;
        public int cellsize;
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int i = 0;
            int x1 = 0, x2 = 0;
            int yy1 = 0, yy2 = 0;
            cellsize = bordervert / polesize;
            while (i != polesize + 1)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 3), x1, 0, x2, borderhoriz);
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 0, yy1, bordervert, yy2);
                x1 += cellsize; x2 += cellsize;
                yy1 += cellsize; yy2 += cellsize;
                i++;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            int x = okr(e.X);
            int y = okr(e.Y);
            g.DrawEllipse(
                new Pen(Color.Red, 3),
                new Rectangle(new Point(x, y),
                new Size(cellsize, cellsize))
                );
            checker.Text = $"{x} {y}";
        }
        private int okr(int x)
        {
            return (int) Math.Floor((decimal) x / cellsize) * cellsize;
        }
    }
}