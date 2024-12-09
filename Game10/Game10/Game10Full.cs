using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using ThanaNita.MonoGameTnt;

namespace Game10
{
    public class Game10 : Game2D
    {
        TextureRegion[] tiles;
        TileMap tileMap;
        Player player;

        private Actor visual;
        private readonly Vector2 tileSize = new Vector2(128, 128);

        // private string currentRoom = "mainRoom";

        // private readonly Dictionary<string, (int[,] layout, string[] transitions)> rooms =
        //     new Dictionary<string, (int[,] layout, string[] transitions)>()
        //     {
        //         {
        //             "mainRoom",
        //             (
        //                 new int[4, 4]
        //                 {
        //                     { 1, 2, 3, 1 },
        //                     { 1, 1, 1, 1 },
        //                     { 1, 1, 1, 1 },
        //                     { 1, 1, 1, 4 } // Door to room1
        //                 },
        //                 new string[] { "room1" } // Transitions available from this room
        //             )
        //         },
        //         {
        //             "room1",
        //             (
        //                 new int[4, 4]
        //                 {
        //                     { 1, 4, 1, 1 },
        //                     { 1, 1, 1, 1 }, // 4 goes back to main room, 5 goes to room2
        //                     { 1, 1, 1, 1 },
        //                     { 1, 1, 1, 5 }
        //                 },
        //                 new string[] { "mainRoom", "room2" } // Transitions available from this room
        //             )
        //         },
        //         {
        //             "room2",
        //             (
        //                 new int[4, 4]
        //                 {
        //                     { 1, 4, 1, 1 },
        //                     { 1, 1, 1, 1 }, // 4 goes back to room1
        //                     { 1, 1, 1, 1 },
        //                     { 1, 1, 1, 1 }
        //                 },
        //                 new string[] { "room1" } // Transitions available from this room
        //             )
        //         }
        //     };

        protected override void LoadContent()
        {
            BackgroundColor = Color.Black;

            visual = new Actor { Position = new Vector2(0, 0) };
            //All.Add(visual);

            var builder = new TileMapBuilder();
            // 1. load map1
            // var colision_map1 = builder.CreateSimple("/resource/colision.png", new Vector2(32, 32), 6, 1, "/tilemap/level_1_colision.csv");
            var floor_map1 = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png",new Vector2(32, 32),76,109,"Content/resource/tilemap/level_1_floor.csv");
            // floor_map1.ShowGrid = true; //show grid
            var wall_map1 = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png",new Vector2(32, 32),76,109,"Content/resource/tilemap/level_1_wall.csv");
            var clothing_map1 = builder.CreateSimple("Content/resource/tileset/21_Clothing_Store_32x32.png",new Vector2(32, 32),16,67,"Content/resource/tilemap/level_1_clothing.csv");
            var gym_map1 = builder.CreateSimple("Content/resource/tileset/8_Gym_32x32.png",new Vector2(32, 32),16,33,"Content/resource/tilemap/level_1_gym.csv");
            var kitchen_map1 = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png",new Vector2(32, 32),16,49,"Content/resource/tilemap/level_1_kitchen.csv");
            var museum_map1 = builder.CreateSimple("Content/resource/tileset/22_Museum_32x32.png",new Vector2(32, 32),16,122,"Content/resource/tilemap/level_1_museum.csv");
            var Hospital_map1 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png",new Vector2(32, 32),16,110,"Content/resource/tilemap/level_1_Hospital.csv");
            var generic_map1 = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png",new Vector2(32, 32),16,78,"Content/resource/tilemap/level_1_generic.csv");
            var television_map1 = builder.CreateSimple("Content/resource/tileset/23_Television_and_Film_Studio_32x32.png",new Vector2(32, 32),16,14,"Content/resource/tilemap/level_1_television.csv");
            var office_map1 = builder.CreateSimple("Content/resource/tileset/Modern_Office_Black_Shadow_32x32.png",new Vector2(32, 32),16,53,"Content/resource/tilemap/level_1_office.csv");

            
            visual.Add(floor_map1);
            visual.Add(wall_map1);
            visual.Add(clothing_map1);
            visual.Add(gym_map1);
            visual.Add(kitchen_map1);
            visual.Add(museum_map1);
            visual.Add(Hospital_map1);
            visual.Add(generic_map1);
            visual.Add(television_map1);
            visual.Add(office_map1);
            // visual.Add(colision_map1);



            // PrepareTileSet();

            // Load initial room (mainRoom)
            // LoadRoom("mainRoom");

            // Create player last to ensure it's on top
            var player = new Player { Position = tileSize / 2 };

            var sorter = new TileMapSorter();
            sorter.Add(player);

            visual.Add(sorter);

            All.Add(visual);
        }

        protected override void Update(float deltaTime)
        {
            //keyQueue.EnqueueAll(GlobalKeyboardInfo.Value.GetPressedKeys());
            SmoothMovement();
            motion.Act(deltaTime);

            // Check for room transitions when motion is finished
            // if (motion.IsFinished())
            // {
            //     CheckRoomTransition();
            // }
        }

