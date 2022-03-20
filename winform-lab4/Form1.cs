namespace winform_lab4
{
    public partial class Form1 : Form
    {
        public int polesize = 3;
        public int bordervert = 300, borderhoriz = 300; 
        public int player = 1;
        public int cellsize;
        public bool game = true;
        public int gamecount = 1;
        public int playerf = 0, players = 0;
        public Dictionary<string, string> arr = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            create_dic(true);
            playertext.Text = "Игрок 1";
        }
            /*Чилловая сетка
            * Строит polesize на polesize */
            private void panel1_Paint(object sender, PaintEventArgs e){
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
            for (int x = 0; x < polesize; x++)for (int g = 0; g < polesize; g++)
                {
                    if (arr[$"{x}-{g}"] == "X")draw_сross(1, x, g);
                    else if (arr[$"{x}-{g}"] == "O")draw_ellipse(1, x, g);
                }
            player1.Text = $"Игрок 1\tСчет: {playerf}";
            player2.Text = $"Игрок 2\tСчет: {players}";
            }
        /*А че будет если кликнуть?*/
        private void panel1_MouseClick(object sender, MouseEventArgs e){
            /* 0 -> Player 1
             * 1 -> Player 2*/
            if (game){
                if ((e.X < borderhoriz) && (e.Y < bordervert)){
                    if (e.Button == MouseButtons.Left){
                        if (player == 0) draw_ellipse(0, e.X, e.Y);
                        else draw_сross(0, e.X, e.Y);}
                    if(win() == 1){
                        MessageBox.Show($"Игрок {(player == 0 ? 1 : 2)} выйграл");
                        if (player == 0) playerf += 1;
                        else players += 1;
                        player = 1;
                        create_dic(false);
                        panel1.Refresh();
                    }
                else if (gamecount == Math.Pow(polesize, 2))
                        {
                        MessageBox.Show($"Ничья");
                        player = 1;
                        create_dic(false);
                        panel1.Refresh();
                        }
                }}}
        /*Кружок*/
        private void draw_ellipse(int kekw, int MouseX, int MouseY)
        {
            /*А вдруг уже кто-то тут закрасил.а-а-а?*/
            if (kekw == 0)
            {
                if (arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] == $"{okr(1, MouseX)}-{okr(1, MouseY)}")
                {
                    gamecount += 1;
                    player = player == 0 ? 1 : 0;
                    playertext.Text = $"Игрок {(player == 0 ? 2 : 1)}";
                    Graphics g = panel1.CreateGraphics();
                    g.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(new Point(okr(0, MouseX), okr(0, MouseY)), new Size(cellsize, cellsize)));
                    arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] = "O";
                    g.Dispose();
                }
            }
            else
            {
                Graphics g = panel1.CreateGraphics();
                g.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(new Point(MouseX * cellsize, MouseY * cellsize), new Size(cellsize, cellsize)));
                g.Dispose();
            }
        }
        /*Крестик*/
        private void draw_сross(int kekw, int MouseX, int MouseY)
        {
            /*А вдруг уже кто-то тут закрасил.а-а-а?*/
            if (kekw == 0)
            {
                if (arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] == $"{okr(1, MouseX)}-{okr(1, MouseY)}")
                {
                    gamecount += 1;
                    player = player == 0 ? 1 : 0;
                    playertext.Text = $"Игрок {(player == 0 ? 2 : 1)}";
                    Graphics g = panel1.CreateGraphics();
                    g.DrawLine(new Pen(Color.Blue, 3), new Point(okr(0, MouseX), okr(0, MouseY)), new Point(okr(0, MouseX) + cellsize, okr(0, MouseY) + cellsize));
                    g.DrawLine(new Pen(Color.Blue, 3), new Point(okr(0, MouseX) + cellsize, okr(0, MouseY)), new Point(okr(0, MouseX), okr(0, MouseY) + cellsize));
                    arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] = "X";
                    g.Dispose();
                }
            }
            else
            {
                Graphics g = panel1.CreateGraphics();
                g.DrawLine(new Pen(Color.Blue, 3), new Point(MouseX * cellsize, MouseY * cellsize), new Point(MouseX * cellsize + cellsize, MouseY * cellsize + cellsize));
                g.DrawLine(new Pen(Color.Blue, 3), new Point(MouseX * cellsize, MouseY * cellsize), new Point(MouseX * cellsize, MouseY * cellsize + cellsize));
                g.Dispose();
            }
        }
        /*Округление в меньшую сторону*/
        private int okr(int value, int x) => value == 0 ? (int)Math.Floor((decimal) x / cellsize) * cellsize : (int)Math.Floor((decimal)x / cellsize);
        /*Cоздание словарика для записи ответиков*/
        private void create_dic(bool kekw)
        {
            for (int i = 0; i < polesize; i++) for (int g = 0; g < polesize; g++)
                {
                    if (kekw) arr.Add($"{i}-{g}", $"{i}-{g}");
                    else arr[$"{i}-{g}"] = $"{i}-{g}";
                }
        }

        private int win(){
            var num = 0;
            if (polesize == 3){
                if (string.Equals(arr["0-0"], arr["1-1"]) && string.Equals(arr["0-0"], arr["2-2"])) num = 1;
                else if (string.Equals(arr["2-0"], arr["1-1"]) && string.Equals(arr["2-0"], arr["0-2"])) num = 1;
                for (int i = 0; i < polesize; i++){
                    if (string.Equals(arr[$"{i}-0"], arr[$"{i}-1"]) && string.Equals(arr[$"{i}-0"], arr[$"{i}-2"])) num = 1;
                    if (string.Equals(arr[$"0-{i}"], arr[$"1-{i}"]) && string.Equals(arr[$"0-{i}"], arr[$"2-{i}"])) num = 1;}}
            else{
                if (string.Equals(arr["0-0"], arr["1-1"]) && string.Equals(arr["0-0"], arr["2-2"]) && string.Equals(arr["0-0"], arr["3-3"]) && string.Equals(arr["0-0"], arr["4-4"])) num = 1;
                else if (string.Equals(arr["5-5"], arr["6-6"]) && string.Equals(arr["5-5"], arr["7-7"]) && string.Equals(arr["5-5"], arr["8-8"]) && string.Equals(arr["5-5"], arr["9-9"])) num = 1;
                else if (string.Equals(arr["9-0"], arr["8-1"]) && string.Equals(arr["9-0"], arr["7-2"]) && string.Equals(arr["9-0"], arr["6-3"]) && string.Equals(arr["9-0"], arr["5-4"])) num = 1;
                else if (string.Equals(arr["0-9"], arr["1-8"]) && string.Equals(arr["0-9"], arr["2-7"]) && string.Equals(arr["0-9"], arr["3-6"]) && string.Equals(arr["0-9"], arr["4-5"])) num = 1;
                for (int i = 0; i < polesize; i++){
                    if (string.Equals(arr[$"{i}-0"], arr[$"{i}-1"]) && string.Equals(arr[$"{i}-0"], arr[$"{i}-2"]) && string.Equals(arr[$"{i}-0"], arr[$"{i}-3"]) && string.Equals(arr[$"{i}-0"], arr[$"{i}-4"])) num = 1;
                    else if (string.Equals(arr[$"{i}-5"], arr[$"{i}-6"]) && string.Equals(arr[$"{i}-5"], arr[$"{i}-7"]) && string.Equals(arr[$"{i}-5"], arr[$"{i}-8"]) && string.Equals(arr[$"{i}-5"], arr[$"{i}-9"])) num = 1;
                    else if (string.Equals(arr[$"0-{i}"], arr[$"1-{i}"]) && string.Equals(arr[$"0-{i}"], arr[$"2-{i}"]) && string.Equals(arr[$"0-{i}"], arr[$"3-{i}"]) && string.Equals(arr[$"0-{i}"], arr[$"4-{i}"])) num = 1;
                    else if (string.Equals(arr[$"5-{i}"], arr[$"6-{i}"]) && string.Equals(arr[$"5-{i}"], arr[$"7-{i}"]) && string.Equals(arr[$"5-{i}"], arr[$"8-{i}"]) && string.Equals(arr[$"5-{i}"], arr[$"9-{i}"])) num = 1;}}
            return num;
        }
    }
}