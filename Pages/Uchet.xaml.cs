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
    /// Логика взаимодействия для Uchet.xaml
    /// </summary>
    public partial class Uchet : Page
    {
        public Uchet()
        {
            InitializeComponent();
            SpecialCmb.SelectedValuePath = "ID";
            SpecialCmb.DisplayMemberPath = "Name";
            SpecialCmb.ItemsSource = ClassConnect.Ent.Specialization.ToList();

            GroupCmb.SelectedValuePath = "ID";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = ClassConnect.Ent.Group.ToList();

            VidCmb.SelectedValuePath = "ID";
            VidCmb.DisplayMemberPath = "Name";
            VidCmb.ItemsSource = ClassConnect.Ent.Direction.ToList();

            SorevCmb.SelectedValuePath = "ID";
            SorevCmb.DisplayMemberPath = "Name";
            SorevCmb.ItemsSource = ClassConnect.Ent.TypeCompetition.ToList();
        }

        private void DatGr_Loaded(object sender, RoutedEventArgs e)
        {
            DatGr.ItemsSource = ClassConnect.Ent.Accounting.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(SpecialCmb.Text))
            {
                mes += "Введите специальность\n";
            }
            if (string.IsNullOrWhiteSpace(GroupCmb.Text))
            {
                mes += "выберете группу\n";
            }
            if (string.IsNullOrWhiteSpace(VidCmb.Text))
            {
                mes += "выберете вид соревнований\n";
            }
            if (string.IsNullOrWhiteSpace(SorevCmb.Text))
            {
                mes += "выберете соревнования\n";
            }
            if (string.IsNullOrWhiteSpace(MarkTB.Text))
            {
                mes += "выберете соревнования\n";
            }

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Accounting accountingDS = new Accounting()
            {
                DateGame = GameDate.DisplayDate,
                TypeCompetition = SorevCmb.SelectedItem as TypeCompetition,
                Evaluation=Convert.ToDecimal(MarkTB.Text),
                Group=GroupCmb.SelectedItem as Group
            };
            ClassConnect.Ent.Accounting.Add(accountingDS);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Соревнования добавлены");

            DatGr.ItemsSource = ClassConnect.Ent.Accounting.ToList();

            GroupCmb.Text = "";
            SpecialCmb.Text = "";
            VidCmb.Text = "";
            MarkTB.Text = "";

        }

        private void SpecialCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectSpezial=Convert.ToInt32(SpecialCmb.SelectedValue);
            GroupCmb.ItemsSource=ClassConnect.Ent.Group.Where(x=>x.IdSpecial==selectSpezial).ToList();
        }

        private void VidCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int vidSorev = Convert.ToInt32(VidCmb.SelectedValue);
            SorevCmb.ItemsSource = ClassConnect.Ent.TypeCompetition.Where(x => x.IdDirection == vidSorev).ToList();
        }
    }
}
