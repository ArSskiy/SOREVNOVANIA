using SOREVNOVANIA.ClassPr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SOREVNOVANIA.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddSorev.xaml
    /// </summary>
    public partial class AddSorev : Page
    {
        public AddSorev()
        {
            InitializeComponent();
            VidCmb.SelectedValuePath = "ID";
            VidCmb.DisplayMemberPath = "Name";
            VidCmb.ItemsSource = ClassConnect.Ent.Direction.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(SorevTB.Text))
            {
                mes += "Введите группу\n";
            }
            if (string.IsNullOrWhiteSpace(VidCmb.Text))
            {
                mes += "выберете вид группы\n";
            }

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            TypeCompetition groupDS = new TypeCompetition()
            {
                Name = SorevTB.Text,
                Direction = VidCmb.SelectedItem as Direction
            };
            ClassConnect.Ent.TypeCompetition.Add(groupDS);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Группа добавлена");

            SorevTB.Text = "";
            VidCmb.Text = "";
        }
    }
}
