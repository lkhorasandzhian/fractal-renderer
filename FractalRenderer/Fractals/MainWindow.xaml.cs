using System;
using System.Collections.Generic;
using System.IO;  // Для вывода сообщения из текстового файла при нажатии 'Help'.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// Пространство имён фракталов.
/// </summary>
namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Ссылка на текущий фрактал.
        /// </summary>
        private Fractal currentFractal;

        /// <summary>
        /// Текущий тип фрактала.
        /// </summary>
        private Type fractalType;

        /// <summary>
        /// Конструктор запуска окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Fractal Tree".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void FirstFractal_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить настройки для фрактала.
            ShowSelectedBlocks("Fractal Tree");

            // Стирание старого фрактала с проверкой ссылки на null.
            currentFractal?.Erasing();

            // Обнуление ссылки.
            currentFractal = null;

            // Сведение типа от старого наследника к родителю, а затем к новому наследнику.
            currentFractal = currentFractal as Fractal as FractalTree;

            // Сохранение типа фрактала.
            fractalType = typeof(FractalTree);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Koch's Curve".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void SecondFractal_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить настройки для фрактала.
            ShowSelectedBlocks("Koch's Curve");

            // Стирание старого фрактала с проверкой ссылки на null.
            currentFractal?.Erasing();

            // Обнуление ссылки.
            currentFractal = null;

            // Сведение типа от старого наследника к родителю, а затем к новому наследнику.
            //currentFractal = currentFractal as Fractal as KochCurve;

            // Сохранение типа фрактала.
            fractalType = typeof(KochCurve);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Sierpinski's Carpet".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void ThirdFractal_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить настройки для фрактала.
            ShowSelectedBlocks("Sierpinski's Carpet");

            // Стирание старого фрактала с проверкой ссылки на null.
            currentFractal?.Erasing();

            // Обнуление ссылки.
            currentFractal = null;

            // Сведение типа от старого наследника к родителю, а затем к новому наследнику.
            //currentFractal = currentFractal as Fractal as SierpinskiСarpet;

            // Сохранение типа фрактала.
            fractalType = typeof(SierpinskiСarpet);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Sierpinski's Triangle".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void FourthFractal_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить настройки для фрактала.
            ShowSelectedBlocks("Sierpinski's Triangle");

            // Стирание старого фрактала с проверкой ссылки на null.
            currentFractal?.Erasing();

            // Обнуление ссылки.
            currentFractal = null;

            // Сведение типа от старого наследника к родителю, а затем к новому наследнику.
            //currentFractal = currentFractal as Fractal as SierpinskiTriangle;

            // Сохранение типа фрактала.
            fractalType = typeof(SierpinskiTriangle);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Cantor's Set".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void FifthFractal_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить настройки для фрактала.
            ShowSelectedBlocks("Cantor's Set");

            // Стирание старого фрактала с проверкой ссылки на null.
            currentFractal?.Erasing();

            // Обнуление ссылки.
            currentFractal = null;

            // Сведение типа от старого наследника к родителю, а затем к новому наследнику.
            //currentFractal = currentFractal as Fractal as CantorSet;

            // Сохранение типа фрактала.
            fractalType = typeof(CantorSet);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Help".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            string pathToREADME = $"..{System.IO.Path.DirectorySeparatorChar}" +
                               $"..{System.IO.Path.DirectorySeparatorChar}" +
                               $"..{System.IO.Path.DirectorySeparatorChar}.." +
                               $"{System.IO.Path.DirectorySeparatorChar}README.txt";
            string info;
            try
            {
                using (StreamReader sr = new(pathToREADME))
                {
                    info = sr.ReadToEnd();
                }

                _ = MessageBox.Show(info, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка чтения информации\n" +
                    $"сообщение для разработчика: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Метод отображения элементов меню для соответствующего типа фрактала.
        /// </summary>
        /// <param name="fractalType"> Тип фрактала. </param>
        private void ShowSelectedBlocks(string fractalType)
        {
            int fractalNum;

            switch (fractalType)
            {
                case "Fractal Tree":
                    FirstSceneType();
                    fractalNum = 1;
                    break;
                case "Koch's Curve":
                    fractalNum = 2;
                    SecondSceneType();
                    break;
                case "Sierpinski's Carpet":
                    fractalNum = 3;
                    SecondSceneType();
                    break;
                case "Sierpinski's Triangle":
                    SecondSceneType();
                    fractalNum = 4;
                    break;
                case "Cantor's Set":
                    ThirdSceneType();
                    fractalNum = 5;
                    break;
                default:
                    _ = MessageBox.Show("Имя введёного блока для отображения отсутствует", "Ошибка программы");
                    return;
            }

            SelectedMenuItemColorizing(fractalNum);

            DepthListChanger(fractalType);
        }

        /// <summary>
        /// Зелёная подсветка выбранного элемента меню.
        /// </summary>
        /// <param name="fractalNum"> Порядок фрактала. </param>
        private void SelectedMenuItemColorizing(int fractalNum)
        {
            switch (fractalNum)
            {
                case 1:
                    FirstFractal.Foreground = Brushes.ForestGreen;
                    SecondFractal.Foreground = Brushes.Black;
                    ThirdFractal.Foreground = Brushes.Black;
                    FourthFractal.Foreground = Brushes.Black;
                    FifthFractal.Foreground = Brushes.Black;
                    break;
                case 2:
                    FirstFractal.Foreground = Brushes.Black;
                    SecondFractal.Foreground = Brushes.ForestGreen;
                    ThirdFractal.Foreground = Brushes.Black;
                    FourthFractal.Foreground = Brushes.Black;
                    FifthFractal.Foreground = Brushes.Black;
                    break;
                case 3:
                    FirstFractal.Foreground = Brushes.Black;
                    SecondFractal.Foreground = Brushes.Black;
                    ThirdFractal.Foreground = Brushes.ForestGreen;
                    FourthFractal.Foreground = Brushes.Black;
                    FifthFractal.Foreground = Brushes.Black;
                    break;
                case 4:
                    FirstFractal.Foreground = Brushes.Black;
                    SecondFractal.Foreground = Brushes.Black;
                    ThirdFractal.Foreground = Brushes.Black;
                    FourthFractal.Foreground = Brushes.ForestGreen;
                    FifthFractal.Foreground = Brushes.Black;
                    break;
                case 5:
                    FirstFractal.Foreground = Brushes.Black;
                    SecondFractal.Foreground = Brushes.Black;
                    ThirdFractal.Foreground = Brushes.Black;
                    FourthFractal.Foreground = Brushes.Black;
                    FifthFractal.Foreground = Brushes.ForestGreen;
                    break;
            }
        }

        /// <summary>
        /// Метод настройки доступных полей контекстного меню глубины рекурсии
        /// <br> в зависимости от выбранного фрактала. </br>
        /// </summary>
        /// <param name="name"> Имя фрактала. </param>
        private void DepthListChanger(string name)
        {
            depthSelector.Items.Clear();

            if (name == "Fractal Tree")
            {
                for (int i = 0; i < 12; i++)
                {
                    var textBlock = new TextBlock { Text = $"{i}" };
                    depthSelector.Items.Add(textBlock);
                }
            }
            else if (name == "Koch's Curve" || name == "Sierpinski's Carpet")
            {
                for (int i = 0; i < 7; i++)
                {
                    var textBlock = new TextBlock { Text = $"{i}" };
                    depthSelector.Items.Add(textBlock);
                }
            }
            else if (name == "Sierpinski's Triangle")
            {
                for (int i = 0; i < 8; i++)
                {
                    var textBlock = new TextBlock { Text = $"{i}" };
                    depthSelector.Items.Add(textBlock);
                }
            }
            else if (name == "Cantor's Set")
            {
                for (int i = 1; i < 12; i++)
                {
                    var textBlock = new TextBlock { Text = $"{i}" };
                    depthSelector.Items.Add(textBlock);
                }
            }
        }

        /// <summary>
        /// Отображение элементов настройки для элемента меню "Fractal Tree".
        /// </summary>
        private void FirstSceneType()
        {
            depthLabel.Visibility = Visibility.Visible;
            depthSelector.Visibility = Visibility.Visible;
            separator1.Visibility = Visibility.Visible;
            segmentRatioLabel.Visibility = Visibility.Visible;
            segmentRatioSelector.Visibility = Visibility.Visible;
            separator2.Visibility = Visibility.Visible;
            firstTiltAngleLabel.Visibility = Visibility.Visible;
            firstTiltAngleSlider.Visibility = Visibility.Visible;
            separator3.Visibility = Visibility.Visible;
            secondTiltAngleLabel.Visibility = Visibility.Visible;
            secondTiltAngleSlider.Visibility = Visibility.Visible;
            separator4.Visibility = Visibility.Visible;
            distanceLabel.Visibility = Visibility.Collapsed;
            distanceSelector.Visibility = Visibility.Collapsed;
            separator5.Visibility = Visibility.Collapsed;
            launchButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Отображение элементов настройки для элементов меню
        /// <br> "Koch's Curve", "Sierpinski's Carpet", "Sierpinski's Triangle". </br>
        /// </summary>
        private void SecondSceneType()
        {
            depthLabel.Visibility = Visibility.Visible;
            depthSelector.Visibility = Visibility.Visible;
            separator1.Visibility = Visibility.Collapsed;
            segmentRatioLabel.Visibility = Visibility.Collapsed;
            segmentRatioSelector.Visibility = Visibility.Collapsed;
            separator2.Visibility = Visibility.Collapsed;
            firstTiltAngleLabel.Visibility = Visibility.Collapsed;
            firstTiltAngleSlider.Visibility = Visibility.Collapsed;
            separator3.Visibility = Visibility.Collapsed;
            secondTiltAngleLabel.Visibility = Visibility.Collapsed;
            secondTiltAngleSlider.Visibility = Visibility.Collapsed;
            separator4.Visibility = Visibility.Collapsed;
            distanceLabel.Visibility = Visibility.Collapsed;
            distanceSelector.Visibility = Visibility.Collapsed;
            separator5.Visibility = Visibility.Visible;
            launchButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Отображение элементов настройки для элемента меню "Cantor's Set".
        /// </summary>
        private void ThirdSceneType()
        {
            depthLabel.Visibility = Visibility.Visible;
            depthSelector.Visibility = Visibility.Visible;
            separator1.Visibility = Visibility.Visible;
            segmentRatioLabel.Visibility = Visibility.Collapsed;
            segmentRatioSelector.Visibility = Visibility.Collapsed;
            separator2.Visibility = Visibility.Collapsed;
            firstTiltAngleLabel.Visibility = Visibility.Collapsed;
            firstTiltAngleSlider.Visibility = Visibility.Collapsed;
            separator3.Visibility = Visibility.Collapsed;
            secondTiltAngleLabel.Visibility = Visibility.Collapsed;
            secondTiltAngleSlider.Visibility = Visibility.Collapsed;
            separator4.Visibility = Visibility.Collapsed;
            distanceLabel.Visibility = Visibility.Visible;
            distanceSelector.Visibility = Visibility.Visible;
            separator5.Visibility = Visibility.Visible;
            launchButton.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Перерисовать".
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления, вызвавший событие. </param>
        /// <param name="e"> Параметр, содержащий данные о событии. </param>
        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            drawningField.Children.Clear();

            if (EmptyFieldsChecker())
            {
                _ = MessageBox.Show("Перед отрисовкой необходимо настроить фрактал", "Ошибка отрисовки");
                return;
            }

            if (fractalType == typeof(FractalTree))
            {
                currentFractal = new FractalTree(drawningField,
                                                 depthSelector.Text,
                                                 segmentRatioSelector.Text,
                                                 firstTiltAngleSlider.Value,
                                                 secondTiltAngleSlider.Value);
            }
            else if (fractalType == typeof(KochCurve))
            {
                currentFractal = new KochCurve(drawningField,
                                               depthSelector.Text);
            }
            else if (fractalType == typeof(SierpinskiСarpet))
            {
                currentFractal = new SierpinskiСarpet(drawningField,
                                                      depthSelector.Text);
            }
            else if (fractalType == typeof(SierpinskiTriangle))
            {
                currentFractal = new SierpinskiTriangle(drawningField,
                                                        depthSelector.Text);
            }
            else if (fractalType == typeof(CantorSet))
            {
                currentFractal = new CantorSet(drawningField,
                                               depthSelector.Text,
                                               distanceSelector.Text);
            }

            currentFractal.Drawning();
        }

        /// <summary>
        /// Защита от попытки отрисовки фрактала с пустыми полями.
        /// </summary>
        /// <returns> Логическое значение наличия пустых полей в настройках. </returns>
        private bool EmptyFieldsChecker()
        {
            if (fractalType == typeof(FractalTree))
            {
                if (depthSelector.SelectedItem == null || segmentRatioSelector.SelectedItem == null)
                    return true;
            }
            else if (fractalType == typeof(KochCurve) ||
                     fractalType == typeof(SierpinskiСarpet) ||
                     fractalType == typeof(SierpinskiTriangle))
            {
                if (depthSelector.SelectedItem == null)
                    return true;
            }
            else if (fractalType == typeof(CantorSet))
            {
                if (depthSelector.SelectedItem == null || distanceSelector.SelectedItem == null)
                    return true;
            }

            return false;
        }
    }
}
