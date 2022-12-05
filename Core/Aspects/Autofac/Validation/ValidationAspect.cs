using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //eger gonderilen validatior type bir validator degilse kiz
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a Validation class");
            }

            //hata almazsa validatortype benim gonderdigimdir
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //calisma aninda bir seyleri calistirmayi saglar reflektion
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validatiortype base typeni bul daha sonra ilkini bul ve 
            //onun parametlerini bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //methodun parametlerine bak validatirin tipine esit olanlari bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
           //her birini tek tek gez birden fazla olabilir
            foreach (var entity in entities)
            {
                //validation tool kullanarak validete et
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
