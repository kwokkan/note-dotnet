using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public partial class Loadable<TModel>
    {
        [Parameter]
        public RenderFragment NotLoaded { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        [Parameter]
        public RenderFragment<TModel> Loaded { get; set; }

        [Parameter]
        public RenderFragment<Exception> Errored { get; set; }

        [Parameter]
        public Func<Task<TModel>> LoadFunc { get; set; }

        protected LoadingState State { get; set; }
        protected Exception Exception { get; set; }
        protected TModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync(LoadFunc);

            await base.OnInitializedAsync();
        }

        protected async Task LoadAsync(Func<Task<TModel>> action)
        {
            State = LoadingState.Loading;

            try
            {
                if (action != null)
                {
                    Model = await action();
                }

                State = LoadingState.Loaded;
            }
            catch (Exception e)
            {
                Exception = e;

                State = LoadingState.Errored;
            }
        }
    }
}
