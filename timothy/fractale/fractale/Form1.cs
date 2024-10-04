using System.Drawing;
namespace fractale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int recurlevel = 30;
        int numberCoup = 1;
        int first = 0;
        private void panneau_Paint(object sender, PaintEventArgs e)
        {
            recurlevel--;
            Point p1 = new Point();
            Point p2 = new Point();
            
            
            if (recurlevel > 0&&first>0)
            {
                for (int i = 0; i < numberCoup/4; i++)
                {
                    for (int j = 0; i < 4; i++)
                    {
                        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                        int l1 = 774 / numberCoup * 3*i;
                        int l2 = 774 / numberCoup * 3*i;
                        int l3 = 774 / numberCoup * 3*i;
                        int l4 = 774 / numberCoup * 3*i;
                        panneau.Refresh();
                        e.Graphics.DrawLine(pen, l1, l2, l3, l4);
                        
                    }
                }
            }
            else
            {
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                first=43;
                e.Graphics.DrawLine(pen, 0, 200, 776, 200);
            }
            //h = (sqrt(3) / 2) * d
            numberCoup *=4;
            //"774; 406";
            

            /*
            e.Graphics.DrawLine(pen, 0, 200, (774/3), 200);
            e.Graphics.DrawLine(pen, (774 / 3), 200, (774 / 2), 100);
            e.Graphics.DrawLine(pen, (774 / 2), 100, ((774 / 3)*2), 200);
            e.Graphics.DrawLine(pen, ((774 / 3) * 2), 200, 774 , 200);*/
            Thread.Sleep(1000);
            if (recurlevel < 1)
            {
                panneau_Paint(sender, e);
            }
        }
    }
}
