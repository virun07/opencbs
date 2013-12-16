
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

        bool AllowAdding { get; set; }
        bool AllowEditing { get; set; }
        bool AllowDeleting { get; set; }

        bool CanEdit { get; set; }
        bool CanDelete { get; set; }
        bool CanChangePassword { get; set; }

        int? SelectedUserId { get; }
        bool ShowDeleted { get; }
        IList<RoleDto> Roles { get; set; }
    }
}
