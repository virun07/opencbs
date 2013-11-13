
using System.Collections.Generic;
using OpenCBS.DataContract;
using OpenCBS.Interface.Presenter;

namespace OpenCBS.Interface.View
{
    public interface IUsersView : IView<IUsersPresenterCallbacks>
    {
        void Run();
        void Translate();
        void ShowUsers(IList<UserDto> users);
        bool CanEdit { get; set; }
        bool CanDelete { get; set; }
        int? SelectedUserId { get; }
        bool ShowDeleted { get; }
        IList<RoleDto> Roles { get; set; }
    }
}
