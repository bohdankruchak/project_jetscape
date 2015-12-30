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
        public static int Rect_size = (page_Width ) / (workspace_ob.field_ex.size_rect - 8);
        public static int height = workspace_ob.field_ex.heigth;
        public static int width = workspace_ob.field_ex.width;
        public static int keys_count = workspace_ob.keys.Count;
        public static PXC_Rect rc = new PXC_Rect();
        public static PXC_Rect rc_out = new PXC_Rect();
        private bool isColor = false;

        public static double x = 0;
        public static double y = 0;

        public Pdf()
        {
            InitializeComponent();
        }

        private static void Draw_Keys(ref IPXC_ContentCreator CC, ref IPXC_Page page)
        {
            page_Width = 800;
            page_Height = 1200;
            Rect_size = (page_Width) / (workspace_ob.field_ex.size_rect - 8);
            height = workspace_ob.field_ex.heigth;
            width = workspace_ob.field_ex.width;
            keys_count = workspace_ob.keys.Count;

            

            CC.SetLineWidth(0.5);
            for (int i = 1, key_counter = 0; i <= keys_count && key_counter < keys_count; i++, key_counter++)
            {
                int key_rect_top = page_Height - (i * Rect_size);
                int key_rect_bottom = page_Height - (i * Rect_size) - Rect_size;
                int key_rect_right = page_Width - Rect_size;
                int key_rect_left = Rect_size;
                Color current_key_color = workspace_ob.keys[key_counter].clr;

                string current_key_text = workspace_ob.keys[key_counter].str;
                rc.top = key_rect_top;
                rc.bottom = key_rect_bottom;
                rc.left = Rect_size;
                rc.right = key_rect_right / 4;

                CC.Rect(rc.left, rc.bottom, rc.right, rc.top);
                CC.SetFillColorRGB(Get_UINT_Color(Color.White));
                CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);

                CC.SetFillColorRGB(Get_UINT_Color(Color.Black));
                CC.ShowTextBlock(current_key_text, ref rc, ref rc, (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                CC.Rect(key_rect_right / 4, key_rect_bottom, key_rect_right / 2 - 2, key_rect_top);
                CC.SetFillColorRGB(Get_UINT_Color(current_key_color));
                CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);

                page.PlaceContent(CC.Detach());
                try
                {
                    current_key_color = workspace_ob.keys[++key_counter].clr;

                    CC.Rect(key_rect_right / 2 + 2, key_rect_bottom, key_rect_right - (key_rect_right / 4), key_rect_top);
                    CC.SetFillColorRGB(Get_UINT_Color(Color.White));
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);

                    current_key_text = workspace_ob.keys[key_counter].str;
                    rc.top = key_rect_top;
                    rc.bottom = key_rect_bottom;
                    rc.left = key_rect_right / 2;
                    rc.right = key_rect_right - (key_rect_right / 4);

                    CC.SetFillColorRGB(Get_UINT_Color(Color.Black));
                    CC.ShowTextBlock(current_key_text, ref rc, ref rc, (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);

                    CC.Rect(key_rect_right - (key_rect_right / 4), key_rect_bottom, key_rect_right, key_rect_top);
                    CC.SetFillColorRGB(Get_UINT_Color(current_key_color));
                    CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);
                }
                catch { break; }
                page.PlaceContent(CC.Detach());
            }
        }

        private static uint Get_UINT_Color(Color current_field_color)
        {
            uint clgr = 0;
            return clgr = (uint)((byte)(current_field_color.R) | ((UInt16)((byte)(current_field_color.G)) << 8)) | 
                (((UInt32)(byte)(current_field_color.B)) << 16);
        }

        private void Pdf_Shown(object sender, EventArgs ep)
        {
            Redraw_PDF();

        }

        private void checkBox_with_color_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_with_color.Checked == true)
                isColor = true;
            else
                isColor = false;

            Redraw_PDF();
        }

        private void Redraw_PDF()
        {
            Rect_size = (page_Width) / (workspace_ob.field_ex.size_rect - 8);
            height = workspace_ob.field_ex.heigth;
            width = workspace_ob.field_ex.width;
            keys_count = workspace_ob.keys.Count;

            AxPXV_Control apx = new AxPXV_Control();
            axPXV_Control1.CreateNewBlankDoc(page_Width, page_Height, 1);

            var page = axPXV_Control1.Doc.CoreDoc.Pages[0];
            var CC = axPXV_Control1.Doc.CoreDoc.CreateContentCreator();

            PXC_Rect rc = new PXC_Rect();
            PXC_Rect rc_out = new PXC_Rect();

            for (int i = 1; i <= width + 1; i++)
            {
                CC.SetLineWidth(1);
                CC.MoveTo(i * Rect_size, Rect_size);
                CC.LineTo(i * Rect_size, Rect_size + (height * Rect_size));
                CC.StrokePath(true);
            }

            for (int i = 1; i <= height + 1; i++)
            {
                CC.SetLineWidth(1);
                CC.MoveTo(Rect_size, i * Rect_size);
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
                    rc.bottom = y - Rect_size;
                    rc.top = y;
                    rc.left = x - (Rect_size);
                    rc.right = x;


                    if (isColor)
                    {
                        CC.Rect(x - Rect_size, (height * Rect_size) - y + Rect_size * 2, x, (height * Rect_size) - y + Rect_size * 3);
                        CC.SetFillColorRGB(Get_UINT_Color(current_field_color));
                        CC.FillPath(true, true, PXC_FillRule.FillRule_EvenOdd);
                        CC.StrokePath(true);
                        page.PlaceContent(CC.Detach());

                        string current_text = workspace_ob.field_ex.str_fild[i - 1][height - j];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                    }
                    else
                    {
                        string current_text = workspace_ob.field_ex.str_fild[i - 1][height - j];
                        CC.SetFillColorRGB(Get_UINT_Color(Color.Black));
                        CC.ShowTextBlock(current_text, ref rc, ref rc,
                            (uint)PXC_DrawTextFlags.DTF_Center | (uint)PXC_DrawTextFlags.DTF_VCenter, (int)-1, null, null, null, out rc_out);
                    }
                    CC.StrokePath(true);
                    page.PlaceContent(CC.Detach());
                    CC.SetLineWidth(0.5);
                    CC.StrokePath(true);
                }
            }


            Draw_Keys(ref CC, ref page);


            CC.SetLineWidth(0.5);
            CC.StrokePath(true);
            //page.PlaceContent(CC.Detach());

            axPXV_Control1.Refresh();
            axPXV_Control1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF Files| *.pdf";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = "SmartColoring.pdf";
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                axPXV_Control1.Doc.CoreDoc.WriteToFile(path);
            }
        }
    }
}
