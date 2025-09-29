using Microsoft.Maui.Graphics;

namespace Yukki.Drawables
{
    public class WaveDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.LightGray;

            var path = new PathF();
            path.MoveTo(0, 120);

            // Curva Bézier cúbica
            path.CurveTo(
                dirtyRect.Width * 0.35f, 70,
                dirtyRect.Width * 0.60f, 220,
                dirtyRect.Width, 100
            );

            // Fecha área
            path.LineTo(dirtyRect.Width, dirtyRect.Height);
            path.LineTo(0, dirtyRect.Height);
            path.Close();

            canvas.FillPath(path);
        }
    }
}
