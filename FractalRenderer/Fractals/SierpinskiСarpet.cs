using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

/// <summary>
/// Пространство имён фракталов.
/// </summary>
namespace Fractals
{
    /// <summary>
    /// Класс "Ковёр Серпинского".
    /// <br> Наследник абстрактного класса "Fractal". </br>
    /// </summary>
    class SierpinskiСarpet : Fractal
    {
        /// <summary>
        /// Выбранная пользователем глубина рекурсии.
        /// </summary>
        private readonly int selectedDepth;

        /// <summary>
        /// Конструктор класса "Ковёр Серпинского".
        /// </summary>
        /// <param name="selectedField"> Место отрисовки ковра Серпинского. </param>
        /// <param name="selectedDepthStr"> Выбранная пользователем глубина рекурсии,
        /// переданная в строковом представлении. </param>
        public SierpinskiСarpet(Canvas selectedField, string selectedDepthStr) : base(selectedField)
        {
            try
            {
                selectedDepth = int.Parse(selectedDepthStr);
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
                var polygon = new Polygon();

                // Нахождение точек квадрата.
                var point1 = new Point(startPoint.x1 - 300, startPoint.y1 + 300);
                var point2 = new Point(startPoint.x1 - 300, startPoint.y1 - 300);
                var point3 = new Point(startPoint.x1 + 300, startPoint.y1 - 300);
                var point4 = new Point(startPoint.x1 + 300, startPoint.y1 + 300);

                polygon.Points.Add(point1);
                polygon.Points.Add(point2);
                polygon.Points.Add(point3);
                polygon.Points.Add(point4);

                polygon.Fill = System.Windows.Media.Brushes.Indigo;

                drawningField.Children.Add(polygon);

                Recoursion(point1, point2, point4, 0);
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
        /// <param name="p1"> Левая нижняя точка квадрата. </param>
        /// <param name="p2"> Левая верхняя точка квадрата. </param>
        /// <param name="p3"> Правая нижняя точка квадрата. </param>
        /// <param name="currentDepth"> Текущая глубина рекурсии. </param>
        private void Recoursion(Point p1, Point p2, Point p3, int currentDepth)
        {
            try
            {
                if (currentDepth == selectedDepth)
                    return;

                var polygon = new Polygon();

                // Треть длины по оси X и по оси Y.
                double dx = (p3.X - p1.X) / 3;
                double dy = (p1.Y - p2.Y) / 3;

                // Левая нижняя точка внутреннего квадрата.
                var p5 = new Point(p1.X + dx, p2.Y + dy * 2);
                // Левая верхняя точка внутреннего квадрата.
                var p6 = new Point(p1.X + dx, p2.Y + dy);
                // Правая верхняя точка внутреннего квадрата.
                var p7 = new Point(p1.X + dx * 2, p2.Y + dy);
                // Правая нижняя точка внутреннего квадрата.
                var p8 = new Point(p1.X + dx * 2, p2.Y + dy * 2);

                polygon.Points.Add(p5);
                polygon.Points.Add(p6);
                polygon.Points.Add(p7);
                polygon.Points.Add(p8);

                polygon.Fill = System.Windows.Media.Brushes.White;

                drawningField.Children.Add(polygon);

                Recoursion(p1, new Point(p1.X, p5.Y), new Point(p5.X, p1.Y), currentDepth + 1);
                Recoursion(new Point(p1.X, p5.Y), new Point(p1.X, p6.Y), p5, currentDepth + 1);
                Recoursion(new Point(p1.X, p6.Y), p2, p6, currentDepth + 1);
                Recoursion(p6, new Point(p6.X, p2.Y), p7, currentDepth + 1);
                Recoursion(p7, new Point(p7.X, p2.Y), new Point(p3.X, p7.Y), currentDepth + 1);
                Recoursion(p8, p7, new Point(p3.X, p8.Y), currentDepth + 1);
                Recoursion(new Point(p8.X, p1.Y), p8, p3, currentDepth + 1);
                Recoursion(new Point(p5.X, p1.Y), p5, new Point(p8.X, p1.Y), currentDepth + 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при отрисовке фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }
    }
}