        // private void CheckRoomTransition()
        // {
        //     int currentTile = tileMap.GetTileCode(tileMap.CalcIndex(player.Position));

        //     // Get available transitions for current room
        //     var availableTransitions = rooms[currentRoom].transitions;

        //     switch (currentRoom)
        //     {
        //         case "mainRoom":
        //             if (currentTile == 4) // Door to room1
        //             {
        //                 ChangeRoom("room1");
        //             }
        //             break;

        //         case "room1":
        //             if (currentTile == 4) // Door back to main room
        //             {
        //                 ChangeRoom("mainRoom");
        //             }
        //             else if (currentTile == 5) // Door to room2
        //             {
        //                 ChangeRoom("room2");
        //             }
        //             break;

        //         case "room2":
        //             if (currentTile == 4) // Door back to room1
        //             {
        //                 ChangeRoom("room1");
        //             }
        //             break;
        //     }
        // }

        // private void ChangeRoom(string newRoom)
        // {
        //     if (!rooms.ContainsKey(newRoom))
        //         return;

        //     currentRoom = newRoom;

        //     // Remove existing actors
        //     visual.Remove(player);
        //     visual.Remove(tileMap);

        //     // Load new room
        //     LoadRoom(newRoom);

        //     // Reset player position and add back on top
        //     player.Position = tileSize / 2;
        //     visual.Add(player);

        //     // Reset movement
        //     motion = LinearMotion.Empty();
        //     keyQueue = new KeyQueue();
        // }

        // private void LoadRoom(string roomName)
        // {
        //     if (!rooms.ContainsKey(roomName))
        //         return;

        //     var roomLayout = rooms[roomName].layout;
        //     tileMap = new TileMap(tileSize, roomLayout, CreateTile);
        //     visual.Add(tileMap);
        // }

        // private bool IsPlayerOnTileCode(int tileCode)
        // {
        //     Vector2i playerTileIndex = tileMap.CalcIndex(player.Position);
        //     return tileMap.GetTileCode(playerTileIndex) == tileCode;
        // }

        // private void PrepareTileSet()
        // {
        //     var texture = TextureCache.Get("TileSet.png");
        //     tiles = RegionSelector.SelectAll(
        //         RegionCutter.Cut(texture, new Vector2(32, 32), 14, 25)
        //     );
        // }

        private Actor CreateTile(int tileCode)
        {
            var sprite = new SpriteActor(tiles[tileCode])
            {
                Origin = tiles[tileCode].Size / 2,
                Scale = new Vector2(4, 4)
            };
            return sprite;
        }

        KeyQueue keyQueue = new KeyQueue();
        LinearMotion motion = LinearMotion.Empty();

        private void LoadNewMap(int[,] layout)
        {
            if (tileMap != null && visual != null)
            {
                visual.Remove(tileMap);
            }
            tileMap = new TileMap(tileSize, layout, CreateTile);
        }

        private void SmoothMovement()
        {
            if (!motion.IsFinished()) // ถ้าไม่มีบรรทัดนี้ จะกดคีย์ใหม่ก่อนเคลื่อนที่เสร็จได้
            {
                var command1 = keyQueue.PeekCommand();
                if (command1.IsOpposite(motion.Direction))
                    UnstableMoveOpposite(keyQueue.GetCommand().Direction);
                return;
            }

            var command = keyQueue.GetCommand();
            Vector2 direction = Vector2.Zero;
            if (command.HasCommand())
                direction = command.Direction;
            else
            {
                direction = DirectionKey.Direction4;
                //if (DirectionKey.Direction4 == Vector2.Zero)
                //    direction = motion.Direction;
            }

            StableMove(direction);
        }

        private void StableMove(Vector2 direction)
        {
            if (!IsAllowMove(direction))
                direction = new Vector2(0, 0);

            if (motion.Direction == Vector2.Zero && direction == Vector2.Zero)
                return; // ถ้าหยุดอยู่แล้ว ไม่ต้องหยุดซ้ำ

            if (direction != motion.Direction)
                motion.ToPreciseTarget(); // ปรับตำแหน่งให้พอดีศูนย์กลาง (กรณี FPS ต่ำๆ)

            CreateMotion(player.Position, direction);
        }

        private void UnstableMoveOpposite(Vector2 direction)
        {
            CreateMotion(motion.TargetPosition, direction);
        }

        private void CreateMotion(Vector2 oldPosition, Vector2 direction)
        {
            var targetPosition = tileMap.TileCenter(oldPosition, direction);
            motion = new LinearMotion(player, speed: 300, targetPosition, direction);
        }

        private bool IsAllowMove(Vector2 direction)
        {
            Vector2i index = tileMap.CalcIndex(player.Position, direction);
            return tileMap.IsInside(index) && IsAllowTile(index);
        }

        private bool IsAllowTile(Vector2i index)
        {
            int tileCode = tileMap.GetTileCode(index);
            return tileCode != 2 && tileCode != 3;
        }
    }
}
