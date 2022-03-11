using SignaturePad.Forms;
using EJERCICIO2_2.Models;
using EJERCICIO2_2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace EJERCICIO2_2
{
    public partial class MainPage : ContentPage
    {
        string valueBase64;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(descripcion.Text))
            {
                await DisplayAlert("Error", "Se deben llenar los campos de nombre y descripcion", "Aceptar");
            }

            else
            { 

            var signatureToSave = new Lista
            {
                imagenCodigo = valueBase64,
                nombre = nombre.Text,
                descripcion = descripcion.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if (result != 1)
            {
                await DisplayAlert("Error", "ha ocurrio un error, por favor intente de nuevo", "Aceptar");
            }

            await DisplayAlert("Aviso", "Se ha guardado con exito!", "Aceptar");
            }
        }

        private async void Ver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFirmas());
        }

        
    }
}
