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

using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.View
{
    public partial class EntryFeeView : BaseView, IEntryFeeView
    {
        public EntryFeeView(ITranslator translator)
            : base(translator)
        {
            InitializeComponent();
        }

        public void Attach(IEntryFeePresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Ok();
            _cancelButton.Click += (sender, e) => presenterCallbacks.Cancel();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        public int Id { get; set; }

        public string EntryFeeName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public string Code
        {
            get { return _codeTextBox.Text; }
            set { _codeTextBox.Text = value; }
        }

        public decimal? ValueMin
        {
            get { return _valueRange.Min; }
            set { _valueRange.Min = value; }
        }

        public decimal? ValueMax
        {
            get { return _valueRange.Max; }
            set { _valueRange.Max = value; }
        }

        public bool Rate
        {
            get { return _rateRadioButton.Checked; }
            set
            {
                if (value)
                    _rateRadioButton.Checked = true;
                else
                    _amountRadioButton.Checked = true;
            }
        }
    }
}
