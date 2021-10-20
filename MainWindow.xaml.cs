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

namespace Farcas_Diana_Lab2
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //adaugat la lab 3 ex 12
        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            //Tema de laborator – instantiem un obiect din clasa DougnutMachine
            //rezolvare:

            myDoughnutMachine = new DoughnutMachine();

            //ex18
            myDoughnutMachine.DoughnutComplete += new
            DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);


        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = true;
            sugarToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }
        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Tema de laborator – completam cu instructiunile necesare
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;

                // Tema de laborator – completam cu instructiunile necesare
                //rezolvare lab3ex17

                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled_.Text = mFilledChocolate.ToString();
                    break;

                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled_.Text = mFilledLemon.ToString();
                    break;

                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled_.Text = mFilledVanilla.ToString();
                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
