using DungeonMapperAndroidForms.Utilities;
using DungeonMapperStandard.DataAccess;
using DungeonMapperStandard.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DungeonMapperAndroidForms.Views
{
    public partial class AboutPage : ContentPage
    {
        private DungeonMapperStandard.Models.Map _map;
        private double ButtonClickLength = 5;

        public AboutPage()
        {
            InitializeComponent();
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DatabaseManager.Initialize(appDataFolder, new DatabaseConnectionHandler());

            var currentMapId = SettingDataAccess.GetSetting<int?>(Setting.CurrentMapId);

            if (currentMapId == null)
            {
                _map = new DungeonMapperStandard.Models.Map();
                _map.Initialize();
                _map.MoveRight();
                _map.MoveDown();
                _map.MoveRight();
                var mapId = MapDataAccess.SaveMap(_map);
                SettingDataAccess.SaveSetting(Setting.CurrentMapId, mapId);
            }
            else
            {
                _map = MapDataAccess.GetMaps().First(map => map.Id == currentMapId);
                _map.LoadData();
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

        private void SaveClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            var mapId = MapDataAccess.SaveMap(_map);
            SettingDataAccess.SaveSetting(Setting.CurrentMapId, mapId);
        }

        private void ClearClick(object sender, EventArgs e)
        {
            Vibration.Vibrate(ButtonClickLength);
            foreach (var tile in _map.MapData.SelectMany(tileArray => tileArray).Where(tile => tile != null && tile.Traveled))
                tile.Clear();
            Canvas.InvalidateSurface();
        }
    }
}