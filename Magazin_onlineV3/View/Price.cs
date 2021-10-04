using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.View
{
    class Price : Panel
    {
        public int Minim { get; private set; }
        public int Maxim { get; private set; }

        public Price()
        {
            Minim = 0;
            Maxim = 10000;
            layout();
        }

        public void layout()
        {
            Size = new Size(100, 150);
            Location = new Point(15, 15);
            BorderStyle = BorderStyle.None;
            setLabel();
            setSlide();
            setMin();
            setMax();
            setCheckBox();
        }

        public void setLabel()
        {
            Label lblPrice = new Label();
            lblPrice.AutoSize = true;
            lblPrice.Text = "Price:";
            lblPrice.Location = new Point(0, 0);
            lblPrice.Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);
            lblPrice.ForeColor = Color.White;
            Controls.Add(lblPrice);
        }

        public void setSlide()
        {
            TrackBar track = new TrackBar();
            track.Location = new Point(5, 120);
            track.Size = new Size(90, 30);
            track.Minimum = 0;
            track.Maximum = 10000;
            track.Name = "slide";
            track.BackColor = Color.White;
            track.ValueChanged += Track_ValueChanged;
            Controls.Add(track);
        }

        private void Track_ValueChanged(object sender, EventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            TextBox minim = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtMin")
                    minim = (TextBox)x;
            }
            minim.Text = track.Value.ToString();
            this.Minim = track.Value;
        }

        public void setMin()
        {
            TextBox minim = new TextBox();
            minim.Size = new Size(40, 20);
            minim.Location = new Point(5, 95);
            minim.Text = "0";
            minim.Name = "txtMin";
            minim.KeyPress += Minim_KeyPress;
            minim.TextChanged += Minim_TextChanged;
            Controls.Add(minim);
        }

        private void Minim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

        private void Minim_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "" && text.Text[0] != '0') 
            {
                TrackBar track = new TrackBar();
                foreach (Control x in Controls)
                {
                    if (x.Name == "slide")
                        track = x as TrackBar;
                }
                track.Minimum = int.Parse(text.Text);
                track.Value = int.Parse(text.Text);
                Minim = int.Parse(text.Text);
            }
        }

        public void setMax()
        {
            TextBox maxim = new TextBox();
            maxim.Size = new Size(40, 20);
            maxim.Location = new Point(55, 95);
            maxim.Text = "10000";
            maxim.Name = "txtMax";
            maxim.KeyPress += Maxim_KeyPress;
            maxim.TextChanged += Maxim_TextChanged;
            Controls.Add(maxim);
        }

        private void Maxim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

        private void Maxim_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "" && text.Text[0] != '0') 
            {
                TrackBar track = new TrackBar();
                foreach (Control x in Controls)
                {
                    if (x.Name == "slide")
                        track = x as TrackBar;
                }
                track.Maximum = int.Parse(text.Text);
                this.Maxim = track.Maximum;
            }
        }

        public void setCheckBox()
        {
            CheckedListBox checkBox = new CheckedListBox();
            checkBox.Name = "checkBox";
            checkBox.Location = new Point(4, 12);
            checkBox.Size = new Size(90, 79);
            checkBox.BorderStyle = BorderStyle.FixedSingle;

            checkBox.CheckOnClick = true;
            checkBox.SelectionMode = SelectionMode.One;

            checkBox.Items.Add("100 - 250", false);
            checkBox.Items.Add("250 - 700", false);
            checkBox.Items.Add("700 - 1500", false);
            checkBox.Items.Add("1500 - 3000", false);
            checkBox.Items.Add("3000 - 7000", false);

            checkBox.ItemCheck += CheckBox_ItemCheck;

            Controls.Add(checkBox);
        }

        private void CheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedList = (CheckedListBox)sender;
            if (e.NewValue == CheckState.Checked && checkedList.CheckedItems.Count > 0)
            {
                if (e.Index == 0)
                {
                    Minim = 100;
                    Maxim = 250;
                }
                else if (e.Index == 1)
                {
                    Minim = 250;
                    Maxim = 700;
                }
                else if (e.Index == 2)
                {
                    Minim = 700;
                    Maxim = 1500;
                }
                else if (e.Index == 3)
                {
                    Minim = 1500;
                    Maxim = 3000;
                }
                else if (e.Index == 4)
                {
                    Minim = 3000;
                    Maxim = 7000;
                }

                checkedList.ItemCheck -= CheckBox_ItemCheck;
                checkedList.SetItemChecked(checkedList.CheckedIndices[0], false);
                checkedList.ItemCheck += CheckBox_ItemCheck;
            }
            else if (e.NewValue == CheckState.Checked && checkedList.CheckedItems.Count == 0) 
            {
                if (e.Index == 0)
                {
                    Minim = 100;
                    Maxim = 250;
                }
                else if (e.Index == 1)
                {
                    Minim = 250;
                    Maxim = 700;
                }
                else if (e.Index == 2)
                {
                    Minim = 700;
                    Maxim = 1500;
                }
                else if (e.Index == 3)
                {
                    Minim = 1500;
                    Maxim = 3000;
                }
                else if (e.Index == 4)
                {
                    Minim = 3000;
                    Maxim = 7000;
                }
            }
            if(e.NewValue==CheckState.Unchecked)
            {
                Minim = 0;
                Maxim = 10000;
            }
        }
    }
}
