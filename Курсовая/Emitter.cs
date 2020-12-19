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
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); 
        public List<ParticleColorful> particles = new List<ParticleColorful>();
        public List<List<ParticleColorful>> particlesHistory = new List<List<ParticleColorful>>(40);
        public List<ParticleColorful> particlesRemove = new List<ParticleColorful>();
        public int currentHistoryIndex = 0;
        public bool ifAdd = true; //в первый раз ли достигается последняя граница списка истории
        public float gravitationX = 0;
        public float gravitationY = 0;
        public int particlesCount ;
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public float Speed = 0; // начальная минимальная скорость движения частицы
        public int Size ; // минимальный радиус частицы
        public int Life ; // минимальное время жизни частицы
        public int ParticlesPerTick = 1;
        public long tickRate = 30;
        public long tickCount = 0;
        public int Width; // длина экрана
        public Color ColorFrom = Color.Black; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.White); // конечный цвет частиц
        public string figure ;
        public void UpdateState()
        {
            if (tickCount % tickRate == 0)
            {
                int particlesToCreate = ParticlesPerTick;
                int i = 0;
                
                foreach (var particle in particles)
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }
                    i++;
                    particle.Life--;
                    
                    if (particle.Life < 0)
                    {
                        if (ParticlesPerTick != 0)
                        {
                            ResetParticle(particle);
                            particlesRemove.Add(particle);
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

                        foreach (var point in impactPoints)
                        {
                            point.ImpactParticle(particle);
                        }
                        particle.SpeedX += gravitationX;
                        particle.SpeedY += gravitationY;

                        particle.X += particle.SpeedX;
                        particle.Y += particle.SpeedY;
                    }
                }
                foreach (var particle in particlesRemove)
                {
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
                if (currentHistoryIndex < 39)
                {
                    if (currentHistoryIndex >= particlesHistory.Count)
                    {
                        particlesHistory.Add(new List<ParticleColorful>());
                    }
                    foreach (var particle in particles)
                    {
                        ParticleColorful part = (ParticleColorful)particle.Clone();
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
                        ParticleColorful part = (ParticleColorful)particle.Clone();
                        particlesHistory[currentHistoryIndex].Add(part);
                    }
                }
            }
            tickCount++;
            if (tickCount < 0) tickCount = 0;
        }
        public virtual ParticleColorful CreateParticle()
        {
            var particle = new ParticleColorful();
            switch (figure)
            {
            case "circle":
                {
                    particle = new ParticleCircle();
                    break;
                }
            case "square":
                {
                    particle = new ParticleSquare();
                    break;
                }
            case "star":
                {
                    particle = new ParticleStar();
                    break;
                }
            }
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            return particle;
        }
        // добавил новый метод, виртуальным, чтобы переопределять можно было
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Life;
            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            particle.SpeedX = (int)(Math.Cos(direction / 180 * Math.PI) * Speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * Speed);
            particle.Size =Size;  
        }
        public void Render(Graphics g)
        {
            // ну тут так и быть уж сам впишу...
            // это то же самое что на форме в методе Render
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints) // тут теперь  impactPoints
            {
                point.Render(g); // это добавили
            }
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
