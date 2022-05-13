using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

/// <summary>
/// Пространство имён фракталов.
/// </summary>
namespace Fractals
{
    /// <summary>
    /// Класс "Кривая Коха".
    /// <br> Наследник абстрактного класса "Fractal". </br>
    /// </summary>
    class KochCurve : Fractal
    {
        /// <summary>
        /// Выбранная пользователем глубина рекурсии.
        /// </summary>
        private readonly int selectedDepth;

        /// <summary>
        /// Конструктор класса "Кривая Коха".
        /// </summary>
        /// <param name="selectedField"> Место отрисовки ковра Серпинского. </param>
        /// <param name="selectedDepthStr"> Выбранная пользователем глубина рекурсии,
        /// переданная в строковом представлении. </param>
        public KochCurve(Canvas selectedField, string selectedDepthStr) : base(selectedField)
        {
            try
            {
                selectedDepth = int.Parse(selectedDepthStr);

                // Сдвиг начальной точки по оси Y вниз. 
                startPoint.y1 += 200;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при инициализации фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Переопределённый метод отрисовки кривой Коха.
        /// </summary>
        public override void Drawning()
        {
            try
            {
                var line = new Line();

                (line.X1, line.Y1) = (startPoint.x1 - 650, startPoint.y1);
                (line.X2, line.Y2) = (startPoint.x1 + 650, startPoint.y1);

                line.StrokeThickness = 1;
                line.Stroke = System.Windows.Media.Brushes.Black;

                Recoursion(line.X1, line.Y1, line.X2, line.Y2, 0);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при создании фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Вспомогательный метод рекурсии для метода Drawning.
        /// </summary>
        /// <param name="x1"> координата X первой точки. </param>
        /// <param name="y1"> координата Y первой точки. </param>
        /// <param name="x2"> координата X второй точки. </param>
        /// <param name="y2"> координата Y второй точки. </param>
        /// <param name="currentDepth"> Текущая глубина рекурсии. </param>
        private void Recoursion(double x1, double y1, double x2, double y2, int currentDepth)
        {
            try
            {
                if (currentDepth == selectedDepth)
                {
                    var line = new Line();

                    (line.X1, line.Y1) = (x1, y1);
                    (line.X2, line.Y2) = (x2, y2);

                    line.StrokeThickness = 1;
                    line.Stroke = System.Windows.Media.Brushes.Black;
                    drawningField.Children.Add(line);
                    return;
                }

                double alpha = -Math.Atan2(x2 - x1, y2 - y1);
                double l = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / 3;

                Recoursion(x1, y1, x1 + ((x2 - x1) / 3), y1 + (y2 - y1) / 3, currentDepth + 1);

                Recoursion(x1 + ((x2 - x1) / 3),
                           y1 + ((y2 - y1) / 3),
                         ((x1 + x2) / 2) + (l * Math.Sqrt(3) / 2 * Math.Cos(alpha)),
                         ((y1 + y2) / 2) + (l * Math.Sqrt(3) / 2 * Math.Sin(alpha)),
                           currentDepth + 1);

                Recoursion(((x1 + x2) / 2) + (l * Math.Sqrt(3) / 2 * Math.Cos(alpha)),
                           ((y1 + y2) / 2) + (l * Math.Sqrt(3) / 2 * Math.Sin(alpha)),
                             x1 + ((x2 - x1) * 2 / 3),
                             y1 + ((y2 - y1) * 2 / 3),
                             currentDepth + 1);

                Recoursion(x1 + ((x2 - x1) * 2 / 3), y1 + (y2 - y1) * 2 / 3, x2, y2, currentDepth + 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при отрисовке фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }
    }
}
