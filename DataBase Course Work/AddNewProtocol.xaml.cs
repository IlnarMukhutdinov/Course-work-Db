using System;
using System.Windows;
namespace DataBase_Course_Work
{
   public partial class AddNewProtocol
    {
        private readonly Protocol _protocol = new Protocol();

        public AddNewProtocol()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _protocol.WitnessReadings = TextBoxWitnessReadings.Text;
                _protocol.DefendantReadings = TextBoxDefendantReadings.Text;
                _protocol.PlaintiffReadings = TextBoxPlaintiffReadings.Text;

                StaticDataContext.DataContext.Protocols.Add(_protocol);
                new MainWindow().UpdateProtocolDataGrid(StaticDataContext.DataContext);
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
