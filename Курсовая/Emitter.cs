using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // чтобы использовать Graphics
namespace Курсовая
{
    public class Emitter
    {
        public List<ParticleColorful> particles = new List<ParticleColorful>();
        public List<List<ParticleColorful>> particlesHistory = new List<List<ParticleColorful>>(20);
        public List<ParticleColorful> particlesRemove = new List<ParticleColorful>();
        public int currentHistoryIndex = 0;
        public bool ifAdd = true; //в первый раз ли достигается последняя граница списка истории
        public float gravitationX = 0;
        public float gravitationY = 0;
        public int particlesCount = 0;
        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public float Speed = 0; // начальная минимальная скорость движения частицы
        public int Radius = 15; // минимальный радиус частицы
        public int LifeMin = 30; // минимальное время жизни частицы
        public int LifeMax = 50; // максимальное время жизни частицы
        public int ParticlesPerTick = 1;
        public long tickRate = 30;
        public long tickCount = 0;
        public int Width; // длина экрана
        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц
        public int rect = 50; // значения сторон квадрата
        public string figure = "circle"; // показывает, какая сейчас фигура
        public bool ifColor = false;
        public void removeList() {
            particles.Clear();
            particlesHistory.Clear();
            currentHistoryIndex = 0;
        }
        public void UpdateState()
        {
            if (tickCount % tickRate == 0)
            {
                if (currentHistoryIndex != 19 && currentHistoryIndex < particlesHistory.Count - 1)
                {
                    //поставить значения дальше по списку
                    particles.RemoveRange(0, particles.Count);
                    foreach (ParticleColorful particle in particlesHistory[currentHistoryIndex + 1])
                    {
                        ParticleColorful part = new ParticleColorful(particle);
                        part.FromColor = ColorFrom;
                        part.ToColor = ColorTo;
                        part.Form = figure;
                        part.size = rect;
                        part.Radius = Radius;
                        particles.Add(part);
                    }
                    currentHistoryIndex++;
                    tickCount++;
                    return;
                }

                int particlesToCreate = ParticlesPerTick;
                int i = 0;
                foreach (var particle in particles)
                {
                    i++;
                    particle.Life--;
                    if (particle.Life < 0)
                    {
                        if (ParticlesPerTick != 0)
                        {
                            ResetParticle(particle);
                            if (!particle.ifColorBefore)
                            {
                                particle.FromColor = ColorFrom;
                                particle.ToColor = ColorTo;
                            }
                            else
                            {
                                particlesRemove.Add(particle);
                            }
                        }
                        else
                        {
                            particlesRemove.Add(particle);
                        }
                        if (i % 3 == 0  ) {
                            particlesRemove.Add(particle);
                        }
                    }
                    else
                    {
                        particle.SpeedX += gravitationX;
                        particle.SpeedY += gravitationY;

                        particle.X += particle.SpeedX;
                        particle.Y += particle.SpeedY;
                    }

                }
                foreach (var particle in particlesRemove) {
                    particles.Remove(particle);
                }
                particlesRemove.Clear();
                while (particlesToCreate >= 1)
                {
                    particlesToCreate -= 1;
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }

                if (currentHistoryIndex < 19)
                {
                    if (currentHistoryIndex >= particlesHistory.Count)
                    {
                        particlesHistory.Add(new List<ParticleColorful>());
                    }
                    foreach (var particle in particles)
                    {
                        ParticleColorful part = createParticleColorful(particle);
                        particlesHistory[currentHistoryIndex].Add(part);
                    }
                    currentHistoryIndex++;
                    ifAdd = true;
                    
                }
                else
                {
                    if (!ifAdd) particlesHistory.RemoveAt(0);
                    ifAdd = false;
                    particlesHistory.Add(new List<ParticleColorful>());
                    foreach (var particle in particles)
                    {
                        ParticleColorful part = createParticleColorful(particle);
                        particlesHistory[currentHistoryIndex].Add(part);
                    }
                }
            }
            tickCount++;
            if (tickCount < 0) tickCount = 0;
        }
        public void MakeColor(int width)
        {
            width = width / 7;
            foreach (var particle in particles)
            {
                if (particle.X >= 0 & particle.X <= width & particle.Y >= 100 & particle.Y <= 140 || particle.ifColorRed)
                {
                    particle.FromColor = Color.Red;
                    ColorFrom = Color.Red;
                    particle.ifColorRed = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width & particle.X <= width * 2 & particle.Y >= 110 & particle.Y <= 150 || particle.ifColorOrange)
                {
                    particle.FromColor = Color.Orange;
                    ColorFrom = Color.Orange;
                    particle.ifColorOrange = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width * 2 & particle.X <= width * 3 & particle.Y >= 120 & particle.Y <= 160 || particle.ifColorYellow)

                {
                    particle.FromColor = Color.Yellow;
                    ColorFrom = Color.Yellow;
                    particle.ifColorYellow = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width * 3 & particle.X <= width * 4 & particle.Y >= 130 & particle.Y <= 170 || particle.ifColorGreen)
                {
                    particle.FromColor = Color.Green;
                    ColorFrom = Color.Green;
                    particle.ifColorGreen = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width * 4 & particle.X <= width * 5 & particle.Y >= 120 & particle.Y <= 160 || particle.ifColorDodgerBlue)
                {
                    particle.FromColor = Color.DodgerBlue;
                    ColorFrom = Color.DodgerBlue;
                    particle.ifColorDodgerBlue = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width * 5 & particle.X <= width * 6 & particle.Y >= 110 & particle.Y <= 150 || particle.ifColorBlue)
                {
                    particle.FromColor = Color.Blue;
                    ColorFrom = Color.Blue;
                    particle.ifColorBlue = true;
                    particle.ifColorBefore = true;
                }
                else if (particle.X >= width * 6 & particle.X <= width * 7 & particle.Y >= 100 & particle.Y <= 140 || particle.ifColorViolet)
                {
                    particle.FromColor = Color.Violet;
                    ColorFrom = Color.Violet;
                    particle.ifColorViolet = true;
                    particle.ifColorBefore = true;
                }
                else ColorFrom = Color.White;
            }

        }
        public virtual ParticleColorful CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            particle.Form = figure;
            return particle;
        }
        public ParticleColorful createParticleColorful(Particle particle)
        {
            Color to, from;
            if (particle.ifColorBefore)
            {
                from = ColorFrom;
                to = ColorFrom;
            }
            else
            {
                from = ColorFrom;
                to = ColorTo;
            }
            return new ParticleColorful
            {
                Radius = particle.Radius,
                SpeedX = particle.SpeedX,
                SpeedY = particle.SpeedY,
                X = particle.X,
                Y = particle.Y,
                Life = particle.Life,
                Form = particle.Form,
                FromColor = from,
                ToColor = to
            };
        }
        // добавил новый метод, виртуальным, чтобы переопределять можно было
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;

