using BeeDone.Data;
using BeeDone.Models;
using BeeDone.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BeeDone
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }
        public MainWindow()
        {
            ViewModel = new MainViewModel(new TacheDataProvider());
            InitializeComponent();

            ViewModel.ChargerTaches();
        }



        private async void btnAjouterTache_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.AjouterTache())
            {
                // Afficher un message d'erreur dans dialogue
                ContentDialog dialogue = new ContentDialog()
                {
                    Title = "Erreur",
                    Content = "Veuillez entrer une tâche avant d'ajouter.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };

                await dialogue.ShowAsync();

            }

        }

        private async void btnSupprimerTache_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.SupprimerTache())
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Erreur",
                    Content = "Veuillez sélectionner une tâche à supprimer.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot
                };
                await dialog.ShowAsync();
            }
        }

        private void btnFermerDetails_Click(object sender, RoutedEventArgs e)
        {
            brdDetailsTache.Visibility = Visibility.Collapsed;

            // Optionnel : Si on veut redimentionner 
            Grid.SetColumnSpan(grdZoneAjout, 2);
            Grid.SetColumnSpan(brdListeTaches, 2);
        }
    }
}
