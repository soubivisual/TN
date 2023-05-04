using System;
using Microsoft.AspNetCore.Components;
using TN.Client.Web.BlazorShared.Models;

namespace TN.Client.Components.Shared.Models.Components
{
	public class ComponentsTestBase : ComponentBase
    {
        [Parameter] public string Action { get; set; }
        protected ComponentsTestModel Model = new ComponentsTestModel();

        protected async Task<bool> OnValidSubmit(BaseModel baseModel)
        {
            //try
            //{
                

                if (baseModel.GetType() == typeof(ComponentsTestModel.FirstStepModel))
                {

                }

                if (baseModel.GetType() == typeof(ComponentsTestModel.SecondStepModel))
                {
                    var model = (ComponentsTestModel.SecondStepModel)baseModel;

                    // El siguiente bloque de código se podrá quitar cuando se active la funcionalidad de OnScheduleEdit
                    // Inicio

                    //AlertMessage.Success = "Operación realizada exitosamente";
                    //NavigateTo("");
                    // Fin
                }

                return true;
            //}
            //catch (BaseException bex)
            //{
            //    AlertMessage.Warning = bex.ToString();
            //}
            //catch (Exception ex)
            //{
            //    AlertMessage.Error = ex.ToCustomString();
            //}

            //this.StateHasChanged();
            //return false;
        }
    }
}

