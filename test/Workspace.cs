using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Workspace
    {
        public struct field
        {
            int heigth;
            int width;
            List<List<SolidBrush>> clr_fild = new List<List<SolidBrush>>();
            List<List<string>> clr_fild = new List<List<string>>();
        };
        public field field_ex = new field(); 
        Workspace(int height = 20, int width = 20)
        {
            slot_for_color[0] = new Rectangle(0, 0, 50, 20);
            slot_for_color[1] = new Rectangle(0, 25, 50, 20);
            slot_for_color[2] = new Rectangle(0, 50, 50, 20);
            slot_for_color[3] = new Rectangle(0, 75, 50, 20);
            slot_for_color[4] = new Rectangle(0, 100, 50, 20);
            slot_for_color[5] = new Rectangle(55, 0, 50, 20);
            slot_for_color[6] = new Rectangle(55, 25, 50, 20);
            slot_for_color[7] = new Rectangle(55, 50, 50, 20);
            slot_for_color[8] = new Rectangle(55, 75, 50, 20);
            slot_for_color[9] = new Rectangle(55, 100, 50, 20);
            
        }
       
        
        Rectangle[] slot_for_color = new Rectangle[10];
    }
    
}
