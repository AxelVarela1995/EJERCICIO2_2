using System;
using System.IO;
using EJERCICIO2_2.Models;
using EJERCICIO2_2.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO2_2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFirmas : ContentPage
    {
        public ListaFirmas()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            LoadCollectionView();
        }
        private async void LoadCollectionView()
        {
            listSignatures.ItemsSource = await App.BaseDatos.GetListSignatures();
        }

        private async void listSignatures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Lista)e.SelectedItem;

            var signatureObtained = await App.BaseDatos.GetSignatureByCode(itemSelected.code);

            var firmainformacion = new FirmaInformacion(signatureObtained);

            await Navigation.PushAsync(firmainformacion);
        }
    }
}