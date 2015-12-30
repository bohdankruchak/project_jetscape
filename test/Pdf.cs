using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxPDFXEdit;
using PDFXEdit;

namespace test
{
    public partial class Pdf : Form
    {
        public static int page_Width = 800;
        public static int page_Height = 1200;
        public static Workspace workspace_ob = new Workspace();
        public static int Rect_size = (page_Height - workspace_ob.field_ex.size_rect * 3) / workspace_ob.field_ex.size_rect;
        public static int height = workspace_ob.field_ex.heigth;
        public static int width = workspace_ob.field_ex.width;
        public static int keys_count = workspace_ob.keys.Count;
        public static PXC_Rect rc = new PXC_Rect();
        public static PXC_Rect rc_out = new PXC_Rect();

        public static double x = 0;
        public static double y = 0;

        public Pdf()
        {
            InitializeComponent();
        }

        private static uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }

        private static void Draw_Keys(ref IPXC_ContentCreator CC, ref IPXC_Page page)
        {
            for (int i = 1; i <= keys_count; i++)
            {
                int key_rect_top = page_Height - (i * Rect_size);
                int key_rect_bottom = page_Height - (i * Rect_size) - Rect_size;
                int key_rect_right = page_Width - Rect_size;
                int key_rect_left = Rect_size;
                Color current_key_color = workspace_ob.keys[i - 1].clr;

                CC.Rect(Rect_size, key_rect_bottom, key_rect_right / 2, key_rect_top);
                CC.SetFillColorRGB(ColorToUInt(Color.White));
                CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);

                CC.Rect(key_rect_right / 2, key_rect_bottom, key_rect_right, key_rect_top);
                CC.SetFillColorRGB(ColorToUInt(current_key_color));
                CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);

                page.PlaceContent(CC.Detach());
            }

            for (int i = 1; i <= keys_count; i++)
            {
                int key_rect_top = page_Height - (i * Rect_size);
                int key_rect_bottom = page_Height - (i * Rect_size) - Rect_size;
                int key_rect_right = page_Width - Rect_size;
                int key_rect_left = Rect_size;

                string current_key_text = workspace_ob.keys[i - 1].str;
                rc.top = key_rect_top - 10;
                rc.bottom = key_rect_top - 50;
                rc.left = key_rect_left + 150;
                rc.right = key_rect_right;

                CC.ShowTextBlock(current_key_text, ref rc, ref rc, 0, (int)-1, null, null, null, out rc_out);
                //CC.Rect(Rect_size, key_rect_bottom, key_rect_right / 2, key_rect_top);
                //CC.Rect(key_rect_right / 2, key_rect_bottom, key_rect_right, key_rect_top);

                page.PlaceContent(CC.Detach());

            }
        }

        private void Pdf_Shown(object sender, EventArgs ep)
        {
            
            AxPXV_Control apx = new AxPXV_Control();
            axPXV_Control1.CreateNewBlankDoc(page_Width, page_Height, 1);

            var page = axPXV_Control1.Doc.CoreDoc.Pages[0];
            var CC = axPXV_Control1.Doc.CoreDoc.CreateContentCreator();

            


            //CC.FillPath(true, true, PDFXEdit.PXC_FillRule.FillRule_EvenOdd);

            PXC_Rect rc = new PXC_Rect();
            PXC_Rect rc_out = new PXC_Rect();


            //for (int i = 1; i <= width; i++)
            //{
            //    for (int j = 1; j <= height; j++)
            //    {
            //        x = i * Rect_size + Rect_size;
            //        y = j * Rect_size + Rect_size;
            //        Color current_field_color = workspace_ob.field_ex.clr_fild[i - 1][j - 1];

            //        CC.Rect(x, y, Rect_size, Rect_size);
            //        CC.SetFillColorRGB(ColorToUInt(current_field_color));
            //        CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);
            //        //CC.SetLineWidth(0.5);
            //        //CC.StrokePath(true);
            //        //page.PlaceContent(CC.Detach());
            //    }
            //}

            for (int i = 1; i <= width + 1; i++)
            {
                CC.SetLineWidth(1);
                CC.MoveTo(i * Rect_size, Rect_size);
                CC.LineTo(i *Rect_size, Rect_size + (height * Rect_size));
                CC.StrokePath(true);
            }

            for (int i = 1; i <= height + 1; i++)
            {
                CC.SetLineWidth(1);
                CC.MoveTo(Rect_size,i * Rect_size);
                CC.LineTo(Rect_size + (width * Rect_size), i * Rect_size);
                CC.StrokePath(true);
            }

            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    x = i * Rect_size + Rect_size;
                    y = j * Rect_size + Rect_size;
                    Color current_field_color = workspace_ob.field_ex.clr_fild[i - 1][j - 1];


                    CC.Rect(x - Rect_size, y - Rect_size, x, y);
                    CC.SetFillColorRGB(ColorToUInt(Color.Blue));
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);
                    //CC.SetLineWidth(0.5);
                    CC.StrokePath(true);
                    //rc.bottom = height - y;
                    rc.top = y - (Rect_size / 4);
                    rc.left = x - (Rect_size / 1.5);
                    rc.right = Rect_size / 2 + x;

                    string current_text = workspace_ob.field_ex.str_fild[i-1][height - j];
                    CC.ShowTextBlock(current_text, ref rc, ref rc, 0, (int)-1, null, null, null, out rc_out);
                    CC.StrokePath(true);
                    page.PlaceContent(CC.Detach());
                }
            }


            Draw_Keys(ref CC, ref page);

            
            CC.SetLineWidth(0.5);
            CC.StrokePath(true);
            //page.PlaceContent(CC.Detach());

            axPXV_Control1.Refresh();
            axPXV_Control1.Update();

        }
    }
}
