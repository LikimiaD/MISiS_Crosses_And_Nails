namespace winform_lab4
{
    public partial class Form1 : Form
    {
        public int polesize = 10;
        public int bordervert = 300, borderhoriz = 300; 
        public int player = 1;
        public int cellsize;
        public bool game = true;
        public Dictionary<string, string> arr = new Dictionary<string, string>();
        public Form1() => InitializeComponent();
         /*Чилловая сетка
         * Строит polesize на polesize */
        private void panel1_Paint(object sender, PaintEventArgs e){
            int i = 0;
            int x1 = 0, x2 = 0;
            int yy1 = 0, yy2 = 0;
            cellsize = bordervert / polesize;
            create_dic();
            while (i != polesize + 1){
                e.Graphics.DrawLine(new Pen(Color.Black, 3), x1, 0, x2, borderhoriz);
                e.Graphics.DrawLine(new Pen(Color.Black, 3), 0, yy1, bordervert, yy2);
                x1 += cellsize; x2 += cellsize;
                yy1 += cellsize; yy2 += cellsize;
                i++;}}
        /*А че будет если кликнуть?*/
        private void panel1_MouseClick(object sender, MouseEventArgs e){
            /* 0 -> Player 1
             * 1 -> Player 2*/
            if (game){
                if ((e.X < borderhoriz) && (e.Y < bordervert)){
                    player = player == 0 ? 1 : 0;
                    if (e.Button == MouseButtons.Left){
                        if (player == 0) draw_ellipse(e.X, e.Y);
                        else draw_сross(e.X, e.Y);}
                    if(win() == 1){
                        MessageBox.Show("You win");
                        game = false;
                    };}}}
        /*Кружок*/
        private void draw_ellipse(int MouseX, int MouseY){
            /*А вдруг уже кто-то тут закрасил.а-а-а?*/
            if (arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] == arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"]){
                Graphics g = panel1.CreateGraphics();
                g.DrawEllipse(new Pen(Color.Red, 3),new Rectangle(new Point(okr(0, MouseX), okr(0, MouseY)),new Size(cellsize, cellsize)));
                arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] = "O";
                g.Dispose();}}
        /*Крестик*/
        private void draw_сross(int MouseX, int MouseY){
            /*А вдруг уже кто-то тут закрасил.а-а-а?*/
            if (arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] == arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"]){
                Graphics g = panel1.CreateGraphics();
                g.DrawLine(new Pen(Color.Blue, 3),new Point(okr(0, MouseX), okr(0, MouseY)),new Point(okr(0, MouseX) + cellsize, okr(0, MouseY) + cellsize));
                g.DrawLine(new Pen(Color.Blue, 3),new Point(okr(0, MouseX) + cellsize, okr(0, MouseY)),new Point(okr(0, MouseX), okr(0, MouseY) + cellsize));
                arr[$"{okr(1, MouseX)}-{okr(1, MouseY)}"] = "X";
                g.Dispose(); }}
        /*Округление в меньшую сторону*/
        private int okr(int value, int x) => value == 0 ? (int)Math.Floor((decimal) x / cellsize) * cellsize : (int)Math.Floor((decimal)x / cellsize);
        /*Cоздание словарика для записи ответиков*/
        private void create_dic() {for (int i = 0; i < polesize; i++) for (int g = 0; g < polesize; g++)arr.Add($"{i}-{g}", $"{i}-{g}");}
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