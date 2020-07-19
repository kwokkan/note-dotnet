using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public class LoadableComponentBase<TModel> : ComponentBase
    {
        [Parameter]
        public RenderFragment NotLoaded { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        [Parameter]
        public RenderFragment<TModel> Loaded { get; set; }

        [Parameter]
        public RenderFragment Errored { get; set; }

        protected LoadingState State { get; set; }
        protected Exception Exception { get; set; }
        protected TModel Model { get; set; }

        protected async Task LoadAsync(Func<Task<TModel>> action)
        {
            State = LoadingState.Loading;

            try
            {
                Model = await action();

                State = LoadingState.Loaded;
            }
            catch (Exception e)
            {
                Exception = e;

                State = LoadingState.Errored;
            }

            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            switch (State)
            {
                case LoadingState.NotLoaded:
                    builder.AddContent((int)State, NotLoaded);
                    break;
                case LoadingState.Loading:
                    builder.AddContent((int)State, Loading);
                    break;
                case LoadingState.Loaded:
                    builder.AddContent((int)State, Loaded);
                    break;
                case LoadingState.Errored:
                    builder.AddContent((int)State, Errored);
                    break;
                default:
                    break;
            }

        }
    }
}
