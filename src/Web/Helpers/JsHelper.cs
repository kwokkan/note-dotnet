using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace NoteDotNet.Web.Helpers
{
    public class JsHelper : IJsHelper
    {
        private readonly IJSRuntime _jSRuntime;

        public JsHelper(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        ValueTask IJsHelper.CloseModal(string id)
        {
            return _jSRuntime.InvokeVoidAsync("modalClose", id);
        }

        ValueTask IJsHelper.ShowModal(string id)
        {
            return _jSRuntime.InvokeVoidAsync("modalShow", id);
        }
    }
}
