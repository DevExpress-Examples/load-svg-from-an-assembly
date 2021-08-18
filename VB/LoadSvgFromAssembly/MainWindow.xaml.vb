Imports System.IO
Imports System.Reflection
Imports System.Windows
Imports DevExpress.Xpf.Core.Native

Namespace LoadSvgFromAssembly
	Partial Public Class MainWindow
		Private Const libraryName As String = "ImagesLibrary"
		Private Const libraryLocation As String = "data\ImagesLibrary.dll"
		Private Const resourceFileName As String = "Logo_Svg_Res"

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub LoadImage()
			Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(libraryLocation)
			assembly.GetManifestResourceInfo(resourceFileName)
			Dim resourceManager As New System.Resources.ResourceManager($"{libraryName}.Resources", assembly)
			Dim obj As Object = resourceManager.GetObject(resourceFileName, New System.Globalization.CultureInfo("en-US"))
			Dim SVGinBytes() As Byte = DirectCast(obj, Byte())

			If SVGinBytes Is Nothing Then
				Return
			End If

			image.Source = WpfSvgRenderer.CreateImageSource(New MemoryStream(SVGinBytes), 1R, Nothing)
		End Sub

		Private Sub Button_OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'load svg image from library (.dll file)
			LoadImage()
		End Sub
	End Class
End Namespace
