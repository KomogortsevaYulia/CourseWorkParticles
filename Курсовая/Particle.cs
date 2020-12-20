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
        public int X; // X координата положения частицы в пространстве
        public int Y; // Y координата положения частицы в пространстве
        public int SpeedX; // скорость перемещения по оси X
        public int SpeedY; // скорость перемещения по оси Y
        public static Random rand = new Random();
        public float Life; // запас здоровья частицы
        public Color FromColor;
        public Color ToColor;
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
        //отрисовка
        public virtual void Draw(Graphics g){ }
        //отрисовка рамки при выделение мышкой
        public virtual void DrawFrame(Graphics g){ }
        //проверяет попала ли мышка в частицу
        public virtual bool ifMouseInFigure(Graphics g, int xMouse, int yMouse)
        {
            return false;
        }
        //клонирование частиц
        public virtual Particle Clone() {
            ParticleColorful instanse = (ParticleColorful)Activator.CreateInstance(this.GetType());
            instanse.Size = this.Size;
            instanse.SpeedX = this.SpeedX;
            instanse.SpeedY = this.SpeedY;
            instanse.X = this.X;
            instanse.Y = this.Y;
            instanse.Life = this.Life;
            return instanse;
        }
        //вывод информации о них
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
    //наследник класса Particle,окрашивает частицы
    public class ParticleColorful : Particle
    {
        public ParticleColorful() { }
        //клонирование
        public override Particle Clone()
        {
            ParticleColorful instanse = (ParticleColorful)Activator.CreateInstance(this.GetType());
            instanse.Size = this.Size;
            instanse.SpeedX = this.SpeedX;
            instanse.SpeedY = this.SpeedY;
            instanse.X = this.X;
            instanse.Y = this.Y;
            instanse.Life = this.Life;
            instanse.FromColor = this.FromColor;
            instanse.ToColor = this.ToColor;
            return instanse;
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
        //смешивание цветов
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
    //наследник класса ParticleColorful, делает форму частиц кругом
    public class ParticleCircle : ParticleColorful
    {
        //отрисовка кругов
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
        //отрисовка рамки для попадание мышкой в частицу
        public override void DrawFrame(Graphics g)
        {
            g.DrawEllipse(new Pen(Brushes.Black), X - Size,Y - Size,Size * 2,Size * 2);
        }
        //проверяет попала ли мышка в частицу
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
    //наследник класса ParticleColorful, делает форму частиц квадратом
    public class ParticleSquare : ParticleColorful
    {
        //отрисовка квадаратов
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
        //отрисовка рамки для попадание мышкой в частицу
        public override void DrawFrame(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black),X, Y, Size, Size);
        }
        //проверяет попала ли мышка в частицу
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
    //наследник класса ParticleColorful, делает форму частиц звездой
    public class ParticleStar : ParticleColorful
    {
        //отрисовка Звезды
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
        //отрисовка рамки для попадание мышкой в частицу
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
        //проверяет попала ли мышка в частицу
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
    //наследник класса ParticleColorful, делает форму частиц снежинкой
    public class ParticleSnowflake : ParticleColorful
    {
        //толщина линии из которой строится снежинка
        public float thicknessLines;
        //клонирование
        public override Particle Clone()
        {
            ParticleSnowflake instanse = (ParticleSnowflake)Activator.CreateInstance(this.GetType());
            instanse.Size = this.Size;
            instanse.SpeedX = this.SpeedX;
            instanse.SpeedY = this.SpeedY;
            instanse.X = this.X;
            instanse.Y = this.Y;
            instanse.Life = this.Life;
            instanse.FromColor = this.FromColor;
            instanse.ToColor = this.ToColor;
            instanse.thicknessLines = this.thicknessLines;
            return instanse;
        }
        //отрисовка снежинки
        public override void Draw(Graphics g)
        {
            thicknessLines = Size / 15;
            Point[] points ={
                 new Point(X,  Y),new Point(X+Size, Y),
                 new Point(X,  Y),new Point(X-Size,Y),
                 new Point(X,  Y),new Point(X, Y+Size),
                 new Point(X,  Y),new Point(X,  Y-Size),
                 new Point(X,  Y),new Point(X+(Size/2), Y+(Size/2)),
                 new Point(X,  Y),new Point(X-(Size/2),  Y+(Size/2)),
                 new Point(X,  Y),new Point(X+(Size/2),Y-(Size/2)),
                 new Point(X,  Y),new Point(X-(Size/2), Y-(Size/2)),
            };
            float k = Math.Min(1f, Life / 100);
            //Draw lines to screen.
            g.DrawLines(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), points);
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X, Y - (Size / 2)),new Point(X - (Size / 2), Y - Size));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X, Y - (Size / 2)), new Point(X + (Size / 2), Y - Size));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X, Y + (Size / 2)),new Point(X - (Size / 2), Y + Size));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X, Y + (Size / 2)), new Point(X + (Size / 2), Y + Size));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X+ (Size / 2), Y ), new Point(X + Size, Y + (Size/2)));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X + (Size / 2), Y), new Point(X + Size, Y - (Size / 2)));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X - (Size / 2), Y), new Point(X - Size, Y + (Size / 2)));
            g.DrawLine(new Pen(mixColor(ToColor, FromColor, k), thicknessLines), new Point(X - (Size / 2), Y), new Point(X - Size, Y - (Size / 2)));
            g.DrawLine(new Pen(Brushes.Green, thicknessLines), new Point((int)X, (int)Y),new Point((int)(X + (int)SpeedX), (int)(Y + Size )));
        }
        //проверяет попала ли мышка в частицу
        public override bool ifMouseInFigure(Graphics g, int xMouse, int yMouse)
        {
           
            // проверяю, находится ли точка внутри прямоугольника
            if (xMouse <= this.X+Size  && xMouse >= this.X - Size  &&
                yMouse <= this.Y+Size  && yMouse >= this.Y - Size )
            {
                return true;
            }
            return false;
        }
    }
}
