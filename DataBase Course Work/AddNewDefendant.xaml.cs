using System;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class AddNewDefendant : Window
    {
        private Defendant _defendant = new Defendant();

        public AddNewDefendant()
        {
            InitializeComponent();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _defendant.FirstName = TextBoxFirstName.Text;
                _defendant.SecondName = TextBoxSecondName.Text;
                _defendant.LastName = TextBoxLastName.Text;
                _defendant.BirthDay = new DateTime(int.Parse(TextBoxYear.Text), int.Parse(TextBoxMonth.Text), int.Parse(TextBoxDay.Text));
                _defendant.PasportSeries = int.Parse(TextBoxPasportSeries.Text);
                _defendant.PasportNum = int.Parse(TextBoxPasportNumber.Text);
                StaticDataContext.DataContext.Defendants.Add(_defendant);
                new MainWindow().UpdateDefendantDataGrid(StaticDataContext.DataContext);
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
