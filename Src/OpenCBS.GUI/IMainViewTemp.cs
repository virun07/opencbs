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

using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Clients;

namespace OpenCBS.GUI
{
    // This is a temporary interface that is implemented
    // by both LotrasmicMainWindowForm and MainView to be able to substitute
    // the new form where the old is expected.
    public interface ITempMainView
    {
        void ReloadAlerts();
        void ReloadAlertsSync();
        void SetInfoMessage(string message);
        void InitializePersonForm(Person person, Project project);
        void InitializeGroupForm(Group group, Project project);
        void InitializeCorporateForm(Corporate corporate, Project project);
        void InitializeVillageForm(Village village);
        void InitializeCreditContractForm(IClient client, int contractId);
        void InitializeSavingContractForm(IClient client, int savingId);
    }
}
