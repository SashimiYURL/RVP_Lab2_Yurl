using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RVP_Lab2_Yurl
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        int backGround;
        Color backColor;
        string file;
        int grafType = 0;
        float zoom = 1.0f;
        Color colorGraf = Color.Black;
        int moveX;
        int moveY;
        bool moveMouse = false;
        Point earlyMouseLocation; 
        
        float scaleX = 0;
        float scaleY = 0;
        float delta = 1;

        List<PointF> pointDraw = new List<PointF>();
        bool drawPointActive=false;
        int countPoint = 0;
        float distance = 0;
        float movePointX=0;
        float movePointY = 0;
        float currentY;
       

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelPaint, new object[] { true });

            panelPaint.MouseWheel += PanelPaint_MouseWheel;
        }

        private void PanelPaint_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta>0 && zoom < 4.9f)
            {
                zoom += 0.1f;
                panelPaint.Invalidate();
            }
            else if(e.Delta<0 && zoom>0.5f)
            {
                zoom -= 0.1f;
                panelPaint.Invalidate();
            }
        }

        private void buttonRandomFunc_Click(object sender, EventArgs e)
        {
            zoom = 1.0f;
            colorGraf = Color.Black;
            moveX = 0;
            moveY = 0;
            pointDraw.Clear();
            drawPointActive = false;
            countPoint = 0;
            distance = 0;
            Random random = new Random();
            grafType = random.Next(1,6);
            //grafType = 5;
            panelPaint.Invalidate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Вы уверены, что хотите сохранить?","Уведомление",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|"+
                "GIF File(*.gif)|*.gif|"+
                "JPEG File(*.jpg)|*.jpg|"+
                "TIF File(*.tif)|*.tif|"+
                "PNG File(*.png)|*.png";

            saveFileDialog.ShowHelp = true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName=saveFileDialog.FileName;
                string strFilExtn=fileName.Remove(0,fileName.Length-3);
                switch (strFilExtn)
                {
                    case "bmp":
                        bitmap.Save(fileName,System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "gif":
                        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "jpeg":
                        bitmap.Save(fileName,System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "tif":
                        bitmap.Save(fileName,System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bitmap.Save(fileName,System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
                MessageBox.Show("Файл успешно сохранён");  
            }

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog diag=new ColorDialog();
            diag.ShowDialog();
            colorGraf=diag.Color;
            panelPaint.Invalidate();
        }

        private void buttonStyleBackground_Click(object sender, EventArgs e)
        {
            DialogBackground dialogStyle=new DialogBackground();
            dialogStyle.ShowDialog();

            if (dialogStyle.DialogResult == DialogResult.OK)
            {
                switch (dialogStyle.StyleType)
                {
                    case 1: 
                    {
                            backGround = 1;
                            backColor=dialogStyle.ColorType;
                            panelPaint.Invalidate();
                            break;
                    }
                    case 2:
                    {
                            backGround= 2;
                            panelPaint.Invalidate();
                            break;
                    
                    }
                    case 3:
                    {
                            backGround = 3;
                            panelPaint.Invalidate ();
                            break;
                    }
                    case 4:
                    {
                            backGround = 4;
                            file=dialogStyle.fileName;
                            panelPaint.Invalidate();
                            break;
                    }
                    case 5:
                        {
                            backGround = 5;
                            panelPaint.Invalidate();
                            break;   
                        }
                    case 6:
                        {
                            backGround=6;
                            panelPaint.Invalidate();
                            break;
                        }

                }
            }

        }
        private void DrawAxle(PointF start,PointF end)
        {
            Graphics graphics=Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black,1f);
            graphics.DrawLine(pen, start, end);
            graphics.Dispose();
        }
        private void DrawCercle()
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen=new Pen(Color.Black,2f);
            pen.DashStyle = DashStyle.Dash;
            float centreX = panelPaint.ClientSize.Width / 2;
            float centreY = panelPaint.ClientSize.Height / 2;
            graphics.DrawEllipse(pen,moveX+centreX-20*zoom,moveY+centreY-20*zoom,40*zoom,40*zoom);

            

        }
        private void DrawBackgroundColor()
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            switch (backGround)
            {
                case 1:
                    {
                        SolidBrush solidBrush = new SolidBrush(backColor);
                        graphics.FillRectangle(solidBrush,panelPaint.ClientRectangle);
                        break;
                    }
                case 2:
                    {
                        LinearGradientBrush gradientBrush = new LinearGradientBrush(panelPaint.ClientRectangle, Color.Pink, Color.Blue, 30);
                        graphics.FillRectangle(gradientBrush,panelPaint.ClientRectangle);
                        break;
                    }
                case 3:
                    {
                        HatchBrush hatchBrush =new HatchBrush(HatchStyle.BackwardDiagonal,Color.Green,Color.White);
                        graphics.FillRectangle(hatchBrush,panelPaint.ClientRectangle);
                        break;
                    }
                case 4:
                    {
                        Bitmap startImage = new Bitmap(file);
                        Bitmap image = new Bitmap(startImage, panelPaint.ClientSize.Width, panelPaint.ClientSize.Height);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawImageUnscaled(image, panelPaint.ClientRectangle);
                        break;
                    }
                case 5:
                    {
                        HatchBrush hatchBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.OrangeRed, Color.Pink);
                        graphics.FillRectangle(hatchBrush, panelPaint.ClientRectangle);
                        break;
                    }
                case 6:
                    {
                        LinearGradientBrush linearGradient = new LinearGradientBrush(panelPaint.ClientRectangle, Color.DarkViolet, Color.Black, 45);
                        graphics.FillRectangle(linearGradient, panelPaint.ClientRectangle);
                        SolidBrush pens=new SolidBrush(Color.White);
                        int maxWidth=panelPaint.ClientRectangle.Width;
                        int maxHeight=panelPaint.ClientRectangle.Height;
                        int countStar = 300;
                        Random random = new Random();
                       
                        for(int i = 0; i < countStar; i++)
                        {
                            graphics.DrawEllipse(Pens.Yellow,random.Next(1,maxWidth),random.Next(1,maxHeight),1,1);
                        }
                        break;
                    }
                default:
                    {
                        SolidBrush solidBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(solidBrush, panelPaint.ClientRectangle);
                        break;
                    }
            }

        }

        //private void DrawParabola()
        //{
        //    float centreX = panelPaint.ClientSize.Width/2;
        //    float centreY = panelPaint.ClientSize.Height/2;

        //    Graphics graphics = Graphics.FromImage(bitmap);
        //    Pen pen = new Pen(colorGraf, 2f);
        //    PointF[] pointsRight = new PointF[30000];
        //    PointF[] pointsLeft = new PointF[30000];
        //    int pointsCount=0;
        //    Parabola parabola=new Parabola();
        //    for (float x = 0.0f; pointsCount < pointsRight.Length; x += 0.01f)
        //    {
        //        pointsRight[pointsCount]=new PointF(zoom*x+centreX+moveX, moveY+centreY-zoom*parabola.Calc(x)*(1/20.0f));
        //        pointsCount++;
        //    }
        //    pointsCount=0;
        //    for (float x = 0.0f; pointsCount < pointsLeft.Length; x += 0.01f)
        //    {
        //        pointsLeft[pointsCount] = new PointF(centreX-zoom*x+moveX, moveY + centreY - zoom*parabola.Calc(x)*(1/20.0f));
        //        pointsCount++;
        //    }
        //    graphics.DrawLines(pen, pointsRight);
        //    graphics.DrawLines(pen, pointsLeft);
        //}
        //private void DrawKubParab()
        //{
        //    float centreX = panelPaint.ClientSize.Width / 2;
        //    float centreY = panelPaint.ClientSize.Height / 2;

        //    Graphics graphics = Graphics.FromImage(bitmap);
        //    Pen pen = new Pen(colorGraf, 2f);
        //    PointF[] pointsRight = new PointF[10000];
        //    PointF[] pointsLeft = new PointF[10000];
        //    int pointsCount = 0;
        //    KubParab parabolaCub = new KubParab();
        //    for (float x = 0; pointsCount < pointsRight.Length; x += 0.01f)
        //    {
        //        pointsRight[pointsCount] = new PointF(zoom*x + centreX+moveX, moveY+centreY - zoom*parabolaCub.Calc(x)*(1/ 400.0f));
        //        pointsCount++;
        //    }
        //    pointsCount = 0;
        //    for (float x = 0; pointsCount < pointsLeft.Length; x += 0.01f)
        //    {
        //        pointsLeft[pointsCount] = new PointF(centreX - x*zoom+moveX, moveY+centreY -zoom*parabolaCub.Calc(-x)*(1 / 400.0f));
        //        pointsCount++;
        //    }
        //    graphics.DrawLines(pen, pointsRight);
        //    graphics.DrawLines(pen, pointsLeft);
        //}
        //private void DrawStraight()
        //{
        //    float centreX = panelPaint.ClientSize.Width / 2;
        //    float centreY = panelPaint.ClientSize.Height / 2;

        //    Graphics graphics = Graphics.FromImage(bitmap);
        //    Pen pen = new Pen(colorGraf, 2f);
        //    PointF[] pointsRight = new PointF[10000];
        //    PointF[] pointsLeft = new PointF[10000];
        //    int pointsCount = 0;
        //    Straight straight = new Straight();
        //    for (float x = 0; pointsCount < pointsRight.Length; x += 1f)
        //    {
        //        pointsRight[pointsCount] = new PointF(zoom*x + centreX+moveX, moveY+centreY - zoom*straight.Calc(x));
        //        pointsCount++;
        //    }
        //    pointsCount = 0;
        //    for (float x = 0; pointsCount < pointsLeft.Length; x += 1f)
        //    {
        //        pointsLeft[pointsCount] = new PointF(centreX - x*zoom+moveX, moveY+centreY - zoom*straight.Calc(-x));
        //        pointsCount++;
        //    }
        //    graphics.DrawLines(pen, pointsRight);
        //    graphics.DrawLines(pen, pointsLeft);

        //}
        //private void DrawSin()
        //{
        //    float centreX = panelPaint.ClientSize.Width / 2;
        //    float centreY = panelPaint.ClientSize.Height / 2;

        //    Graphics graphics = Graphics.FromImage(bitmap);
        //    Pen pen = new Pen(colorGraf, 2f);
        //    PointF[] pointsRight = new PointF[10000];
        //    PointF[] pointsLeft = new PointF[10000];
        //    int pointsCount = 0;
        //    Sin sin = new Sin();
        //    for (float x = 0; pointsCount < pointsRight.Length; x += 1f)
        //    {
        //        pointsRight[pointsCount] = new PointF(zoom*x + centreX+moveX,moveY+ centreY - zoom*sin.Calc(x/20.0f)*20.0f);
        //        pointsCount++;
        //    }
        //    pointsCount = 0;
        //    for (float x = 0; pointsCount < pointsLeft.Length; x += 1f)
        //    {
        //        pointsLeft[pointsCount] = new PointF(centreX - zoom*x+moveX, moveY+centreY - zoom*sin.Calc(-x/20.0f)*20.0f);
        //        pointsCount++;
        //    }
        //    graphics.DrawLines(pen, pointsRight);
        //    graphics.DrawLines(pen, pointsLeft);
        //}
        private void DrawTg()
        {
            for (int k = 0; k * 20 <= panelPaint.ClientSize.Width; k++)
            {
                GenerateTg(k, -1);
                GenerateTg(k, 1);
            }
        }
        private void GenerateTg(int k, int sign)
        {
            float centreX = panelPaint.ClientSize.Width / 2;
            float centreY = panelPaint.ClientSize.Height / 2;

            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen = new Pen(colorGraf, 2f);
            PointF[] pointsRight = new PointF[10000];
            PointF[] pointsLeft = new PointF[10000];
            int pointsCount = 0;
            Tg tg = new Tg();
            for (float x = 0; pointsCount < pointsRight.Length; x += 1f)
            {
                if (x * zoom >= zoom * (float)20.0f * Math.PI / 2) { break; }
                pointsRight[pointsCount] = new PointF(zoom * x + centreX + moveX + 20.0f * sign * k * zoom * (float)Math.PI, moveY + centreY - zoom * tg.Calc(x / 20.0f) * 20.0f);
                if (pointsCount > 0)
                {
                    graphics.DrawLine(pen, pointsRight[pointsCount - 1], pointsRight[pointsCount]);
                }
                pointsCount++;
            }
            pointsCount = 0;
            for (float x = 0; pointsCount < pointsLeft.Length; x += 1f)
            {
                if (zoom * x >= zoom * (float)20.0f * Math.PI / 2) { break; }
                pointsLeft[pointsCount] = new PointF(-x * zoom + centreX + moveX + 20.0f * sign * k * zoom * (float)Math.PI, moveY + centreY - zoom * tg.Calc(-x / 20.0f) * 20.0f);
                if (pointsCount > 0)
                {
                    graphics.DrawLine(pen, pointsLeft[pointsCount - 1], pointsLeft[pointsCount]);
                }
                pointsCount++;
            }
        }
        private void DrawFunc()
        {
            IFunction function=null;
            switch (grafType)
            {
                case 1:
                    {
                        scaleX = 1;
                        scaleY = 1 / 20.0f;
                        delta = 0.01f;
                        function = new Parabola(); ;
                        //DrawFunctionType();
                        break;
                    }
                case 2:
                    {
                        scaleX = 1;
                        scaleY =1/400.0f;
                        delta = 0.1f;
                        function=new KubParab(); ;
                        //DrawKubParab();
                        break;
                    }
                case 3:
                    {
                        scaleX=1;
                        scaleY = 1;
                        delta = 1;
                        function = new Straight();
                        //DrawStraight();
                        break;
                    }
                case 4:
                    {
                        scaleX=1/20.0f;
                        scaleY = 20.0f;
                        delta = 1;
                        function = new Sin();
                        //DrawSin();
                        break;
                    }
                case 5:
                    {
                        DrawTg();
                        break;
                    }
                   
            }
            if (grafType != 5)
            {
                DrawFunctionType(function);
            }

        }
        private void DrawFunctionType(IFunction funcStart)
        {
            if (funcStart != null)
            {
                float centreX = panelPaint.ClientSize.Width / 2;
                float centreY = panelPaint.ClientSize.Height / 2;

                Graphics graphics = Graphics.FromImage(bitmap);
                Pen pen = new Pen(colorGraf, 2f);
                PointF[] pointsRight = new PointF[30000];
                PointF[] pointsLeft = new PointF[30000];
                int pointsCount = 0;
                

                for (float x = 0.0f; pointsCount < pointsRight.Length; x += 1.0f*delta)
                {
                    pointsRight[pointsCount] = new PointF(zoom * x + centreX + moveX, moveY + centreY - zoom * funcStart.Calc(x*scaleX)*scaleY);
                    pointsCount++;
                }
                pointsCount = 0;
                for (float x = 0.0f; pointsCount < pointsLeft.Length; x -= 1.0f*delta)
                {
                    pointsLeft[pointsCount] = new PointF(centreX + zoom * x + moveX, moveY + centreY - zoom * funcStart.Calc(x*scaleX)*scaleY);
                    pointsCount++;
                }
                graphics.DrawLines(pen, pointsRight);
                graphics.DrawLines(pen, pointsLeft);
            }

        }
        private void DrawScale()
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            Brush brush=new SolidBrush(Color.Black);
            Font font = new Font("Arial", 11f);
            graphics.DrawString("Масштаб", font, brush, panelPaint.ClientSize.Width-80, 20);
            graphics.DrawString(zoom.ToString("0.0"), font, brush, panelPaint.ClientSize.Width - 80, 40);
        }

        private void panelPaint_Paint(object sender, PaintEventArgs e)
        {
            bitmap = new Bitmap(panelPaint.ClientSize.Width,panelPaint.ClientSize.Height);
            float centreX = panelPaint.ClientSize.Width / 2;
            float centreY = panelPaint.ClientSize.Height / 2;
            DrawBackgroundColor();
            DrawAxle(new PointF(0, centreY+moveY),new PointF(centreX*2,moveY+centreY));
            DrawAxle(new PointF(centreX+moveX, 0), new PointF(centreX+moveX, centreY*2));
            DrawCercle();
            DrawFunc();
            if(drawPointActive) DrawPoint();
            if (zoom != 1.0f)
            {
                DrawScale();
            }
            

            e.Graphics.DrawImageUnscaled(bitmap, Point.Empty);
        }

        private void panelPaint_SizeChanged(object sender, EventArgs e)
        {
            panelPaint.Invalidate();
        }

        private void panelPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveMouse = false;
            }
        }
        private void panelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveMouse = true;
            }
        }

        private void panelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveMouse)
            {
                moveX += e.Location.X - earlyMouseLocation.X;
                moveY+=e.Location.Y - earlyMouseLocation.Y;

                //movePointX += e.Location.X - earlyMouseLocation.X;
                //movePointY += e.Location.Y - earlyMouseLocation.Y;
                panelPaint.Invalidate();
            }
            earlyMouseLocation=e.Location;
        }

        private void DrawPoint()
        {

            PointF[] point = new PointF[2];
            Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(Color.Red);
            float centreX = panelPaint.ClientSize.Width / 2;
            float centreY = panelPaint.ClientSize.Height / 2;

            for (int i=0; i<countPoint;i++)
            {
                graphics.FillEllipse(brush, pointDraw[i].X *zoom + centreX -3 + moveX, -zoom*pointDraw[i].Y + centreY -3 + moveY, 6, 6);
                point[i].X= zoom*pointDraw[i].X + centreX  + moveX;
                point[i].Y= -zoom * pointDraw[i].Y + centreY +  moveY;
            }
            if(countPoint==2)
            {
                graphics.DrawLine(Pens.Red, point[0], point[1]);
                distance = DistanceLength(point[0], point[1]) / (20 * zoom);
                DistanceBarRender();
                //MessageBox.Show((DistanceLength(point[0], point[1])/(20*zoom)).ToString());
            }

        }
        private void DistanceBarRender()
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 11f);
            graphics.DrawString("Расстояние", font, brush, 20, 20);
            graphics.DrawString(distance.ToString("0.0"), font, brush, 20, 40);
        }
        private float DistanceLength(PointF start, PointF end)
        {
            float lenght = 0;
            if(start.X == end.X)
            {
                return Math.Abs(start.Y - end.Y);
            }
            if(start.Y == end.Y)
            {
                return Math.Abs(start.X - end.X);
            }
            else
            {
                lenght = (float)Math.Sqrt(Math.Pow(Math.Abs(start.X - end.X), 2) + Math.Pow(Math.Abs(start.Y - end.Y), 2));
                return lenght;
            }
        }
        private bool PointOnGraf(float xAbsolut,float yAbsolut)
        {
            IFunction func = null;
            switch (grafType)
            {
                case 1:
                    {
                        func = new Parabola();
                        break;
                    }
                case 2:
                    {
                        func = new KubParab();
                        break;
                    }
                case 3:
                    {
                        func = new Straight();
                        break;
                    }
                case 4:
                    {
                        func = new Sin();
                        break;
                    }
                case 5:
                    {
                        func = new Tg();
                        scaleX = 1 / 20.0f;
                        scaleY = 20.0f;
                        
                        break;
                    }
            }

            float centreX = panelPaint.ClientSize.Width / 2;
            float centreY = panelPaint.ClientSize.Height / 2;
            float x=(xAbsolut - centreX-moveX)/zoom;
            float inaccuracy = 10.0f;
            float curX = 0;
            float curY = 0;
            if(grafType == 5)
            {
                inaccuracy = 50.0f;
                //int pointsCount = 0;
                //Tg tg = new Tg();
                //for (float xi = 0; pointsCount < 10000; x += 1f)
                //{
                    
                    
                //    curX = zoom * xi + centreX + moveX + 20.0f * zoom;
                //    curY = moveY + centreY - zoom * tg.Calc(xi / 20.0f) * 20.0f;
                //    if(Math.Abs(xAbsolut-curX)<=inaccuracy && Math.Abs(yAbsolut - curY) <= inaccuracy)
                //    {
                //        return true;
                //    }
                //    pointsCount++;
                //}
                //pointsCount = 0;
                //for (float xi = 0; pointsCount < 10000; x += 1f)
                //{
                    
                    
                //    curX = -xi * zoom + centreX + moveX + 20.0f * zoom;
                //    curY = moveY + centreY - zoom * tg.Calc(-xi / 20.0f) * 20.0f;
                //    if (Math.Abs(xAbsolut - curX) <= inaccuracy && Math.Abs(yAbsolut - curY) <= inaccuracy)
                //    {
                //        return true;
                //    }
                //    pointsCount++;
                //}
                //return false;
            }
            if (Math.Abs(yAbsolut - (centreY + moveY - zoom * scaleY * func.Calc(x * scaleX))) <= inaccuracy)
            {
                //MessageBox.Show(yAbsolut.ToString()+";"+(centreY + moveY - zoom * scaleY * func.Calc(x * scaleX))).ToString();
                currentY = scaleY * func.Calc(x * scaleX);
                return true;
            }
            else
            {
                //MessageBox.Show(yAbsolut.ToString() + ";"+ (centreY + moveY - zoom * scaleY * func.Calc(x * scaleX))).ToString() + ";" + x.ToString());
                return false;
            }

            
         
            
         
        }
        private void panelPaint_MouseClick(object sender, MouseEventArgs e)
        {
            float centreX = panelPaint.ClientSize.Width / 2;

            if (e.Button == MouseButtons.Right)
            {
                if (grafType > 0 && PointOnGraf(e.Location.X, e.Location.Y))
                {
                    drawPointActive = true;
                    countPoint++;
                    if (countPoint > 2)
                    {
                        countPoint = 1;
                        movePointX = 0;
                        movePointY = 0;
                        pointDraw.Clear();
                        pointDraw.Add(new PointF((e.Location.X - centreX - moveX)/zoom, currentY));

                    }
                    else
                    {
                        pointDraw.Add(new PointF((e.Location.X - centreX - moveX) / zoom, currentY));
                    }
                    
                    panelPaint.Invalidate(); 
                }

            }
        }
    }
}
