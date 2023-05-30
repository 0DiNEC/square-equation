namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const char dot =  ',' ;
        char[] arifmetic = { '-', '+' };

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox == null)
                return;

            if (!char.IsDigit(e.KeyChar) && !arifmetic.Contains(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
                e.Handled = true;

            // only one plus or minus
            if (arifmetic.Contains(e.KeyChar) && textBox.Text.Length > 0)
                if (textBox.SelectionStart != 0)
                    e.Handled = true;

            // if more one dot
            if ((textBox.Text.Contains(dot) || textBox.Text.Length < 1) && e.KeyChar == ',')
                e.Handled = true;

            if (textBox.Text.Length == 1 && arifmetic.Contains(textBox.Text[0]) && e.KeyChar == ',')
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a, b, c;
                bool isA = double.TryParse(textBox1.Text, out a);
                bool isB = double.TryParse(textBox2.Text, out b);
                bool isC = double.TryParse(textBox3.Text, out c);

                if (!isA)
                    throw new Exception($"значение а недопустимо {textBox1.Text}");
                if (!isB)
                    throw new Exception($"значение b недопустимо {textBox2.Text}");
                if (!isC)
                    throw new Exception($"значение c недопустимо {textBox3.Text}");


                double d = b * b - 4 * a * c;
                d = Math.Round(d, 4);
                if (d < 0)
                    MessageBox.Show($"Дискриминант равен {d}, что меньше 0. Нет корней");
                else if (d == 0)
                {
                    double x = Math.Round((-b / (2 * a)), 4);
                    MessageBox.Show($"Дискриминант равен 0.\n Корень x = {x}");
                }
                else
                {
                    double x1 = Math.Round((-b - Math.Sqrt(d)) / (2 * a), 4);
                    double x2 = Math.Round((-b + Math.Sqrt(d)) / (2 * a), 4);
                    MessageBox.Show($"Дискриминант равен {d}.\n Корень x1 = {x1}\n Корень x2 = {x2}");
                }
            }
            catch
            {
                
            }
        }
    }
}