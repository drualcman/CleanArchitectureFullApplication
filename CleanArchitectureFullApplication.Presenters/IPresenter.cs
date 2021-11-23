using System;

namespace CleanArchitectureFullApplication.Presenters
{
    public interface IPresenter<ResponseType>
    {
        ResponseType Content { get; }
    }
}
