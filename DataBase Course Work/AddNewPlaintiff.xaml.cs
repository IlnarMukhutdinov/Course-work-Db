using System;
using System.Windows;

namespace DataBase_Course_Work
{
    /// <summary>
    /// Логика взаимодействия для AddNewPlaintiff.xaml
    /// </summary>
    public partial class AddNewPlaintiff
    {
        private Plaintiff _plaintiff = new Plaintiff();

        public AddNewPlaintiff()
        {
            InitializeComponent();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _plaintiff.FirstName = TextBoxFirstName.Text;
                _plaintiff.SecondName = TextBoxSecondName.Text;
                _plaintiff.LastName = TextBoxLastName.Text;
                _plaintiff.BirthDay = new DateTime(int.Parse(TextBoxYear.Text), int.Parse(TextBoxMonth.Text), int.Parse(TextBoxDay.Text));
                _plaintiff.PasportSeries = int.Parse(TextBoxPasportSeries.Text);
                _plaintiff.PasportNum = int.Parse(TextBoxPasportNumber.Text);
                StaticDataContext.DataContext.Plaintiffs.Add(_plaintiff);
                new MainWindow().UpdatePlaintiffDataGrid(StaticDataContext.DataContext);
                ClearFields();
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
            ClearFields();
        }

        private void ClearFields()
        {
            TextBoxYear.Clear();
            TextBoxMonth.Clear();
            TextBoxDay.Clear();
            TextBoxFirstName.Clear();
            TextBoxSecondName.Clear();
            TextBoxLastName.Clear();
            TextBoxPasportNumber.Clear();
            TextBoxPasportSeries.Clear();
        }
    }
}
