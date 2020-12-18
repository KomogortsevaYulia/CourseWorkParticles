using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // чтобы использовать Graphics
namespace Курсовая
{
    public abstract class IImpactPoint
    {
        public float width; 
        public float height;
        public float XBegin;
        public float YBegin;
        public int thickness;
        public Color colorSquare;
        // абстрактный метод с помощью которого будем изменять состояние частиц
        public abstract void ImpactParticle(ParticleColorful particle);

        // базовый класс для отрисовки прямоугольников
        public virtual void Render(Graphics g)
        {
            g.DrawRectangle(new Pen(colorSquare, thickness), XBegin , YBegin, width,height);
        }
    }
    public class ColorPoint : IImpactPoint
    {
        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(ParticleColorful particle)
        {
            if (particle.X >= 0 & particle.X <= width & particle.Y >= YBegin & particle.Y <= YBegin+ height)
            {
                particle.FromColor = Color.Red;
            }
            if (particle.X >= width & particle.X <= width*2 & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.Orange;
            }
            if (particle.X >= width*2 & particle.X <=width*3 & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.Yellow;
            }
            if (particle.X >= width*3 & particle.X <= width * 4 & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.Green;
            }
            if (particle.X >= width * 4 & particle.X <= width * 5 & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.DodgerBlue;
            }
            if (particle.X >= width * 5 & particle.X <= width * 6 & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.Blue;
            }
            if (particle.X >= width * 6 & particle.X <= width*7  & particle.Y >= YBegin & particle.Y <= YBegin + height)
            {
                particle.FromColor = Color.Violet;
            }
        } 
    }
}
