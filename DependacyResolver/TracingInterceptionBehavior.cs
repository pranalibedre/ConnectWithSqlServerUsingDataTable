using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace DependacyResolver
{
    public class TracingInterceptionBehavior : IInterceptionBehavior
    {
        #region Private Variables


        #endregion

        #region Constructors

        public TracingInterceptionBehavior()
        {

        }

        #endregion

        #region Public Methods

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //Before invoking the method on the original target
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string ContextId = input.MethodBase.Name + "->";

            //Invoke the next behaviour in the chain            
            IMethodReturn result = getNext()(input, getNext);
            stopwatch.Stop();

            //After invoking the method on the original target
            if (result.Exception == null)
            {
                //No exception occured in the method                
                //TraceLog(input.MethodBase, stopwatch.ElapsedMilliseconds);
            }

            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        public void TraceLog(MethodBase methodBase, long elapseTimeInMilliSeconds)
        {
            var classType = methodBase.ReflectedType;
            string className = classType.Name;
            string methodName = methodBase.Name;
            string fullClassName = classType.FullName;
            TraceLog(className, methodName, fullClassName, elapseTimeInMilliSeconds);
        }

        public void TraceLog(string className, string methodName, string fullClassName, long elapseTimeInMilliSeconds)
        {
            //_logger.LogTraceWithMetadataInSuccess(fullClassName, className, methodName, elapseTimeInMilliSeconds);
        }

        #endregion
    }
}
