using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace HiddenSolutionsClient.Components
{

    public interface IBaseComponent
    {
        string Id { get; set; }
        string Name { get; set; }
        IDictionary<string, string> Style { get; set; }
    }
    
    public abstract class BaseComponent:IBaseComponent
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Name { get; set; }
        
        [Parameter]
        public IDictionary<string, string> Style { get; set; }
    }
}