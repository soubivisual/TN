using System;
using TN.Client.Web.BlazorShared.Models;

namespace TN.Client.Components.Shared.Models.Components
{
	public class ComponentsTestModel : BaseModel
	{
        public ComponentsTestModel()
        {
            FirstStep = new();
            SecondStep = new();
        }

        public FirstStepModel FirstStep { get; set; }

        public SecondStepModel SecondStep { get; set; }

        public class FirstStepModel : BaseModel
        {
            public bool IsAdmin { get; set; }

            public string FirstInputTest { get; set; }
        }

        public class SecondStepModel : BaseModel
        {
            public string SecondInputTest { get; set; }
        }
    }
}

