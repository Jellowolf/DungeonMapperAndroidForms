using DungeonMapperStandard.Models;
using SkiaSharp;

namespace DungeonMapperAndroidForms.Utilities
{
    public static class MapUtility
    {
        public static void PrintToCanvas(this Map map, SKCanvas canvas)
        {
            int left, top;

            for (int indexY = 0; indexY < map.MaxIndexY + 1; indexY++)
            {
                for (int indexX = 0; indexX < map.MaxIndexX + 1; indexX++)
                {
                    var tile = map.MapData[indexX][map.MaxIndexY - indexY];
                    left = (indexX * map.TileSize) + 1;
                    top = (indexY * map.TileSize) + 1;

                    // draw some text
                    var paint = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Fill };

                    // draw the background square for a grid effect
                    var gridRectangle = SKRect.Create(left, top, map.TileSize, map.TileSize);
                    canvas.DrawRect(gridRectangle, new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Fill });

                    // draw the base for the tile if it's null or hasn't been marked for travel
                    var travelRectangle = SKRect.Create(left, top, map.TileSize - 1, map.TileSize - 1);
                    if (tile == null || !tile.Traveled)
                    {
                        canvas.DrawRect(travelRectangle, new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Fill });
                        continue;
                    }
                    canvas.DrawRect(travelRectangle, new SKPaint { Color = SKColors.DarkGray, Style = SKPaintStyle.Fill });

                    // draw walls
                    if (tile.Walls.HasFlag(Wall.Up))
                        canvas.DrawRect(SKRect.Create(left, top, map.TileSize, map.WallWidth), new SKPaint { Color = SKColors.DimGray, Style = SKPaintStyle.Fill });
                    if (tile.Walls.HasFlag(Wall.Down))
                        canvas.DrawRect(SKRect.Create(left, top + map.TileSize - map.WallWidth, map.TileSize, map.WallWidth), new SKPaint { Color = SKColors.DimGray, Style = SKPaintStyle.Fill });
                    if (tile.Walls.HasFlag(Wall.Left))
                        canvas.DrawRect(SKRect.Create(left, top, map.WallWidth, map.TileSize), new SKPaint { Color = SKColors.DimGray, Style = SKPaintStyle.Fill });
                    if (tile.Walls.HasFlag(Wall.Right))
                        canvas.DrawRect(SKRect.Create(left + map.TileSize - map.WallWidth, top, map.WallWidth, map.TileSize), new SKPaint { Color = SKColors.DimGray, Style = SKPaintStyle.Fill });

                    // draw doors
                    if (tile.Doors.HasFlag(Wall.Up))
                        canvas.DrawRect(SKRect.Create(left, top, map.TileSize, map.DoorWidth), new SKPaint { Color = SKColors.Brown, Style = SKPaintStyle.Fill });
                    if (tile.Doors.HasFlag(Wall.Down))
                        canvas.DrawRect(SKRect.Create(left, top + map.TileSize - map.DoorWidth, map.TileSize, map.DoorWidth), new SKPaint { Color = SKColors.Brown, Style = SKPaintStyle.Fill });
                    if (tile.Doors.HasFlag(Wall.Left))
                        canvas.DrawRect(SKRect.Create(left, top, map.DoorWidth, map.TileSize), new SKPaint { Color = SKColors.Brown, Style = SKPaintStyle.Fill });
                    if (tile.Doors.HasFlag(Wall.Right))
                        canvas.DrawRect(SKRect.Create(left + map.TileSize - map.DoorWidth, top, map.DoorWidth, map.TileSize), new SKPaint { Color = SKColors.Brown, Style = SKPaintStyle.Fill });

                    // draw transport if available
                    /*if (tile.Transport != null)
                    {
                        var halfmap.TileSize = (double)map.TileSize / 2;
                        var quartermap.TileSize = (double)map.TileSize / 4;

                        if (tile.Transport == TransportType.Unknown)
                            drawingContext.DrawEllipse(Brushes.Black, null, new Point(left + halfmap.TileSize, top + halfmap.TileSize), quartermap.TileSize, quartermap.TileSize);
                        else if (tile.Transport == TransportType.Pit)
                            drawingContext.DrawEllipse(Brushes.Black, null, new Point(left + halfmap.TileSize, top + halfmap.TileSize), quartermap.TileSize, quartermap.TileSize);
                        else if (tile.Transport == TransportType.Portal)
                            drawingContext.DrawEllipse(Brushes.Black, null, new Point(left + halfmap.TileSize, top + halfmap.TileSize), quartermap.TileSize, quartermap.TileSize);
                    }*/
                }
            }

            left = map.Position.x * map.TileSize;
            top = (map.MaxIndexY - map.Position.y) * map.TileSize;

            // draw the position marker
            canvas.DrawRect(SKRect.Create(left + 1, top + 1, 3, 7), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });
            canvas.DrawRect(SKRect.Create(left + 1, top + 1, 7, 3), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });

            canvas.DrawRect(SKRect.Create(left + 1, top + map.TileSize - 6, 3, 7), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });
            canvas.DrawRect(SKRect.Create(left + 1, top + map.TileSize - 2, 7, 3), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });

            canvas.DrawRect(SKRect.Create(left + map.TileSize - 6, top + 1, 7, 3), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });
            canvas.DrawRect(SKRect.Create(left + map.TileSize - 2, top + 1, 3, 7), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });

            canvas.DrawRect(SKRect.Create(left + map.TileSize - 6, top + map.TileSize - 2, 7, 3), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });
            canvas.DrawRect(SKRect.Create(left + map.TileSize - 2, top + map.TileSize - 6, 3, 7), new SKPaint { Color = SKColors.Red, Style = SKPaintStyle.Fill });
        }
    }
}
