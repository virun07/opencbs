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

using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.DataContract;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.View
{
    public partial class CurrenciesView : BaseView, ICurrenciesView
    {
        public CurrenciesView()
        {
            InitializeComponent();
            MdiParent = Application.OpenForms[0];
        }

        public void Run()
        {
            Show();
        }

        public void ShowCurrencies(IList<CurrencyDto> currencies)
        {
            _currenciesListView.SetObjects(currencies);
        }

        public void Attach(ICurrenciesPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
        }
    }
}
