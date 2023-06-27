using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Npgsql;
using Npgsql.Internal;
using NpgsqlTypes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public NpgsqlConnection npgsqlConnection1 { get; set; }
        public ObservableCollection<Dima> Dimas { get; set; } 

        public Dima selectDima;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            //Надо
            DataContext = this;
            
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection("Server=127.0.0.1; Port=5432; User Id=postgres; Password=1234; Database=ForTest");
            npgsqlConnection.Open();
       
            npgsqlConnection1 = npgsqlConnection;
            Get();
            /// ///
            /// 
            /////
            
            

        }
        /// <summary>
        /// хуууууууууууууууууууууууй
        /// пиздааааааааааааааааааааааааааа
        /// жопааааааааааааааа 
        /// о маа гад
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (selectDima != null)
            {
                NpgsqlCommand npgsqlCommand = npgsqlConnection1.CreateCommand();
                npgsqlCommand.CommandText = "Delete From \"Namesss\" where \"Nameee\" = @oar ";
                npgsqlCommand.Parameters.AddWithValue("@oar", NpgsqlDbType.Varchar, selectDima.Brawler);
                npgsqlCommand.ExecuteNonQuery();
                Dimas.Remove(selectDima);

            }
            
            ///////////////////////////
            /*var getInterface = CollectionViewSource.GetDefaultView(идинахуй.ItemsSource);*/
            /*getInterface.Filter = new Predicate<object>
                (
                идинахуй =>
                {
                    Dima dima = (Dima)идинахуй;
                    bool isHave = true;
                    if (dima.Brawler[0] == 'Н')
                    {
                        isHave = false;
                    }
                    return isHave;
                }
                );*/
           /* getInterface.SortDescriptions.Add(new System.ComponentModel.SortDescription("Brawler", System.ComponentModel.ListSortDirection.Descending));
*/
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Get()
        {
            NpgsqlCommand npgsqlCommand = npgsqlConnection1.CreateCommand();
            npgsqlCommand.CommandText = "SELECT \"Nameee\"FROM public.\"Namesss\";";
            var result = npgsqlCommand.ExecuteReader();
            Dimas = new ObservableCollection<Dima>();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Dimas.Add(new Dima(result.GetString(0)));
                }
            }
            result.Close();
        }
    }
}
