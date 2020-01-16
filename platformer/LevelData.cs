using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace platformgame {
    public class LevelHelper {
        public static Dictionary<string, ArrayList> getItems(int level) {
            Dictionary<string, ArrayList> items = new Dictionary<string, ArrayList>();
            ArrayList platforms = new ArrayList();

            switch (level) {
                case 1 :
                    platforms.Add(new ScreenComponent(Color.Brown,0,772,"ground",1463,50));
                    platforms.Add(new ScreenComponent(Color.Brown,327,693,"platform1",150,50));
                    platforms.Add(new ScreenComponent(Color.Brown,518,582,"platform2",100,50));
                    platforms.Add(new ScreenComponent(Color.Brown,700,477,"platform3",250,50));
                    platforms.Add(new ScreenComponent(Color.Brown,420,357,"platform4",200,50));
                    platforms.Add(new ScreenComponent(Color.Brown,710,237,"platform5",50,50));
                    platforms.Add(new ScreenComponent(Color.Brown,910,237,"platform6",200,50));
                    platforms.Add(new ScreenComponent(Color.Brown,1193,143,"platform7",270,50));
                    break;
                default :
                    break;
            }
            items["platform"] = platforms;
            return items;
        }

        public static Dictionary<string, string> getImages() {
            Dictionary<string, string> images = new Dictionary<string, string>();
            images["platform"] = "platformer/public/platform.png";
            return images;
        }
    }
}