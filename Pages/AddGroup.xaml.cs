using SOREVNOVANIA.ClassPr;
using System;
using System.Collections.Generic;
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

namespace SOREVNOVANIA.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Page
    {
        public AddGroup()
        {
            InitializeComponent();
            SpecialCmb.SelectedValuePath = "ID";
            SpecialCmb.DisplayMemberPath = "Name";
            SpecialCmb.ItemsSource = ClassConnect.Ent.Specialization.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(GroupTB.Text))
            {
                mes += "Введите группу\n";
            }
            if (string.IsNullOrWhiteSpace(SpecialCmb.Text))
            {
                mes += "выберете вид группы\n";
            }

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Group groupDS = new Group()
            {
                Name = GroupTB.Text,
                Specialization = SpecialCmb.SelectedItem as Specialization
            };
            ClassConnect.Ent.Group.Add(groupDS);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Соревнования добавлены");

            GroupTB.Text = "";
            SpecialCmb.Text = "";
        }
    }
}
