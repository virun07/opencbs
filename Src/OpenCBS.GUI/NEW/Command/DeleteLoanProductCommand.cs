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

using OpenCBS.GUI.NEW.AppController;
using OpenCBS.GUI.NEW.CommandData;
using OpenCBS.GUI.NEW.Event;
using OpenCBS.GUI.NEW.Service;

namespace OpenCBS.GUI.NEW.Command
{
    public class DeleteLoanProductCommand : ICommand<DeleteLoanProductData>
    {
        private readonly ILoanProductService _loanProductService;
        private readonly IApplicationController _appController;

        public DeleteLoanProductCommand(ILoanProductService loanProductService, IApplicationController appController)
        {
            _loanProductService = loanProductService;
            _appController = appController;
        }

        public void Execute(DeleteLoanProductData commandData)
        {
            _loanProductService.Remove(commandData.Id);
            _appController.Raise(new LoanProductDeletedEvent { Id = commandData.Id });
        }
    }
}
