using DungeonMapperAndroidForms.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DungeonMapperAndroidForms.Views
{
    public partial class AboutPage : ContentPage
    {
        private FormsMap _map;
        private double ButtonClickLength = 5;

        public AboutPage()
        {
            InitializeComponent();
            CheckDatabase();
            _map = new FormsMap();
            _map.Initialize();
            _map.MoveRight();
            _map.MoveDown();
            _map.MoveRight();
        }

        private void CheckDatabase()
        {
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "bluhbluhbluh.txt");
                File.WriteAllText(path, "asdfasdfaf");
            }
            catch (Exception ex)
            {
                var bluh = "asdad";
            }
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Black);
            _map.PrintToCanvas(canvas);
        }

        private void UpClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            _map.MoveUp();
            Canvas.InvalidateSurface();
        }

        private void DownClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            _map.MoveDown();
            Canvas.InvalidateSurface();
        }

        private void LeftClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            _map.MoveLeft();
            Canvas.InvalidateSurface();
        }

        private void RightClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            _map.MoveRight();
            Canvas.InvalidateSurface();
        }
    }
}