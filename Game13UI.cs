
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using ThanaNita.MonoGameTnt;

namespace Game13
{
    public class Game13UI : Game2D
    {
        ProgressBar hpBar;
        Text text;
        string str;
        protected override void LoadContent()
        {
            // 1.1
            hpBar = new ProgressBar(size: new Vector2(200, 20), max: 100, Color.Black, Color.Green);
            hpBar.Position = new Vector2(50, 50);
            hpBar.Value = 70;
            All.Add(hpBar);

            // 1.2
            text = new Text("Trirong-Regular.ttf", 75, Color.White, "Text:") { Position = new(100,100)};
            str = "abcd ทดสอบ Thanakit --- abcd ทดสอบ Chatwichian --- \nabcd ทดสอบ Jet ---";
            All.Add(text);
            // 1.3
            var nineRect = new NinePatchRect(
                                new TextureRegion(TextureCache.Get("Items.jpg"), new RectF(300, 300, 300, 300)), 
                                offset1: new Vector2(80, 80));
            nineRect.SetSize(new Vector2(1000, 600));
            nineRect.Origin = nineRect.RawSize / 2;
            nineRect.Position = ScreenSize / 2;
            All.Add(nineRect);

            // 1.4
            var puppyTexture = TextureCache.Get("Puppy.jpg");
            var morph = new MorphActor(puppyTexture, Vector2.Zero,
                positions: [new Vector2(200, 0), new Vector2(0, 400), new Vector2(400, 400)],
                indices: [0, 1, 2]);
            morph.Origin = morph.RawSize / 2;
            morph.Position = ScreenSize / 2;
            All.Add(morph);
        }
        protected override void Update(float deltaTime)
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            // 1.1
            if (keyInfo.IsKeyDown(Keys.Right))
                hpBar.Value += 1;
            if (keyInfo.IsKeyDown(Keys.Left))
                hpBar.Value -= 1;
            // 1.2
            if (keyInfo.IsKeyPressed(Keys.Space))
                text.AddAction(new TextAnimation(text, str, 45));

        }
    }
}
