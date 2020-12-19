using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // чтобы использовать Graphics

namespace Курсовая
{
    public class Particle
    {
        public int Size; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public static Random rand = new Random();
        public float Life; // запас здоровья частицы

        public Particle()
        {
            // генерируем произвольное направление и скорость
            var direction = (double)rand.Next(360);
            Size = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }
        public Particle(Particle particle)
        {
            this.X = particle.X;
            this.Y = particle.Y;
            this.SpeedX = particle.SpeedX;
            this.SpeedY = particle.SpeedY;
            this.Life = particle.Life;
            this.Size = particle.Size;
        }
        public virtual void Draw(Graphics g){ }
        public virtual void DrawFrame(Graphics g){ }
        public virtual bool ifMouseInFigure(Graphics g, int xMouse, int yMouse)
        {
            return false;
        }
        public virtual Particle Clone() {
            return new Particle { 
                Size=this.Size,
                SpeedX=this.SpeedX,
                SpeedY=this.SpeedY,
                X=this.X,
                Y=this.Y,
                Life=this.Life
            };
        }
        public void ShowInfo(Graphics g)
        {
            g.FillRectangle(
                    new SolidBrush(Color.FromArgb(125, Color.White)),
                    this.X,
                    this.Y - this.Size,
                    60,
                    50
                    );
            g.DrawString(
                $"X : {this.X}\n" +
                $"Y : {this.Y}\n" +
                $"Life : {this.Life}",
                new Font("Verdana", 10),
                new SolidBrush(Color.Black),
                this.X,
                this.Y - this.Size
                );
        }
    }
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        public ParticleColorful() { }
        public override Particle Clone()
        {
            return new ParticleColorful
            {
                Size = this.Size,
                SpeedX = this.SpeedX,
                SpeedY = this.SpeedY,
                X = this.X,
                Y = this.Y,
                Life = this.Life,
                ToColor=this.ToColor,
                FromColor=this.FromColor
            };
        }
        public ParticleColorful(ParticleColorful particleColorful)
        {
            this.X = particleColorful.X;
            this.Y = particleColorful.Y;
            this.Size = particleColorful.Size;
            this.SpeedX = particleColorful.SpeedX;
            this.SpeedY = particleColorful.SpeedY;
            this.Life = particleColorful.Life;
            this.FromColor = particleColorful.FromColor;
            this.ToColor = particleColorful.ToColor;
        }
        public static Color mixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1 - k)),
                    (int)(color2.R * k + color1.R * (1 - k)),
                    (int)(color2.G * k + color1.G * (1 - k)),
                    (int)(color2.B * k + color1.B * (1 - k))
                );
        }
    }
    public class ParticleCircle : ParticleColorful
    {
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            var color = mixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Size, Y - Size, Size * 2, Size * 2);
            b.Dispose();
            g.DrawLine(new Pen(Brushes.Green), new Point((int)X, (int)Y),
                new Point((int)(X + (int)SpeedX),
                (int)(Y + Size / 4 * 3)));
        }
        public override void DrawFrame(Graphics g)
        {
            g.DrawEllipse(new Pen(Brushes.Black), X - Size,Y - Size,Size * 2,Size * 2);
        }
        public override bool ifMouseInFigure(Graphics g,int xMouse,int yMouse)
        {
            float gX = xMouse - this.X;
            float gY = yMouse - this.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + this.Size <= this.Size * 2 || r + this.Size <= this.Size * 2) // если частица оказалось внутри эллипса
            {
                return true;
            }
            return false;
        }
    }
    public class ParticleSquare : ParticleColorful
    {
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            var color = mixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            g.FillRectangle(b, X, Y, Size, Size);
            b.Dispose();
            g.DrawLine(new Pen(Brushes.Green), new Point((int)(X + Size / 2), (int)(Y + Size / 2)),
               new Point((int)(X + Size / 2 + (int)SpeedX),
               (int)(Y + Size / 4 * 3)));
        }
        public override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black),X, Y, Size, Size);
        }
        public override bool ifMouseInFigure(Graphics g, int xMouse, int yMouse)
        {
            float centerX = this.X + this.Size / 2;
            float centerY = this.Y + this.Size / 2;
            // проверяю, находится ли точка внутри прямоугольника
            if (xMouse <= centerX + this.Size / 2 && xMouse >= centerX - this.Size / 2 &&
                yMouse <= centerY + this.Size / 2 && yMouse >= centerY - this.Size / 2)
            {
                return true;
            }
            return false;
        }
    }
    public class ParticleStar : ParticleColorful
    {
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            var color = mixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);
            PointF[] points = new PointF[2 * 5 + 1];
            double a = 0, da = Math.PI / 5, l;
            for (int k1 = 0; k1 < 2 * 5 + 1; k1++)
            {
                l = k1 % 2 == 0 ? Size * 2 : Size;
                points[k1] = new PointF((float)(X + l * Math.Cos(a)), (float)(Y + l * Math.Sin(a)));
                a += da;
            }
            g.FillPolygon(b, points);
            b.Dispose();
            g.DrawLine(new Pen(Brushes.Green), new Point((int)X, (int)Y),
               new Point((int)(X + (int)SpeedX),
               (int)(Y + Size / 4 * 3)));
        }
        public override void DrawFrame(Graphics g)
        {
            double alpha = 0;        // поворот
            PointF[] points = new PointF[2 * 5 + 1];
            double a = alpha, da = Math.PI / 5, l;
            for (int k = 0; k < 2 * 5 + 1; k++)
            {
                l = k % 2 == 0 ? this.Size * 2 : this.Size;
                points[k] = new PointF((float)(this.X + l * Math.Cos(a)), (float)(this.Y + l * Math.Sin(a)));
                a += da;
            }
            g.DrawLines(Pens.Black, points);
        }
        public override bool ifMouseInFigure(Graphics g, int xMouse, int yMouse)
        {
            float gX = xMouse - this.X;
            float gY = yMouse - this.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + this.Size <= this.Size * 2 || r + this.Size <= this.Size * 2) // если частица оказалось внутри эллипса
            {
                return true;
            }
            return false;
        }
    }
}
