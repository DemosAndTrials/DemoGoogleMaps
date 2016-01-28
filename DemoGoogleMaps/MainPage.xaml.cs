using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DemoGoogleMaps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static string GeneratedHTML = "";

        public MainPage()
        {
            this.InitializeComponent();
            //Load Data method is called to populate the default.html string which we are rendering in
            //our WebView.
            LoadData();
            //Setting the HTML content in the WebView control.
            MapWebView.NavigateToString(GeneratedHTML);
        }

        private async void LoadData()
        {
            try
            {
                await loadJsonLocalnew("default.html", "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async static Task loadJsonLocalnew(string url, object ClassName)
        {
            try
            {
                //*******************************************************
                //To pick up file from local folder in window store app
                //*******************************************************
                StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Map");
                StorageFile file = await folder.GetFileAsync(url);
                Stream stream = await file.OpenStreamForReadAsync();
                StreamReader reader = new StreamReader(stream);
                String html = reader.ReadToEnd();
                GeneratedHTML = html.ToString();
                //*******************************************************
                //*******************************************************
            }
            catch (Exception ex)
            {
            }
        }
    }
}
