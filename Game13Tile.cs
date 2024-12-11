
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Game13
{
    public class Game13Tile : Game2D
    {
        CameraMan cameraMan;
        protected override void LoadContent()
        {
            BackgroundColor = Color.LightGray;

            var builder = new TileMapBuilder();
            // 1. tileMap1
            //var tileMap1 = builder.CreateSimple("TileSet.png", new Vector2(32,32),14,25,"TileMap1.csv");
            var floor2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_floor.csv");
            var floor2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 6, 1, "Content/resource/tilemap/level_2_colision.csv");
            var floor2_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_wall.csv");
            var floor2_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/level_2_hospital.csv");
            var floor2_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/level_2_generic.csv");
            var floor2_kitchen = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png", new Vector2(32, 32), 16, 49, "Content/resource/tilemap/level_2_kitchen.csv");




            // 3. guy
            var guy = new Guy(floor2_colision);
            //int[] prohibitTiles = [104, 105, 118, 119];
            int[] prohibitTiles = [0];
            guy.ProhibitTiles = prohibitTiles;
            guy.Position = floor2_floor.TileCenter(5, 5);

           

            // 5. cameraMan
            cameraMan = new CameraMan(Camera, ScreenSize);
            cameraMan.FrameLimit = new RectF(ScreenSize).CreateExpand(new Vector2(-500, -400));
            guy.Add(cameraMan);

            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(2, 2);
            visual.Add(floor2_floor);
            visual.Add(floor2_wall);
            visual.Add(floor2_hospital);
            visual.Add(floor2_generic);
            visual.Add(floor2_kitchen);
            visual.Add(floor2_colision);

            var sorter = new TileMapSorter();
            sorter.Add(guy); // girl
            //sorter.Add(tree);
            visual.Add(sorter);

            All.Add(visual);
        }
        protected override void AfterUpdateAndCollision()
        {
            if (cameraMan != null)
                cameraMan.AdjustCamera();
        }
       

    }
}
