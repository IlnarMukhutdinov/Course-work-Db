using System;
using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class AddNewCourtCase
    {
        private readonly CourtCase _courtCase = new CourtCase();

        public AddNewCourtCase()
        {
            InitializeComponent();
            ComboBoxJudge.ItemsSource = StaticDataContext.DataContext.Employees
                .Where(c => c.Post == "Судья")
                .Select(p => p.EmployeeId)
                .ToList();
            ComboBoxPlaintiff.ItemsSource = StaticDataContext.DataContext.Plaintiffs
                .Select(p => p.PlaintiffId)
                .ToList();
            ComboBoxDefendant.ItemsSource = StaticDataContext.DataContext.Defendants
                .Select(p => p.DefendantId)
                .ToList();
            ComboBoxProtocol.ItemsSource = StaticDataContext.DataContext.Protocols
                .Select(p => p.ProtocolId)
                .ToList();
            ComboBoxCaseMaterials.ItemsSource = StaticDataContext.DataContext.CaseMaterials
                .Select(p => p.CaseMaterialId)
                .ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _courtCase.StartDateTime = new DateTime(int.Parse(TextBoxStartYear.Text),
                    int.Parse(TextBoxStartMonth.Text), int.Parse(TextBoxStartDay.Text));
                _courtCase.EndDateTime = new DateTime(int.Parse(TextBoxEndYear.Text), int.Parse(TextBoxEndMonth.Text),
                    int.Parse(TextBoxEndDay.Text));
                _courtCase.Decision = TextBoxDecision.Text;
                _courtCase.EmployeeId = int.Parse(ComboBoxJudge.Text);
                _courtCase.DefendantId = int.Parse(ComboBoxDefendant.Text);
                _courtCase.PlaintiffId = int.Parse(ComboBoxPlaintiff.Text);
                _courtCase.CaseMaterialId = int.Parse(ComboBoxCaseMaterials.Text);
                _courtCase.ProtocolId = int.Parse(ComboBoxProtocol.Text);
                StaticDataContext.DataContext.CourtCases.Add(_courtCase);
                new MainWindow().UpdateCourtCaseDataGrid(StaticDataContext.DataContext);
            }
            catch (FormatException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
