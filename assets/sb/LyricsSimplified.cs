using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class LyricsSimplified : StoryboardObjectGenerator
    {
        [Configurable] public string SubtitlesPath;
        [Configurable] public string FontName = "Verdana";
        [Configurable] public int PosX = 320;
        [Configurable] public int PosY = 240;
        SubtitleSet Subtitles;
        FontGenerator Font;
        public override void Generate()
        {
            //Set the private variable subtitle to the subtitlefile info
		    Subtitles = LoadSubtitles(SubtitlesPath);

            //Set the Font variable to the right fontGenerator
            Font = SetFont();

            //This launch the function for rendering our lyrics!
            GenerateSubtitles();
        }
        private FontGenerator SetFont()
        {
            //these line create a FontGenerator object that have the font parameters you want to be generated
            //this load the fontName, style, color, size etc etc... everything you see in the sb/f folder stuff is stored in that object
            var font = LoadFont("sb/f", new FontDescription{
                FontPath = FontName,
                FontSize = 100,
                Color = Color4.White
            });

            //after setting the font we simply return it to the function! (this is why I can do Font = SetFont())
            return font;
        }
        private void GenerateSubtitles()
        {
            //First we loop into every lines of our lyrics file!
            foreach(var line in Subtitles.Lines)
            {
                //For each line we're gonna set a base position to X = PosX & Y = PosY
                //and also a scale that is set to 0.3 to not have stretched up sprites!
                float LetterX = PosX;
                float LetterY = PosY;
                float scale = 0.3f;

                //Once we're done with setting up all this things we're gonna split our lines into letters (HELLO WORLDS => H, E, L, L, O... etc..)
                foreach(var letter in line.Text)
                {
                    //so for each letter we link a texture, which, is the thing that gonna use the Font object we've created earlier to generate our sprite!!
                    var texture = Font.GetTexture(letter.ToString());

                    //We check if the texture isn't empty (white spaces)
                    if(!texture.IsEmpty)
                    {
                        //We set the position of each letter, and add an offset for them (to fix not aligned stuffs!)
                        var position = new Vector2(LetterX, LetterY)
                            + texture.OffsetFor(OsbOrigin.TopCentre) * scale;

                        //Now we're good! we can finally code our sprite methods! :)
                        var sprite = GetLayer("Foreground").CreateSprite(texture.Path, OsbOrigin.Centre, position);
                        sprite.Fade(line.StartTime, line.EndTime, 1, 1);
                        sprite.Scale(line.StartTime, scale);
                    }
                    //don't forget to move your letter position after each new letter!
                    LetterX += texture.BaseWidth * scale;
                }
            }
        }
    }
}
