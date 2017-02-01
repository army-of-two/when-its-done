using System;
using System.Collections.Generic;

using WhenItsDone.MVP.ContentContainers.TopDishesMVP;

namespace WhenItsDone.MVP.Tests.ContentContainersTests.TopDishesMVPTests.Mocks
{
    internal class FakeTopDishesView : ITopDishesView
    {
        private event EventHandler<TopDishesEventArgs> getTopDishes;

        public event EventHandler Load;

        public event EventHandler<TopDishesEventArgs> GetTopDishes
        {
            add
            {
                this.SubscribedMethodNames.Add(value.Method.Name, value.Target);

                getTopDishes += value;
            }

            remove
            {
                getTopDishes -= value;
            }

        }

        public IDictionary<string, object> SubscribedMethodNames { get; set; } = new Dictionary<string, object>();

        public TopDishesViewModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool ContainsSubscribedMethod(string methodName)
        {
            return this.SubscribedMethodNames.ContainsKey(methodName);
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
