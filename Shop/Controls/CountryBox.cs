using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Controls
{
    public class CountryBox : System.Windows.Forms.ComboBox
    {
        private System.Windows.Forms.ImageList ImageList;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryBox));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Austria");
            this.ImageList.Images.SetKeyName(1, "Canada");
            this.ImageList.Images.SetKeyName(2, "France");

            foreach (string key in this.ImageList.Images.Keys)
            {
                this.Items.Add(key);
            }

            this.ResumeLayout(false);

        }

        public CountryBox()
        {
            InitializeComponent();
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        protected override void OnMeasureItem(System.Windows.Forms.MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
            base.OnMeasureItem(e);
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            bool isSelected = (e.State & System.Windows.Forms.DrawItemState.Selected) == System.Windows.Forms.DrawItemState.Selected;

            string key = this.Items[e.Index].ToString();
            e.Graphics.DrawString(key,
                this.Font,
                isSelected ? SystemBrushes.HighlightText : SystemBrushes.ControlText,
                new Rectangle(e.Bounds.X + 24, e.Bounds.Y, e.Bounds.Width - 24, e.Bounds.Height),
                new StringFormat() { LineAlignment = StringAlignment.Center });

            e.Graphics.DrawImage(this.ImageList.Images[key],
                e.Bounds.X,
                e.Bounds.Y);

            base.OnDrawItem(e);
        }
    }
}
