using System.Linq;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class AddNewCourtCase
    {
        public AddNewCourtCase()
        {
            InitializeComponent();
            ComboBoxJudge.ItemsSource = StaticDataContext.DataContext.Employees.Where(c => c.Post == "Судья")
                .Select(p => p.FirstName + " " + p.SecondName + " " + p.LastName)
                .ToList();
            
        }
    }
}
