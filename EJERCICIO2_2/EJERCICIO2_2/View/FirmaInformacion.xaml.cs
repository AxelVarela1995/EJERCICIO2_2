using EJERCICIO2_2.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO2_2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirmaInformacion : ContentPage
    {
        public FirmaInformacion(Lista signatures)
        {
            InitializeComponent();
            nombre.Text = signatures.nombre;
            descripcion.Text = signatures.descripcion;
            imageSignature.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(signatures.imagenCodigo)));
        }
    }
}