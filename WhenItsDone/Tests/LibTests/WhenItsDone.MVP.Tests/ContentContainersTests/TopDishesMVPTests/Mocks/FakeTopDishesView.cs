using System;
using System.Collections.Generic;

using WhenItsDone.MVP.ContentContainers.TopDishesMVP;

namespace WhenItsDone.MVP.Tests.ContentContainersTests.TopDishesMVPTests.Mocks
{
    internal class FakeTopDishesView : ITopDishesView
    {
        private event EventHandler<TopDishesEventArgs> getTopDishes;
        private IDictionary<string, object> subscribedMethodNames = new Dictionary<string, object>();

        public event EventHandler Load;

        public event EventHandler<TopDishesEventArgs> GetTopDishes
        {
            add
            {
                this.subscribedMethodNames.Add(value.Method.Name, value.Target);

                getTopDishes += value;
            }

            remove
            {
                this.subscribedMethodNames.Remove(value.Method.Name);

                getTopDishes -= value;
            }
        }

        public TopDishesViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool ContainsSubscribedMethod(string methodName)
        {
            return this.subscribedMethodNames.ContainsKey(methodName);
        }

        public void InvokeGetTopDishes()
        {
            this.getTopDishes?.Invoke(null, null);
        }

        public void InvokeLoad()
        {
            this.Load?.Invoke(null, null);
        }
    }
}
