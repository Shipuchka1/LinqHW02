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

namespace LinqHW02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model1 db = new Model1();
        public MainWindow()
        {
            InitializeComponent();

        }

        public void task1()
        {
            
        }

        public void task2()
        {
            var q = db.Areas.Where(w =>(bool) w.AssemblyArea==true);
        }

        public void task3()
        {
            var q = db.Areas.Take(10);
        }

        public void task4()
        {
            var q = db.Areas.Skip(5).Take(3);
        }

        public void task5()
        {
            var q = db.Areas.TakeWhile(t=>t.OrderExecution!=0);
        }

        public void task6()
        {
            var q = db.Areas.TakeWhile(t => t.OrderExecution == 0);
        }

        public void task7()
        {
            var q = db.Areas.GroupBy(gb=>gb.IP);
        }

        public void task8()
        {
            //var q = db.Areas.Where(w => w.AreaId <= 22 && w.AreaId >= 28);
            //var r = db.Timers.Where(w => w.AreaId <= 22 && w.AreaId >= 28);

            int[] arr = new[] { 22, 23, 24, 25, 26, 27, 28 };
            var data = db.Timers.Where(w => arr.Contains(w.AreaId.Value));
        }

        public void task9()
        {
            int[] arr = new[] { 38,39,102 };
            var q = db.Timers.Where(w => arr.Contains(w.AreaId.Value) && w.DateFinish != null).Where(w => w.DateStart >= DateTime.Parse("01.06.2017") && w.DateFinish <= DateTime.Parse("30.08.2017"));
        }

        public void task10()
        {
            var q = db.Timers.Where(w => w.DateFinish != null).Count();
        }

        public void task11()
        {
            var q = db.Timers.Join(db.Areas, Timers => Timers.DocumentId, ar => ar.AreaId, (Timer, ar) => new { Timer, ar });
        }

        public void task12()
        {
            var q = db.Timers.GroupBy(gr => gr.DateStart).OrderByDescending(o => o.Key.Value);
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GV.Columns.Clear();
            List<Area> q = db.Areas.Where(w => w.WorkingPeople > 2).ToList();
            GV.Columns.Add(new GridViewColumn() { Header = "AreaId", DisplayMemberBinding = new Binding() { Path = new PropertyPath("AreaId") } });
            GV.Columns.Add(new GridViewColumn() { Header = "Name", DisplayMemberBinding = new Binding() { Path = new PropertyPath("Name") } });
            ListView1.ItemsSource = q;
        }
    }
}
