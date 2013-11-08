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

using System.Windows.Forms;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Interface.Presenter;
using StructureMap;

namespace OpenCBS.GUI
{
    public class AppContext : ApplicationContext
    {
        private readonly IContainer _container;

        public AppContext(IContainer container)
        {
            _container = container;
            MainForm = GetLoginForm();
        }

        private Form GetLoginForm()
        {
            var presenter = _container.GetInstance<ILoginPresenter>();
            presenter.Run();

            return (Form) presenter.View;
        }

        private Form GetMainForm()
        {
            var presenter = _container.GetInstance<IMainPresenter>();
            presenter.Run();
            return (Form) presenter.View;
        }

        protected override void OnMainFormClosed(object sender, System.EventArgs e)
        {
            if (sender is ILoginView)
            {
                var userService = _container.GetInstance<IUserService>();
                if (userService.IsLoggedIn())
                    MainForm = GetMainForm();
                else
                    base.OnMainFormClosed(sender, e);
            }
            else if (sender is IMainView)
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
