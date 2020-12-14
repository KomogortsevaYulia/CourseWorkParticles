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
        public void check() {
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
                        part.figure = figure;
                        part.rect = rect;
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
                            if (!particle.ifColoredBefore)
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
                if (particle.X >= 0 & particle.X <= width & particle.Y >= 100 & particle.Y <= 140 || particle.ifColoredRed)
                {
                    particle.FromColor = Color.Red;
                    particle.ifColoredRed = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width  & particle.X <=width*2 & particle.Y >= 110 & particle.Y <= 150 || particle.ifColoredOrange)
                {
                    particle.FromColor = Color.Orange;
                    particle.ifColoredOrange = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width*2 & particle.X <= width*3 & particle.Y >= 120 & particle.Y <= 160 || particle.ifColoredYellow)
                    
                {
                    particle.FromColor = Color.Yellow;
                    particle.ifColoredYellow = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width*3 & particle.X <=width*4 & particle.Y >= 130 & particle.Y <= 170 || particle.ifColoredGreen)
                {
                    particle.FromColor = Color.Green;
                    particle.ifColoredGreen = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width*4 & particle.X <= width*5 & particle.Y >= 120 & particle.Y <= 160 || particle.ifColoredDodgerBlue)
                {
                    particle.FromColor = Color.DodgerBlue;
                    particle.ifColoredDodgerBlue = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width*5 & particle.X <= width*6  & particle.Y >= 110 & particle.Y <= 150 || particle.ifColoredBlue)
                {
                    particle.FromColor = Color.Blue;
                    particle.ifColoredBlue = true;
                    particle.ifColoredBefore = true;
                }
                else if (particle.X >= width*6 & particle.X <= width*7 & particle.Y >= 100 & particle.Y <= 140 || particle.ifColoredViolet)
                {
                    particle.FromColor = Color.Violet;
                    particle.ifColoredViolet = true;
                    particle.ifColoredBefore = true;
                }

            }

        }
        public virtual ParticleColorful CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            particle.figure = figure;
            return particle;
        }
        public ParticleColorful createParticleColorful(Particle particle)
        {
            return new ParticleColorful
            {
                Radius = particle.Radius,
                SpeedX = particle.SpeedX,
                SpeedY = particle.SpeedY,
                X = particle.X,
                Y = particle.Y,
                Life = particle.Life,
                figure = particle.figure
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
            if (figure.ToLower().Equals("circle"))
            {
                particle.Radius =Radius;
                
            }
            else if (figure.ToLower().Equals("square"))
            {
                particle.rect =rect;
                
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
                particle.FromColor = ColorFrom;
                particle.ToColor = ColorTo;
                particle.figure = figure;
            }
            
        }
        public Particle ifInCircle()
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
        public Particle ifInSquare()
        {
            foreach (var particle in particles)
            {
                float centerX = particle.X + particle.rect / 2;
                float centerY = particle.Y + particle.rect / 2;
                // проверяю, находится ли точка внутри прямоугольника
                if (X <= centerX + particle.rect /2 && X >= centerX - particle.rect /2 &&
                    Y <= centerY + particle.rect /2 && Y >= centerY - particle.rect/2 )
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
