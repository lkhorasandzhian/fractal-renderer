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
    /// Класс "Треугольник Серпинского".
    /// <br> Наследник абстрактного класса "Fractal". </br>
    /// </summary>
    class SierpinskiTriangle : Fractal
    {
        /// <summary>
        /// Выбранная пользователем глубина рекурсии.
        /// </summary>
        private readonly int selectedDepth;

        /// <summary>
        /// Точка A равностороннего треугольника ABC.
        /// </summary>
        private (int x, int y) A;

        /// <summary>
        /// Точка B равностороннего треугольника ABC.
        /// </summary>
        private (int x, int y) B;

        /// <summary>
        /// Точка C равностороннего треугольника ABC.
        /// </summary>
        private (int x, int y) C;

        /// <summary>
        /// Конструктор класса "Треугольник Серпинского".
        /// </summary>
        /// <param name="selectedField"> Место отрисовки треугольника Серпинского. </param>
        /// <param name="selectedDepthStr"> Выбранная пользователем глубина рекурсии,
        /// переданная в строковом представлении. </param>
        public SierpinskiTriangle(Canvas selectedField, string selectedDepthStr) : base(selectedField)
        {
            try
            {
                selectedDepth = int.Parse(selectedDepthStr);

                // Сдвиг начальной точки отрисовки вниз по оси Y.
                startPoint.y1 += 100;

                // Создание точек равностороннего треугольника.
                A = (startPoint.x1 - 300, startPoint.y1 + 150);
                B = (startPoint.x1 + 300, startPoint.y1 + 150);
                C = (startPoint.x1, (int)(startPoint.y1 - (300 * Math.Sqrt(3) - 150)));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при инициализации фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Переопределённый метод отрисовки треугольника Серпинского.
        /// </summary>
        public override void Drawning()
        {
            try
            {
                Line line1 = new(), line2 = new(), line3 = new();

                (line1.X1, line1.Y1) = (A.x, A.y);
                (line1.X2, line1.Y2) = (B.x, B.y);

                (line2.X1, line2.Y1) = (A.x, A.y);
                (line2.X2, line2.Y2) = (C.x, C.y);

                (line3.X1, line3.Y1) = (B.x, B.y);
                (line3.X2, line3.Y2) = (C.x, C.y);

                line1.StrokeThickness = 1;
                line1.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line1);

                line2.StrokeThickness = 1;
                line2.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line2);

                line3.StrokeThickness = 1;
                line3.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line3);

                Recoursion(A.x, A.y, B.x, B.y, C.x, C.y, 0);
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
        /// <param name="x1"> Координата X первой точки. </param>
        /// <param name="y1"> Координата Y первой точки. </param>
        /// <param name="x2"> Координата X второй точки. </param>
        /// <param name="y2"> Координата Y второй точки. </param>
        /// <param name="x3"> Координата X третьей точки. </param>
        /// <param name="y3"> Координата Y третьей точки. </param>
        /// <param name="currentDepth"> Текущая глубина рекурсии. </param>
        private void Recoursion(int x1, int y1, int x2, int y2, int x3, int y3, int currentDepth)
        {
            try
            {
                if (currentDepth == selectedDepth)
                    return;

                Line line1 = new(), line2 = new(), line3 = new();

                // Нахождение середин отрезков треугольника.
                (int x, int y) M1 = ((x1 + x2) / 2, (y1 + y2) / 2);
                (int x, int y) M2 = ((x1 + x3) / 2, (y1 + y3) / 2);
                (int x, int y) M3 = ((x2 + x3) / 2, (y2 + y3) / 2);

                (line1.X1, line1.Y1) = (M1.x, M1.y);
                (line1.X2, line1.Y2) = (M2.x, M2.y);

                (line2.X1, line2.Y1) = (M1.x, M1.y);
                (line2.X2, line2.Y2) = (M3.x, M3.y);

                (line3.X1, line3.Y1) = (M2.x, M2.y);
                (line3.X2, line3.Y2) = (M3.x, M3.y);

                line1.StrokeThickness = 1;
                line1.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line1);

                line2.StrokeThickness = 1;
                line2.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line2);

                line3.StrokeThickness = 1;
                line3.Stroke = System.Windows.Media.Brushes.Black;
                drawningField.Children.Add(line3);

                Recoursion(x1, y1, M1.x, M1.y, M2.x, M2.y, currentDepth + 1);
                Recoursion(M2.x, M2.y, M3.x, M3.y, x3, y3, currentDepth + 1);
                Recoursion(M1.x, M1.y, x2, y2, M3.x, M3.y, currentDepth + 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при отрисовке фрактала\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка");
            }
        }
    }
}
