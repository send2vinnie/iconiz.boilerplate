﻿using System.Threading.Tasks;
using Iconiz.Boilerplate.Views;
using Xamarin.Forms;

namespace Iconiz.Boilerplate.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