            particle.SpeedX = (int)(Math.Cos(direction / 180 * Math.PI) * Speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * Speed);

            
            // задаю размеры в зависимости от текущей фигуры
            if (figure.ToLower().Equals("circle")|| figure.ToLower().Equals("star"))
            {
                particle.Radius =Radius;
                
            }
            else if (figure.ToLower().Equals("square"))
            {
                particle.size =rect;
                
            }
        }
        public void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);
                if (particle is ParticleColorful) ((ParticleColorful)particle).drawSpeedVectors(g);
                if (particle.ifColorBefore)
                {
                    particle.FromColor = ColorFrom;
                    particle.ToColor = ColorFrom;
                }
                else
                {
                    particle.FromColor = ColorFrom;
                    particle.ToColor = ColorTo;
                }
                particle.Form = figure;
            }
            
        }
        public Particle ifMouseInCircle()
        {
            foreach (var particle in particles)
            {
                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
                if (r + particle.Radius <= particle.Radius * 2 || r + particle.Radius <= particle.Radius * 2) // если частица оказалось внутри эллипса
                {
                    return particle;
                }
            }
            return null;
        }
        public Particle ifMouseInSquare()
        {
            foreach (var particle in particles)
            {
                float centerX = particle.X + particle.size / 2;
                float centerY = particle.Y + particle.size / 2;
                // проверяю, находится ли точка внутри прямоугольника
                if (X <= centerX + particle.size /2 && X >= centerX - particle.size /2 &&
                    Y <= centerY + particle.size /2 && Y >= centerY - particle.size/2 )
                {
                    return particle;
                }
            }
            return null;
        }
        public Particle ifMouseInStar()
        {
            foreach (var particle in particles)
            {
                float centerX = particle.X + particle.size / 2;
                float centerY = particle.Y + particle.size / 2;
                // проверяю, находится ли точка внутри прямоугольника
                if (X <= centerX + particle.size / 2 && X >= centerX - particle.size / 2 &&
                    Y <= centerY + particle.size / 2 && Y >= centerY - particle.size / 2)
                {
                    return particle;
                }
            }
            return null;
        }
    }
    public class TopEmitter : Emitter
    {
        public int Width; // длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое

            // а теперь тут уже подкручиваем параметры движения
            particle.X = Particle.rand.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;  // ноль -- это верх экрана 

            particle.SpeedY = 1; // падаем вниз по умолчанию
            particle.SpeedX = Particle.rand.Next(-10, 10); // разброс влево и вправа у частиц 
        }
    }
}
