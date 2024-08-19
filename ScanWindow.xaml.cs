namespace AC;

using Microsoft.Maui.Controls;
using ZXing.Net.Maui;
using ZXing;

public partial class ScanWindow : ContentPage
{
    //private string qrCodeResult;

    public ScanWindow()
    {
        InitializeComponent();
        barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = true
        };
    }

    private async void OnStatisticsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Statistics());
    }
    private async void GoBack(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desktop());
    }
    private async void OnDesktopClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desktop());
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profile());
    }

    private async void OnScanWindowButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoomInfo());
        //if (!string.IsNullOrEmpty(qrCodeResult))
        //{
        // Переход на страницу RoomInfo с результатом сканирования
        //  await Navigation.PushAsync(new RoomInfo(qrCodeResult));
        //}
        //else
        // {
        // Обработка случая, когда QR-код не был сканирован
        //    await DisplayAlert("Ошибка", "QR-код не был сканирован", "OK");
        //}
    }

    private void barcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        if (first is null)
        {
            return;
        }
        Dispatcher.DispatchAsync(async () =>
        {
            await DisplayAlert("Barcode Detected", first.Value, "OK");
        });
    }
}
