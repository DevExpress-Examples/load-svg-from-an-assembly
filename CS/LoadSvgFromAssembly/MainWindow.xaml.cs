using System.IO;
using System.Reflection;
using System.Windows;
using DevExpress.Xpf.Core.Native;

namespace LoadSvgFromAssembly
{
    public partial class MainWindow
    {
        const string libraryName = @"ImagesLibrary";
        const string libraryLocation = "data\\ImagesLibrary.dll";
        const string resourceFileName = @"Logo_Svg_Res";

        public MainWindow()
        {
            InitializeComponent();
        }

        void LoadImage()
        {
            Assembly assembly = Assembly.LoadFrom(libraryLocation);
            assembly.GetManifestResourceInfo(resourceFileName);
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager($"{libraryName}.Resources", assembly);
            object obj = resourceManager.GetObject(resourceFileName, new System.Globalization.CultureInfo("en-US"));
            byte[] SVGinBytes = (byte[])obj;

            if (SVGinBytes == null)
                return;

            image.Source = WpfSvgRenderer.CreateImageSource(new MemoryStream(SVGinBytes), 1d, null);
        }

        void Button_OnClick(object sender, RoutedEventArgs e)
        {
            //load svg image from library (.dll file)
            LoadImage();
        }
    }
}
