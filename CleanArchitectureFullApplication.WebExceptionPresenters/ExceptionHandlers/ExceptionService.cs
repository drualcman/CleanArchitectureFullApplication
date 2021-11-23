using CleanArchitectureFullApplication.Main.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebExceptionPresenters.ExceptionHandlers
{
    public class ExceptionService
    {
        readonly Dictionary<Type, Type> ExceptionHandlers = new Dictionary<Type, Type>();

        public ExceptionService()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                IEnumerable<Type> handlers = type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
                foreach (Type handler in handlers)
                {
                    Type exceptioinType = handler.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(exceptioinType, type);
                }
            }
        }

        public ValueTask<ProblemDetails> Handle(Exception exception)
        {
            ValueTask<ProblemDetails> result;

            if (ExceptionHandlers.TryGetValue(exception.GetType(), out Type handlerType))
            {
                var handler = Activator.CreateInstance(handlerType);
                result = (ValueTask<ProblemDetails>)handlerType.GetMethod(nameof(IExceptionHandler<Type>.Handle))
                    .Invoke(handler, new object[] { exception });
            }
            else
            {
                result = new GeneralExceptionHandler()
                    .Handle(new GeneralException("Ha ocurrido un error al procesar la respuesta.", "Consulte al administrador."));
            }

            return result;
        }

    }
}
