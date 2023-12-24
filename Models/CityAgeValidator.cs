using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace BlazorSV.Models
{
    public class CityAgeValidator : ComponentBase
    {
        [Parameter]
        public string City { get; set; }

        [Parameter]
        public int Age { get; set; }

        [CascadingParameter]
        public EditContext EC { get; set; }

        protected override void OnInitialized()
        {
            ValidationMessageStore store = new ValidationMessageStore(EC);
            EC.OnFieldChanged += (sender, args) =>
            {
                string name = args.FieldIdentifier.FieldName;
                if (name == "City" || name == "Age")
                {
                    Validate(EC.Model as Employee, store);
                }
            };
        }

        private void Validate(Employee model, ValidationMessageStore store)
        {
            if (model.City == City && (model.Age == Age))
            {
                string message = City + " does not allow " + Age + " years person for job";
                store.Add(EC.Field("Age"), message);
            }
            else
                store.Clear();
            EC.NotifyValidationStateChanged();
        }
    }
}
