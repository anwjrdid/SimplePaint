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
            canvasBitmap = new Bitmap(800, 600); // 기본 캔버스 크기
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            UpdateCanvasSize();
        }

        // ?? 줌
        private void PicCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoom *= 1.1f;
            else
                zoom /= 1.1f;

            if (zoom < 0.2f) zoom = 0.2f;
            if (zoom > 5f) zoom = 5f;

            UpdateCanvasSize();
        }

        // ?? PictureBox 크기 변경 (핵심)
        private void UpdateCanvasSize()
        {
            if (canvasBitmap == null) return;

            picCanvas.Width = (int)(canvasBitmap.Width * zoom);
            picCanvas.Height = (int)(canvasBitmap.Height * zoom);

            picCanvas.Invalidate();
        }

        // 좌표 변환
        private Point ToImage(Point p)
        {
            return new Point((int)(p.X / zoom), (int)(p.Y / zoom));
        }

        private Point ToScreen(Point p)
        {
            return new Point((int)(p.X * zoom), (int)(p.Y * zoom));
        }

        // 파일 열기
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지 (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);

                canvasBitmap = new Bitmap(img);
                canvasGraphics = Graphics.FromImage(canvasBitmap);

                zoom = 1.0f;
                UpdateCanvasSize();
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

                if (sfd.FileName.EndsWith(".jpg")) format = ImageFormat.Jpeg;
                else if (sfd.FileName.EndsWith(".bmp")) format = ImageFormat.Bmp;

                canvasBitmap.Save(sfd.FileName, format);
                MessageBox.Show("저장 완료!");
            }
        }

        // 마우스
        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = ToImage(e.Location);
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            endPoint = ToImage(e.Location);
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            endPoint = ToImage(e.Location);

            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }

            picCanvas.Invalidate();
        }

        // Paint
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (canvasBitmap != null)
            {
                e.Graphics.DrawImage(canvasBitmap, 0, 0, picCanvas.Width, picCanvas.Height);
            }

            if (isDrawing)
            {
                using (Pen pen = new Pen(currentColor, currentLineWidth))
                {
                    pen.DashStyle = DashStyle.Dash;

                    DrawShape(
                        e.Graphics,
                        pen,
                        ToScreen(startPoint),
                        ToScreen(endPoint)
                    );
                }
            }
        }

        // 도형
        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );

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
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }
    }
}