using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using ADO.NET_HW.DataBase;

namespace ADO.NET_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AreaDb DB = new AreaDb();
        private string _connstring = "";
        public MainWindow()
        {
            _connstring = "data source=192.168.1.201;initial catalog=CRCMS_new;persist security info=True;user id=sa;password=lisa1999;MultipleActiveResultSets=True;App=EntityFramework";
            InitializeComponent();

        }

        private void GetDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                var tt = "";
                //SqlConnection con = new SqlConnection(_connstring);
                //SqlDataAdapter adapter = new SqlDataAdapter("select * from Area", con);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds); var b = ds.Tables[0];
                GetData_4();
                // GetData_5();
                //GetData_6();
                //GetData_7();
                //GetData_8();
                // GetData_9();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text += ex.Message + "\n";
            }
        }

        private void GetData_4()
        {
            Stopwatch stop = new Stopwatch();
            stop.Start();
            try
            {
                AreaListView.ItemsSource = null;
                AreaListView.Items.Clear();
                DataGridView.Columns.Clear();
                var list = DB.Areas.Where(w => w.TypeArea == 1).OrderByDescending(or => or.AreaId).Select(s => new
                {
                    s.AreaId,
                    s.Name,
                    s.FullName,
                    s.IP
                }).ToList();
                AreaListView.ItemsSource = list;
                ErrorOrSuccesTextBlock.Text = null;
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text += ex.Message + "\n";
                stop.Stop();
            }

            if (string.IsNullOrEmpty(ErrorOrSuccesTextBlock.Text))
            {


                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "AreaId",
                    DisplayMemberBinding = new Binding("AreaId")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "Name",
                    DisplayMemberBinding = new Binding("Name")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "FullName",
                    DisplayMemberBinding = new Binding("FullName")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "IP",
                    DisplayMemberBinding = new Binding("IP")
                });


                ErrorOrSuccesTextBlock.Text = null;
                stop.Stop();
                ErrorOrSuccesTextBlock.Text += "Выгрузка произошла успешно!\nПрошло миллисекунд - " +
                                               stop.ElapsedMilliseconds + "\nSeconds - " +
                                               stop.ElapsedMilliseconds / 60;
            }
        }
        private void GetData_5()
        {
            try
            {
                AreaListView.ItemsSource = null;
                AreaListView.Items.Clear();
                DataGridView.Columns.Clear();
                var list =
                    from s in DB.Areas
                    where s.ParentId == 0
                    select new
                    {
                        s.AreaId,
                        s.FullName,
                        s.Name,
                        s.IP
                    };
                AreaListView.ItemsSource = list.ToList();
                ErrorOrSuccesTextBlock.Text = null;

            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = null;
                ErrorOrSuccesTextBlock.Text += ex.Message + "\n";
            }

            if (string.IsNullOrEmpty(ErrorOrSuccesTextBlock.Text))
            {

                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "AreaId",
                    DisplayMemberBinding = new Binding("AreaId")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "Name",
                    DisplayMemberBinding = new Binding("Name")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "FullName",
                    DisplayMemberBinding = new Binding("FullName")
                });
                DataGridView.Columns.Add(new GridViewColumn()
                {
                    Header = "IP",
                    DisplayMemberBinding = new Binding("IP")
                });
            }
        }

        private void GetData_6()
        {
            AreaListView.ItemsSource = null;
            AreaListView.Items.Clear();
            DataGridView.Columns.Clear();
            int[] pavillion = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            var list = DB.Areas.Where(w => pavillion.Contains(w.PavilionId)).Where(w => w.PavilionId == 2 || w.PavilionId == 4 || w.PavilionId == 6).Select(s => new
            {
                s.PavilionId,
                s.Name,
                s.FullName,
                s.IP
            }).ToList();
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "PavilionId",
                DisplayMemberBinding = new Binding("PavilionId")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "FullName",
                DisplayMemberBinding = new Binding("FullName")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "IP",
                DisplayMemberBinding = new Binding("IP")
            });
            AreaListView.ItemsSource = list;
        }

        private void GetData_7()
        {
            AreaListView.ItemsSource = null;
            AreaListView.Items.Clear();
            DataGridView.Columns.Clear();
            int[] pavillion = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            var list = from a in DB.Areas
                       where pavillion.Contains(a.PavilionId)
                       where a.PavilionId == 2 || a.PavilionId == 4 || a.PavilionId == 6
                       select new
                       {
                           a.PavilionId,
                           a.Name,
                           a.FullName,
                           a.IP
                       };

            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "PavilionId",
                DisplayMemberBinding = new Binding("PavilionId")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "FullName",
                DisplayMemberBinding = new Binding("FullName")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "IP",
                DisplayMemberBinding = new Binding("IP")
            });
            AreaListView.ItemsSource = list.ToList();
        }

        private void GetData_8()
        {
            AreaListView.ItemsSource = null;
            AreaListView.Items.Clear();
            DataGridView.Columns.Clear();
            var list = from w in DB.Areas
                       let a = w
                       where a.WorkingPeople > 1
                       select a;
            AreaListView.ItemsSource = list.ToList();
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "AreaId",
                DisplayMemberBinding = new Binding("AreaId")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "FullName",
                DisplayMemberBinding = new Binding("FullName")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "IP",
                DisplayMemberBinding = new Binding("IP")
            });
        }

        private void GetData_9()
        {
            AreaListView.ItemsSource = null;
            AreaListView.Items.Clear();
            DataGridView.Columns.Clear();
            var list = from w in DB.Areas
                select w
                into a
                where a.Dependence>0
                select new
                {
                    a.PavilionId,a.ParentId,a.FullName,a.Dependence,a.Name
                };


            AreaListView.ItemsSource = list.ToList();
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "PavilionId",
                DisplayMemberBinding = new Binding("PavilionId")
                ,
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "ParentId",
                DisplayMemberBinding = new Binding("ParentId")
            });

            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "FullName",
                DisplayMemberBinding = new Binding("FullName")
            });
            DataGridView.Columns.Add(new GridViewColumn()
            {
                Header = "Dependence",
                DisplayMemberBinding = new Binding("Dependence")
            });
          
        }

        private void GetDataButton2_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                GetData_5();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = ex.Message;
            }
          
        }

        private void GetDataButton3_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                GetData_6();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = ex.Message;
            }
        }

        private void GetDataButton4_OnClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                GetData_7();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = ex.Message;
            }
        }

        private void GetDataButton5_OnClick(object sender, RoutedEventArgs e)
        {
          
            try
            {
                GetData_8();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = ex.Message;
            }
        }

        private void GetDataButton6_OnClick(object sender, RoutedEventArgs e)
        {
         
            try
            {
                GetData_9();
            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text = ex.Message;
            }
        }
        
    }

    struct BestStruct
    {
        
    }
}
