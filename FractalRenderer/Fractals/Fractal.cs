using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/// <summary>
/// Пространство имён фракталов.
/// </summary>
namespace Fractals
{
    /// <summary>
    /// Абстрактный класс "Фрактал".
    /// <br> Родитель классов:</br>
    /// <br> "FractalTree"; </br>
    /// <br> "KochCurve"; </br>
    /// <br> "SierpinskiCarpet"; </br>
    /// <br> "SierpinskiTriangle"; </br>
    /// <br> "CantorSet". </br>
    /// </summary>
    abstract class Fractal
    {
        /// <summary>
        /// Начальная точка отрисовки фракталов.
        /// </summary>
        protected (int x1, int y1) startPoint;

        /// <summary>
        /// Место отрисовки фракталов.
        /// </summary>
        protected Canvas drawningField;

        /// <summary>
        /// Конструктор класса "Фрактал".
        /// </summary>
        /// <param name="myField"> Переданное поле для отрисовки фрактала. </param>
        protected Fractal(Canvas myField)
        {
            // Центр поля.
            startPoint = (1388 / 2, 786 / 2);

            //this.drawningField = drawningField;
            drawningField = myField;
        }

        /// <summary>
        /// Абстрактный метод отрисовки фракталов.
        /// </summary>
        public abstract void Drawning();

        /// <summary>
        /// Метод очистки поля от фракталов.
        /// </summary>
        public void Erasing() => drawningField.Children.Clear();
    }
}
