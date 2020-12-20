using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        Emitter emitter;
        public Color colorPicture=Color.White;
        bool ifRun = true;
        bool stepPermission = false;
        int xMouse;
        int yMouse;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            // а тут теперь вручную создаем
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                gravitationY = 5
            };
            //задаем начальные значения частиц исходя из начальных значений трекбаров
            emitter.Size = tbSize.Value * 5;
            emitter.Life = 10 * tbLife.Value;
            emitter.ParticlesPerTick = tbNumber.Value;
            emitter.figure = "circle";
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //если пользователь задал скорость больше 0
            if ((tbSpeed.Value != 0 && ifRun) || stepPermission)
            {
                //то выполняем остальное
                emitter.UpdateState();
            }
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(colorPicture);
                emitter.Render(g);
                foreach (var particle in emitter.particles)
                {
                    if (particle.ifMouseInFigure(g, xMouse ,yMouse))
                    {
                        //если мышка попала в частицу,то рисуем рамку вокруг частицы и выводим информацию
                        particle.DrawFrame(g);
                        particle.ShowInfo(g);
                    }
                }
            }
            picDisplay.Invalidate();
            stepPermission = false;
        }
        //количество тиков
        private void ChangeTick()
        {
            switch (tbSpeed.Value)
            {
                case 0:
                    ifRun = false;
                    break;
                case 1:
                    emitter.tickRate = 30;
                    break;
                case 2:
                    emitter.tickRate = 25;
                    break;
                case 3:
                    emitter.tickRate = 20;
                    break;
                case 4:
                    emitter.tickRate = 15;
                    break;
                case 5:
                    emitter.tickRate = 10;
                    break;
                case 6:
                    emitter.tickRate = 7;
                    break;
                case 7:
                    emitter.tickRate = 5;
                    break;
                case 8:
                    emitter.tickRate = 3;
                    break;
                case 9:
                    emitter.tickRate = 2;
                    break;
                case 10:
                    emitter.tickRate = 1;
                    break;
            }
        }

        //кнопочки 
        private void Start_Click(object sender, EventArgs e)
        {
            ifRun = true;
            ChangeTick();
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            ifRun = false;
        }
        private void Step_Click(object sender, EventArgs e)
        {
            ifRun = false;
            if (emitter.currentHistoryIndex < emitter.particlesHistory.Count - 1 && emitter.currentHistoryIndex != 19)
            {
                //поставить значения дальше по списку
                emitter.particles.RemoveRange(0, emitter.particles.Count);
                foreach (ParticleColorful particle in emitter.particlesHistory[emitter.currentHistoryIndex + 1])
                {
                    ParticleColorful part = (ParticleColorful)particle.Clone();
                    emitter.particles.Add(part);
                }
                emitter.currentHistoryIndex++;
            }
            else
            {
                emitter.tickCount += (emitter.tickRate - emitter.tickCount % emitter.tickRate);
                stepPermission = true;
            }
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            xMouse = e.X;
            yMouse = e.Y;
        }
        private void StepBack_Click(object sender, EventArgs e)
        {
            ifRun = false;
            if (emitter.currentHistoryIndex >= 1)
            {
                //вернуться на значения из списка
                emitter.particles.RemoveRange(0, emitter.particles.Count);
                foreach (ParticleColorful particle in emitter.particlesHistory[emitter.currentHistoryIndex - 1])
                {
                    ParticleColorful part = (ParticleColorful)particle.Clone();
                    emitter.particles.Add(part);
                }
                emitter.currentHistoryIndex--;
            }
        }
        private void tbSpeed_ValueChanged(object sender, EventArgs e)
        {
            ifRun = true;
            ChangeTick();
        }
        private void tbNumber_Scroll_1(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick =  tbNumber.Value;
        }
        private void tbSize_Scroll(object sender, EventArgs e)
        {
            emitter.Size = 5 * tbSize.Value;
        }
        //рандомный цвет частиц
        private void RandomColorParticles_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int R = random.Next(255);
            int G = random.Next(255);
            int B = random.Next(255);
            emitter.ColorFrom = Color.FromArgb(R, G, B);
            emitter.ColorTo = colorPicture;
        }
        //рандомный цвет фона
        private void RandomColorPictures_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int R = random.Next(255);
            int G = random.Next(255);
            int B = random.Next(255);
            var g = Graphics.FromImage(picDisplay.Image);
            colorPicture = Color.FromArgb(R, G, B);
            emitter.ColorTo = colorPicture;
        }
        //Выбрать цвет частиц
        private void ColorParticles_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.Color = emitter.ColorFrom;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                emitter.ColorFrom = MyDialog.Color;
            emitter.ColorTo = colorPicture;
        }
        //Выбрать цвет фона
        private void ColorPictures_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.Color = colorPicture;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorPicture = MyDialog.Color;
            emitter.ColorTo = colorPicture;

        }
        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //комбобокс-для формы частиц
            switch (cmbForm.Text)
            {
                case "Круг":
                    emitter.figure = "circle";
                    break;
                case "Квадрат":
                    emitter.figure = "square";
                    break;
                case "Звезда":
                    emitter.figure = "star";
                    break;
                case "Снежинки":
                    emitter.figure = "snowflake";
                    break;
            }
            //очистка всех списков,сверка количества
            emitter.particles.Clear();
            emitter.particlesHistory.Clear();
            emitter.currentHistoryIndex = 0;
            tbNumber_Scroll_1(sender, e);
        }
        private void tbLife_Scroll(object sender, EventArgs e)
        {
            emitter.Life =10* tbLife.Value;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //комбобокс-для режима работы
            switch (comboBox1.Text) {
            case "Простой":
                {
                        //отключение влияния точек-окрашивателей
                    emitter.impactPoints.Clear();
                }
                break;
            case "Окрашивание":
                {
                        //создание точек-окрашивателей
                    float w = picDisplay.Width / 7;
                    emitter.impactPoints.Add(new ColorPoint
                    { 
                        colorSquare=Color.Red,
                        thickness=4,
                        XBegin=0,
                        YBegin=100,
                        height=40,
                        width=w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.Orange,
                        thickness = 4,
                        XBegin = w+4,
                        YBegin = 100,
                        height = 40,
                        width =w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.Yellow,
                        thickness = 4,
                        XBegin = w*2+4,
                        YBegin = 100,
                        height = 40,
                        width = w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.Green,
                        thickness = 4,
                        XBegin = w*3+4,
                        YBegin = 100,
                        height = 40,
                        width = w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.DodgerBlue,
                        thickness = 4,
                        XBegin  = w*4+4,
                        YBegin = 100,
                        height = 40,
                        width = w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.Blue,
                        thickness = 4,
                        XBegin = w*5+4,
                        YBegin = 100,
                        height = 40,
                        width = w
                    });
                    emitter.impactPoints.Add(new ColorPoint
                    {
                        colorSquare = Color.Violet,
                        thickness = 4,
                        XBegin = w*6+4,
                        YBegin = 100,
                        height = 40,
                        width = w
                    });
                }
                break;            
            }
        }
    }
}
