using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace platformgame {
    public class LevelHelper {
        public static Dictionary<string, ArrayList> getItems(int level) {
            Dictionary<string, ArrayList> items = new Dictionary<string, ArrayList>();
            ArrayList platforms = new ArrayList();
            ArrayList buttons = new ArrayList();
            ArrayList interactivePlatforms = new ArrayList();
            ArrayList spikes = new ArrayList();
            ArrayList interactiveSpikes = new ArrayList();
            ArrayList ending = new ArrayList();

            switch (level) {
                case 1 :
                    platforms.Add(new ScreenComponent(0,772,"ground",1463,50));
                    platforms.Add(new ScreenComponent(327,693,"platform1",150,50));
                    platforms.Add(new ScreenComponent(518,582,"platform2",100,50));
                    platforms.Add(new ScreenComponent(700,477,"platform3",250,50));
                    platforms.Add(new ScreenComponent(420,357,"platform4",200,50));
                    platforms.Add(new ScreenComponent(710,237,"platform5",50,50));
                    platforms.Add(new ScreenComponent(910,237,"platform6",200,50));
                    platforms.Add(new ScreenComponent(1193,143,"platform7",270,50));
                    ending.Add(new ScreenComponent(1366,47, "ending",98,100));
                    break;
                case 2 :
                    platforms.Add(new ScreenComponent(0,772,"ground",300,50));
                    interactivePlatforms.Add(new ScreenComponent(327,663,"interactivePlatform1",200,50));
                    buttons.Add(new InteractiveButton(227,715,"button1",50,50, "interactivePlatform1", false));
                    platforms.Add(new ScreenComponent(82,571,"platform1",150,50));
                    interactivePlatforms.Add(new ScreenComponent(477,582,"interactivePlatform2",50,50));
                    buttons.Add(new InteractiveButton(82,514,"button2",50,50, "interactivePlatform2", false));
                    platforms.Add(new ScreenComponent(377,501,"platform2",150,50));
                    interactivePlatforms.Add(new ScreenComponent(612,571,"interactivePlatform3",50,50));
                    buttons.Add(new InteractiveButton(542,501,"button3",50,50, "interactivePlatform3", false));
                    platforms.Add(new ScreenComponent(1193,143,"platform7",270,50));
                    interactivePlatforms.Add(new ScreenComponent(577,381,"interactivePlatform4",300,50));
                    buttons.Add(new InteractiveButton(577,324,"button4",50,50, "interactivePlatform4", true));
                    interactivePlatforms.Add(new ScreenComponent(970,262,"interactivePlatform5",150,50));
                    buttons.Add(new InteractiveButton(727,324,"button5",50,50, "interactivePlatform5", false));
                    ending.Add(new ScreenComponent(1366,47, "ending",98,100));
                    break;
                case 3 :
                    platforms.Add(new ScreenComponent(0,772,"platform1",200,50));
                    platforms.Add(new ScreenComponent(230,693,"platform2",150,50));
                    interactiveSpikes.Add(new ScreenComponent(230, 643, "interactiveSpike1", 150, 50));
                    buttons.Add(new InteractiveButton(125,715,"button1",50,50, "interactiveSpike1", true));
                    ending.Add(new ScreenComponent(1366,47, "ending",98,100));
                    break;
                default :
                    break;
            }
            items["platform"] = platforms;
            items["button"] = buttons;
            items["interactivePlatform"] = interactivePlatforms;
            items["spikes"] = spikes;
            items["interactiveSpikes"] = interactiveSpikes;
            items["ending"] = ending;
            return items;
        }

        public static Dictionary<string, string> getImages() {
            Dictionary<string, string> images = new Dictionary<string, string>();
            images["platform"] = "platformer/public/platform.png";
            images["button"] = "platformer/public/button.png";
            images["interactivePlatform"] = "platformer/public/platform.png";
            images["ending"] = "platformer/public/door.png";
            images["spikes"] = "platformer/public/platform.png";
            images["interactiveSpikes"] = "platformer/public/platform.png";
            return images;
        }
    }
}