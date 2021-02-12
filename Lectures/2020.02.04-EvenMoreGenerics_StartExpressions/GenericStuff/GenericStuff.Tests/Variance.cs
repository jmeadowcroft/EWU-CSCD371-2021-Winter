using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericStuff.Tests
{
    [TestClass]
    public class VarianceTests
    {
        public interface IReadOnlySetting<out TValue>
        {
            string Name { get; }
            TValue Value { get; }

            //T GetValue(string name);
        }

        public interface IWriteOnlySetting<in T>
        {
            string Name { set; }
            T Value { set; }

            //void SetValue(string name, T value);
        }

        public class Setting<T> : IReadOnlySetting<T>, IWriteOnlySetting<T>
        {
            public string Name
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            public T Value
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }

        interface ICompare<T>
        {
            int Compare(T first, T second);
        }

        public class FileSetting<T> : IReadOnlySetting<T>
        {
            public string Name => "Inigo Montoya";

            public T Value => default;
        }

        [TestMethod]
        public void Covariance()
        {
            Setting<int> intSetting = new();
            Setting<object> objSetting = new();
            IReadOnlySetting<object> readOnlySetting = (IReadOnlySetting<object>)intSetting;
            object value = readOnlySetting.Value;
            IWriteOnlySetting<int> writeOnlySetting = (IWriteOnlySetting<int>)objSetting;
            writeOnlySetting.Value = 42;
        }

        [TestMethod]
        public void Covariance_WithActionExpressions()
        {
            Action<int> actionInt = item => Console.WriteLine(item);
            actionInt(42);
            // Action<object> actionObject = (Action<object>)actionInt; ///??
            // actionObject(42);
        }

        [TestMethod]
        public void Covariance_WithFuncExpressions()
        {
            Func<object> expressionObject = () => new object();
            object data = expressionObject();
            //Func<int> expressionInt = ()=>expressionObject();
            //int number = expressionInt();
        }
    }
}
