using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Infrastructure
{
    public class DependencyContainer
    {
        private static volatile DependencyContainer instance;

        private static readonly object lockObject = new object();

        public static DependencyContainer Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DependencyContainer();
                    }
                }

                return instance;
            }
        }

        private DependencyContainer()
        {
            this.unityContainer = Bootstrapper.Initialise();
        }

        private IUnityContainer unityContainer;

        public object Resolve(Type type, IDictionary<string, object> parameters = null)
        {
            object result = null;
            ParameterOverrides parameterOverrides = null;

            try
            {
                if (parameters != null)
                {
                    parameterOverrides = new ParameterOverrides();

                    foreach (var parameter in parameters)
                    {
                        parameterOverrides.Add(parameter.Key, parameter.Value);
                    }
                    result = this.unityContainer.Resolve(type, parameterOverrides);
                }
                else
                {
                    result = this.unityContainer.Resolve(type);
                }
            }
            catch (Exception)
            {
                var dependantContructors = type.GetConstructors();
                if (dependantContructors.Count() > 0)
                {
                    var dependantContructor = dependantContructors.First();
                    var constructorParameters = dependantContructor.GetParameters();
                    var parameterValues = new object[constructorParameters.Length];
                    for (int i = 0; i < constructorParameters.Length; i++)
                    {
                        var constructorParameter = constructorParameters[i];
                        parameterValues[i] = this.unityContainer.Resolve(constructorParameter.ParameterType, null);
                    }
                    result = dependantContructor.Invoke(parameterValues);
                }
            }

            return result;
        }

        public object Resolve(string typeName)
        {
            object result = null;
            var type = Type.GetType(typeName, false);
            if (type != null)
            {
                var dependantContructors = type.GetConstructors();
                if (dependantContructors.Count() > 0)
                {
                    var dependantContructor = dependantContructors.First();
                    var constructorParameters = dependantContructor.GetParameters();
                    var parameterValues = new object[constructorParameters.Length];
                    for (int i = 0; i < constructorParameters.Length; i++)
                    {
                        var constructorParameter = constructorParameters[i];
                        parameterValues[i] = this.unityContainer.Resolve(constructorParameter.ParameterType, null);
                    }
                    result = dependantContructor.Invoke(parameterValues);
                }
            }
            return result;
        }
    }
}
