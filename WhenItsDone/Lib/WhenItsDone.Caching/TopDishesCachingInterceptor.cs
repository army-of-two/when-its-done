using System;
using System.Web;

using Bytes2you.Validation;

using Ninject.Extensions.Interception;

using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Caching
{
    public class TopDishesCachingInterceptor : IInterceptor
    {
        private const string CacheItemName = "TopDishes";

        private readonly IDishesAsyncRepository dishesAsyncRepository;

        private DateTime? lastUpdate;

        public TopDishesCachingInterceptor(IDishesAsyncRepository dishesAsyncRepository)
        {
            Guard.WhenArgument(dishesAsyncRepository, nameof(IDishesAsyncRepository)).IsNull().Throw();

            this.dishesAsyncRepository = dishesAsyncRepository;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name != "GetTopCountDishesByRating")
            {
                invocation.Proceed();
                return;
            }

            var timeElapsedSinceLastUpdate = (DateTime.UtcNow - (lastUpdate ?? DateTime.UtcNow)).Duration();
            var currentCachedContent = HttpContext.Current.Cache[TopDishesCachingInterceptor.CacheItemName];
            if (currentCachedContent != null && timeElapsedSinceLastUpdate.Minutes < 15)
            {
                invocation.ReturnValue = currentCachedContent;
                return;
            }
            else
            {
                var dishesCount = 3;
                var addSampleData = true;

                var topDishes = this.dishesAsyncRepository.GetTopCountDishesByRating(dishesCount).Result;
                if (topDishes.Count < dishesCount && addSampleData == true)
                {
                    topDishes = this.dishesAsyncRepository.AddTopCountDishesSampleData(dishesCount, topDishes);
                }

                this.lastUpdate = DateTime.UtcNow;
                HttpContext.Current.Cache[TopDishesCachingInterceptor.CacheItemName] = topDishes;
                invocation.ReturnValue = topDishes;
                return;
            }
        }
    }
}
