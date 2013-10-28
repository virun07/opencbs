// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// 
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using OpenCBS.GUI.NEW.Model;

namespace OpenCBS.GUI.NEW.View.LoanProduct.Page
{
    public partial class GeneralPage : ErrorProviderAwareControl
    {
        public GeneralPage()
        {
            InitializeComponent();
            Setup();
        }

        public string LoanProductName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public string Code
        {
            get { return _codeTextBox.Text; }
            set { _codeTextBox.Text = value; }
        }

        public AvailableFor AvailableFor
        {
            get
            {
                var result = AvailableFor.None;
                if (_availableForIndividualCheckBox.Checked) result |= AvailableFor.Individual;
                if (_availableForSgCheckBox.Checked) result |= AvailableFor.SolidarityGroup;
                if (_availableForNsgCheckBox.Checked) result |= AvailableFor.NonSolidarityGroup;
                if (_availableForCompanyCheckBox.Checked) result |= AvailableFor.Company;
                return result;
            }

            set
            {
                _availableForIndividualCheckBox.Checked = (value & AvailableFor.Individual) == AvailableFor.Individual;
                _availableForSgCheckBox.Checked = (value & AvailableFor.SolidarityGroup) == AvailableFor.SolidarityGroup;
                _availableForNsgCheckBox.Checked = (value & AvailableFor.NonSolidarityGroup) == AvailableFor.NonSolidarityGroup;
                _availableForCompanyCheckBox.Checked = (value & AvailableFor.Company) == AvailableFor.Company;
            }
        }

        private void Setup()
        {
            _nameTextBox.TextChanged += (sender, e) => ClearError(_nameTextBox);
            _codeTextBox.TextChanged += (sender, e) => ClearError(_codeTextBox);
        }
    }
}
