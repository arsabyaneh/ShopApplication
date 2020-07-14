using Shop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Dialogs
{
    public partial class CustomerDialog : Form
    {
        public CustomerDialog()
        {
            InitializeComponent();
        }

        private Customer _Value;
        public Customer Value
        {
            get
            {
                if (_Value == null)
                    _Value = new Customer();

                _Value.Code = this.Code.Text;
                _Value.FirstName = this.FirstName.Text;
                _Value.LastName = this.LastName.Text;
                _Value.Gender = this.Male.Checked ? Gender.Male : Gender.Female;
                _Value.BirthDate = this.BirthDate.Value;
                _Value.Country = this.Country.SelectedItem.ToString();
                _Value.Telephone = this.Telephone.Text;
                _Value.Email = this.Email.Text;
                _Value.Address = this.Address.Text;

                return _Value;
            }
            set
            {
                _Value = value;

                if (_Value == null)
                    return;

                this.Code.Text = _Value.Code;
                this.FirstName.Text = _Value.FirstName;
                this.LastName.Text = _Value.LastName;
                this.Male.Checked = (_Value.Gender == Gender.Male);
                this.Female.Checked = (_Value.Gender == Gender.Female);
                this.BirthDate.Value = _Value.BirthDate;
                this.Country.SelectedIndex = FindSelectedIndexOfCountry(_Value.Country);
                this.Telephone.Text = _Value.Telephone;
                this.Email.Text = _Value.Email;
                this.Address.Text = _Value.Address;
            }
        }

        private int FindSelectedIndexOfCountry(string name)
        {
            for (int i = 0; i < this.Country.Items.Count; i++)
            {
                if (this.Country.Items[i].ToString() == name)
                    return i;
            }

            return 0;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
