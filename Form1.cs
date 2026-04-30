using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        enum ToolType { Line, Rectangle, Circle }

        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;

        private ToolType currentTool = ToolType.Line;
        private Color currentColor = Color.Black;
        private int currentLineWidth = 2;

        private float zoom = 1.0f;

        public Form1()
        {
            InitializeComponent();

            InitCanvas();

            picCanvas.Resize += PicCanvas_Resize;
            picCanvas.MouseWheel += PicCanvas_MouseWheel;
            picCanvas.Focus();

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = 2;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            btnSaveFile.Click += btnSaveFile_Click;
            btnOpenFile.Click += btnOpenFile_Click;

            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
            picCanvas.Paint += PicCanvas_Paint;
        }

        private void InitCanvas()
        {
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);
        }

        // Resize
        private void PicCanvas_Resize(object sender, EventArgs e)
        {
            if (picCanvas.Width <= 0 || picCanvas.Height <= 0) return;

            Bitmap newBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            g.Clear(Color.White);

            if (canvasBitmap != null)
                g.DrawImage(canvasBitmap, 0, 0);

            canvasBitmap = newBitmap;
            canvasGraphics = Graphics.FromImage(canvasBitmap);

            picCanvas.Invalidate();
        }

        // Zoom
        private void PicCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoom *= 1.1f;
            else
                zoom /= 1.1f;

            if (zoom < 0.2f) zoom = 0.2f;
            if (zoom > 5f) zoom = 5f;

            picCanvas.Invalidate();
        }

        // 좌표 보정
        private Point GetScaledPoint(Point p)
        {
            return new Point((int)(p.X / zoom), (int)(p.Y / zoom));
        }

        // 파일 열기
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지 파일 (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);

                canvasBitmap = new Bitmap(img);
                canvasGraphics = Graphics.FromImage(canvasBitmap);

                picCanvas.Invalidate();
            }
        }

        // 저장
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ImageFormat format = ImageFormat.Png;

                if (sfd.FileName.EndsWith(".jpg"))
                    format = ImageFormat.Jpeg;
                else if (sfd.FileName.EndsWith(".bmp"))
                    format = ImageFormat.Bmp;

                canvasBitmap.Save(sfd.FileName, format);
                MessageBox.Show("저장 완료!");
            }
        }

        // 마우스
        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = GetScaledPoint(e.Location);
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = GetScaledPoint(e.Location);
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = GetScaledPoint(e.Location);

            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }

            picCanvas.Invalidate();
        }

        // Paint (?? 핵심)
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(zoom, zoom);

            if (canvasBitmap != null)
                e.Graphics.DrawImage(canvasBitmap, 0, 0);

            if (isDrawing)
            {
                using (Pen pen = new Pen(currentColor, currentLineWidth))
                {
                    pen.DashStyle = DashStyle.Dash;
                    DrawShape(e.Graphics, pen, startPoint, endPoint);
                }
            }
        }

        // 도형
        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);

            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }

        // UI
        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: currentColor = Color.Black; break;
                case 1: currentColor = Color.Red; break;
                case 2: currentColor = Color.Blue; break;
                case 3: currentColor = Color.Green; break;
                default: currentColor = Color.Black; break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }
    }
}