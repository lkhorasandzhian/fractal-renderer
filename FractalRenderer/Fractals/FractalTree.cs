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
    /// Класс "Фрактальное Дерево".
    /// <br> Наследник абстрактного класса "Fractal". </br>
    /// </summary>
    class FractalTree : Fractal
    {
        /// <summary>
        /// Выбранная пользователем глубина рекурсии.
        /// </summary>
        private readonly int selectedDepth;

        /// <summary>
        /// Выбранное пользователем отношение длин отрезков между итерациями.
        /// </summary>
        private double segmentRatio;

        /// <summary>
        /// Угол наклона влево.
        /// </summary>
        private double tilt1;

        /// <summary>
        /// Угол наклона вправо.
        /// </summary>
        private double tilt2;

        /// <summary>
        /// Фиксированная начальная длина отрезка.
        /// </summary>
        private const double fixedLength = 120;

        /// <summary>
        /// Фиксированный начальный угол отрезка.
        /// </summary>
        private const double startAngle = -Math.PI / 2;

        /// <summary>
        /// Конструктор класса "Фрактальное Дерево".
        /// </summary>
        /// <param name="selectedField"> Место отрисовки ковра Серпинского. </param>
        /// <param name="selectedDepthStr"> Выбранная пользователем глубина рекурсии,
        /// переданная в строковом представлении. </param>
        /// <param name="segmentRatioStr"> Выбранное пользователем отношение отрезков,
        /// переданное в строковом представлении. </param>
        /// <param name="tilt1"> Выбранный пользователем угол наклона влево. </param>
        /// <param name="tilt2"> Выбранный пользователем угол наклона вправо. </param>
        public FractalTree(Canvas selectedField, string selectedDepthStr, string segmentRatioStr,
                           double tilt1, double tilt2) : base(selectedField)
        {
            try
            {
                // Сдвиг точки старта по вертикальной оси вниз.
                startPoint.y1 += 150;

                selectedDepth = int.Parse(selectedDepthStr);

                switch (segmentRatioStr)
                {
                    case "3 : 5":
                        segmentRatio = (double)3 / 5;
                        break;
                    case "3 : 4":
                        segmentRatio = (double)3 / 4;
                        break;
                    case "4 : 5":
                        segmentRatio = (double)4 / 5;
                        break;
                }

                this.tilt1 = tilt1;
                this.tilt2 = tilt2;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при инициализации фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Переопределённый метод отрисовки фрактального дерева.
        /// </summary>
        public override void Drawning()
        {
            try
            {
                var firstLine = new Line();
                (firstLine.X1, firstLine.Y1) = (startPoint.x1, startPoint.y1);
                (firstLine.X2, firstLine.Y2) = (startPoint.x1, startPoint.y1 + 200);
                firstLine.StrokeThickness = 5;
                firstLine.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(firstLine);
                Recoursion(startPoint.x1, startPoint.y1, fixedLength, 0, startAngle);
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
        /// <param name="x"> Координата X начальной точки. </param>
        /// <param name="y"> Координата Y начальной точки. </param>
        /// <param name="length"> Длина отрезка. </param>
        /// <param name="currentDepth"> Текущая глубина рекурсии. </param>
        /// <param name="currentAngle"> Текущий угол. </param>
        private void Recoursion(double x, double y, double length, int currentDepth, double currentAngle)
        {
            try
            {
                if (currentDepth == selectedDepth)
                    return;

                var line1 = new Line();
                var line2 = new Line();

                (double x1, double y1) = (x + (length * Math.Cos(currentAngle - tilt1)), y + (length * Math.Sin(currentAngle - tilt1)));
                (double x2, double y2) = (x + (length * Math.Cos(currentAngle + tilt2)), y + (length * Math.Sin(currentAngle + tilt2)));

                (line1.X1, line1.Y1) = (x, y);
                (line1.X2, line1.Y2) = (x1, y1);
                (line2.X1, line2.Y1) = (x, y);
                (line2.X2, line2.Y2) = (x2, y2);

                line1.StrokeThickness = 5;
                line2.StrokeThickness = 5;
                line1.Stroke = System.Windows.Media.Brushes.Black;
                line2.Stroke = System.Windows.Media.Brushes.Black;

                drawningField.Visibility = System.Windows.Visibility.Visible;

                drawningField.Children.Add(line1);
                drawningField.Children.Add(line2);

                Recoursion(x1, y1, length * segmentRatio, currentDepth + 1, currentAngle - tilt1);
                Recoursion(x2, y2, length * segmentRatio, currentDepth + 1, currentAngle + tilt2);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при отрисовке фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }
    }
}
