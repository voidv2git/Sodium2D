using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Sodium
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class GameEngine
    {
        public static Vector ScreenSize = new Vector(500, 500);
        public string Title = "";
        public static double deltaTime;
        public static Canvas Window = null;
        private Thread GameLoopThread = null;
        public static List<Shape> RenderStack = new List<Shape>();

        public enum Type
        {
            Square,Sprite
        };
        
        public GameEngine(Vector Screensize, string title)
        {
            ScreenSize = Screensize;
            this.Title = title;
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.SetApartmentState(ApartmentState.STA);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        public static void RegisterShape(Shape s)
        {
            if (s != null)
            {
                RenderStack.Add(s);
            }
        }

        public static List<Shape> GetShapes(string tag)
        {
            List<Shape> found = new List<Shape>();
            foreach (Shape s in RenderStack)
            {
                if (s.Tag == tag)
                {
                    found.Add(s);
                }
            }
            return found;
        }

        void GameLoop()
        {
            OnLoad();
            while (true)
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Thread.Sleep(1);
                    sw.Stop();
                    deltaTime = sw.Elapsed.TotalSeconds;
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                }
                catch (Exception) { }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            List<Shape> Render = new List<Shape>(RenderStack);
            foreach (Shape s in Render)
            {
                if (s.type == Type.Square)
                {
                    g.FillRectangle(new SolidBrush(s.color), (int)s.Position.X, (int)s.Position.Y, (int)s.Scale.X, (int)s.Scale.Y);
                }
                else if (s.type == Type.Sprite)
                {
                    g.DrawImageUnscaledAndClipped(s.image, new Rectangle((int)s.Position.X, (int)s.Position.Y, (int)s.Scale.X, (int)s.Scale.Y));
                }
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
