
using OpenCBS.Interface.Presenter;

namespace OpenCBS.Interface.View
{
    public interface IUsersView : IView<IUsersPresenterCallbacks>
    {
        void Run();
    }
}
