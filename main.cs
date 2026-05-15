using System.Windows;
using System.Windows.Media;

namespace LineSegmentWPF
{
    public partial class MainWindow : Window
    {
        private LineSegment? _mySegment;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateClick(
            object sender,
            RoutedEventArgs e)
        {
            if (!double.TryParse(TxtX.Text, out double x))
            {
                MessageBox.Show(
                    "Ошибка! Введите число для начала отрезка (X).",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(TxtY.Text, out double y))
            {
                MessageBox.Show(
                    "Ошибка! Введите число для конца отрезка (Y).",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            _mySegment = new LineSegment(x, y);

            ClearOperationResults();
            UpdateUiState();

            TxtSegmentInfo.Text =
                $"Успешно создан! {_mySegment}";
        }

        private void BtnLengthClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            TxtLength.Text =
                $"Длина отрезка: {!_mySegment}";
        }

        private void BtnIncrementClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            _mySegment++;
            UpdateUiState();
            TxtAfterIncrement.Text =
                $"После ++: {_mySegment}";
        }

        private void BtnAddClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            if (!int.TryParse(
                    TxtAddValue.Text,
                    out int addValue))
            {
                MessageBox.Show(
                    "Ошибка! Введите корректное число для сдвига.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            _mySegment = _mySegment + addValue;
            UpdateUiState();
            TxtAfterAdd.Text =
                $"После + {addValue}: {_mySegment}";
        }

        private void BtnCheckClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            if (!double.TryParse(
                    TxtCheckNum.Text,
                    out double result)
                || result < -100
                || result > 100)
            {
                MessageBox.Show(
                    "Ошибка! Введите число в диапазоне от -100 до 100.",
                    "Ошибка диапазона",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            int checkNum = (int)result;

            if (_mySegment < checkNum)
            {
                TxtCheckResult.Text =
                    $"Число {checkNum} входит в отрезок.";
            }
            else
            {
                TxtCheckResult.Text =
                    $"Число {checkNum} НЕ входит в отрезок.";
            }
        }

        private void BtnCastIntClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            int castedX = (int)_mySegment;
            TxtCastInt.Text =
                $"Результат (int): {castedX}";
        }

        private void BtnCastDoubleClick(
            object sender,
            RoutedEventArgs e)
        {
            if (_mySegment is null)
            {
                return;
            }

            double castedY = _mySegment;
            TxtCastDouble.Text =
                $"Результат (double): {castedY}";
        }

        private void UpdateUiState()
        {
            if (_mySegment is not null)
            {
                TxtCurrentState.Text =
                    _mySegment.ToString();
                TxtCurrentState.Foreground =
                    Brushes.Black;
                GrpOperations.IsEnabled = true;
            }
        }

        private void ClearOperationResults()
        {
            TxtLength.Text = string.Empty;
            TxtAfterIncrement.Text = string.Empty;
            TxtAfterAdd.Text = string.Empty;
            TxtCheckResult.Text = string.Empty;
            TxtCastInt.Text = string.Empty;
            TxtCastDouble.Text = string.Empty;
        }
    }
}
