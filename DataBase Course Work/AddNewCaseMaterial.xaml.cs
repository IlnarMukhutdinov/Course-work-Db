using System;
using System.Windows;

namespace DataBase_Course_Work
{
    public partial class AddNewCaseMaterial
    {
        private readonly CaseMaterial _caseMaterial = new CaseMaterial();

        public AddNewCaseMaterial()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _caseMaterial.Evidence = TextBoxEvidence.Text;
                StaticDataContext.DataContext.CaseMaterials.Add(_caseMaterial);
                new MainWindow().UpdateCaseMaterialDataGrid(StaticDataContext.DataContext);
            }
            catch (NullReferenceException)
            {
                new TryAgainWindow().Show();
            }
        }
    }
}
