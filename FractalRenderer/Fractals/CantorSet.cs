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
    /// Класс "Множество Кантора".
    /// <br> Наследник абстрактного класса "Fractal". </br>
    /// </summary>
    class CantorSet : Fractal
    {
        /// <summary>
        /// Выбранная пользователем глубина рекурсии.
        /// </summary>
        private readonly int selectedDepth;

        /// <summary>
        /// Выбранное пользователем расстояние между отрезками.
        /// </summary>
        private int selectedDistance;

        /// <summary>
        /// Левая точка отрезка.
        /// </summary>
        private (int x, int y) leftPoint;

        /// <summary>
        /// Правая точка отрезка.
        /// </summary>
        private (int x, int y) rightPoint;

        /// <summary>
        /// Конструктор класса "Множество Кантора".
        /// </summary>
        /// <param name="selectedField"> Место отрисовки множества Кантора. </param>
        /// <param name="selectedDepthStr"> Выбранная пользователем глубина рекурсии,
        /// переданная в строковом представлении. </param>
        /// <param name="selectedDistanceStr"> Выбранное пользователем расстояние между отрезками,
        /// переданное в строковом представлении. </param>
        public CantorSet(Canvas selectedField, string selectedDepthStr,
                         string selectedDistanceStr) : base(selectedField)
        {
            try
            {
                // Сдвиг точки старта по вертикальной оси вверх.
                startPoint.y1 -= 200;

                (leftPoint.x, leftPoint.y) = (startPoint.x1 - (2 * startPoint.x1 / 3), startPoint.y1);
                (rightPoint.x, rightPoint.y) = (startPoint.x1 + (2 * startPoint.x1 / 3), startPoint.y1);

                selectedDepth = int.Parse(selectedDepthStr);
                selectedDistance = int.Parse(selectedDistanceStr);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при инициализации фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Переопределённый метод отрисовки ковра Серпинского.
        /// </summary>
        public override void Drawning()
        {
            try
            {
                Recoursion(leftPoint.x, leftPoint.y, rightPoint.x, rightPoint.y, selectedDistance, 0);
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
        /// <param name="x1"> Координата X левой точки отрезка. </param>
        /// <param name="y1"> Координата Y левой точки отрезка. </param>
        /// <param name="x2"> Координата X правой точки отрезка. </param>
        /// <param name="y2"> Координата Y правой точки отрезка. </param>
        /// <param name="currentDistance"> Текущее растояние между отрезками. </param>
        /// <param name="currentDepth"> Текущая глубина рекурсии. </param>
        private void Recoursion(int x1, int y1, int x2, int y2, int currentDistance, int currentDepth)
        {
            try
            {
                if (currentDepth == selectedDepth)
                    return;

                var line = new Line();

                (line.X1, line.Y1) = (x1, y1);
                (line.X2, line.Y2) = (x2, y2);

                // Нахождение координат точек новых отрезков, составляющих треть от исходного.
                (int x, int y) A = (x1, y1 + currentDistance);
                (int x, int y) B = (x1 + ((x2 - x1) / 3), y2 + currentDistance);
                (int x, int y) C = (x1 + (2 * (x2 - x1) / 3), y2 + currentDistance);
                (int x, int y) D = (x2, y1 + currentDistance);

                line.StrokeThickness = 15;
                line.Stroke = System.Windows.Media.Brushes.Black;

                drawningField.Children.Add(line);

                Recoursion(A.x, A.y, B.x, B.y, currentDistance, currentDepth + 1);
                Recoursion(C.x, C.y, D.x, D.y, currentDistance, currentDepth + 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при отрисовке фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }
    }
}
