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
using NetVips;

namespace Test_Netvips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          
          

            await Task.Run(() =>
            {
                var image = NetVips.Image.Black(18642 + 1, 10860 + 1);
                string save_directory = @"C:\Users\franc\Documents\SharpDevelop Projects\Test_Netvips\Test_Netvips\images\";
            for (int decalage_boucle_for_y = 0; decalage_boucle_for_y <= 42; decalage_boucle_for_y++)
                {
                    for (int decalage_boucle_for_x = 0; decalage_boucle_for_x <= 73; decalage_boucle_for_x++)
                    {
                        int tuile_x = 135732 + decalage_boucle_for_x;
                        int tuile_y = 90908 + decalage_boucle_for_y;

                        int pixel_decalage_x = (decalage_boucle_for_x * 256);
                        int pixel_decalage_y = (decalage_boucle_for_y * 256);

                        string filename = save_directory + "tiles\\" + tuile_y + "_" + tuile_x + "." + "jpeg"; ;
                        using var tile = NetVips.Image.NewFromFile(filename);
                        image = image.Insert(tile, pixel_decalage_x, pixel_decalage_y);
                        tile.Dispose();
                    }
                }

                image.WriteToFile(save_directory + "final.jpeg");
                image = null;
            });
            MessageBox.Show("End");

        }
    }
}
