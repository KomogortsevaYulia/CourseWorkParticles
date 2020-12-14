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
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public string figure = "square";
        public int rect; // ширина прямоугольника
        // добавили генератор случайных чисел
        public static Random rand = new Random();

        public float Life; // запас здоровья частицы
        public Particle()
        {
            // генерируем произвольное направление и скорость
            var direction = (double)rand.Next(360);

            rect =20+ rand.Next(100);
            // а это не трогаем
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }
        public Particle(Particle particle)
        {
            this.X = particle.X;
            this.Y = particle.Y;
            this.Radius = particle.Radius;
            this.SpeedX = particle.SpeedX;
            this.SpeedY = particle.SpeedY;
            this.Life = particle.Life;
            this.rect = particle.rect;
            this.figure = particle.figure;
        }
        public virtual void Draw(Graphics g)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            // рассчитываем значение альфа канала в шкале от 0 до 255
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);

            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            if (figure.ToLower().Equals("circle")) g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            else if (figure.ToLower().Equals("square")) g.FillRectangle(b, X, Y, rect, rect);

            b.Dispose();
        }
        
    }
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        public ParticleColorful() { }

        public ParticleColorful(ParticleColorful particleColorful)
        {
            this.X = particleColorful.X;
            this.Y = particleColorful.Y;
            this.Radius = particleColorful.Radius;
            this.rect = particleColorful.rect;
            this.SpeedX = particleColorful.SpeedX;
            this.SpeedY = particleColorful.SpeedY;
            this.Life = particleColorful.Life;
            this.FromColor = particleColorful.FromColor;
            this.ToColor = particleColorful.ToColor;
            this.figure = particleColorful.figure;
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

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            var color = mixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            if (figure.ToLower().Equals("circle")) g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            else if (figure.ToLower().Equals("square")) g.FillRectangle(b, X, Y, rect, rect);

            b.Dispose();
        }

        public void drawSpeedVectors(Graphics g)
        {
            int deviation = (int)SpeedX;

            Pen pen = new Pen(Brushes.Green);
            if (figure.ToLower().Equals("circle"))
            {
                g.DrawLine(pen, new Point((int)X, (int)Y),
                new Point((int)(X + deviation),
                (int)(Y + Radius / 4 * 3)));
            }
            else if (figure.ToLower().Equals("square"))
            {
                g.DrawLine(pen, new Point((int)(X + rect / 2), (int)(Y + rect / 2)),
                new Point((int)(X+ rect / 2 + deviation),
                (int)(Y+ rect / 4 * 3)));
            }
            pen.Dispose();
        }
    }
}
